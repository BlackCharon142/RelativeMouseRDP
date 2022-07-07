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

        private void txtConnectionSpecificationsPort_TextChanged(object sender, EventArgs e)
        {
            if (ConnectionSpecification.ValidatePort(txtConnectionSpecificationsPort.Text))
            {
                SystemSounds.Exclamation.Play();
                txtConnectionSpecificationsPort.Text = "65535";
            }
        }

        private void txtConnectionSpecificationsIP_Leave(object sender, EventArgs e)
        {
            if (!ConnectionSpecification.ValidateIP(txtConnectionSpecificationsIP.Text))
            {
                SystemSounds.Exclamation.Play();
                txtConnectionSpecificationsIP.Text = "";
                txtConnectionSpecificationsIP.Focus();
            }
        }

        #endregion

        #endregion

    }
}
