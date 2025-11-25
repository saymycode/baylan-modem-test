using System;
using System.IO.Ports;
using System.Windows.Forms;
using BaylanModemTest.Models;

namespace BaylanModemTest
{
    public partial class FrmSettings : Form
    {
        public AppSettings UpdatedSettings { get; private set; }
        public string SettingsFilePath { get; private set; }

        public FrmSettings(AppSettings settings, string filePath)
        {
            InitializeComponent();
            SettingsFilePath = filePath;
            txtFilePath.Text = SettingsFilePath;

            cmbParity.Items.AddRange(Enum.GetNames(typeof(Parity)));
            cmbStopBits.Items.AddRange(Enum.GetNames(typeof(StopBits)));
            cmbBaudRate.Items.AddRange(new object[] { 9600, 19200, 38400, 57600, 115200 });
            cmbDataBits.Items.AddRange(new object[] { 7, 8 });
            cmbMeterBaudRate.Items.AddRange(new object[] { 9600, 19200, 38400, 57600, 115200 });

            RefreshComPorts();
            LoadFromSettings(settings);
        }

        private void RefreshComPorts()
        {
            cmbComPort.Items.Clear();
            cmbComPort.Items.AddRange(SerialPort.GetPortNames());
        }

        private void LoadFromSettings(AppSettings settings)
        {
            UpdatedSettings = settings?.Clone() ?? AppSettings.CreateDefault();

            if (!string.IsNullOrEmpty(UpdatedSettings.ComPort) && !cmbComPort.Items.Contains(UpdatedSettings.ComPort))
                cmbComPort.Items.Add(UpdatedSettings.ComPort);

            cmbComPort.Text = UpdatedSettings.ComPort;
            cmbBaudRate.Text = UpdatedSettings.BaudRate.ToString();
            cmbParity.Text = UpdatedSettings.Parity.ToString();
            cmbDataBits.Text = UpdatedSettings.DataBits.ToString();
            cmbStopBits.Text = UpdatedSettings.StopBits.ToString();
            txtMeterFlag.Text = UpdatedSettings.MeterFlag;
            cmbMeterBaudRate.Text = UpdatedSettings.MeterBaudRate.ToString();
            txtTcpIp.Text = UpdatedSettings.TcpIp;
            numPushPort.Value = UpdatedSettings.PushPort;
            numPullPort.Value = UpdatedSettings.PullPort;
            txtMeterSerial.Text = UpdatedSettings.MeterSerial;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                UpdatedSettings = new AppSettings
                {
                    ComPort = cmbComPort.Text,
                    BaudRate = int.Parse(cmbBaudRate.Text),
                    Parity = (Parity)Enum.Parse(typeof(Parity), cmbParity.Text),
                    DataBits = int.Parse(cmbDataBits.Text),
                    StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmbStopBits.Text),
                    MeterFlag = txtMeterFlag.Text,
                    MeterBaudRate = int.Parse(cmbMeterBaudRate.Text),
                    TcpIp = txtTcpIp.Text,
                    PushPort = (int)numPushPort.Value,
                    PullPort = (int)numPullPort.Value,
                    MeterSerial = txtMeterSerial.Text
                };

                SettingsFilePath = txtFilePath.Text;

                if (string.IsNullOrWhiteSpace(SettingsFilePath))
                    throw new InvalidOperationException("Dosya yolu boş olamaz.");

                if (!SettingsFilePath.EndsWith(".db", StringComparison.OrdinalIgnoreCase))
                    SettingsFilePath += ".db";

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = "Veritabanı Dosyası (*.db)|*.db|Tüm Dosyalar (*.*)|*.*";
                dialog.FileName = txtFilePath.Text;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    txtFilePath.Text = dialog.FileName;
                }
            }
        }
    }
}
