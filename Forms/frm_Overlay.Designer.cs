namespace RelativeMouseRDP
{
    partial class frm_Overlay
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
            this.cmsFunctions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiSendMenuShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSendCtrlAltDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDisableOverlay = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHideCursor = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGameMode = new System.Windows.Forms.ToolStripMenuItem();
            this.pbRecordingIndicator = new System.Windows.Forms.PictureBox();
            this.RecorderCheck = new System.Windows.Forms.Timer(this.components);
            this.cmsFunctions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbRecordingIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsFunctions
            // 
            this.cmsFunctions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsFunctions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSendMenuShortcut,
            this.tsmiSendCtrlAltDelete,
            this.tss1,
            this.tsmiDisableOverlay,
            this.tsmiHideCursor,
            this.tsmiGameMode});
            this.cmsFunctions.Name = "cmsFunctions";
            this.cmsFunctions.Size = new System.Drawing.Size(242, 140);
            this.cmsFunctions.Opening += new System.ComponentModel.CancelEventHandler(this.cmsFunctions_Opening);
            // 
            // tsmiSendMenuShortcut
            // 
            this.tsmiSendMenuShortcut.Image = global::RelativeMouseRDP.Properties.Resources.enter_mac_key_48px;
            this.tsmiSendMenuShortcut.Name = "tsmiSendMenuShortcut";
            this.tsmiSendMenuShortcut.Size = new System.Drawing.Size(241, 26);
            this.tsmiSendMenuShortcut.Text = "Send ";
            this.tsmiSendMenuShortcut.Click += new System.EventHandler(this.tsmiSendMenuShortcut_Click);
            // 
            // tsmiSendCtrlAltDelete
            // 
            this.tsmiSendCtrlAltDelete.Image = global::RelativeMouseRDP.Properties.Resources.Bullet_List_60px;
            this.tsmiSendCtrlAltDelete.Name = "tsmiSendCtrlAltDelete";
            this.tsmiSendCtrlAltDelete.Size = new System.Drawing.Size(241, 26);
            this.tsmiSendCtrlAltDelete.Text = "Send Ctrl + Alt + Delete";
            this.tsmiSendCtrlAltDelete.Click += new System.EventHandler(this.tsmiSendCtrlAltDelete_Click);
            // 
            // tss1
            // 
            this.tss1.Name = "tss1";
            this.tss1.Size = new System.Drawing.Size(238, 6);
            // 
            // tsmiDisableOverlay
            // 
            this.tsmiDisableOverlay.CheckOnClick = true;
            this.tsmiDisableOverlay.Image = global::RelativeMouseRDP.Properties.Resources.hide_48px;
            this.tsmiDisableOverlay.Name = "tsmiDisableOverlay";
            this.tsmiDisableOverlay.Size = new System.Drawing.Size(241, 26);
            this.tsmiDisableOverlay.Text = "Disable Overlay";
            this.tsmiDisableOverlay.Click += new System.EventHandler(this.tsmiDisableOverlay_Click);
            // 
            // tsmiHideCursor
            // 
            this.tsmiHideCursor.CheckOnClick = true;
            this.tsmiHideCursor.Image = global::RelativeMouseRDP.Properties.Resources.cursor_48px;
            this.tsmiHideCursor.Name = "tsmiHideCursor";
            this.tsmiHideCursor.Size = new System.Drawing.Size(241, 26);
            this.tsmiHideCursor.Text = "Hide Cursor";
            this.tsmiHideCursor.Click += new System.EventHandler(this.tsmiHideCursor_Click);
            // 
            // tsmiGameMode
            // 
            this.tsmiGameMode.CheckOnClick = true;
            this.tsmiGameMode.Image = global::RelativeMouseRDP.Properties.Resources.game_controller_96px;
            this.tsmiGameMode.Name = "tsmiGameMode";
            this.tsmiGameMode.Size = new System.Drawing.Size(241, 26);
            this.tsmiGameMode.Text = "Game Mode";
            // 
            // pbRecordingIndicator
            // 
            this.pbRecordingIndicator.Location = new System.Drawing.Point(12, 12);
            this.pbRecordingIndicator.Name = "pbRecordingIndicator";
            this.pbRecordingIndicator.Size = new System.Drawing.Size(30, 30);
            this.pbRecordingIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbRecordingIndicator.TabIndex = 1;
            this.pbRecordingIndicator.TabStop = false;
            // 
            // RecorderCheck
            // 
            this.RecorderCheck.Enabled = true;
            this.RecorderCheck.Interval = 1;
            this.RecorderCheck.Tick += new System.EventHandler(this.RecorderCheck_Tick);
            // 
            // frm_Overlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.Controls.Add(this.pbRecordingIndicator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frm_Overlay";
            this.ShowInTaskbar = false;
            this.Text = "Overlay";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.AliceBlue;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Overlay_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_Overlay_MouseDown);
            this.MouseEnter += new System.EventHandler(this.frm_Overlay_MouseEnter);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frm_Overlay_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frm_Overlay_MouseUp);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.frm_Overlay_MouseWheel);
            this.cmsFunctions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbRecordingIndicator)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ContextMenuStrip cmsFunctions;
        private ToolStripMenuItem tsmiDisableOverlay;
        private ToolStripMenuItem tsmiHideCursor;
        private ToolStripMenuItem tsmiSendMenuShortcut;
        private PictureBox pbRecordingIndicator;
        private System.Windows.Forms.Timer RecorderCheck;
        private ToolStripMenuItem tsmiGameMode;
        private ToolStripSeparator tss1;
        private ToolStripMenuItem tsmiSendCtrlAltDelete;
    }
}