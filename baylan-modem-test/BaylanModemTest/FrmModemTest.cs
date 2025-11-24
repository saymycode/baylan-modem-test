using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaylanModemTest
{
    public partial class FrmModemTest : Form
    {
        private CancellationTokenSource _cts;
        private SerialPort _serial;
        private TcpClient _tcpPush;
        private TcpClient _tcpPull;


        private readonly List<TestStep> _steps;

        public FrmModemTest()
        {
            InitializeComponent();

            // COM port listesini doldur
            cmbComPort.Items.AddRange(SerialPort.GetPortNames());
            if (cmbComPort.Items.Count > 0) cmbComPort.SelectedIndex = 0;

            cmbBaudRate.Items.AddRange(new object[] { 9600, 19200, 38400, 57600, 115200 });
            cmbBaudRate.SelectedIndex = 3;
            cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbParity.SelectedItem = "None";
            cmbDataBits.Items.AddRange(new object[] { 7, 8 });
            cmbDataBits.SelectedItem = 8;
            cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));
            cmbStopBits.SelectedItem = "One";


            // Test adımları
            _steps = new List<TestStep>
            {
                new TestStep(1, "Uyanma Testi", pnlStep1Led, lblStep1Status),
                new TestStep(2, "Reset Testi", pnlStep2Led, lblStep2Status),
                new TestStep(3, "Sayaç Ekleme Testi", pnlStep3Led, lblStep3Status),
                new TestStep(4, "Sayaç Okuma Testi", pnlStep4Led, lblStep4Status),
                new TestStep(5, "Röle Testi", pnlStep5Led, lblStep5Status),
                new TestStep(6, "Input Testi", pnlStep6Led, lblStep6Status),
                new TestStep(7, "Finalize Testi", pnlStep7Led, lblStep7Status),
            };

            ResetUi();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_cts != null) return;

            ResetUi();
            LockSettings(true);

            _cts = new CancellationTokenSource();
            _ = RunAllStepsAsync(_cts.Token);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            StopAll("Kullanıcı testi durdurdu.");
        }

        private async Task RunAllStepsAsync(CancellationToken ct)
        {
            try
            {
                LogInfo("Test başladı.");

                await OpenConnectionsAsync(ct);

                for (int i = 0; i < _steps.Count; i++)
                {
                    ct.ThrowIfCancellationRequested();

                    var step = _steps[i];
                    step.SetRunning();
                    lblCurrentStep.Text = $"Şu an: {step.Name}";
                    overallProgress.Value = (int)((i / (double)_steps.Count) * 100);

                    bool ok = await RunStepAsync(step, ct);

                    if (!ok)
                    {
                        step.SetFail("Hata");
                        LogError($"Adım {step.Number} başarısız. Test durdu.");
                        StopAll("Test hata ile durdu.");
                        return;
                    }

                    step.SetPass();
                    LogInfo($"Adım {step.Number} geçti.");
                }

                overallProgress.Value = 100;
                lblCurrentStep.Text = "Şu an: Tamamlandı";
                LogInfo("Tüm testler başarıyla tamamlandı.");
                StopAll("Test bitti.");
            }
            catch (OperationCanceledException)
            {
                LogInfo("Test iptal edildi.");
                StopAll("İptal.");
            }
            catch (Exception ex)
            {
                LogError("Beklenmeyen hata: " + ex.Message);
                StopAll("Hata.");
            }
        }

        private async Task<bool> RunStepAsync(TestStep step, CancellationToken ct)
        {
            // Her adım için dummy/gerçek komut seti burada
            var txCommands = GetStepTxCommands(step.Number);
            var expectedRx = GetStepExpectedRx(step.Number);

            foreach (var cmd in txCommands)
            {
                ct.ThrowIfCancellationRequested();

                LogTx(cmd);
                string rx;


                rx = await SendAndReceiveAsync(cmd, ct);


                LogRx(rx);

                if (!ValidateRx(rx, expectedRx))
                    return false;
            }

            return true;
        }

        // ====== Command Maps (dummy) ======

        private List<string> GetStepTxCommands(int stepNo)
        {
            switch (stepNo)
            {
                case 1:
                    return new List<string> { "AT\r\n" };

                case 2:
                    return new List<string> { "AT+RST\r\n" };

                case 3:
                    return new List<string> { "AT+MTRADD=00112233\r\n" };

                case 4:
                    return new List<string> { "AT+MTRRD=00112233\r\n" };

                case 5:
                    return new List<string> { "AT+RELAY=ON\r\n", "AT+RELAY=OFF\r\n" };

                case 6:
                    return new List<string> { "AT+INPUT?\r\n" };

                case 7:
                    return new List<string> { "AT+FIN\r\n" };

                default:
                    return new List<string>();
            }
        }

        private string GetStepExpectedRx(int stepNo)
        {
            switch (stepNo)
            {
                case 1:
                case 2:
                    return "OK";

                case 3:
                    return "MTRADDED";

                case 4:
                    return "MTRDATA";

                case 5:
                    return "RELAYOK";

                case 6:
                    return "INPUTOK";

                case 7:
                    return "FINOK";

                default:
                    return "OK";
            }
        }


        private bool ValidateRx(string rx, string expected)
        {
            if (string.IsNullOrWhiteSpace(rx))
                return false;

            return rx.IndexOf(expected, StringComparison.OrdinalIgnoreCase) >= 0;
        }


        // ====== Real IO (COM/TCP) ======

        private async Task OpenConnectionsAsync(CancellationToken ct)
        {
            // COM
            _serial = new SerialPort(
                cmbComPort.Text,
                int.Parse(cmbBaudRate.Text),
                (Parity)Enum.Parse(typeof(Parity), cmbParity.Text),
                int.Parse(cmbDataBits.Text),
                (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text)
            )
            {
                ReadTimeout = 3000,
                WriteTimeout = 3000
            };

            _serial.Open();
            LogInfo("COM açıldı.");
        }



        private async Task<string> SendAndReceiveAsync(string cmd, CancellationToken ct)
        {
            if (_serial == null || !_serial.IsOpen)
                throw new InvalidOperationException("COM açık değil.");

            _serial.Write(cmd);

            // Basit okuma; gerçek protokolün framing’ine göre değiştir
            return await Task.Run(() =>
            {
                var sb = new StringBuilder();
                var start = DateTime.UtcNow;
                while ((DateTime.UtcNow - start).TotalMilliseconds < 3000)
                {
                    ct.ThrowIfCancellationRequested();
                    try
                    {
                        var chunk = _serial.ReadExisting();
                        if (!string.IsNullOrEmpty(chunk))
                        {
                            sb.Append(chunk);
                            if (sb.ToString().Contains("\n") || sb.ToString().Contains("OK"))
                                break;
                        }
                    }
                    catch { /* timeout ignore */ }
                    Thread.Sleep(30);
                }
                return sb.ToString();
            }, ct);
        }


        private void StopAll(string reason)
        {
            _cts?.Cancel();
            _cts = null;

            try { _serial?.Close(); } catch { }
            try { _tcpPush?.Close(); } catch { }
            try { _tcpPull?.Close(); } catch { }

            _serial = null; _tcpPush = null; _tcpPull = null;

            LockSettings(false);
            LogInfo("Test sonlandı: " + reason);
        }

        private void LockSettings(bool locked)
        {
            grpConnection.Enabled = !locked;

            btnStart.Enabled = !locked;
            btnStop.Enabled = locked;
        }

        private void ResetUi()
        {
            foreach (var s in _steps) s.SetWaiting();
            lblCurrentStep.Text = "Şu an: Bekliyor";
            overallProgress.Value = 0;
            rtbLog.Clear();
        }

        private void LogInfo(string msg) => AppendLog("INFO", msg, Color.Gray);
        private void LogError(string msg) => AppendLog("ERR ", msg, Color.IndianRed);
        private void LogTx(string msg) => AppendLog("TX  ", msg.Trim(), Color.DeepSkyBlue);
        private void LogRx(string msg) => AppendLog("RX  ", msg.Trim(), Color.LightGreen);

        private void AppendLog(string tag, string msg, Color color)
        {
            if (InvokeRequired) { Invoke(new Action(() => AppendLog(tag, msg, color))); return; }

            rtbLog.SelectionStart = rtbLog.TextLength;
            rtbLog.SelectionColor = color;
            rtbLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {tag}: {msg}\r\n");
            rtbLog.SelectionColor = rtbLog.ForeColor;

                rtbLog.ScrollToCaret();
        }
    }

    internal class TestStep
    {
        public int Number { get; }
        public string Name { get; }
        private readonly Panel _led;
        private readonly Label _status;

        public TestStep(int number, string name, Panel led, Label statusLabel)
        {
            Number = number;
            Name = name;
            _led = led;
            _status = statusLabel;
        }

        public void SetWaiting()
        {
            _led.BackColor = Color.Silver;
            _status.Text = "Bekliyor";
            _status.ForeColor = Color.Silver;
        }

        public void SetRunning()
        {
            _led.BackColor = Color.Orange;
            _status.Text = "Çalışıyor";
            _status.ForeColor = Color.Orange;
        }

        public void SetPass()
        {
            _led.BackColor = Color.LimeGreen;
            _status.Text = "Geçti";
            _status.ForeColor = Color.LimeGreen;
        }

        public void SetFail(string reason)
        {
            _led.BackColor = Color.Red;
            _status.Text = reason;
            _status.ForeColor = Color.Red;
        }
    }
}
