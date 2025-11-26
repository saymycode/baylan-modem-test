namespace BaylanModemTest
{
    partial class FrmModemTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModemTest));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.headerLayout = new System.Windows.Forms.TableLayoutPanel();
            this.startStopLayout = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblCurrentStep = new System.Windows.Forms.Label();
            this.overallProgress = new System.Windows.Forms.ProgressBar();
            this.middleLayout = new System.Windows.Forms.TableLayoutPanel();
            this.grpSteps = new System.Windows.Forms.GroupBox();
            this.stepsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.pnlStep1Led = new System.Windows.Forms.Panel();
            this.lblStep1Name = new System.Windows.Forms.Label();
            this.lblStep1Status = new System.Windows.Forms.Label();
            this.pnlStep5Led = new System.Windows.Forms.Panel();
            this.lblStep5Name = new System.Windows.Forms.Label();
            this.lblStep5Status = new System.Windows.Forms.Label();
            this.pnlStep3Led = new System.Windows.Forms.Panel();
            this.lblStep3Name = new System.Windows.Forms.Label();
            this.lblStep3Status = new System.Windows.Forms.Label();
            this.pnlStep4Led = new System.Windows.Forms.Panel();
            this.lblStep4Name = new System.Windows.Forms.Label();
            this.lblStep4Status = new System.Windows.Forms.Label();
            this.pnlStep7Led = new System.Windows.Forms.Panel();
            this.lblStep7Name = new System.Windows.Forms.Label();
            this.lblStep7Status = new System.Windows.Forms.Label();
            this.grpLog = new System.Windows.Forms.GroupBox();
            this.rtbLog = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.headerLayout.SuspendLayout();
            this.startStopLayout.SuspendLayout();
            this.statusLayout.SuspendLayout();
            this.middleLayout.SuspendLayout();
            this.grpSteps.SuspendLayout();
            this.stepsLayout.SuspendLayout();
            this.grpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1400, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(56, 20);
            this.settingsMenuItem.Text = "Ayarlar";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            // 
            // mainLayout
            // 
            this.mainLayout.ColumnCount = 1;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Controls.Add(this.headerLayout, 0, 0);
            this.mainLayout.Controls.Add(this.middleLayout, 0, 1);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Location = new System.Drawing.Point(0, 24);
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.RowCount = 2;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.Size = new System.Drawing.Size(1400, 665);
            this.mainLayout.TabIndex = 0;
            // 
            // headerLayout
            // 
            this.headerLayout.ColumnCount = 2;
            this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.headerLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.headerLayout.Controls.Add(this.startStopLayout, 0, 0);
            this.headerLayout.Controls.Add(this.statusLayout, 1, 0);
            this.headerLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLayout.Location = new System.Drawing.Point(10, 10);
            this.headerLayout.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.headerLayout.Name = "headerLayout";
            this.headerLayout.RowCount = 1;
            this.headerLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headerLayout.Size = new System.Drawing.Size(1380, 124);
            this.headerLayout.TabIndex = 0;
            // 
            // startStopLayout
            // 
            this.startStopLayout.ColumnCount = 1;
            this.startStopLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.startStopLayout.Controls.Add(this.btnStart, 0, 0);
            this.startStopLayout.Controls.Add(this.btnStop, 0, 1);
            this.startStopLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startStopLayout.Location = new System.Drawing.Point(3, 3);
            this.startStopLayout.Name = "startStopLayout";
            this.startStopLayout.RowCount = 2;
            this.startStopLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startStopLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.startStopLayout.Size = new System.Drawing.Size(546, 118);
            this.startStopLayout.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.LightGreen;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(540, 53);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "TESTİ BAŞLAT";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.LightCoral;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.btnStop.Location = new System.Drawing.Point(3, 62);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(540, 53);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "DURDUR";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // statusLayout
            // 
            this.statusLayout.ColumnCount = 1;
            this.statusLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.statusLayout.Controls.Add(this.lblCurrentStep, 0, 0);
            this.statusLayout.Controls.Add(this.overallProgress, 0, 1);
            this.statusLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLayout.Location = new System.Drawing.Point(555, 3);
            this.statusLayout.Name = "statusLayout";
            this.statusLayout.RowCount = 2;
            this.statusLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.statusLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.statusLayout.Size = new System.Drawing.Size(822, 118);
            this.statusLayout.TabIndex = 1;
            // 
            // lblCurrentStep
            // 
            this.lblCurrentStep.AutoSize = true;
            this.lblCurrentStep.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentStep.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblCurrentStep.Location = new System.Drawing.Point(3, 0);
            this.lblCurrentStep.Name = "lblCurrentStep";
            this.lblCurrentStep.Size = new System.Drawing.Size(816, 64);
            this.lblCurrentStep.TabIndex = 0;
            this.lblCurrentStep.Text = "Şu an: Bekliyor";
            this.lblCurrentStep.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // overallProgress
            // 
            this.overallProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.overallProgress.Location = new System.Drawing.Point(3, 67);
            this.overallProgress.Name = "overallProgress";
            this.overallProgress.Size = new System.Drawing.Size(816, 48);
            this.overallProgress.TabIndex = 1;
            // 
            // middleLayout
            // 
            this.middleLayout.ColumnCount = 2;
            this.middleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.middleLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.middleLayout.Controls.Add(this.grpSteps, 0, 0);
            this.middleLayout.Controls.Add(this.grpLog, 1, 0);
            this.middleLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.middleLayout.Location = new System.Drawing.Point(10, 149);
            this.middleLayout.Margin = new System.Windows.Forms.Padding(10);
            this.middleLayout.Name = "middleLayout";
            this.middleLayout.RowCount = 1;
            this.middleLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.middleLayout.Size = new System.Drawing.Size(1380, 506);
            this.middleLayout.TabIndex = 1;
            // 
            // grpSteps
            // 
            this.grpSteps.Controls.Add(this.stepsLayout);
            this.grpSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSteps.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.grpSteps.Location = new System.Drawing.Point(3, 3);
            this.grpSteps.Name = "grpSteps";
            this.grpSteps.Padding = new System.Windows.Forms.Padding(10);
            this.grpSteps.Size = new System.Drawing.Size(753, 500);
            this.grpSteps.TabIndex = 0;
            this.grpSteps.TabStop = false;
            this.grpSteps.Text = "Test Adımları";
            // 
            // stepsLayout
            // 
            this.stepsLayout.ColumnCount = 3;
            this.stepsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.stepsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.stepsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.stepsLayout.Controls.Add(this.pnlStep1Led, 0, 0);
            this.stepsLayout.Controls.Add(this.lblStep1Name, 1, 0);
            this.stepsLayout.Controls.Add(this.lblStep1Status, 2, 0);
            this.stepsLayout.Controls.Add(this.pnlStep5Led, 0, 1);
            this.stepsLayout.Controls.Add(this.lblStep5Name, 1, 1);
            this.stepsLayout.Controls.Add(this.lblStep5Status, 2, 1);
            this.stepsLayout.Controls.Add(this.pnlStep3Led, 0, 2);
            this.stepsLayout.Controls.Add(this.lblStep3Name, 1, 2);
            this.stepsLayout.Controls.Add(this.lblStep3Status, 2, 2);
            this.stepsLayout.Controls.Add(this.pnlStep4Led, 0, 3);
            this.stepsLayout.Controls.Add(this.lblStep4Name, 1, 3);
            this.stepsLayout.Controls.Add(this.lblStep4Status, 2, 3);
            this.stepsLayout.Controls.Add(this.pnlStep7Led, 0, 4);
            this.stepsLayout.Controls.Add(this.lblStep7Name, 1, 4);
            this.stepsLayout.Controls.Add(this.lblStep7Status, 2, 4);
            this.stepsLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this.stepsLayout.Location = new System.Drawing.Point(10, 34);
            this.stepsLayout.Name = "stepsLayout";
            this.stepsLayout.RowCount = 5;
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.stepsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.stepsLayout.Size = new System.Drawing.Size(733, 450);
            this.stepsLayout.TabIndex = 0;
            // 
            // pnlStep1Led
            // 
            this.pnlStep1Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep1Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep1Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep1Led.Location = new System.Drawing.Point(3, 10);
            this.pnlStep1Led.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.pnlStep1Led.Name = "pnlStep1Led";
            this.pnlStep1Led.Size = new System.Drawing.Size(74, 70);
            this.pnlStep1Led.TabIndex = 0;
            // 
            // lblStep1Name
            // 
            this.lblStep1Name.AutoSize = true;
            this.lblStep1Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep1Name.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStep1Name.Location = new System.Drawing.Point(83, 0);
            this.lblStep1Name.Name = "lblStep1Name";
            this.lblStep1Name.Size = new System.Drawing.Size(467, 90);
            this.lblStep1Name.TabIndex = 1;
            this.lblStep1Name.Text = "Uyanma Testi";
            this.lblStep1Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStep1Status
            // 
            this.lblStep1Status.AutoSize = true;
            this.lblStep1Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep1Status.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblStep1Status.Location = new System.Drawing.Point(556, 0);
            this.lblStep1Status.Name = "lblStep1Status";
            this.lblStep1Status.Size = new System.Drawing.Size(174, 90);
            this.lblStep1Status.TabIndex = 2;
            this.lblStep1Status.Text = "Bekliyor";
            this.lblStep1Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStep5Led
            // 
            this.pnlStep5Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep5Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep5Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep5Led.Location = new System.Drawing.Point(3, 100);
            this.pnlStep5Led.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.pnlStep5Led.Name = "pnlStep5Led";
            this.pnlStep5Led.Size = new System.Drawing.Size(74, 70);
            this.pnlStep5Led.TabIndex = 3;
            // 
            // lblStep5Name
            // 
            this.lblStep5Name.AutoSize = true;
            this.lblStep5Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep5Name.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStep5Name.Location = new System.Drawing.Point(83, 90);
            this.lblStep5Name.Name = "lblStep5Name";
            this.lblStep5Name.Size = new System.Drawing.Size(467, 90);
            this.lblStep5Name.TabIndex = 4;
            this.lblStep5Name.Text = "Röle Testi";
            this.lblStep5Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStep5Status
            // 
            this.lblStep5Status.AutoSize = true;
            this.lblStep5Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep5Status.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblStep5Status.Location = new System.Drawing.Point(556, 90);
            this.lblStep5Status.Name = "lblStep5Status";
            this.lblStep5Status.Size = new System.Drawing.Size(174, 90);
            this.lblStep5Status.TabIndex = 5;
            this.lblStep5Status.Text = "Bekliyor";
            this.lblStep5Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStep3Led
            // 
            this.pnlStep3Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep3Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep3Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep3Led.Location = new System.Drawing.Point(3, 190);
            this.pnlStep3Led.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.pnlStep3Led.Name = "pnlStep3Led";
            this.pnlStep3Led.Size = new System.Drawing.Size(74, 70);
            this.pnlStep3Led.TabIndex = 6;
            // 
            // lblStep3Name
            // 
            this.lblStep3Name.AutoSize = true;
            this.lblStep3Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep3Name.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStep3Name.Location = new System.Drawing.Point(83, 180);
            this.lblStep3Name.Name = "lblStep3Name";
            this.lblStep3Name.Size = new System.Drawing.Size(467, 90);
            this.lblStep3Name.TabIndex = 7;
            this.lblStep3Name.Text = "Sayaç Ekleme Testi";
            this.lblStep3Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStep3Status
            // 
            this.lblStep3Status.AutoSize = true;
            this.lblStep3Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep3Status.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblStep3Status.Location = new System.Drawing.Point(556, 180);
            this.lblStep3Status.Name = "lblStep3Status";
            this.lblStep3Status.Size = new System.Drawing.Size(174, 90);
            this.lblStep3Status.TabIndex = 8;
            this.lblStep3Status.Text = "Bekliyor";
            this.lblStep3Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStep4Led
            // 
            this.pnlStep4Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep4Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep4Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep4Led.Location = new System.Drawing.Point(3, 280);
            this.pnlStep4Led.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.pnlStep4Led.Name = "pnlStep4Led";
            this.pnlStep4Led.Size = new System.Drawing.Size(74, 70);
            this.pnlStep4Led.TabIndex = 9;
            // 
            // lblStep4Name
            // 
            this.lblStep4Name.AutoSize = true;
            this.lblStep4Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep4Name.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStep4Name.Location = new System.Drawing.Point(83, 270);
            this.lblStep4Name.Name = "lblStep4Name";
            this.lblStep4Name.Size = new System.Drawing.Size(467, 90);
            this.lblStep4Name.TabIndex = 10;
            this.lblStep4Name.Text = "Sayaç Okuma Testi";
            this.lblStep4Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStep4Status
            // 
            this.lblStep4Status.AutoSize = true;
            this.lblStep4Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep4Status.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblStep4Status.Location = new System.Drawing.Point(556, 270);
            this.lblStep4Status.Name = "lblStep4Status";
            this.lblStep4Status.Size = new System.Drawing.Size(174, 90);
            this.lblStep4Status.TabIndex = 11;
            this.lblStep4Status.Text = "Bekliyor";
            this.lblStep4Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStep7Led
            // 
            this.pnlStep7Led.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlStep7Led.BackColor = System.Drawing.Color.DimGray;
            this.pnlStep7Led.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStep7Led.Location = new System.Drawing.Point(3, 370);
            this.pnlStep7Led.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.pnlStep7Led.Name = "pnlStep7Led";
            this.pnlStep7Led.Size = new System.Drawing.Size(74, 70);
            this.pnlStep7Led.TabIndex = 12;
            // 
            // lblStep7Name
            // 
            this.lblStep7Name.AutoSize = true;
            this.lblStep7Name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep7Name.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblStep7Name.Location = new System.Drawing.Point(83, 360);
            this.lblStep7Name.Name = "lblStep7Name";
            this.lblStep7Name.Size = new System.Drawing.Size(467, 90);
            this.lblStep7Name.TabIndex = 13;
            this.lblStep7Name.Text = "Finalize Testi";
            this.lblStep7Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStep7Status
            // 
            this.lblStep7Status.AutoSize = true;
            this.lblStep7Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStep7Status.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblStep7Status.Location = new System.Drawing.Point(556, 360);
            this.lblStep7Status.Name = "lblStep7Status";
            this.lblStep7Status.Size = new System.Drawing.Size(174, 90);
            this.lblStep7Status.TabIndex = 14;
            this.lblStep7Status.Text = "Bekliyor";
            this.lblStep7Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpLog
            // 
            this.grpLog.Controls.Add(this.rtbLog);
            this.grpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLog.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.grpLog.Location = new System.Drawing.Point(762, 3);
            this.grpLog.Name = "grpLog";
            this.grpLog.Padding = new System.Windows.Forms.Padding(10);
            this.grpLog.Size = new System.Drawing.Size(615, 500);
            this.grpLog.TabIndex = 1;
            this.grpLog.TabStop = false;
            this.grpLog.Text = "Canlı Log (TX/RX)";
            // 
            // rtbLog
            // 
            this.rtbLog.BackColor = System.Drawing.SystemColors.Control;
            this.rtbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLog.Font = new System.Drawing.Font("Consolas", 12F);
            this.rtbLog.Location = new System.Drawing.Point(10, 34);
            this.rtbLog.Name = "rtbLog";
            this.rtbLog.Size = new System.Drawing.Size(595, 456);
            this.rtbLog.TabIndex = 0;
            this.rtbLog.Text = "";
            // 
            // FrmModemTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1400, 689);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmModemTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modem Test";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainLayout.ResumeLayout(false);
            this.headerLayout.ResumeLayout(false);
            this.startStopLayout.ResumeLayout(false);
            this.statusLayout.ResumeLayout(false);
            this.statusLayout.PerformLayout();
            this.middleLayout.ResumeLayout(false);
            this.grpSteps.ResumeLayout(false);
            this.stepsLayout.ResumeLayout(false);
            this.stepsLayout.PerformLayout();
            this.grpLog.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.TableLayoutPanel headerLayout;
        private System.Windows.Forms.TableLayoutPanel startStopLayout;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TableLayoutPanel statusLayout;
        private System.Windows.Forms.Label lblCurrentStep;
        private System.Windows.Forms.ProgressBar overallProgress;
        private System.Windows.Forms.TableLayoutPanel middleLayout;
        private System.Windows.Forms.GroupBox grpSteps;
        private System.Windows.Forms.TableLayoutPanel stepsLayout;
        private System.Windows.Forms.Panel pnlStep1Led;
        private System.Windows.Forms.Label lblStep1Name;
        private System.Windows.Forms.Label lblStep1Status;
        private System.Windows.Forms.Panel pnlStep5Led;
        private System.Windows.Forms.Label lblStep5Name;
        private System.Windows.Forms.Label lblStep5Status;
        private System.Windows.Forms.Panel pnlStep3Led;
        private System.Windows.Forms.Label lblStep3Name;
        private System.Windows.Forms.Label lblStep3Status;
        private System.Windows.Forms.Panel pnlStep4Led;
        private System.Windows.Forms.Label lblStep4Name;
        private System.Windows.Forms.Label lblStep4Status;
        private System.Windows.Forms.Panel pnlStep7Led;
        private System.Windows.Forms.Label lblStep7Name;
        private System.Windows.Forms.Label lblStep7Status;
        private System.Windows.Forms.GroupBox grpLog;
        private System.Windows.Forms.RichTextBox rtbLog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
    }
}
