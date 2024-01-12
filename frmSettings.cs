using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wordle_SDD
{
    public partial class frmSettings : Form
    {
        private frmWordle FrmWordle = new frmWordle();
        public frmSettings()
        {
            InitializeComponent();
        }

        private void chkDarkMode_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDarkMode.Checked == true)
            {
                FrmWordle.darkMode = true;
            }
            else
            {
                FrmWordle.darkMode = false;
            }
            FrmWordle.resetForms();
        }

        private void chkHighContrast_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHighContrast.Checked == true)
            {
                FrmWordle.highContrastMode = true;
            }
            else
            {
                FrmWordle.highContrastMode = false;
            }
            FrmWordle.resetForms();
        }

        private void chkOnScreenKeyboard_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
