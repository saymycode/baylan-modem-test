using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
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
        private TcpListener _tcpListener;
        private TcpClient _tcpPush;
        private TcpClient _tcpPull;
        private Task _tcpListenerTask;
        private Task _comListenerTask;
        private CancellationTokenSource _listenerCts;

        private readonly ConcurrentQueue<string> _incomingMessages = new ConcurrentQueue<string>();


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
                new TestStep(2, "Röle Testi", pnlStep5Led, lblStep5Status),
                new TestStep(3, "Input Testi", pnlStep6Led, lblStep6Status),
                new TestStep(4, "Sayaç Ekleme Testi", pnlStep3Led, lblStep3Status),
                new TestStep(5, "Sayaç Okuma Testi", pnlStep4Led, lblStep4Status),
                new TestStep(6, "Finalize Testi", pnlStep7Led, lblStep7Status),
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
            StopAll("Kullanıcı testi durdurdu.", true);
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
                        StopAll("Test hata ile durdu.", true);
                        return;
                    }

                    step.SetPass();
                    LogInfo($"Adım {step.Number} geçti.");
                }

                overallProgress.Value = 100;
                lblCurrentStep.Text = "Şu an: Tamamlandı";
                LogInfo("Tüm testler başarıyla tamamlandı.");
                StopAll("Test bitti.", false);
            }
            catch (OperationCanceledException)
            {
                LogInfo("Test iptal edildi.");
                StopAll("İptal.", true);
            }
            catch (Exception ex)
            {
                LogError("Beklenmeyen hata: " + ex.Message);
                StopAll("Hata.", true);
            }
        }

        private async Task<bool> RunStepAsync(TestStep step, CancellationToken ct)
        {
            // Her adım için dummy/gerçek komut seti burada
            var txCommands = GetStepTxCommands(step.Number);
            var expectedRx = GetStepExpectation(step.Number);

            foreach (var cmd in txCommands)
            {
                ct.ThrowIfCancellationRequested();

                LogTx(cmd);
                string rx = await SendAndReceiveAsync(cmd, expectedRx, ct);

                if (!ValidateRx(rx, expectedRx, out var error))
                {
                    LogError($"Adım {step.Number} doğrulama hatası: {error}");
                    return false;
                }
            }

            return true;
        }

        // ====== Command Maps (dummy) ======

        private List<string> GetStepTxCommands(int stepNo)
        {
            switch (stepNo)
            {
                case 1:
                    return new List<string> { "QCK_RESET_OSOS\r\n" };

                case 2:
                    return new List<string> { "AT+RELAY=ON\r\n", "AT+RELAY=OFF\r\n" };

                case 3:
                    return new List<string> { "AT+INPUT?\r\n" };

                case 4:
                    return new List<string> { "AT+MTRADD=00112233\r\n" };

                case 5:
                    return new List<string> { "AT+MTRRD=00112233\r\n" };

                case 6:
                    return new List<string> { "AT+FIN\r\n" };

                default:
                    return new List<string>();
            }
        }

        private StepExpectation GetStepExpectation(int stepNo)
        {
            switch (stepNo)
            {
                case 1:
                    return new StepExpectation("FREE");

                case 2:
                    return new StepExpectation("RELAYOK", new Dictionary<string, string>
                    {
                        {"RELAY", "CLOSED"}
                    });

                case 3:
                    return new StepExpectation("INPUTOK", new Dictionary<string, string>
                    {
                        {"INPUT", "HIGH"}
                    });

                case 4:
                    return new StepExpectation("MTRADDED", new Dictionary<string, string>
                    {
                        {"RESULT", "OK"},
                        {"METER", "00112233"}
                    });

                case 5:
                    return new StepExpectation("MTRDATA", new Dictionary<string, string>
                    {
                        {"METER", "00112233"},
                        {"STATUS", "OK"}
                    });

                case 6:
                    return new StepExpectation("FINOK", new Dictionary<string, string>
                    {
                        {"STATUS", "OK"}
                    });

                default:
                    return new StepExpectation("OK");
            }
        }


        private bool ValidateRx(string rx, StepExpectation expectation, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(rx))
            {
                error = "Cevap boş geldi.";
                return false;
            }

            if (expectation == null)
                return true;

            if (expectation.Fields.Any())
            {
                var parsed = ParseFields(rx);
                foreach (var kvp in expectation.Fields)
                {
                    if (!parsed.TryGetValue(kvp.Key, out var actual))
                    {
                        error = $"{kvp.Key} alanı bulunamadı.";
                        return false;
                    }

                    if (!string.Equals(actual, kvp.Value, StringComparison.OrdinalIgnoreCase))
                    {
                        error = $"{kvp.Key} beklenen: {kvp.Value}, gelen: {actual}";
                        return false;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(expectation.ContainsText) &&
                rx.IndexOf(expectation.ContainsText, StringComparison.OrdinalIgnoreCase) < 0)
            {
                error = $"Cevap içinde beklenen ifade yok: {expectation.ContainsText}";
                return false;
            }

            return true;
        }

        private Dictionary<string, string> ParseFields(string rx)
        {
            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            var separators = new[] { ';', '\n', '\r' };
            var parts = rx.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                var trimmed = part.Trim();
                if (string.IsNullOrEmpty(trimmed))
                    continue;

                var idx = trimmed.IndexOf('=');
                if (idx < 0)
                    idx = trimmed.IndexOf(':');

                if (idx <= 0 || idx >= trimmed.Length - 1)
                    continue;

                var key = trimmed.Substring(0, idx).Trim();
                var value = trimmed.Substring(idx + 1).Trim();

                if (!result.ContainsKey(key))
                    result[key] = value;
            }

            return result;
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
                ReadTimeout = 180000,
                WriteTimeout = 180000
            };

            _serial.Open();
            LogInfo("COM açıldı.");

            _listenerCts = CancellationTokenSource.CreateLinkedTokenSource(ct);

            _comListenerTask = Task.Run(() => ListenSerialAsync(_listenerCts.Token), ct);
            _tcpListenerTask = Task.Run(() => ListenTcpAsync(_listenerCts.Token), ct);
        }



        private async Task<string> SendAndReceiveAsync(string cmd, StepExpectation expectation, CancellationToken ct)
        {
            if (_serial == null || !_serial.IsOpen)
                throw new InvalidOperationException("COM açık değil.");

            _serial.Write(cmd);

            ClearIncomingMessages();

            return await WaitForExpectedResponseAsync(expectation, ct);
        }

        private async Task ListenSerialAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    if (_serial != null && _serial.IsOpen)
                    {
                        var chunk = _serial.ReadExisting();
                        if (!string.IsNullOrEmpty(chunk))
                        {
                            _incomingMessages.Enqueue(chunk);
                            LogRx(chunk);
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError($"COM dinleyicide hata: {ex.Message}");
                }

                await Task.Delay(50, token);
            }
        }

        private async Task ListenTcpAsync(CancellationToken token)
        {
            try
            {
                _tcpListener = new TcpListener(IPAddress.Any, 4444);
                _tcpListener.Start();
                LogInfo("TCP dinleyici 4444 portunda başlatıldı.");

                while (!token.IsCancellationRequested)
                {
                    var acceptTask = _tcpListener.AcceptTcpClientAsync();
                    var completed = await Task.WhenAny(acceptTask, Task.Delay(100, token));
                    if (completed != acceptTask)
                        continue;

                    var client = acceptTask.Result;
                    _ = Task.Run(() => HandleTcpClientAsync(client, token), token);
                }
            }
            catch (Exception ex)
            {
                if (!token.IsCancellationRequested)
                    LogError($"TCP dinleyici hatası: {ex.Message}");
            }
        }

        private async Task HandleTcpClientAsync(TcpClient client, CancellationToken token)
        {
            using (client)
            {
                try
                {
                    var buffer = new byte[4096];
                    using (var stream = client.GetStream())
                    {
                        while (!token.IsCancellationRequested && client.Connected)
                        {
                            if (!stream.DataAvailable)
                            {
                                await Task.Delay(50, token);
                                continue;
                            }

                            var read = await stream.ReadAsync(buffer, 0, buffer.Length, token);
                            if (read <= 0)
                                break;

                            var text = Encoding.UTF8.GetString(buffer, 0, read);
                            _incomingMessages.Enqueue(text);
                            LogRx(text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!token.IsCancellationRequested)
                        LogError($"TCP istemci hatası: {ex.Message}");
                }
            }
        }

        private async Task<string> WaitForExpectedResponseAsync(StepExpectation expectation, CancellationToken ct)
        {
            var deadline = DateTime.UtcNow.AddMinutes(3);

            while (DateTime.UtcNow < deadline)
            {
                ct.ThrowIfCancellationRequested();

                if (_incomingMessages.TryDequeue(out var message))
                {
                    if (ValidateRx(message, expectation, out _))
                        return message;
                }

                await Task.Delay(100, ct);
            }

            throw new TimeoutException("3 dakika içinde beklenen cevap alınamadı.");
        }

        private void ClearIncomingMessages()
        {
            while (_incomingMessages.TryDequeue(out _)) { }
        }


        private void StopAll(string reason, bool resetSteps = true)
        {
            _cts?.Cancel();
            _cts = null;

            try { _listenerCts?.Cancel(); } catch { }
            try { _tcpListener?.Stop(); } catch { }
            try { _tcpListenerTask?.Wait(500); } catch { }
            try { _comListenerTask?.Wait(500); } catch { }

            try { _serial?.Close(); } catch { }
            try { _tcpPush?.Close(); } catch { }
            try { _tcpPull?.Close(); } catch { }

            _listenerCts = null;
            _tcpListener = null;
            _tcpListenerTask = null;
            _comListenerTask = null;
            _serial = null; _tcpPush = null; _tcpPull = null;

            LockSettings(false);

            if (resetSteps)
                ResetStepsState();

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
            ResetStepsState();
            rtbLog.Clear();
        }

        private void ResetStepsState()
        {
            foreach (var s in _steps) s.SetWaiting();
            lblCurrentStep.Text = "Şu an: Bekliyor";
            overallProgress.Value = 0;
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

    internal class StepExpectation
    {
        public string ContainsText { get; }
        public Dictionary<string, string> Fields { get; }

        public StepExpectation(string containsText, Dictionary<string, string> fields = null)
        {
            ContainsText = containsText ?? string.Empty;
            Fields = fields ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
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
