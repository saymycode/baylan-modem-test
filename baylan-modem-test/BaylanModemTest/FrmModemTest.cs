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
            cmbMeterBaudRate.Items.AddRange(new object[] { 9600, 19200, 38400, 57600, 115200 });
            cmbMeterBaudRate.SelectedItem = 9600;
            txtMeterFlag.Text = "0";


            // Test adımları
            _steps = new List<TestStep>
            {
                new TestStep(1, "Uyanma Testi", pnlStep1Led, lblStep1Status),
                new TestStep(2, "Röle Testi", pnlStep5Led, lblStep5Status),
                new TestStep(3, "Sayaç Ekleme Testi", pnlStep3Led, lblStep3Status),
                new TestStep(4, "Sayaç Okuma Testi", pnlStep4Led, lblStep4Status),
                new TestStep(5, "Finalize Testi", pnlStep7Led, lblStep7Status),
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
                        LogError($"Adım {step.Name} başarısız. Test durdu.");
                        StopAll("Test hata ile durdu.", true);
                        return;
                    }

                    step.SetPass();
                    LogInfo($"Adım {step.Name} geçti.");

                    // --- ADIM TAMAMLANDI → 5-10 sn bekleme ---
                    await Task.Delay(7000, ct);  // 7 saniye (ister 5000–10000 arası yaparsın)
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
        private class StepCommandPlanItem
        {
            public string Cmd { get; }
            public StepExpectation Expectation { get; }
            public bool UseTcp { get; }
            public TimeSpan DelayAfter { get; }

            public StepCommandPlanItem(string cmd, StepExpectation exp, bool useTcp = false, TimeSpan? delayAfter = null)
            {
                Cmd = cmd;
                Expectation = exp;
                UseTcp = useTcp;
                DelayAfter = delayAfter ?? TimeSpan.Zero;
            }
        }

        private async Task<bool> RunStepAsync(TestStep step, CancellationToken ct)
        {
            var plan = GetStepCommandPlan(step.Number);

            foreach (var item in plan)
            {
                ct.ThrowIfCancellationRequested();

                LogTx(item.Cmd);
                string rx = item.UseTcp
                    ? await SendAndReceiveTcpAsync(item.Cmd, item.Expectation, ct)
                    : await SendAndReceiveAsync(item.Cmd, item.Expectation, ct);

                if (!ValidateRx(rx, item.Expectation, out var error))
                {
                    LogError($"Adım {step.Name} doğrulama hatası: {error}");
                    return false;
                }

                if (item.DelayAfter > TimeSpan.Zero)
                {
                    LogInfo($"Sonraki komut öncesi {item.DelayAfter.TotalSeconds:0.#} saniye bekleniyor.");
                    await Task.Delay(item.DelayAfter, ct);
                }
            }

            await Task.Delay(TimeSpan.FromSeconds(2), ct);
            return true;
        }

        private List<StepCommandPlanItem> GetStepCommandPlan(int stepNo)
        {
            switch (stepNo)
            {
                case 1:
                    return BuildWakeStepPlan();
                case 2:
                    return BuildRelayStepPlan();
                case 3:
                    return BuildMeterAddStepPlan();
                case 4:
                    return BuildMeterReadStepPlan();
                case 5:
                    return BuildFinalizeStepPlan();
                default:
                    return new List<StepCommandPlanItem>();
            }
        }


        private List<StepCommandPlanItem> BuildWakeStepPlan()
        {
            return new List<StepCommandPlanItem>
            {
                new StepCommandPlanItem(
                    "QCK_RESET_OSOS\r\n",
                    new StepExpectation("FREE SPACE")
                )
            };
        }

        private List<StepCommandPlanItem> BuildRelayStepPlan()
        {
            return new List<StepCommandPlanItem>
            {
                new StepCommandPlanItem(
                    BuildRelayCommand(1),
                    new StepExpectation("RPS01:1"),
                    delayAfter: TimeSpan.FromSeconds(3)
                ),
                new StepCommandPlanItem(
                    BuildRelayCommand(0),
                    new StepExpectation("RPS01:0")
                )
            };
        }

        private List<StepCommandPlanItem> BuildMeterAddStepPlan()
        {
            var meterSerialToAdd = GetMeterSerialNumber();
            return new List<StepCommandPlanItem>
            {
                new StepCommandPlanItem(
                    BuildMeterAddCommand(meterSerialToAdd),
                    new StepExpectation("MTRADDED", new Dictionary<string, string>
                    {
                        {"RESULT", "OK"},
                        {"METER", meterSerialToAdd}
                    }),
                    useTcp: true
                )
            };
        }

        private List<StepCommandPlanItem> BuildMeterReadStepPlan()
        {
            var meterSerialToRead = GetMeterSerialNumber();
            return new List<StepCommandPlanItem>
            {
                new StepCommandPlanItem(
                    BuildMeterReadCommand(meterSerialToRead),
                    new StepExpectation("MTRDATA", new Dictionary<string, string>
                    {
                        {"METER", meterSerialToRead},
                        {"STATUS", "OK"}
                    }),
                    useTcp: true
                )
            };
        }

        private List<StepCommandPlanItem> BuildFinalizeStepPlan()
        {
            return new List<StepCommandPlanItem>
            {
                new StepCommandPlanItem(
                    "AT+FIN\r\n",
                    new StepExpectation("FINOK", new Dictionary<string, string>
                    {
                        {"STATUS", "OK"}
                    })
                )
            };
        }

        // ====== Command Maps (dummy) ======
        private string BuildRelayCommand(int targetState)
        {
            return "#\x1C" +
                   "#\x1D" +
                   "#\x1F" +
                   "QTYPE:RELAY_PROCESS$\x1F$\x1D" +
                   "#\x1E" +
                   "#\x1F" +
                   "OADUN:admin$\x1F" +
                   "#\x1F" +
                   "OADPW:12345678$\x1F" +
                   "#\x1F" +
                   $"RNP01:{targetState}$\x1F$\x1D" +
                   "#\x1F" +
                   "QANSD:3$\x1F$\x1E$" +
                   "\x1C";
        }

        private string BuildMeterAddCommand(string meterSerial)
        {
            return $"AT+MTRADD={meterSerial}\r\n";
        }

        private string BuildMeterReadCommand(string meterSerial)
        {
            return $"AT+MTRRD={meterSerial}\r\n";
        }

        private string GetMeterSerialNumber()
        {
            var serial = txtMeterSerial.Text?.Trim();

            if (string.IsNullOrWhiteSpace(serial))
                throw new InvalidOperationException("Sayaç seri numarası boş olamaz.");

            return serial.ToUpperInvariant();
        }

        private string GetMeterFlag()
        {
            return txtMeterFlag.Text?.Trim() ?? string.Empty;
        }

        private int GetMeterBaudRate()
        {
            if (int.TryParse(cmbMeterBaudRate.Text, out var baud))
                return baud;

            throw new InvalidOperationException("Sayaç baudrate değeri geçersiz.");
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

                // 1) Önce FS (\x1C) ile biten OSOS paketlerini çek
                int fsIndex;
                while ((fsIndex = text.IndexOf('\x1C')) >= 0)
                {
                    var msg = text.Substring(0, fsIndex);
                    if (!string.IsNullOrWhiteSpace(msg))
                        messages.Add(msg.Trim());

                    text = text.Substring(fsIndex + 1); // FS sonrası kalan
                }

                // 2) Kalan kısımda CR/LF ile biten satırları çek
                // Son newline pozisyonunu bul (tamamlanmış satırlar)
                int lastNl = Math.Max(text.LastIndexOf('\n'), text.LastIndexOf('\r'));

                if (lastNl >= 0)
                {
                    var completedBlock = text.Substring(0, lastNl + 1);
                    var remaining = text.Substring(lastNl + 1);

                    var parts = completedBlock.Split(
                        new[] { "\r\n", "\n", "\r" },
                        StringSplitOptions.RemoveEmptyEntries
                    );

                    foreach (var p in parts)
                    {
                        var line = p.Trim();
                        if (!string.IsNullOrEmpty(line))
                            messages.Add(line);
                    }

                    text = remaining;
                }

                // 3) Buffer'ı sadece tamamlanmamış kalanla güncelle
                _serialBuffer.Clear();
                if (!string.IsNullOrEmpty(text))
                    _serialBuffer.Append(text);
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

            _tcpListenerTask = Task.Run(() => ListenTcpAsync(_listenerCts.Token), ct);

            var ipText = txtTcpIp.Text?.Trim();
            if (string.IsNullOrWhiteSpace(ipText))
                throw new InvalidOperationException("TCP IP boş olamaz.");

            var ip = IPAddress.Parse(ipText);

            const int pushPort = 4069;
            _tcpPush = new TcpClient();
            await _tcpPush.ConnectAsync(ip, pushPort);
            LogInfo($"TCP Push bağlantısı açıldı ({ip}:{pushPort}).");

            _tcpPull = new TcpClient();
            await _tcpPull.ConnectAsync(ip, (int)numPullPort.Value);
            LogInfo($"TCP Pull bağlantısı açıldı ({ip}:{numPullPort.Value}).");
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

        private async Task<string> SendAndReceiveTcpAsync(string cmd, StepExpectation expectation, CancellationToken ct)
        {
            if (_tcpPush == null || !_tcpPush.Connected || _tcpPull == null || !_tcpPull.Connected)
                throw new InvalidOperationException("TCP bağlantıları hazır değil.");

            ClearIncomingMessages();

            PrepareForExpectedResponse(expectation);

            var buffer = Encoding.ASCII.GetBytes(cmd);
            await _tcpPush.GetStream().WriteAsync(buffer, 0, buffer.Length, ct);

            return await WaitForExpectedTcpResponseAsync(ct);
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

        private async Task<string> WaitForExpectedTcpResponseAsync(CancellationToken ct)
        {
            if (_pendingSerialResponse == null)
                throw new InvalidOperationException("Beklenen bir TCP cevabı yok.");

            var buffer = new byte[4096];
            var deadline = DateTime.UtcNow.AddMinutes(3);
            var stream = _tcpPull.GetStream();

            while (DateTime.UtcNow < deadline)
            {
                ct.ThrowIfCancellationRequested();

                if (stream.DataAvailable)
                {
                    var read = await stream.ReadAsync(buffer, 0, buffer.Length, ct);
                    if (read > 0)
                    {
                        var text = Encoding.ASCII.GetString(buffer, 0, read);
                        LogRx(text);
                        TryCompletePending(text);

                        if (_pendingSerialResponse.Task.IsCompleted)
                            return await _pendingSerialResponse.Task;
                    }
                }

                await Task.Delay(100, ct);
            }

            throw new TimeoutException("3 dakika içinde beklenen TCP cevap alınamadı.");
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
            //grpConnection.Enabled = !locked;

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
