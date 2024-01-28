using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wordle_SDD.Properties;

namespace Wordle_SDD
{
    public partial class frmSettings : Form
    {
        private frmWordle FrmWordle = new frmWordle();
        public frmSettings(frmWordle frmWordleInstance)
        {
            InitializeComponent();
            FrmWordle = frmWordleInstance;
            drawSettingsForm();
            if (FrmWordle.darkMode == true )
            {
                chkDarkMode.Checked = true;
            }
            else 
            { 
                chkDarkMode.Checked = false; 
            }

        }

        private void drawSettingsForm()
        {
            this.BackColor = FrmWordle.baseColour;
            btnClose.ForeColor = FrmWordle.baseColour;
            if (FrmWordle.darkMode == true)
            {
                btnClose.BackgroundImage = Resources.imgCrossIconLight;

            }
            else
            {
                btnClose.BackgroundImage = Resources.imgCrossIconDark;
            }
            chkDarkMode.ForeColor = FrmWordle.textColour;
            chkHighContrast.ForeColor = FrmWordle.textColour;
            chkOnScreenKeyboard.ForeColor = FrmWordle.textColour;
            lblGraphicsTitle.ForeColor = FrmWordle.textColour;

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
            drawSettingsForm();
            FrmWordle.redrawWordleForm();
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
            drawSettingsForm();
            FrmWordle.redrawWordleForm();
        }

        private void chkOnScreenKeyboard_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
