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
                Log.Append("IP Changed to " + txtConnectionSpecificationsIP.Text);
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
                Log.Append("Port Changed to " + txtConnectionSpecificationsPort.Text);
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

        #endregion
    }
}
