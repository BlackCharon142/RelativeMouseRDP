namespace RelativeMouseRDP
{
    partial class frm_Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
            this.gpbConnectionMethod = new System.Windows.Forms.GroupBox();
            this.rbtnConnectionMethodAutomatic = new System.Windows.Forms.RadioButton();
            this.rbtnConnectionMethodUDP = new System.Windows.Forms.RadioButton();
            this.rbtnConnectionMethodTCP = new System.Windows.Forms.RadioButton();
            this.gpbConnectionStatus = new System.Windows.Forms.GroupBox();
            this.chbConnectionStatusRefreshConstantly = new System.Windows.Forms.CheckBox();
            this.lblPing = new System.Windows.Forms.Label();
            this.lblUploadSpeed = new System.Windows.Forms.Label();
            this.lblDownloadSpeed = new System.Windows.Forms.Label();
            this.btnConnectionStatusRefresh = new System.Windows.Forms.Button();
            this.lblgpbConnectionStatusUploadSpeed = new System.Windows.Forms.Label();
            this.lblConnectionStatusDownloadSpeed = new System.Windows.Forms.Label();
            this.gpbConnectionStatusPing = new System.Windows.Forms.Label();
            this.gpbDevicePosition = new System.Windows.Forms.GroupBox();
            this.rbtnDevicePositionServer = new System.Windows.Forms.RadioButton();
            this.rbtnDevicePositionClient = new System.Windows.Forms.RadioButton();
            this.gpbConnectionSpecifications = new System.Windows.Forms.GroupBox();
            this.txtConnectionSpecificationsIP = new System.Windows.Forms.TextBox();
            this.lblConnectionSpecificationsPort = new System.Windows.Forms.Label();
            this.txtConnectionSpecificationsPort = new System.Windows.Forms.TextBox();
            this.lblConnectionSpecificationsIP = new System.Windows.Forms.Label();
            this.gpbLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.pnlStatusBar = new System.Windows.Forms.Panel();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.pbVisualStatus = new System.Windows.Forms.PictureBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.LogChecker = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.UpdateStaus = new System.Windows.Forms.Timer(this.components);
            this.gpbConnectionMethod.SuspendLayout();
            this.gpbConnectionStatus.SuspendLayout();
            this.gpbDevicePosition.SuspendLayout();
            this.gpbConnectionSpecifications.SuspendLayout();
            this.gpbLog.SuspendLayout();
            this.pnlStatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisualStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbConnectionMethod
            // 
            this.gpbConnectionMethod.Controls.Add(this.rbtnConnectionMethodAutomatic);
            this.gpbConnectionMethod.Controls.Add(this.rbtnConnectionMethodUDP);
            this.gpbConnectionMethod.Controls.Add(this.rbtnConnectionMethodTCP);
            this.gpbConnectionMethod.Location = new System.Drawing.Point(12, 296);
            this.gpbConnectionMethod.Name = "gpbConnectionMethod";
            this.gpbConnectionMethod.Size = new System.Drawing.Size(282, 120);
            this.gpbConnectionMethod.TabIndex = 3;
            this.gpbConnectionMethod.TabStop = false;
            this.gpbConnectionMethod.Text = "Connection Method";
            // 
            // rbtnConnectionMethodAutomatic
            // 
            this.rbtnConnectionMethodAutomatic.AutoSize = true;
            this.rbtnConnectionMethodAutomatic.Location = new System.Drawing.Point(6, 26);
            this.rbtnConnectionMethodAutomatic.Name = "rbtnConnectionMethodAutomatic";
            this.rbtnConnectionMethodAutomatic.Size = new System.Drawing.Size(99, 24);
            this.rbtnConnectionMethodAutomatic.TabIndex = 0;
            this.rbtnConnectionMethodAutomatic.Text = "Automatic";
            this.toolTip.SetToolTip(this.rbtnConnectionMethodAutomatic, resources.GetString("rbtnConnectionMethodAutomatic.ToolTip"));
            this.rbtnConnectionMethodAutomatic.UseVisualStyleBackColor = true;
            this.rbtnConnectionMethodAutomatic.CheckedChanged += new System.EventHandler(this.rbtnConnectionMethodAutomatic_CheckedChanged);
            // 
            // rbtnConnectionMethodUDP
            // 
            this.rbtnConnectionMethodUDP.AutoSize = true;
            this.rbtnConnectionMethodUDP.Location = new System.Drawing.Point(6, 86);
            this.rbtnConnectionMethodUDP.Name = "rbtnConnectionMethodUDP";
            this.rbtnConnectionMethodUDP.Size = new System.Drawing.Size(204, 24);
            this.rbtnConnectionMethodUDP.TabIndex = 2;
            this.rbtnConnectionMethodUDP.Text = "UDP (Fast but not reliable)";
            this.toolTip.SetToolTip(this.rbtnConnectionMethodUDP, "UDP\r\nUDP does not require connection to be established and\r\nmaintained. It is a m" +
        "uch faster, simpler, and efficient protocol tho\r\nsome data may get corrupted whe" +
        "n using this protocol");
            this.rbtnConnectionMethodUDP.UseVisualStyleBackColor = true;
            this.rbtnConnectionMethodUDP.CheckedChanged += new System.EventHandler(this.rbtnConnectionMethodUDP_CheckedChanged);
            // 
            // rbtnConnectionMethodTCP
            // 
            this.rbtnConnectionMethodTCP.AutoSize = true;
            this.rbtnConnectionMethodTCP.Location = new System.Drawing.Point(6, 56);
            this.rbtnConnectionMethodTCP.Name = "rbtnConnectionMethodTCP";
            this.rbtnConnectionMethodTCP.Size = new System.Drawing.Size(231, 24);
            this.rbtnConnectionMethodTCP.TabIndex = 1;
            this.rbtnConnectionMethodTCP.Text = "TCP (Reliable but maybe slow)";
            this.toolTip.SetToolTip(this.rbtnConnectionMethodTCP, "TCP\r\nTCP guarantees the integrity of the data being\r\n communicated over the netwo" +
        "rk\r\n");
            this.rbtnConnectionMethodTCP.UseVisualStyleBackColor = true;
            this.rbtnConnectionMethodTCP.CheckedChanged += new System.EventHandler(this.rbtnConnectionMethodTCP_CheckedChanged);
            // 
            // gpbConnectionStatus
            // 
            this.gpbConnectionStatus.Controls.Add(this.chbConnectionStatusRefreshConstantly);
            this.gpbConnectionStatus.Controls.Add(this.lblPing);
            this.gpbConnectionStatus.Controls.Add(this.lblUploadSpeed);
            this.gpbConnectionStatus.Controls.Add(this.lblDownloadSpeed);
            this.gpbConnectionStatus.Controls.Add(this.btnConnectionStatusRefresh);
            this.gpbConnectionStatus.Controls.Add(this.lblgpbConnectionStatusUploadSpeed);
            this.gpbConnectionStatus.Controls.Add(this.lblConnectionStatusDownloadSpeed);
            this.gpbConnectionStatus.Controls.Add(this.gpbConnectionStatusPing);
            this.gpbConnectionStatus.Location = new System.Drawing.Point(12, 163);
            this.gpbConnectionStatus.Name = "gpbConnectionStatus";
            this.gpbConnectionStatus.Size = new System.Drawing.Size(282, 127);
            this.gpbConnectionStatus.TabIndex = 2;
            this.gpbConnectionStatus.TabStop = false;
            this.gpbConnectionStatus.Text = "Connection Status";
            // 
            // chbConnectionStatusRefreshConstantly
            // 
            this.chbConnectionStatusRefreshConstantly.AutoSize = true;
            this.chbConnectionStatusRefreshConstantly.Location = new System.Drawing.Point(251, 65);
            this.chbConnectionStatusRefreshConstantly.Name = "chbConnectionStatusRefreshConstantly";
            this.chbConnectionStatusRefreshConstantly.Size = new System.Drawing.Size(18, 17);
            this.chbConnectionStatusRefreshConstantly.TabIndex = 7;
            this.toolTip.SetToolTip(this.chbConnectionStatusRefreshConstantly, "Live Status\r\nShows the connection strength live as data is being sent and receive" +
        "d");
            this.chbConnectionStatusRefreshConstantly.UseVisualStyleBackColor = true;
            this.chbConnectionStatusRefreshConstantly.CheckedChanged += new System.EventHandler(this.chbConnectionStatusRefreshConstantly_CheckedChanged);
            // 
            // lblPing
            // 
            this.lblPing.Location = new System.Drawing.Point(129, 96);
            this.lblPing.Name = "lblPing";
            this.lblPing.Size = new System.Drawing.Size(95, 20);
            this.lblPing.TabIndex = 5;
            this.lblPing.Text = "0 ms";
            this.lblPing.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUploadSpeed
            // 
            this.lblUploadSpeed.Location = new System.Drawing.Point(129, 65);
            this.lblUploadSpeed.Name = "lblUploadSpeed";
            this.lblUploadSpeed.Size = new System.Drawing.Size(95, 20);
            this.lblUploadSpeed.TabIndex = 3;
            this.lblUploadSpeed.Text = "0 Mbit/s";
            this.lblUploadSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDownloadSpeed
            // 
            this.lblDownloadSpeed.Location = new System.Drawing.Point(129, 34);
            this.lblDownloadSpeed.Name = "lblDownloadSpeed";
            this.lblDownloadSpeed.Size = new System.Drawing.Size(95, 20);
            this.lblDownloadSpeed.TabIndex = 1;
            this.lblDownloadSpeed.Text = "0 Mbit/s";
            this.lblDownloadSpeed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConnectionStatusRefresh
            // 
            this.btnConnectionStatusRefresh.BackgroundImage = global::RelativeMouseRDP.Properties.Resources.refresh_32px;
            this.btnConnectionStatusRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnConnectionStatusRefresh.Location = new System.Drawing.Point(244, 26);
            this.btnConnectionStatusRefresh.Name = "btnConnectionStatusRefresh";
            this.btnConnectionStatusRefresh.Size = new System.Drawing.Size(32, 32);
            this.btnConnectionStatusRefresh.TabIndex = 6;
            this.toolTip.SetToolTip(this.btnConnectionStatusRefresh, "Examine Connection Status\r\nExamines the total strength of the connection between " +
        "the two ends");
            this.btnConnectionStatusRefresh.UseVisualStyleBackColor = true;
            this.btnConnectionStatusRefresh.Click += new System.EventHandler(this.btnConnectionStatusRefresh_Click);
            // 
            // lblgpbConnectionStatusUploadSpeed
            // 
            this.lblgpbConnectionStatusUploadSpeed.AutoSize = true;
            this.lblgpbConnectionStatusUploadSpeed.Location = new System.Drawing.Point(6, 65);
            this.lblgpbConnectionStatusUploadSpeed.Name = "lblgpbConnectionStatusUploadSpeed";
            this.lblgpbConnectionStatusUploadSpeed.Size = new System.Drawing.Size(104, 20);
            this.lblgpbConnectionStatusUploadSpeed.TabIndex = 2;
            this.lblgpbConnectionStatusUploadSpeed.Text = "Upload Speed";
            // 
            // lblConnectionStatusDownloadSpeed
            // 
            this.lblConnectionStatusDownloadSpeed.AutoSize = true;
            this.lblConnectionStatusDownloadSpeed.Location = new System.Drawing.Point(6, 34);
            this.lblConnectionStatusDownloadSpeed.Name = "lblConnectionStatusDownloadSpeed";
            this.lblConnectionStatusDownloadSpeed.Size = new System.Drawing.Size(124, 20);
            this.lblConnectionStatusDownloadSpeed.TabIndex = 0;
            this.lblConnectionStatusDownloadSpeed.Text = "Download Speed";
            // 
            // gpbConnectionStatusPing
            // 
            this.gpbConnectionStatusPing.AutoSize = true;
            this.gpbConnectionStatusPing.Location = new System.Drawing.Point(6, 96);
            this.gpbConnectionStatusPing.Name = "gpbConnectionStatusPing";
            this.gpbConnectionStatusPing.Size = new System.Drawing.Size(38, 20);
            this.gpbConnectionStatusPing.TabIndex = 4;
            this.gpbConnectionStatusPing.Text = "Ping";
            // 
            // gpbDevicePosition
            // 
            this.gpbDevicePosition.Controls.Add(this.rbtnDevicePositionServer);
            this.gpbDevicePosition.Controls.Add(this.rbtnDevicePositionClient);
            this.gpbDevicePosition.Location = new System.Drawing.Point(12, 12);
            this.gpbDevicePosition.Name = "gpbDevicePosition";
            this.gpbDevicePosition.Size = new System.Drawing.Size(282, 63);
            this.gpbDevicePosition.TabIndex = 0;
            this.gpbDevicePosition.TabStop = false;
            this.gpbDevicePosition.Text = "Device Position";
            // 
            // rbtnDevicePositionServer
            // 
            this.rbtnDevicePositionServer.AutoSize = true;
            this.rbtnDevicePositionServer.Location = new System.Drawing.Point(142, 26);
            this.rbtnDevicePositionServer.Name = "rbtnDevicePositionServer";
            this.rbtnDevicePositionServer.Size = new System.Drawing.Size(71, 24);
            this.rbtnDevicePositionServer.TabIndex = 1;
            this.rbtnDevicePositionServer.Text = "Server";
            this.toolTip.SetToolTip(this.rbtnDevicePositionServer, "Server\r\nSets the program to listen for incoming data from a client");
            this.rbtnDevicePositionServer.UseVisualStyleBackColor = true;
            this.rbtnDevicePositionServer.CheckedChanged += new System.EventHandler(this.rbtnDevicePositionServer_CheckedChanged);
            // 
            // rbtnDevicePositionClient
            // 
            this.rbtnDevicePositionClient.AutoSize = true;
            this.rbtnDevicePositionClient.Location = new System.Drawing.Point(6, 26);
            this.rbtnDevicePositionClient.Name = "rbtnDevicePositionClient";
            this.rbtnDevicePositionClient.Size = new System.Drawing.Size(68, 24);
            this.rbtnDevicePositionClient.TabIndex = 0;
            this.rbtnDevicePositionClient.Text = "Client";
            this.toolTip.SetToolTip(this.rbtnDevicePositionClient, "Client\r\nSets the program to send data to server\r\n");
            this.rbtnDevicePositionClient.UseVisualStyleBackColor = true;
            this.rbtnDevicePositionClient.CheckedChanged += new System.EventHandler(this.rbtnDevicePositionClient_CheckedChanged);
            // 
            // gpbConnectionSpecifications
            // 
            this.gpbConnectionSpecifications.Controls.Add(this.txtConnectionSpecificationsIP);
            this.gpbConnectionSpecifications.Controls.Add(this.lblConnectionSpecificationsPort);
            this.gpbConnectionSpecifications.Controls.Add(this.txtConnectionSpecificationsPort);
            this.gpbConnectionSpecifications.Controls.Add(this.lblConnectionSpecificationsIP);
            this.gpbConnectionSpecifications.Enabled = false;
            this.gpbConnectionSpecifications.Location = new System.Drawing.Point(12, 81);
            this.gpbConnectionSpecifications.Name = "gpbConnectionSpecifications";
            this.gpbConnectionSpecifications.Size = new System.Drawing.Size(282, 76);
            this.gpbConnectionSpecifications.TabIndex = 1;
            this.gpbConnectionSpecifications.TabStop = false;
            this.gpbConnectionSpecifications.Text = "Connection Specifications";
            // 
            // txtConnectionSpecificationsIP
            // 
            this.txtConnectionSpecificationsIP.Location = new System.Drawing.Point(31, 33);
            this.txtConnectionSpecificationsIP.MaxLength = 15;
            this.txtConnectionSpecificationsIP.Name = "txtConnectionSpecificationsIP";
            this.txtConnectionSpecificationsIP.PlaceholderText = "000.000.000.000";
            this.txtConnectionSpecificationsIP.Size = new System.Drawing.Size(141, 27);
            this.txtConnectionSpecificationsIP.TabIndex = 1;
            this.txtConnectionSpecificationsIP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.txtConnectionSpecificationsIP, "IP\r\nThe IP that program will send/get data from\r\n\r\nFor Server Leave empty to acce" +
        "pt incoming data\r\n from all ip addresses");
            this.txtConnectionSpecificationsIP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConnectionSpecificationsIP_KeyPress);
            this.txtConnectionSpecificationsIP.Leave += new System.EventHandler(this.txtConnectionSpecificationsIP_Leave);
            // 
            // lblConnectionSpecificationsPort
            // 
            this.lblConnectionSpecificationsPort.AutoSize = true;
            this.lblConnectionSpecificationsPort.Location = new System.Drawing.Point(178, 36);
            this.lblConnectionSpecificationsPort.Name = "lblConnectionSpecificationsPort";
            this.lblConnectionSpecificationsPort.Size = new System.Drawing.Size(35, 20);
            this.lblConnectionSpecificationsPort.TabIndex = 2;
            this.lblConnectionSpecificationsPort.Text = "Port";
            // 
            // txtConnectionSpecificationsPort
            // 
            this.txtConnectionSpecificationsPort.Location = new System.Drawing.Point(219, 33);
            this.txtConnectionSpecificationsPort.MaxLength = 5;
            this.txtConnectionSpecificationsPort.Name = "txtConnectionSpecificationsPort";
            this.txtConnectionSpecificationsPort.PlaceholderText = "12345";
            this.txtConnectionSpecificationsPort.Size = new System.Drawing.Size(57, 27);
            this.txtConnectionSpecificationsPort.TabIndex = 3;
            this.txtConnectionSpecificationsPort.Text = "54321";
            this.txtConnectionSpecificationsPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.txtConnectionSpecificationsPort, "Port\r\nThe channel that two ends use to communicate with each other\r\nThe Port shou" +
        "ld be the same on both ends");
            this.txtConnectionSpecificationsPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConnectionSpecificationsPort_KeyPress);
            this.txtConnectionSpecificationsPort.Leave += new System.EventHandler(this.txtConnectionSpecificationsPort_Leave);
            // 
            // lblConnectionSpecificationsIP
            // 
            this.lblConnectionSpecificationsIP.AutoSize = true;
            this.lblConnectionSpecificationsIP.Location = new System.Drawing.Point(4, 36);
            this.lblConnectionSpecificationsIP.Name = "lblConnectionSpecificationsIP";
            this.lblConnectionSpecificationsIP.Size = new System.Drawing.Size(21, 20);
            this.lblConnectionSpecificationsIP.TabIndex = 0;
            this.lblConnectionSpecificationsIP.Text = "IP";
            // 
            // gpbLog
            // 
            this.gpbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbLog.Controls.Add(this.txtLog);
            this.gpbLog.Location = new System.Drawing.Point(300, 12);
            this.gpbLog.Name = "gpbLog";
            this.gpbLog.Size = new System.Drawing.Size(584, 404);
            this.gpbLog.TabIndex = 4;
            this.gpbLog.TabStop = false;
            this.gpbLog.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.SystemColors.Control;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtLog.Location = new System.Drawing.Point(3, 23);
            this.txtLog.MaxLength = 999999999;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(578, 378);
            this.txtLog.TabIndex = 0;
            this.toolTip.SetToolTip(this.txtLog, "Double Click To Stop Showing The Live Log");
            this.txtLog.DoubleClick += new System.EventHandler(this.txtLog_DoubleClick);
            // 
            // pnlStatusBar
            // 
            this.pnlStatusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlStatusBar.Controls.Add(this.btnChangeStatus);
            this.pnlStatusBar.Controls.Add(this.pbVisualStatus);
            this.pnlStatusBar.Controls.Add(this.lblStatus);
            this.pnlStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlStatusBar.Location = new System.Drawing.Point(0, 422);
            this.pnlStatusBar.Name = "pnlStatusBar";
            this.pnlStatusBar.Size = new System.Drawing.Size(896, 33);
            this.pnlStatusBar.TabIndex = 5;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChangeStatus.Location = new System.Drawing.Point(766, 0);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(97, 29);
            this.btnChangeStatus.TabIndex = 1;
            this.btnChangeStatus.Text = "Start";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // pbVisualStatus
            // 
            this.pbVisualStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.pbVisualStatus.Location = new System.Drawing.Point(863, 0);
            this.pbVisualStatus.Name = "pbVisualStatus";
            this.pbVisualStatus.Size = new System.Drawing.Size(29, 29);
            this.pbVisualStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbVisualStatus.TabIndex = 1;
            this.pbVisualStatus.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 6);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(60, 20);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Status : ";
            // 
            // LogChecker
            // 
            this.LogChecker.Enabled = true;
            this.LogChecker.Interval = 500;
            this.LogChecker.Tick += new System.EventHandler(this.LogChecker_Tick);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 10000;
            this.toolTip.InitialDelay = 340;
            this.toolTip.ReshowDelay = 68;
            // 
            // UpdateStaus
            // 
            this.UpdateStaus.Enabled = true;
            this.UpdateStaus.Interval = 1000;
            this.UpdateStaus.Tick += new System.EventHandler(this.UpdateStaus_Tick);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 455);
            this.Controls.Add(this.pnlStatusBar);
            this.Controls.Add(this.gpbLog);
            this.Controls.Add(this.gpbConnectionSpecifications);
            this.Controls.Add(this.gpbDevicePosition);
            this.Controls.Add(this.gpbConnectionStatus);
            this.Controls.Add(this.gpbConnectionMethod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Main";
            this.Text = "RDP Relative Mouse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
            this.gpbConnectionMethod.ResumeLayout(false);
            this.gpbConnectionMethod.PerformLayout();
            this.gpbConnectionStatus.ResumeLayout(false);
            this.gpbConnectionStatus.PerformLayout();
            this.gpbDevicePosition.ResumeLayout(false);
            this.gpbDevicePosition.PerformLayout();
            this.gpbConnectionSpecifications.ResumeLayout(false);
            this.gpbConnectionSpecifications.PerformLayout();
            this.gpbLog.ResumeLayout(false);
            this.gpbLog.PerformLayout();
            this.pnlStatusBar.ResumeLayout(false);
            this.pnlStatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbVisualStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox gpbConnectionMethod;
        private RadioButton rbtnConnectionMethodAutomatic;
        private RadioButton rbtnConnectionMethodUDP;
        private RadioButton rbtnConnectionMethodTCP;
        private GroupBox gpbConnectionStatus;
        private Label gpbConnectionStatusPing;
        private Label lblgpbConnectionStatusUploadSpeed;
        private Label lblConnectionStatusDownloadSpeed;
        private GroupBox gpbDevicePosition;
        private RadioButton rbtnDevicePositionServer;
        private RadioButton rbtnDevicePositionClient;
        private GroupBox gpbConnectionSpecifications;
        private Label lblConnectionSpecificationsPort;
        private TextBox txtConnectionSpecificationsPort;
        private Label lblConnectionSpecificationsIP;
        private Button btnConnectionStatusRefresh;
        private GroupBox gpbLog;
        private TextBox txtLog;
        private Panel pnlStatusBar;
        private PictureBox pbVisualStatus;
        private Label lblStatus;
        private Button btnChangeStatus;
        private Label lblUploadSpeed;
        private Label lblDownloadSpeed;
        private Label lblPing;
        private CheckBox chbConnectionStatusRefreshConstantly;
        private TextBox txtConnectionSpecificationsIP;
        private System.Windows.Forms.Timer LogChecker;
        private ToolTip toolTip;
        private System.Windows.Forms.Timer UpdateStaus;
    }
}