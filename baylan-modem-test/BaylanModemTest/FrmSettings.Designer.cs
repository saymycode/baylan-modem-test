namespace BaylanModemTest
{
    partial class FrmSettings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.connectionGroup = new System.Windows.Forms.GroupBox();
            this.connectionLayout = new System.Windows.Forms.TableLayoutPanel();
            this.comLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblComPort = new System.Windows.Forms.Label();
            this.cmbComPort = new System.Windows.Forms.ComboBox();
            this.lblBaud = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.lblParity = new System.Windows.Forms.Label();
            this.cmbParity = new System.Windows.Forms.ComboBox();
            this.lblDataBits = new System.Windows.Forms.Label();
            this.cmbDataBits = new System.Windows.Forms.ComboBox();
            this.lblStopBits = new System.Windows.Forms.Label();
            this.cmbStopBits = new System.Windows.Forms.ComboBox();
            this.tcpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblTcpIp = new System.Windows.Forms.Label();
            this.txtTcpIp = new System.Windows.Forms.TextBox();
            this.lblPushPort = new System.Windows.Forms.Label();
            this.numPushPort = new System.Windows.Forms.NumericUpDown();
            this.lblPullPort = new System.Windows.Forms.Label();
            this.numPullPort = new System.Windows.Forms.NumericUpDown();
            this.lblMeterSerial = new System.Windows.Forms.Label();
            this.txtMeterSerial = new System.Windows.Forms.TextBox();
            this.fileLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeterFlag = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMeterBaudRate = new System.Windows.Forms.ComboBox();
            this.mainLayout.SuspendLayout();
            this.connectionGroup.SuspendLayout();
            this.connectionLayout.SuspendLayout();
            this.comLayout.SuspendLayout();
            this.tcpLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPushPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPullPort)).BeginInit();
            this.fileLayout.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.connectionGroup, 0, 0);
            this.mainLayout.Controls.Add(this.fileLayout, 0, 1);
            this.mainLayout.Controls.Add(this.buttonsPanel, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(10, 10);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.mainLayout.Size = new System.Drawing.Size(780, 530);
            this.mainLayout.TabIndex = 0;
            // 
            // connectionGroup
            // 
            this.connectionGroup.Controls.Add(this.connectionLayout);
            this.connectionGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionGroup.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.connectionGroup.Location = new System.Drawing.Point(3, 3);
            this.connectionGroup.Name = "connectionGroup";
            this.connectionGroup.Padding = new System.Windows.Forms.Padding(10);
            this.connectionGroup.Size = new System.Drawing.Size(774, 394);
            this.connectionGroup.TabIndex = 0;
            this.connectionGroup.TabStop = false;
            this.connectionGroup.Text = "Bağlantı ve Sayaç Ayarları";
            // 
            // connectionLayout
            // 
            this.connectionLayout.ColumnCount = 2;
            this.connectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.connectionLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.connectionLayout.Controls.Add(this.comLayout, 0, 0);
            this.connectionLayout.Controls.Add(this.tcpLayout, 1, 0);
            this.connectionLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionLayout.Location = new System.Drawing.Point(10, 30);
            this.connectionLayout.Name = "connectionLayout";
            this.connectionLayout.RowCount = 1;
            this.connectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.connectionLayout.Size = new System.Drawing.Size(754, 354);
            this.connectionLayout.TabIndex = 0;
            // 
            // comLayout
            // 
            this.comLayout.ColumnCount = 2;
            this.comLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.comLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.comLayout.Controls.Add(this.lblComPort, 0, 0);
            this.comLayout.Controls.Add(this.cmbComPort, 1, 0);
            this.comLayout.Controls.Add(this.lblBaud, 0, 1);
            this.comLayout.Controls.Add(this.cmbBaudRate, 1, 1);
            this.comLayout.Controls.Add(this.lblParity, 0, 2);
            this.comLayout.Controls.Add(this.cmbParity, 1, 2);
            this.comLayout.Controls.Add(this.lblDataBits, 0, 3);
            this.comLayout.Controls.Add(this.cmbDataBits, 1, 3);
            this.comLayout.Controls.Add(this.lblStopBits, 0, 4);
            this.comLayout.Controls.Add(this.cmbStopBits, 1, 4);
            this.comLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comLayout.Location = new System.Drawing.Point(3, 3);
            this.comLayout.Name = "comLayout";
            this.comLayout.RowCount = 7;
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.comLayout.Size = new System.Drawing.Size(371, 348);
            this.comLayout.TabIndex = 0;
            // 
            // lblComPort
            // 
            this.lblComPort.AutoSize = true;
            this.lblComPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComPort.Location = new System.Drawing.Point(3, 0);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(134, 45);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "COM Port";
            this.lblComPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbComPort
            // 
            this.cmbComPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(143, 3);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(225, 28);
            this.cmbComPort.TabIndex = 1;
            // 
            // lblBaud
            // 
            this.lblBaud.AutoSize = true;
            this.lblBaud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaud.Location = new System.Drawing.Point(3, 45);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(134, 45);
            this.lblBaud.TabIndex = 2;
            this.lblBaud.Text = "Baud";
            this.lblBaud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(143, 48);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(225, 28);
            this.cmbBaudRate.TabIndex = 3;
            // 
            // lblParity
            // 
            this.lblParity.AutoSize = true;
            this.lblParity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParity.Location = new System.Drawing.Point(3, 90);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(134, 45);
            this.lblParity.TabIndex = 4;
            this.lblParity.Text = "Parity";
            this.lblParity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbParity
            // 
            this.cmbParity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Location = new System.Drawing.Point(143, 93);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(225, 28);
            this.cmbParity.TabIndex = 5;
            // 
            // lblDataBits
            // 
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataBits.Location = new System.Drawing.Point(3, 135);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(134, 45);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "Data Bits";
            this.lblDataBits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbDataBits
            // 
            this.cmbDataBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Location = new System.Drawing.Point(143, 138);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(225, 28);
            this.cmbDataBits.TabIndex = 7;
            // 
            // lblStopBits
            // 
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStopBits.Location = new System.Drawing.Point(3, 180);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(134, 45);
            this.lblStopBits.TabIndex = 8;
            this.lblStopBits.Text = "Stop Bits";
            this.lblStopBits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbStopBits
            // 
            this.cmbStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Location = new System.Drawing.Point(143, 183);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(225, 28);
            this.cmbStopBits.TabIndex = 9;
            // 
            // tcpLayout
            // 
            this.tcpLayout.ColumnCount = 2;
            this.tcpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tcpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tcpLayout.Controls.Add(this.label2, 0, 5);
            this.tcpLayout.Controls.Add(this.cmbMeterBaudRate, 0, 5);
            this.tcpLayout.Controls.Add(this.label1, 0, 4);
            this.tcpLayout.Controls.Add(this.txtMeterFlag, 0, 4);
            this.tcpLayout.Controls.Add(this.lblTcpIp, 0, 0);
            this.tcpLayout.Controls.Add(this.txtTcpIp, 1, 0);
            this.tcpLayout.Controls.Add(this.lblPushPort, 0, 1);
            this.tcpLayout.Controls.Add(this.numPushPort, 1, 1);
            this.tcpLayout.Controls.Add(this.lblPullPort, 0, 2);
            this.tcpLayout.Controls.Add(this.numPullPort, 1, 2);
            this.tcpLayout.Controls.Add(this.lblMeterSerial, 0, 3);
            this.tcpLayout.Controls.Add(this.txtMeterSerial, 1, 3);
            this.tcpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcpLayout.Location = new System.Drawing.Point(380, 3);
            this.tcpLayout.Name = "tcpLayout";
            this.tcpLayout.RowCount = 7;
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tcpLayout.Size = new System.Drawing.Size(371, 348);
            this.tcpLayout.TabIndex = 1;
            // 
            // lblTcpIp
            // 
            this.lblTcpIp.AutoSize = true;
            this.lblTcpIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTcpIp.Location = new System.Drawing.Point(3, 0);
            this.lblTcpIp.Name = "lblTcpIp";
            this.lblTcpIp.Size = new System.Drawing.Size(144, 35);
            this.lblTcpIp.TabIndex = 0;
            this.lblTcpIp.Text = "SIM IP";
            this.lblTcpIp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTcpIp
            // 
            this.txtTcpIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTcpIp.Location = new System.Drawing.Point(153, 3);
            this.txtTcpIp.Name = "txtTcpIp";
            this.txtTcpIp.Size = new System.Drawing.Size(215, 27);
            this.txtTcpIp.TabIndex = 1;
            // 
            // lblPushPort
            // 
            this.lblPushPort.AutoSize = true;
            this.lblPushPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPushPort.Location = new System.Drawing.Point(3, 35);
            this.lblPushPort.Name = "lblPushPort";
            this.lblPushPort.Size = new System.Drawing.Size(144, 34);
            this.lblPushPort.TabIndex = 2;
            this.lblPushPort.Text = "Push Port";
            this.lblPushPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPushPort
            // 
            this.numPushPort.Location = new System.Drawing.Point(153, 38);
            this.numPushPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPushPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPushPort.Name = "numPushPort";
            this.numPushPort.Size = new System.Drawing.Size(120, 27);
            this.numPushPort.TabIndex = 3;
            this.numPushPort.Value = new decimal(new int[] {
            4069,
            0,
            0,
            0});
            // 
            // lblPullPort
            // 
            this.lblPullPort.AutoSize = true;
            this.lblPullPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPullPort.Location = new System.Drawing.Point(3, 69);
            this.lblPullPort.Name = "lblPullPort";
            this.lblPullPort.Size = new System.Drawing.Size(144, 36);
            this.lblPullPort.TabIndex = 4;
            this.lblPullPort.Text = "Pull Port";
            this.lblPullPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numPullPort
            // 
            this.numPullPort.Location = new System.Drawing.Point(153, 72);
            this.numPullPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numPullPort.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPullPort.Name = "numPullPort";
            this.numPullPort.Size = new System.Drawing.Size(120, 27);
            this.numPullPort.TabIndex = 5;
            this.numPullPort.Value = new decimal(new int[] {
            5200,
            0,
            0,
            0});
            // 
            // lblMeterSerial
            // 
            this.lblMeterSerial.AutoSize = true;
            this.lblMeterSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeterSerial.Location = new System.Drawing.Point(3, 105);
            this.lblMeterSerial.Name = "lblMeterSerial";
            this.lblMeterSerial.Size = new System.Drawing.Size(144, 35);
            this.lblMeterSerial.TabIndex = 6;
            this.lblMeterSerial.Text = "Sayaç Seri No";
            this.lblMeterSerial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMeterSerial
            // 
            this.txtMeterSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMeterSerial.Location = new System.Drawing.Point(153, 108);
            this.txtMeterSerial.Name = "txtMeterSerial";
            this.txtMeterSerial.Size = new System.Drawing.Size(215, 27);
            this.txtMeterSerial.TabIndex = 7;
            // 
            // fileLayout
            // 
            this.fileLayout.ColumnCount = 3;
            this.fileLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.fileLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fileLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.fileLayout.Controls.Add(this.lblFilePath, 0, 0);
            this.fileLayout.Controls.Add(this.txtFilePath, 1, 0);
            this.fileLayout.Controls.Add(this.btnBrowse, 2, 0);
            this.fileLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileLayout.Location = new System.Drawing.Point(3, 403);
            this.fileLayout.Name = "fileLayout";
            this.fileLayout.RowCount = 1;
            this.fileLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fileLayout.Size = new System.Drawing.Size(774, 74);
            this.fileLayout.TabIndex = 1;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFilePath.Location = new System.Drawing.Point(3, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(114, 74);
            this.lblFilePath.TabIndex = 0;
            this.lblFilePath.Text = "Dosya Yolu";
            this.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFilePath.Location = new System.Drawing.Point(123, 3);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(528, 23);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBrowse.Location = new System.Drawing.Point(657, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(114, 68);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Gözat";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // buttonsPanel
            // 
            this.buttonsPanel.AutoSize = true;
            this.buttonsPanel.Controls.Add(this.btnSave);
            this.buttonsPanel.Controls.Add(this.btnCancel);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonsPanel.Location = new System.Drawing.Point(615, 483);
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.buttonsPanel.Size = new System.Drawing.Size(162, 44);
            this.buttonsPanel.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(84, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(3, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 36);
            this.label1.TabIndex = 12;
            this.label1.Text = "Sayaç Flag";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMeterFlag
            // 
            this.txtMeterFlag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMeterFlag.Location = new System.Drawing.Point(153, 143);
            this.txtMeterFlag.Name = "txtMeterFlag";
            this.txtMeterFlag.Size = new System.Drawing.Size(215, 27);
            this.txtMeterFlag.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 37);
            this.label2.TabIndex = 14;
            this.label2.Text = "Sayaç Baud";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbMeterBaudRate
            // 
            this.cmbMeterBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbMeterBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMeterBaudRate.FormattingEnabled = true;
            this.cmbMeterBaudRate.Location = new System.Drawing.Point(153, 179);
            this.cmbMeterBaudRate.Name = "cmbMeterBaudRate";
            this.cmbMeterBaudRate.Size = new System.Drawing.Size(215, 28);
            this.cmbMeterBaudRate.TabIndex = 15;
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ayarlar";
            this.mainLayout.ResumeLayout(false);
            this.mainLayout.PerformLayout();
            this.connectionGroup.ResumeLayout(false);
            this.connectionLayout.ResumeLayout(false);
            this.comLayout.ResumeLayout(false);
            this.comLayout.PerformLayout();
            this.tcpLayout.ResumeLayout(false);
            this.tcpLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPushPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPullPort)).EndInit();
            this.fileLayout.ResumeLayout(false);
            this.fileLayout.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.GroupBox connectionGroup;
        private System.Windows.Forms.TableLayoutPanel connectionLayout;
        private System.Windows.Forms.TableLayoutPanel comLayout;
        private System.Windows.Forms.Label lblComPort;
        private System.Windows.Forms.ComboBox cmbComPort;
        private System.Windows.Forms.Label lblBaud;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label lblParity;
        private System.Windows.Forms.ComboBox cmbParity;
        private System.Windows.Forms.Label lblDataBits;
        private System.Windows.Forms.ComboBox cmbDataBits;
        private System.Windows.Forms.Label lblStopBits;
        private System.Windows.Forms.ComboBox cmbStopBits;
        private System.Windows.Forms.TableLayoutPanel tcpLayout;
        private System.Windows.Forms.Label lblTcpIp;
        private System.Windows.Forms.TextBox txtTcpIp;
        private System.Windows.Forms.Label lblPushPort;
        private System.Windows.Forms.NumericUpDown numPushPort;
        private System.Windows.Forms.Label lblPullPort;
        private System.Windows.Forms.NumericUpDown numPullPort;
        private System.Windows.Forms.Label lblMeterSerial;
        private System.Windows.Forms.TextBox txtMeterSerial;
        private System.Windows.Forms.TableLayoutPanel fileLayout;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbMeterBaudRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeterFlag;
    }
}
