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
using BaylanModemTest.Models;

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
        private CancellationTokenSource _listenerCts;
        private readonly object _serialLock = new object();
        private DateTime _modemDate = DateTime.MinValue;

        private readonly StringBuilder _serialBuffer = new StringBuilder();
        private StepExpectation _pendingExpectation;
        private TaskCompletionSource<string> _pendingSerialResponse;

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
            Thread.Sleep(2000);
            return true;
        }

        // ====== Command Maps (dummy) ======
        string relayCmd =
    "#\x1C" +
    "#\x1D" +
    "#\x1F" +
    "QTYPE:RELAY_PROCESS$\x1F$\x1D" +
    "#\x1E" +
    "#\x1F" +
    "OADUN:admin$\x1F" +
    "#\x1F" +
    "OADPW:12345678$\x1F" +
    "#\x1F" +
    "RNP01:1$\x1F$\x1D" +
    "#\x1F" +
    "QANSD:3$\x1F$\x1E$" +
    "\x1C";

        private List<string> GetStepTxCommands(int stepNo)
        {
            switch (stepNo)
            {
                case 1:
                    return new List<string> { "QCK_RESET_OSOS\r\n" };

                case 2:
                    return new List<string> { relayCmd, "AT+RELAY=OFF\r\n" };

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
                    return new StepExpectation("FREE SPACE");

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
        // ADD: eski uygulamadaki mantığın aynısı
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                _modemDate = DateTime.MinValue;

                if (_serial == null || !_serial.IsOpen)
                {
                    LogInfo("Usb Portu Kapalı");
                    return;
                }

                string incomingData = _serial.ReadExisting();
                if (string.IsNullOrEmpty(incomingData))
                    return;

                LogRx(SanitizeIncoming(incomingData));

                foreach (var message in CollectSerialMessages(incomingData))
                {
                    _incomingMessages.Enqueue(message);
                    TryCompletePending(message);
                }
            }
            catch (Exception ex)
            {
                LogError($"COM DataReceived hatası: {ex.Message}");
            }
        }

        private string SanitizeIncoming(string incomingData)
        {
            return incomingData
                .Replace("\0", "")
                .Replace("\x1C", "<FS>")
                .Replace("\x1D", "<GS>")
                .Replace("\x1E", "<RS>")
                .Replace("\x1F", "<US>")
                .Replace("\x0A", "<LF>")
                .Replace("\x0D", "<CR>");
        }

        private IEnumerable<string> CollectSerialMessages(string incomingData)
        {
            var messages = new List<string>();

            lock (_serialLock)
            {
                _serialBuffer.Append(incomingData);

                var text = _serialBuffer.ToString();
                var parts = text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);

                // son parça tamamlanmamış mesaj olabilir
                var trailing = parts[parts.Length - 1];

                _serialBuffer.Clear();
                if (!text.EndsWith("\n") && !text.EndsWith("\r"))
                {
                    _serialBuffer.Append(trailing);
                }
                else if (!string.IsNullOrWhiteSpace(trailing))
                {
                    messages.Add(trailing.Trim());
                }

                for (int i = 0; i < parts.Length - 1; i++)
                {
                    var message = parts[i].Trim();
                    if (!string.IsNullOrEmpty(message))
                        messages.Add(message);
                }
            }

            return messages;
        }

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

            _serial.DataReceived += Serial_DataReceived;

            _listenerCts = CancellationTokenSource.CreateLinkedTokenSource(ct);

            //_tcpListenerTask = Task.Run(() => ListenTcpAsync(_listenerCts.Token), ct);
        }

        private async Task<string> SendAndReceiveAsync(string cmd, StepExpectation expectation, CancellationToken ct)
        {
            if (_serial == null || !_serial.IsOpen)
                throw new InvalidOperationException("COM açık değil.");

            ClearIncomingMessages();

            PrepareForExpectedResponse(expectation);

            _serial.Write(cmd);

            return await WaitForExpectedResponseAsync(ct);
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
                            TryCompletePending(text);
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

        private async Task<string> WaitForExpectedResponseAsync(CancellationToken ct)
        {
            if (_pendingSerialResponse == null)
                throw new InvalidOperationException("Beklenen bir seri port cevabı yok.");

            var deadline = DateTime.UtcNow.AddMinutes(3);

            while (DateTime.UtcNow < deadline)
            {
                ct.ThrowIfCancellationRequested();

                if (_pendingSerialResponse.Task.IsCompleted)
                    return await _pendingSerialResponse.Task;

                await Task.Delay(100, ct);
            }

            throw new TimeoutException("3 dakika içinde beklenen cevap alınamadı.");
        }

        private void PrepareForExpectedResponse(StepExpectation expectation)
        {
            _pendingExpectation = expectation;
            _pendingSerialResponse = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
        }

        private void TryCompletePending(string message)
        {
            if (_pendingExpectation == null || _pendingSerialResponse == null)
                return;

            if (ValidateRx(message, _pendingExpectation, out _))
            {
                _pendingExpectation = null;
                _pendingSerialResponse.TrySetResult(message);
            }
        }

        private void ClearIncomingMessages()
        {
            while (_incomingMessages.TryDequeue(out _)) { }

            lock (_serialLock)
            {
                _serialBuffer.Clear();
            }

            _pendingExpectation = null;
            _pendingSerialResponse = null;
        }


        private void StopAll(string reason, bool resetSteps = true)
        {
            _cts?.Cancel();
            _cts = null;

            _pendingSerialResponse?.TrySetCanceled();

            try { _listenerCts?.Cancel(); } catch { }
            try { _tcpListener?.Stop(); } catch { }
            try { _tcpListenerTask?.Wait(500); } catch { }
            try { _tcpPush?.Close(); } catch { }
            try { _tcpPull?.Close(); } catch { }

            var serial = _serial;
            _listenerCts = null;
            _tcpListener = null;
            _tcpListenerTask = null;
            _serial = null; _tcpPush = null; _tcpPull = null;

            try
            {
                serial.DataReceived -= Serial_DataReceived;
            }
            catch { }

            try { serial?.Close(); } catch { }

            LockSettings(false);

            if (resetSteps)
                ResetStepsState();

            LogInfo("Test sonlandı: " + reason);
        }

        private void LockSettings(bool locked)
        {
            grpConnection.Enabled = !locked;

            btnStart.Enabled = !locked;
            btnStop.Enabled = true;
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
}
