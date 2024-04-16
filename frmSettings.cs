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
        private Color lightBaseColour = Color.FromArgb(245, 245, 245);
        private Color darkBaseColour = Color.FromArgb(20, 20, 20);
        private Color lightAlternateColour = Color.FromArgb(150,150,150);
        private Color darkAlternateColour = Color.FromArgb(75, 75, 75);
        private Color lightTertiaryColour = Color.FromArgb(200, 200, 200);
        private Color darkTertiaryColour = Color.DimGray;
        private Color lightTextColour = Color.Black;
        private Color darkTextColour = Color.White;
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
                FrmWordle.baseColour = darkBaseColour;
                FrmWordle.alternateColour = darkAlternateColour;
                FrmWordle.tertiaryColour = darkTertiaryColour;
                FrmWordle.textColour = darkTextColour;
                FrmWordle.darkMode = true;
            }
            else
            {
                FrmWordle.baseColour = lightBaseColour;
                FrmWordle.alternateColour = lightAlternateColour;
                FrmWordle.tertiaryColour = lightTertiaryColour;
                FrmWordle.textColour = lightTextColour;
                FrmWordle.darkMode = false;
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
            //FrmWordle.redrawFormsDarkMode();
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
