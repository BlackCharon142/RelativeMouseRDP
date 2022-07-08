using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public frm_Main()
        {
            InitializeComponent();
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
            if (ConnectionSpecification.ValidateIP(txtConnectionSpecificationsIP.Text))
                Log.Register("IP Set to " + txtConnectionSpecificationsIP.Text);
            else
            {
                if (txtConnectionSpecificationsIP.Text != "")
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
                Log.Register("Port Set to " + txtConnectionSpecificationsPort.Text);
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
            txtLog.Text = Log.ReadCurrentLog();
        }

        private void UpdateStaus_Tick(object sender, EventArgs e)
        {
            toolTip.SetToolTip(pbVisualStatus, lblStatus.Text);
        }

        #endregion

        #region Set Device Position

        private void rbtnDevicePositionClient_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDevicePositionClient.Checked)
                Log.Register("Device Position Set to " + rbtnDevicePositionClient.Text);
        }

        private void rbtnDevicePositionServer_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnDevicePositionServer.Checked)
                Log.Register("Device Position Set to " + rbtnDevicePositionServer.Text);
        }

        #endregion

        #region Set Connection Method

        private void rbtnConnectionMethodAutomatic_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConnectionMethodAutomatic.Checked)
                Log.Register("Connection Method Set to " + rbtnConnectionMethodAutomatic.Text);
        }

        private void rbtnConnectionMethodTCP_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConnectionMethodTCP.Checked)
                Log.Register("Connection Method Set to " + rbtnConnectionMethodTCP.Text);
        }

        private void rbtnConnectionMethodUDP_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnConnectionMethodUDP.Checked)
                Log.Register("Connection Method Set to " + rbtnConnectionMethodUDP.Text);
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

        #region Set Status Bar

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            Log.Register("Changing Status Started...");
        }

        #endregion

    }
}
