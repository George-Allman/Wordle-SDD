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
        private frmHelp FrmHelp = new frmHelp();
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
                FrmWordle.baseColour = Colours.darkBaseColour;
                FrmWordle.alternateColour = Colours.darkAlternateColour;
                FrmWordle.tertiaryColour = Colours.darkTertiaryColour;
                FrmWordle.correctColour = Colours.darkCorrectColour;
                FrmWordle.partialColour = Colours.darkPartialColour;
                FrmWordle.textColour = Colours.darkTextColour;
                FrmWordle.darkMode = true;
                
            }
            else
            {
                FrmWordle.baseColour = Colours.lightBaseColour;
                FrmWordle.alternateColour = Colours.lightAlternateColour;
                FrmWordle.tertiaryColour = Colours.lightTertiaryColour;
                FrmWordle.correctColour = Colours.lightCorrectColour;
                FrmWordle.partialColour = Colours.lightPartialColour;
                FrmWordle.textColour = Colours.lightTextColour;
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
