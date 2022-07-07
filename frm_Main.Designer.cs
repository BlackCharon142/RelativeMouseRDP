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
            this.gpbConnectionMethod = new System.Windows.Forms.GroupBox();
            this.rbtnConnectionMethodAutomatic = new System.Windows.Forms.RadioButton();
            this.rbtnConnectionMethodUDP = new System.Windows.Forms.RadioButton();
            this.rbtnConnectionMethodTCP = new System.Windows.Forms.RadioButton();
            this.gpbConnectionStatus = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblPing = new System.Windows.Forms.Label();
            this.lblUploadSpeed = new System.Windows.Forms.Label();
            this.lblDownloadSpeed = new System.Windows.Forms.Label();
            this.gpbConnectionStatusRefresh = new System.Windows.Forms.Button();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChangeStatus = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LogChecker = new System.Windows.Forms.Timer(this.components);
            this.gpbConnectionMethod.SuspendLayout();
            this.gpbConnectionStatus.SuspendLayout();
            this.gpbDevicePosition.SuspendLayout();
            this.gpbConnectionSpecifications.SuspendLayout();
            this.gpbLog.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.rbtnConnectionMethodAutomatic.Checked = true;
            this.rbtnConnectionMethodAutomatic.Location = new System.Drawing.Point(6, 26);
            this.rbtnConnectionMethodAutomatic.Name = "rbtnConnectionMethodAutomatic";
            this.rbtnConnectionMethodAutomatic.Size = new System.Drawing.Size(99, 24);
            this.rbtnConnectionMethodAutomatic.TabIndex = 0;
            this.rbtnConnectionMethodAutomatic.TabStop = true;
            this.rbtnConnectionMethodAutomatic.Text = "Automatic";
            this.rbtnConnectionMethodAutomatic.UseVisualStyleBackColor = true;
            // 
            // rbtnConnectionMethodUDP
            // 
            this.rbtnConnectionMethodUDP.AutoSize = true;
            this.rbtnConnectionMethodUDP.Location = new System.Drawing.Point(6, 86);
            this.rbtnConnectionMethodUDP.Name = "rbtnConnectionMethodUDP";
            this.rbtnConnectionMethodUDP.Size = new System.Drawing.Size(204, 24);
            this.rbtnConnectionMethodUDP.TabIndex = 2;
            this.rbtnConnectionMethodUDP.Text = "UDP (Fast but not reliable)";
            this.rbtnConnectionMethodUDP.UseVisualStyleBackColor = true;
            // 
            // rbtnConnectionMethodTCP
            // 
            this.rbtnConnectionMethodTCP.AutoSize = true;
            this.rbtnConnectionMethodTCP.Location = new System.Drawing.Point(6, 56);
            this.rbtnConnectionMethodTCP.Name = "rbtnConnectionMethodTCP";
            this.rbtnConnectionMethodTCP.Size = new System.Drawing.Size(231, 24);
            this.rbtnConnectionMethodTCP.TabIndex = 1;
            this.rbtnConnectionMethodTCP.Text = "TCP (Reliable but maybe slow)";
            this.rbtnConnectionMethodTCP.UseVisualStyleBackColor = true;
            // 
            // gpbConnectionStatus
            // 
            this.gpbConnectionStatus.Controls.Add(this.checkBox1);
            this.gpbConnectionStatus.Controls.Add(this.lblPing);
            this.gpbConnectionStatus.Controls.Add(this.lblUploadSpeed);
            this.gpbConnectionStatus.Controls.Add(this.lblDownloadSpeed);
            this.gpbConnectionStatus.Controls.Add(this.gpbConnectionStatusRefresh);
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
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(251, 65);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.UseVisualStyleBackColor = true;
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
            // gpbConnectionStatusRefresh
            // 
            this.gpbConnectionStatusRefresh.BackgroundImage = global::RelativeMouseRDP.Properties.Resources.refresh_32px;
            this.gpbConnectionStatusRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gpbConnectionStatusRefresh.Location = new System.Drawing.Point(244, 26);
            this.gpbConnectionStatusRefresh.Name = "gpbConnectionStatusRefresh";
            this.gpbConnectionStatusRefresh.Size = new System.Drawing.Size(32, 32);
            this.gpbConnectionStatusRefresh.TabIndex = 6;
            this.gpbConnectionStatusRefresh.UseVisualStyleBackColor = true;
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
            this.rbtnDevicePositionServer.TabStop = true;
            this.rbtnDevicePositionServer.Text = "Server";
            this.rbtnDevicePositionServer.UseVisualStyleBackColor = true;
            // 
            // rbtnDevicePositionClient
            // 
            this.rbtnDevicePositionClient.AutoSize = true;
            this.rbtnDevicePositionClient.Location = new System.Drawing.Point(6, 26);
            this.rbtnDevicePositionClient.Name = "rbtnDevicePositionClient";
            this.rbtnDevicePositionClient.Size = new System.Drawing.Size(68, 24);
            this.rbtnDevicePositionClient.TabIndex = 0;
            this.rbtnDevicePositionClient.TabStop = true;
            this.rbtnDevicePositionClient.Text = "Client";
            this.rbtnDevicePositionClient.UseVisualStyleBackColor = true;
            // 
            // gpbConnectionSpecifications
            // 
            this.gpbConnectionSpecifications.Controls.Add(this.txtConnectionSpecificationsIP);
            this.gpbConnectionSpecifications.Controls.Add(this.lblConnectionSpecificationsPort);
            this.gpbConnectionSpecifications.Controls.Add(this.txtConnectionSpecificationsPort);
            this.gpbConnectionSpecifications.Controls.Add(this.lblConnectionSpecificationsIP);
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
            this.gpbLog.Size = new System.Drawing.Size(335, 404);
            this.gpbLog.TabIndex = 4;
            this.gpbLog.TabStop = false;
            this.gpbLog.Text = "Log";
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(3, 23);
            this.txtLog.MaxLength = 999999999;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(329, 378);
            this.txtLog.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnChangeStatus);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 422);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(647, 33);
            this.panel1.TabIndex = 5;
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnChangeStatus.Location = new System.Drawing.Point(516, 0);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(94, 29);
            this.btnChangeStatus.TabIndex = 1;
            this.btnChangeStatus.Text = "Change Status";
            this.btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.pictureBox1.Location = new System.Drawing.Point(610, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 29);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status : ";
            // 
            // LogChecker
            // 
            this.LogChecker.Enabled = true;
            this.LogChecker.Interval = 500;
            this.LogChecker.Tick += new System.EventHandler(this.LogChecker_Tick);
            // 
            // frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 455);
            this.Controls.Add(this.panel1);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private Button gpbConnectionStatusRefresh;
        private GroupBox gpbLog;
        private TextBox txtLog;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btnChangeStatus;
        private Label lblUploadSpeed;
        private Label lblDownloadSpeed;
        private Label lblPing;
        private CheckBox checkBox1;
        private TextBox txtConnectionSpecificationsIP;
        private System.Windows.Forms.Timer LogChecker;
    }
}