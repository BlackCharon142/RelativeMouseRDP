using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RelativeMouseRDP
{
    public partial class frm_Main : Form
    {
        bool showLiveLog = true;

        public frm_Main()
        {
            InitializeComponent();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (EstablishConnection.GetServerStatus())
            {
                EstablishConnection.StopServer();
            }
        }

        #region Validations

        #region Key Presses

        private void txtConnectionSpecificationsIP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && !(e.KeyChar == '.'))
            {
                e.Handled = true;
                SystemSounds.Exclamation.Play();
            }
        }

        private void txtConnectionSpecificationsPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                SystemSounds.Exclamation.Play();
            }
        }

        #endregion

        #region Value Validation

        private void txtConnectionSpecificationsIP_Leave(object sender, EventArgs e)
        {
            if ((txtConnectionSpecificationsIP.Text == "" && EstablishConnection.GetPosition() == Positions.Server) || ConnectionSpecification.ValidateIP(txtConnectionSpecificationsIP.Text))
            {
                if (EstablishConnection.SetConnectionSpecification(txtConnectionSpecificationsIP.Text))
                {
                    Log.Register("IP Set to " + (txtConnectionSpecificationsIP.Text == "" ? "All" : txtConnectionSpecificationsIP.Text));
                }
            }
            else
            {
                if (txtConnectionSpecificationsIP.Text != "" || EstablishConnection.GetPosition() == Positions.Client)
                {
                    SystemSounds.Exclamation.Play();
                    txtConnectionSpecificationsIP.Text = "";
                    return;
                }
            }
        }

        private void txtConnectionSpecificationsPort_Leave(object sender, EventArgs e)
        {
            if (ConnectionSpecification.ValidatePort(txtConnectionSpecificationsPort.Text))
            {
                if (EstablishConnection.SetConnectionSpecification(null, int.Parse(txtConnectionSpecificationsPort.Text)))
                {
                    Log.Register("Port Set to " + txtConnectionSpecificationsPort.Text);
                }
            }
            else
            {
                if (txtConnectionSpecificationsPort.Text != "")
                {
                    SystemSounds.Exclamation.Play();
                    txtConnectionSpecificationsPort.Text = "";
                    return;
                }
            }
        }

        #endregion

        #endregion

        #region Timers

        private void LogChecker_Tick(object sender, EventArgs e)
        {
            if (showLiveLog)
            {
                if (txtLog.Text != Log.ReadCurrentLog())
                    txtLog.Text = Log.ReadCurrentLog();

                txtLog.SelectionStart = txtLog.Text.Length;
                txtLog.ScrollToCaret();
            }
        }

        private void UpdateStaus_Tick(object sender, EventArgs e)
        {
            string defaultStatusText = "Status : ";
            lblStatus.Text = defaultStatusText + (EstablishConnection.GetServerStatus() ? "Online" : "Offline");

            ChangeVisualStatus(EstablishConnection.GetServerStatus());

            toolTip.SetToolTip(pbVisualStatus, lblStatus.Text);

            btnChangeStatus.Text = (EstablishConnection.GetServerStatus() ? "Stop" : "Start");
        }

        #endregion

        #region Set Device Position

        private void rbtnDevicePositionClient_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDevicePositionClient.Checked)
            {
                if (EstablishConnection.SetPosition(Positions.Client))
                {
                    gpbConnectionSpecifications.Enabled = true;
                    Log.Register("Device Position Set to " + rbtnDevicePositionClient.Text);
                }
            }
        }

        private void rbtnDevicePositionServer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDevicePositionServer.Checked)
            {
                if (EstablishConnection.SetPosition(Positions.Server))
                {
                    gpbConnectionSpecifications.Enabled = true;
                    Log.Register("Device Position Set to " + rbtnDevicePositionServer.Text);
                }
            }
        }

        #endregion

        #region Set Connection Method

        private void rbtnConnectionMethodAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConnectionMethodAutomatic.Checked)
                Log.Register("Connection Method Set to " + rbtnConnectionMethodAutomatic.Text + "(Work in Progress)");
        }

        private void rbtnConnectionMethodTCP_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConnectionMethodTCP.Checked)
            {
                if (EstablishConnection.SetConnectionMethod(ConnectionMethods.TCP))
                {
                    Log.Register("Connection Method Set to " + rbtnConnectionMethodTCP.Text);
                }
            }
        }

        private void rbtnConnectionMethodUDP_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConnectionMethodUDP.Checked)
            {
                if (EstablishConnection.SetConnectionMethod(ConnectionMethods.UDP))
                {
                    Log.Register("Connection Method Set to " + rbtnConnectionMethodUDP.Text);
                }
            }
        }

        #endregion

        #region Get Connection Status

        private void btnConnectionStatusRefresh_Click(object sender, EventArgs e)
        {
            Log.Register("Connection Status Update Requested");
        }

        private void chbConnectionStatusRefreshConstantly_CheckedChanged(object sender, EventArgs e)
        {
            if (chbConnectionStatusRefreshConstantly.Checked)
                Log.Register("Connection Status Live Update Enabled");
            else
                Log.Register("Connection Status Live Update Disabled");

            btnConnectionStatusRefresh.Enabled = !chbConnectionStatusRefreshConstantly.Checked;
        }

        #endregion

        #region Set Log Status

        private void txtLog_DoubleClick(object sender, EventArgs e)
        {
            showLiveLog = !showLiveLog;
            txtLog.BackColor = txtLog.BackColor;
            txtLog.ForeColor = txtLog.ForeColor == SystemColors.GrayText ? SystemColors.WindowText : SystemColors.GrayText;
        }

        #endregion

        #region Set Status Bar

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            EstablishConnection.ChangeServerStatus();
        }

        private void ChangeVisualStatus(bool status)
        {
            if (status)
            {
                pbVisualStatus.Refresh();
                Graphics g = pbVisualStatus.CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.DrawEllipse(new Pen(Color.FromArgb(21, 224, 91), 4), (pbVisualStatus.Width / 4), (pbVisualStatus.Height / 4), pbVisualStatus.Width / 2, pbVisualStatus.Height / 2);
            }
            else
            {
                pbVisualStatus.Refresh();
                Graphics g = pbVisualStatus.CreateGraphics();
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                g.DrawEllipse(new Pen(Brushes.Red, 4), (pbVisualStatus.Width / 4), (pbVisualStatus.Height / 4), pbVisualStatus.Width / 2, pbVisualStatus.Height / 2);
            }
        }

        #endregion
    }
}
