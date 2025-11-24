namespace BaylanModemTest
{
    partial class FrmModemTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grpConnection = new System.Windows.Forms.GroupBox();
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
            this.btnTestCom = new System.Windows.Forms.Button();
            this.tcpLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblTcpIp = new System.Windows.Forms.Label();
            this.txtTcpIp = new System.Windows.Forms.TextBox();
            this.lblPushPort = new System.Windows.Forms.Label();
            this.numPushPort = new System.Windows.Forms.NumericUpDown();
            this.lblPullPort = new System.Windows.Forms.Label();
            this.numPullPort = new System.Windows.Forms.NumericUpDown();
            this.chkUseTcp = new System.Windows.Forms.CheckBox();
            this.middleLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grpSteps = new System.Windows.Forms.GroupBox();
            this.stepsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStep1Led = new System.Windows.Forms.Panel();
            this.lblStep1Name = new System.Windows.Forms.Label();
            this.lblStep1Status = new System.Windows.Forms.Label();
            this.pnlStep2Led = new System.Windows.Forms.Panel();
            this.lblStep2Name = new System.Windows.Forms.Label();
            this.lblStep2Status = new System.Windows.Forms.Label();
            this.pnlStep3Led = new System.Windows.Forms.Panel();
            this.lblStep3Name = new System.Windows.Forms.Label();
            this.lblStep3Status = new System.Windows.Forms.Label();
            this.pnlStep4Led = new System.Windows.Forms.Panel();
            this.lblStep4Name = new System.Windows.Forms.Label();
            this.lblStep4Status = new System.Windows.Forms.Label();
            this.pnlStep5Led = new System.Windows.Forms.Panel();
            this.lblStep5Name = new System.Windows.Forms.Label();
            this.lblStep5Status = new System.Windows.Forms.Label();
            this.pnlStep6Led = new System.Windows.Forms.Panel();
            this.lblStep6Name = new System.Windows.Forms.Label();
            this.lblStep6Status = new System.Windows.Forms.Label();
            this.pnlStep7Led = new System.Windows.Forms.Panel();
            this.lblStep7Name = new System.Windows.Forms.Label();
            this.lblStep7Status = new System.Windows.Forms.Label();
            this.grpControls = new System.Windows.Forms.GroupBox();
            this.controlsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.overallProgress = new System.Windows.Forms.ProgressBar();
            this.lblCurrentStep = new System.Windows.Forms.Label();
            this.chkAutoScrollLog = new System.Windows.Forms.CheckBox();
            this.bottomLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.grpDummy = new System.Windows.Forms.GroupBox();
            this.dummyLayout = new System.Windows.Forms.TableLayoutPanel();
            this.txtDummyTx = new System.Windows.Forms.TextBox();
            this.lblDummyInfo = new System.Windows.Forms.Label();
            this.txtDummyRx = new System.Windows.Forms.TextBox();
            this.chkUseDummy = new System.Windows.Forms.CheckBox();
            this.mainLayout.SuspendLayout();
            this.grpConnection.SuspendLayout();
            this.connectionLayout.SuspendLayout();
            this.comLayout.SuspendLayout();
            this.tcpLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPushPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPullPort)).BeginInit();
            this.middleLayout.SuspendLayout();
            this.grpSteps.SuspendLayout();
            this.stepsLayout.SuspendLayout();
            this.grpControls.SuspendLayout();
            this.controlsLayout.SuspendLayout();
            this.bottomLayout.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.grpDummy.SuspendLayout();
            this.dummyLayout.SuspendLayout();
            this.SuspendLayout();
            //
            // mainLayout
            //
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.grpConnection, 0, 0);
            this.mainLayout.Controls.Add(this.middleLayout, 0, 1);
            this.mainLayout.Controls.Add(this.bottomLayout, 0, 2);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 0);
            this.mainLayout.Margin = new System.Windows.Forms.Padding(4);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 3;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 440F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1200, 750);
            this.mainLayout.TabIndex = 0;
            //
            // grpConnection
            //
            this.grpConnection.Controls.Add(this.connectionLayout);
            this.grpConnection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConnection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpConnection.Location = new System.Drawing.Point(10, 10);
            this.grpConnection.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.grpConnection.Name = "grpConnection";
            this.grpConnection.Padding = new System.Windows.Forms.Padding(10);
            this.grpConnection.Size = new System.Drawing.Size(1180, 155);
            this.grpConnection.TabIndex = 0;
            this.grpConnection.TabStop = false;
            this.grpConnection.Text = "Bağlantı Ayarları";
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
            this.connectionLayout.Margin = new System.Windows.Forms.Padding(4);
            this.connectionLayout.Name = "connectionLayout";
            this.connectionLayout.RowCount = 1;
            this.connectionLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.connectionLayout.Size = new System.Drawing.Size(1160, 115);
            this.connectionLayout.TabIndex = 0;
            //
            // comLayout
            //
            this.comLayout.ColumnCount = 3;
            this.comLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.comLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.comLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
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
            this.comLayout.Controls.Add(this.btnTestCom, 2, 0);
            this.comLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comLayout.Location = new System.Drawing.Point(4, 4);
            this.comLayout.Margin = new System.Windows.Forms.Padding(4);
            this.comLayout.Name = "comLayout";
            this.comLayout.RowCount = 5;
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.comLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.comLayout.Size = new System.Drawing.Size(572, 107);
            this.comLayout.TabIndex = 0;
            //
            // lblComPort
            //
            this.lblComPort.AutoSize = true;
            this.lblComPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComPort.Location = new System.Drawing.Point(3, 0);
            this.lblComPort.Name = "lblComPort";
            this.lblComPort.Size = new System.Drawing.Size(114, 21);
            this.lblComPort.TabIndex = 0;
            this.lblComPort.Text = "COM Port";
            this.lblComPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbComPort
            //
            this.cmbComPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbComPort.FormattingEnabled = true;
            this.cmbComPort.Location = new System.Drawing.Point(123, 3);
            this.cmbComPort.Name = "cmbComPort";
            this.cmbComPort.Size = new System.Drawing.Size(326, 28);
            this.cmbComPort.TabIndex = 1;
            //
            // lblBaud
            //
            this.lblBaud.AutoSize = true;
            this.lblBaud.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBaud.Location = new System.Drawing.Point(3, 21);
            this.lblBaud.Name = "lblBaud";
            this.lblBaud.Size = new System.Drawing.Size(114, 21);
            this.lblBaud.TabIndex = 2;
            this.lblBaud.Text = "Baud";
            this.lblBaud.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbBaudRate
            //
            this.cmbBaudRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(123, 24);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(326, 28);
            this.cmbBaudRate.TabIndex = 3;
            //
            // lblParity
            //
            this.lblParity.AutoSize = true;
            this.lblParity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblParity.Location = new System.Drawing.Point(3, 42);
            this.lblParity.Name = "lblParity";
            this.lblParity.Size = new System.Drawing.Size(114, 21);
            this.lblParity.TabIndex = 4;
            this.lblParity.Text = "Parity";
            this.lblParity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbParity
            //
            this.cmbParity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParity.FormattingEnabled = true;
            this.cmbParity.Location = new System.Drawing.Point(123, 45);
            this.cmbParity.Name = "cmbParity";
            this.cmbParity.Size = new System.Drawing.Size(326, 28);
            this.cmbParity.TabIndex = 5;
            //
            // lblDataBits
            //
            this.lblDataBits.AutoSize = true;
            this.lblDataBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDataBits.Location = new System.Drawing.Point(3, 63);
            this.lblDataBits.Name = "lblDataBits";
            this.lblDataBits.Size = new System.Drawing.Size(114, 21);
            this.lblDataBits.TabIndex = 6;
            this.lblDataBits.Text = "Data Bits";
            this.lblDataBits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbDataBits
            //
            this.cmbDataBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBits.FormattingEnabled = true;
            this.cmbDataBits.Location = new System.Drawing.Point(123, 66);
            this.cmbDataBits.Name = "cmbDataBits";
            this.cmbDataBits.Size = new System.Drawing.Size(326, 28);
            this.cmbDataBits.TabIndex = 7;
            //
            // lblStopBits
            //
            this.lblStopBits.AutoSize = true;
            this.lblStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStopBits.Location = new System.Drawing.Point(3, 84);
            this.lblStopBits.Name = "lblStopBits";
            this.lblStopBits.Size = new System.Drawing.Size(114, 23);
            this.lblStopBits.TabIndex = 8;
            this.lblStopBits.Text = "Stop Bits";
            this.lblStopBits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // cmbStopBits
            //
            this.cmbStopBits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBits.FormattingEnabled = true;
            this.cmbStopBits.Location = new System.Drawing.Point(123, 87);
            this.cmbStopBits.Name = "cmbStopBits";
            this.cmbStopBits.Size = new System.Drawing.Size(326, 28);
            this.cmbStopBits.TabIndex = 9;
            //
            // btnTestCom
            //
            this.btnTestCom.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTestCom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTestCom.Location = new System.Drawing.Point(455, 3);
            this.btnTestCom.Name = "btnTestCom";
            this.comLayout.SetRowSpan(this.btnTestCom, 2);
            this.btnTestCom.Size = new System.Drawing.Size(114, 39);
            this.btnTestCom.TabIndex = 10;
            this.btnTestCom.Text = "Test COM";
            this.btnTestCom.UseVisualStyleBackColor = false;
            //
            // tcpLayout
            //
            this.tcpLayout.ColumnCount = 2;
            this.tcpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tcpLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tcpLayout.Controls.Add(this.lblTcpIp, 0, 0);
            this.tcpLayout.Controls.Add(this.txtTcpIp, 1, 0);
            this.tcpLayout.Controls.Add(this.lblPushPort, 0, 1);
            this.tcpLayout.Controls.Add(this.numPushPort, 1, 1);
            this.tcpLayout.Controls.Add(this.lblPullPort, 0, 2);
            this.tcpLayout.Controls.Add(this.numPullPort, 1, 2);
            this.tcpLayout.Controls.Add(this.chkUseTcp, 1, 3);
            this.tcpLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcpLayout.Location = new System.Drawing.Point(584, 4);
            this.tcpLayout.Margin = new System.Windows.Forms.Padding(4);
            this.tcpLayout.Name = "tcpLayout";
            this.tcpLayout.RowCount = 4;
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tcpLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tcpLayout.Size = new System.Drawing.Size(572, 107);
            this.tcpLayout.TabIndex = 1;
            //
            // lblTcpIp
            //
            this.lblTcpIp.AutoSize = true;
            this.lblTcpIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTcpIp.Location = new System.Drawing.Point(3, 0);
            this.lblTcpIp.Name = "lblTcpIp";
            this.lblTcpIp.Size = new System.Drawing.Size(114, 26);
            this.lblTcpIp.TabIndex = 0;
            this.lblTcpIp.Text = "TCP IP";
            this.lblTcpIp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // txtTcpIp
            //
            this.txtTcpIp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTcpIp.Location = new System.Drawing.Point(123, 3);
            this.txtTcpIp.Name = "txtTcpIp";
            this.txtTcpIp.Size = new System.Drawing.Size(446, 27);
            this.txtTcpIp.TabIndex = 1;
            this.txtTcpIp.Text = "192.168.1.50";
            //
            // lblPushPort
            //
            this.lblPushPort.AutoSize = true;
            this.lblPushPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPushPort.Location = new System.Drawing.Point(3, 26);
            this.lblPushPort.Name = "lblPushPort";
            this.lblPushPort.Size = new System.Drawing.Size(114, 26);
            this.lblPushPort.TabIndex = 2;
            this.lblPushPort.Text = "Push Port";
            this.lblPushPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numPushPort
            //
            this.numPushPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.numPushPort.Location = new System.Drawing.Point(123, 29);
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
            5001,
            0,
            0,
            0});
            //
            // lblPullPort
            //
            this.lblPullPort.AutoSize = true;
            this.lblPullPort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPullPort.Location = new System.Drawing.Point(3, 52);
            this.lblPullPort.Name = "lblPullPort";
            this.lblPullPort.Size = new System.Drawing.Size(114, 26);
            this.lblPullPort.TabIndex = 4;
            this.lblPullPort.Text = "Pull Port";
            this.lblPullPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // numPullPort
            //
            this.numPullPort.Dock = System.Windows.Forms.DockStyle.Left;
            this.numPullPort.Location = new System.Drawing.Point(123, 55);
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
            5002,
            0,
            0,
            0});
            //
            // chkUseTcp
            //
            this.chkUseTcp.AutoSize = true;
            this.chkUseTcp.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkUseTcp.Location = new System.Drawing.Point(123, 81);
            this.chkUseTcp.Name = "chkUseTcp";
            this.chkUseTcp.Size = new System.Drawing.Size(158, 23);
            this.chkUseTcp.TabIndex = 6;
            this.chkUseTcp.Text = "TCP Testlerini Dahil Et";
            this.chkUseTcp.UseVisualStyleBackColor = true;
            //
            // middleLayout
            //
            this.middleLayout.ColumnCount = 2;
            this.middleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.middleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.middleLayout.Controls.Add(this.grpSteps, 0, 0);
            this.middleLayout.Controls.Add(this.grpControls, 1, 0);
            this.middleLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middleLayout.Location = new System.Drawing.Point(10, 180);
            this.middleLayout.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.middleLayout.Name = "middleLayout";
            this.middleLayout.RowCount = 1;
            this.middleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.middleLayout.Size = new System.Drawing.Size(1180, 301);
            this.middleLayout.TabIndex = 1;
            //
            // grpSteps
            //
            this.grpSteps.Controls.Add(this.stepsLayout);
            this.grpSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSteps.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpSteps.Location = new System.Drawing.Point(3, 3);
            this.grpSteps.Name = "grpSteps";
            this.grpSteps.Padding = new System.Windows.Forms.Padding(10);
            this.grpSteps.Size = new System.Drawing.Size(759, 295);
            this.grpSteps.TabIndex = 0;
            this.grpSteps.TabStop = false;
            this.grpSteps.Text = "Test Adımları";
            //
            // stepsLayout
            //
            this.stepsLayout.ColumnCount = 3;
            this.stepsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.stepsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.stepsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.stepsLayout.Controls.Add(this.pnlStep1Led, 0, 0);
            this.stepsLayout.Controls.Add(this.lblStep1Name, 1, 0);
            this.stepsLayout.Controls.Add(this.lblStep1Status, 2, 0);
            this.stepsLayout.Controls.Add(this.pnlStep2Led, 0, 1);
            this.stepsLayout.Controls.Add(this.lblStep2Name, 1, 1);
            this.stepsLayout.Controls.Add(this.lblStep2Status, 2, 1);
            this.stepsLayout.Controls.Add(this.pnlStep3Led, 0, 2);
            this.stepsLayout.Controls.Add(this.lblStep3Name, 1, 2);
            this.stepsLayout.Controls.Add(this.lblStep3Status, 2, 2);
            this.stepsLayout.Controls.Add(this.pnlStep4Led, 0, 3);
            this.stepsLayout.Controls.Add(this.lblStep4Name, 1, 3);
            this.stepsLayout.Controls.Add(this.lblStep4Status, 2, 3);
            this.stepsLayout.Controls.Add(this.pnlStep5Led, 0, 4);
            this.stepsLayout.Controls.Add(this.lblStep5Name, 1, 4);
            this.stepsLayout.Controls.Add(this.lblStep5Status, 2, 4);
            this.stepsLayout.Controls.Add(this.pnlStep6Led, 0, 5);
            this.stepsLayout.Controls.Add(this.lblStep6Name, 1, 5);
            this.stepsLayout.Controls.Add(this.lblStep6Status, 2, 5);
            this.stepsLayout.Controls.Add(this.pnlStep7Led, 0, 6);
            this.stepsLayout.Controls.Add(this.lblStep7Name, 1, 6);
            this.stepsLayout.Controls.Add(this.lblStep7Status, 2, 6);
            this.stepsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stepsLayout.Location = new System.Drawing.Point(10, 30);
            this.stepsLayout.Name = "stepsLayout";
            this.stepsLayout.RowCount = 7;
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.stepsLayout.Size = new System.Drawing.Size(739, 255);
            this.stepsLayout.TabIndex = 0;
            //
            // pnlStep1Led
            //
            this.pnlStep1Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep1Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep1Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep1Led.Location = new System.Drawing.Point(3, 4);
            this.pnlStep1Led.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pnlStep1Led.Name = "pnlStep1Led";
            this.pnlStep1Led.Size = new System.Drawing.Size(28, 28);
            this.pnlStep1Led.TabIndex = 0;
            //
            // lblStep1Name
            //
            this.lblStep1Name.AutoSize = true;
            this.lblStep1Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep1Name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblStep1Name.Location = new System.Drawing.Point(63, 0);
            this.lblStep1Name.Name = "lblStep1Name";
            this.lblStep1Name.Size = new System.Drawing.Size(533, 36);
            this.lblStep1Name.TabIndex = 1;
            this.lblStep1Name.Text = "Uyanma Testi";
            this.lblStep1Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStep1Status
            //
            this.lblStep1Status.AutoSize = true;
            this.lblStep1Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep1Status.Location = new System.Drawing.Point(602, 0);
            this.lblStep1Status.Name = "lblStep1Status";
            this.lblStep1Status.Size = new System.Drawing.Size(134, 36);
            this.lblStep1Status.TabIndex = 2;
            this.lblStep1Status.Text = "Bekliyor";
            this.lblStep1Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlStep2Led
            //
            this.pnlStep2Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep2Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep2Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep2Led.Location = new System.Drawing.Point(3, 40);
            this.pnlStep2Led.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pnlStep2Led.Name = "pnlStep2Led";
            this.pnlStep2Led.Size = new System.Drawing.Size(28, 28);
            this.pnlStep2Led.TabIndex = 3;
            //
            // lblStep2Name
            //
            this.lblStep2Name.AutoSize = true;
            this.lblStep2Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep2Name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblStep2Name.Location = new System.Drawing.Point(63, 36);
            this.lblStep2Name.Name = "lblStep2Name";
            this.lblStep2Name.Size = new System.Drawing.Size(533, 36);
            this.lblStep2Name.TabIndex = 4;
            this.lblStep2Name.Text = "Reset Testi";
            this.lblStep2Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStep2Status
            //
            this.lblStep2Status.AutoSize = true;
            this.lblStep2Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep2Status.Location = new System.Drawing.Point(602, 36);
            this.lblStep2Status.Name = "lblStep2Status";
            this.lblStep2Status.Size = new System.Drawing.Size(134, 36);
            this.lblStep2Status.TabIndex = 5;
            this.lblStep2Status.Text = "Bekliyor";
            this.lblStep2Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlStep3Led
            //
            this.pnlStep3Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep3Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep3Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep3Led.Location = new System.Drawing.Point(3, 76);
            this.pnlStep3Led.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pnlStep3Led.Name = "pnlStep3Led";
            this.pnlStep3Led.Size = new System.Drawing.Size(28, 28);
            this.pnlStep3Led.TabIndex = 6;
            //
            // lblStep3Name
            //
            this.lblStep3Name.AutoSize = true;
            this.lblStep3Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep3Name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblStep3Name.Location = new System.Drawing.Point(63, 72);
            this.lblStep3Name.Name = "lblStep3Name";
            this.lblStep3Name.Size = new System.Drawing.Size(533, 36);
            this.lblStep3Name.TabIndex = 7;
            this.lblStep3Name.Text = "Sayaç Ekleme Testi";
            this.lblStep3Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStep3Status
            //
            this.lblStep3Status.AutoSize = true;
            this.lblStep3Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep3Status.Location = new System.Drawing.Point(602, 72);
            this.lblStep3Status.Name = "lblStep3Status";
            this.lblStep3Status.Size = new System.Drawing.Size(134, 36);
            this.lblStep3Status.TabIndex = 8;
            this.lblStep3Status.Text = "Bekliyor";
            this.lblStep3Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlStep4Led
            //
            this.pnlStep4Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep4Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep4Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep4Led.Location = new System.Drawing.Point(3, 112);
            this.pnlStep4Led.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pnlStep4Led.Name = "pnlStep4Led";
            this.pnlStep4Led.Size = new System.Drawing.Size(28, 28);
            this.pnlStep4Led.TabIndex = 9;
            //
            // lblStep4Name
            //
            this.lblStep4Name.AutoSize = true;
            this.lblStep4Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep4Name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblStep4Name.Location = new System.Drawing.Point(63, 108);
            this.lblStep4Name.Name = "lblStep4Name";
            this.lblStep4Name.Size = new System.Drawing.Size(533, 36);
            this.lblStep4Name.TabIndex = 10;
            this.lblStep4Name.Text = "Sayaç Okuma Testi";
            this.lblStep4Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStep4Status
            //
            this.lblStep4Status.AutoSize = true;
            this.lblStep4Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep4Status.Location = new System.Drawing.Point(602, 108);
            this.lblStep4Status.Name = "lblStep4Status";
            this.lblStep4Status.Size = new System.Drawing.Size(134, 36);
            this.lblStep4Status.TabIndex = 11;
            this.lblStep4Status.Text = "Bekliyor";
            this.lblStep4Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlStep5Led
            //
            this.pnlStep5Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep5Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep5Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep5Led.Location = new System.Drawing.Point(3, 148);
            this.pnlStep5Led.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pnlStep5Led.Name = "pnlStep5Led";
            this.pnlStep5Led.Size = new System.Drawing.Size(28, 28);
            this.pnlStep5Led.TabIndex = 12;
            //
            // lblStep5Name
            //
            this.lblStep5Name.AutoSize = true;
            this.lblStep5Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep5Name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblStep5Name.Location = new System.Drawing.Point(63, 144);
            this.lblStep5Name.Name = "lblStep5Name";
            this.lblStep5Name.Size = new System.Drawing.Size(533, 36);
            this.lblStep5Name.TabIndex = 13;
            this.lblStep5Name.Text = "Röle Testi";
            this.lblStep5Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStep5Status
            //
            this.lblStep5Status.AutoSize = true;
            this.lblStep5Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep5Status.Location = new System.Drawing.Point(602, 144);
            this.lblStep5Status.Name = "lblStep5Status";
            this.lblStep5Status.Size = new System.Drawing.Size(134, 36);
            this.lblStep5Status.TabIndex = 14;
            this.lblStep5Status.Text = "Bekliyor";
            this.lblStep5Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlStep6Led
            //
            this.pnlStep6Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep6Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep6Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep6Led.Location = new System.Drawing.Point(3, 184);
            this.pnlStep6Led.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pnlStep6Led.Name = "pnlStep6Led";
            this.pnlStep6Led.Size = new System.Drawing.Size(28, 28);
            this.pnlStep6Led.TabIndex = 15;
            //
            // lblStep6Name
            //
            this.lblStep6Name.AutoSize = true;
            this.lblStep6Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep6Name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblStep6Name.Location = new System.Drawing.Point(63, 180);
            this.lblStep6Name.Name = "lblStep6Name";
            this.lblStep6Name.Size = new System.Drawing.Size(533, 36);
            this.lblStep6Name.TabIndex = 16;
            this.lblStep6Name.Text = "Input Testi";
            this.lblStep6Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStep6Status
            //
            this.lblStep6Status.AutoSize = true;
            this.lblStep6Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep6Status.Location = new System.Drawing.Point(602, 180);
            this.lblStep6Status.Name = "lblStep6Status";
            this.lblStep6Status.Size = new System.Drawing.Size(134, 36);
            this.lblStep6Status.TabIndex = 17;
            this.lblStep6Status.Text = "Bekliyor";
            this.lblStep6Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // pnlStep7Led
            //
            this.pnlStep7Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep7Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep7Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep7Led.Location = new System.Drawing.Point(3, 220);
            this.pnlStep7Led.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.pnlStep7Led.Name = "pnlStep7Led";
            this.pnlStep7Led.Size = new System.Drawing.Size(28, 28);
            this.pnlStep7Led.TabIndex = 18;
            //
            // lblStep7Name
            //
            this.lblStep7Name.AutoSize = true;
            this.lblStep7Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep7Name.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblStep7Name.Location = new System.Drawing.Point(63, 216);
            this.lblStep7Name.Name = "lblStep7Name";
            this.lblStep7Name.Size = new System.Drawing.Size(533, 39);
            this.lblStep7Name.TabIndex = 19;
            this.lblStep7Name.Text = "Finalize Testi";
            this.lblStep7Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblStep7Status
            //
            this.lblStep7Status.AutoSize = true;
            this.lblStep7Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep7Status.Location = new System.Drawing.Point(602, 216);
            this.lblStep7Status.Name = "lblStep7Status";
            this.lblStep7Status.Size = new System.Drawing.Size(134, 39);
            this.lblStep7Status.TabIndex = 20;
            this.lblStep7Status.Text = "Bekliyor";
            this.lblStep7Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // grpControls
            //
            this.grpControls.Controls.Add(this.controlsLayout);
            this.grpControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControls.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpControls.Location = new System.Drawing.Point(768, 3);
            this.grpControls.Name = "grpControls";
            this.grpControls.Padding = new System.Windows.Forms.Padding(10);
            this.grpControls.Size = new System.Drawing.Size(409, 295);
            this.grpControls.TabIndex = 1;
            this.grpControls.TabStop = false;
            this.grpControls.Text = "Kontroller";
            //
            // controlsLayout
            //
            this.controlsLayout.ColumnCount = 1;
            this.controlsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlsLayout.Controls.Add(this.btnStart, 0, 0);
            this.controlsLayout.Controls.Add(this.btnStop, 0, 1);
            this.controlsLayout.Controls.Add(this.overallProgress, 0, 2);
            this.controlsLayout.Controls.Add(this.lblCurrentStep, 0, 3);
            this.controlsLayout.Controls.Add(this.chkAutoScrollLog, 0, 4);
            this.controlsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.controlsLayout.Location = new System.Drawing.Point(10, 30);
            this.controlsLayout.Name = "controlsLayout";
            this.controlsLayout.RowCount = 5;
            this.controlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.controlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.controlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.controlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.controlsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.controlsLayout.Size = new System.Drawing.Size(389, 255);
            this.controlsLayout.TabIndex = 0;
            //
            // btnStart
            //
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(383, 54);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "TESTİ BAŞLAT";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            //
            // btnStop
            //
            this.btnStop.BackColor = System.Drawing.Color.LightCoral;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStop.Location = new System.Drawing.Point(3, 63);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(383, 54);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "DURDUR";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            //
            // overallProgress
            //
            this.overallProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overallProgress.Location = new System.Drawing.Point(3, 123);
            this.overallProgress.Name = "overallProgress";
            this.overallProgress.Size = new System.Drawing.Size(383, 34);
            this.overallProgress.TabIndex = 2;
            //
            // lblCurrentStep
            //
            this.lblCurrentStep.AutoSize = true;
            this.lblCurrentStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentStep.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCurrentStep.Location = new System.Drawing.Point(3, 160);
            this.lblCurrentStep.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblCurrentStep.Name = "lblCurrentStep";
            this.lblCurrentStep.Size = new System.Drawing.Size(383, 35);
            this.lblCurrentStep.TabIndex = 3;
            this.lblCurrentStep.Text = "Şu an: Bekliyor";
            this.lblCurrentStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // chkAutoScrollLog
            //
            this.chkAutoScrollLog.AutoSize = true;
            this.chkAutoScrollLog.Checked = true;
            this.chkAutoScrollLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoScrollLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkAutoScrollLog.Location = new System.Drawing.Point(3, 198);
            this.chkAutoScrollLog.Name = "chkAutoScrollLog";
            this.chkAutoScrollLog.Size = new System.Drawing.Size(383, 24);
            this.chkAutoScrollLog.TabIndex = 4;
            this.chkAutoScrollLog.Text = "Log otomatik kaydır";
            this.chkAutoScrollLog.UseVisualStyleBackColor = true;
            //
            // bottomLayout
            //
            this.bottomLayout.ColumnCount = 2;
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.bottomLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.bottomLayout.Controls.Add(this.grpLog, 0, 0);
            this.bottomLayout.Controls.Add(this.grpDummy, 1, 0);
            this.bottomLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomLayout.Location = new System.Drawing.Point(10, 491);
            this.bottomLayout.Margin = new System.Windows.Forms.Padding(10, 5, 10, 10);
            this.bottomLayout.Name = "bottomLayout";
            this.bottomLayout.RowCount = 1;
            this.bottomLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.bottomLayout.Size = new System.Drawing.Size(1180, 249);
            this.bottomLayout.TabIndex = 2;
            //
            // grpLog
            //
            this.grpLog.Controls.Add(this.rtbLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpLog.Location = new System.Drawing.Point(3, 3);
            this.grpLog.Name = "grpLog";
            this.grpLog.Padding = new System.Windows.Forms.Padding(10);
            this.grpLog.Size = new System.Drawing.Size(702, 243);
            this.grpLog.TabIndex = 0;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Canlı Log (TX/RX)";
            //
            // rtbLog
            //
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 10F);
            this.rtbLog.Location = new System.Drawing.Point(10, 30);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(682, 203);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            //
            // grpDummy
            //
            this.grpDummy.Controls.Add(this.dummyLayout);
            this.grpDummy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDummy.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.grpDummy.Location = new System.Drawing.Point(711, 3);
            this.grpDummy.Name = "grpDummy";
            this.grpDummy.Padding = new System.Windows.Forms.Padding(10);
            this.grpDummy.Size = new System.Drawing.Size(466, 243);
            this.grpDummy.TabIndex = 1;
            this.grpDummy.TabStop = false;
            this.grpDummy.Text = "Dummy Komut / Dummy Cevap";
            //
            // dummyLayout
            //
            this.dummyLayout.ColumnCount = 1;
            this.dummyLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.dummyLayout.Controls.Add(this.txtDummyTx, 0, 0);
            this.dummyLayout.Controls.Add(this.lblDummyInfo, 0, 1);
            this.dummyLayout.Controls.Add(this.txtDummyRx, 0, 2);
            this.dummyLayout.Controls.Add(this.chkUseDummy, 0, 3);
            this.dummyLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dummyLayout.Location = new System.Drawing.Point(10, 30);
            this.dummyLayout.Name = "dummyLayout";
            this.dummyLayout.RowCount = 4;
            this.dummyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.dummyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.dummyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.dummyLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.dummyLayout.Size = new System.Drawing.Size(446, 203);
            this.dummyLayout.TabIndex = 0;
            //
            // txtDummyTx
            //
            this.txtDummyTx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDummyTx.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDummyTx.Location = new System.Drawing.Point(3, 3);
            this.txtDummyTx.Multiline = true;
            this.txtDummyTx.Name = "txtDummyTx";
            this.txtDummyTx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDummyTx.Size = new System.Drawing.Size(440, 64);
            this.txtDummyTx.TabIndex = 0;
            this.txtDummyTx.Text = "AT\r\nAT+RST\r\nAT+MTRADD=00112233\r\nAT+MTRRD=00112233\r\nAT+RELAY=ON\r\nAT+INPUT?\r\nAT+FIN";
            //
            // lblDummyInfo
            //
            this.lblDummyInfo.AutoSize = true;
            this.lblDummyInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDummyInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDummyInfo.Location = new System.Drawing.Point(3, 70);
            this.lblDummyInfo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.lblDummyInfo.Name = "lblDummyInfo";
            this.lblDummyInfo.Size = new System.Drawing.Size(440, 25);
            this.lblDummyInfo.TabIndex = 1;
            this.lblDummyInfo.Text = "Gerçek cihaz yoksa test burada yazılan TX/RX ile simüle edilir.";
            //
            // txtDummyRx
            //
            this.txtDummyRx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDummyRx.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDummyRx.Location = new System.Drawing.Point(3, 103);
            this.txtDummyRx.Multiline = true;
            this.txtDummyRx.Name = "txtDummyRx";
            this.txtDummyRx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDummyRx.Size = new System.Drawing.Size(440, 64);
            this.txtDummyRx.TabIndex = 2;
            this.txtDummyRx.Text = "OK\r\nOK\r\nMTRADDED\r\nMTRDATA\r\nRELAYOK\r\nINPUTOK\r\nFINOK";
            //
            // chkUseDummy
            //
            this.chkUseDummy.AutoSize = true;
            this.chkUseDummy.Dock = System.Windows.Forms.DockStyle.Left;
            this.chkUseDummy.Location = new System.Drawing.Point(3, 173);
            this.chkUseDummy.Name = "chkUseDummy";
            this.chkUseDummy.Size = new System.Drawing.Size(136, 27);
            this.chkUseDummy.TabIndex = 3;
            this.chkUseDummy.Text = "Dummy kullan";
            this.chkUseDummy.UseVisualStyleBackColor = true;
            //
            // FrmModemTest
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.mainLayout);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmModemTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modem Test";
            this.mainLayout.ResumeLayout(false);
            this.grpConnection.ResumeLayout(false);
            this.connectionLayout.ResumeLayout(false);
            this.comLayout.ResumeLayout(false);
            this.comLayout.PerformLayout();
            this.tcpLayout.ResumeLayout(false);
            this.tcpLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPushPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPullPort)).EndInit();
            this.middleLayout.ResumeLayout(false);
            this.grpSteps.ResumeLayout(false);
            this.stepsLayout.ResumeLayout(false);
            this.stepsLayout.PerformLayout();
            this.grpControls.ResumeLayout(false);
            this.controlsLayout.ResumeLayout(false);
            this.controlsLayout.PerformLayout();
            this.bottomLayout.ResumeLayout(false);
            this.grpLog.ResumeLayout(false);
            this.grpDummy.ResumeLayout(false);
            this.dummyLayout.ResumeLayout(false);
            this.dummyLayout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.GroupBox grpConnection;
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
        private System.Windows.Forms.Button btnTestCom;
        private System.Windows.Forms.TableLayoutPanel tcpLayout;
        private System.Windows.Forms.Label lblTcpIp;
        private System.Windows.Forms.TextBox txtTcpIp;
        private System.Windows.Forms.Label lblPushPort;
        private System.Windows.Forms.NumericUpDown numPushPort;
        private System.Windows.Forms.Label lblPullPort;
        private System.Windows.Forms.NumericUpDown numPullPort;
        private System.Windows.Forms.CheckBox chkUseTcp;
        private System.Windows.Forms.TableLayoutPanel middleLayout;
        private System.Windows.Forms.GroupBox grpSteps;
        private System.Windows.Forms.TableLayoutPanel stepsLayout;
        private System.Windows.Forms.Panel pnlStep1Led;
        private System.Windows.Forms.Label lblStep1Name;
        private System.Windows.Forms.Label lblStep1Status;
        private System.Windows.Forms.Panel pnlStep2Led;
        private System.Windows.Forms.Label lblStep2Name;
        private System.Windows.Forms.Label lblStep2Status;
        private System.Windows.Forms.Panel pnlStep3Led;
        private System.Windows.Forms.Label lblStep3Name;
        private System.Windows.Forms.Label lblStep3Status;
        private System.Windows.Forms.Panel pnlStep4Led;
        private System.Windows.Forms.Label lblStep4Name;
        private System.Windows.Forms.Label lblStep4Status;
        private System.Windows.Forms.Panel pnlStep5Led;
        private System.Windows.Forms.Label lblStep5Name;
        private System.Windows.Forms.Label lblStep5Status;
        private System.Windows.Forms.Panel pnlStep6Led;
        private System.Windows.Forms.Label lblStep6Name;
        private System.Windows.Forms.Label lblStep6Status;
        private System.Windows.Forms.Panel pnlStep7Led;
        private System.Windows.Forms.Label lblStep7Name;
        private System.Windows.Forms.Label lblStep7Status;
        private System.Windows.Forms.GroupBox grpControls;
        private System.Windows.Forms.TableLayoutPanel controlsLayout;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar overallProgress;
        private System.Windows.Forms.Label lblCurrentStep;
        private System.Windows.Forms.CheckBox chkAutoScrollLog;
        private System.Windows.Forms.TableLayoutPanel bottomLayout;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.GroupBox grpDummy;
        private System.Windows.Forms.TableLayoutPanel dummyLayout;
        private System.Windows.Forms.TextBox txtDummyTx;
        private System.Windows.Forms.Label lblDummyInfo;
        private System.Windows.Forms.TextBox txtDummyRx;
        private System.Windows.Forms.CheckBox chkUseDummy;
    }
}
