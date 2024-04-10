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
        //Creates FrmWordle instance to refer to variables on that form
        private frmWordle FrmWordle = new frmWordle();
        //Accepts the instance of frmWordle assigned
        //to this form when it was instantiated
        public frmSettings(frmWordle frmWordleInstance)
        {
            //Constructs form
            InitializeComponent();
            //Makes the new instance of the wordle form equal
            //to the one already on screen, enabling us to actively edit
            //variables and invoke methods to instantly perform the
            //necessary visual augments
            FrmWordle = frmWordleInstance;
            if (FrmWordle.darkMode == true )
            {
                chkDarkMode.Checked = true;
            }
            else 
            { 
                chkDarkMode.Checked = false; 
            }

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
            if (FrmWordle.darkMode == true)
            {
                btnClose.BackgroundImage = Resources.imgCrossIconLight;

            }
            else
            {
                btnClose.BackgroundImage = Resources.imgCrossIconDark;
            }
            this.BackColor = FrmWordle.baseColour;
            btnClose.ForeColor = FrmWordle.baseColour;

            chkDarkMode.ForeColor = FrmWordle.textColour;
            chkHighContrast.ForeColor = FrmWordle.textColour;
            chkOnScreenKeyboard.ForeColor = FrmWordle.textColour;
            lblGraphicsTitle.ForeColor = FrmWordle.textColour;
            FrmWordle.redrawFormsDarkMode();
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
