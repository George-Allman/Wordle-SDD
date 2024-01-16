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
                FrmWordle.alternateColour = Color.FromArgb(75, 75, 75);
                FrmWordle.baseColour = Color.FromArgb(20, 20, 20);
                FrmWordle.textColour = Color.White;
            }
            else
            {
                FrmWordle.darkMode = false;
                FrmWordle.alternateColour = Color.FromArgb(200, 200, 200);
                FrmWordle.baseColour = Color.FromArgb(245, 245, 245);
                FrmWordle.textColour = Color.Black;
            }
            FrmWordle.redrawForms();
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
            FrmWordle.redrawForms();
        }

        private void chkOnScreenKeyboard_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
