using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wordle_SDD.Properties;

namespace Wordle_SDD
{
    public partial class frmWordle : Form
    {
        //Declares the local variables for all of the public
        //booleans and colours, signifys the local variant with an '_' prefix
        private Color _baseColour = Color.FromArgb(20, 20, 20);
        private Color _alternateColour = Color.FromArgb(75, 75, 75);
        private Color _textColour = Color.White;
        private bool _darkMode = true;
        private bool _highContrastMode = false;
        private bool _onScreenKeyboard = true;
        //Declares the local only variables
        private string input;
        //Publicly declares all universal variables,
        //with their initial values set to the local variant
        public Color baseColour
        {
            get { return _baseColour; }
            set { _baseColour = value; }
        }
        public Color alternateColour
        {
            get { return _alternateColour; }
            set { _alternateColour = value; }
        }
        public Color textColour
        {
            get { return _textColour; }
            set { _textColour = value; }
        }
        public bool darkMode
        {
            get { return _darkMode; }
            set { _darkMode = value; }
        }
        public bool highContrastMode
        {
            get { return _highContrastMode; }
            set { _highContrastMode = value; }
        }
        public bool onScreenKeyboard
        {
            get { return _onScreenKeyboard; }
            set { _onScreenKeyboard = value; }
        }

        public frmWordle()
        {
            InitializeComponent();
            //Attaches any physical keypresses to the event handler
            //KeyPreview enables key presses to be interpretted at
            //the form level, enabling the use of btn?.performClick,
            //unifying the two keyboards under the same code
            this.KeyDown += frmWordle_KeyDown;
            this.KeyPreview = true;
            //Attaches all of the onscreen keys to
            //the event handler 'KeyboardInput'
            btnA.Click += KeyboardInput;
            btnB.Click += KeyboardInput;
            btnC.Click += KeyboardInput;
            btnD.Click += KeyboardInput;
            btnE.Click += KeyboardInput;
            btnF.Click += KeyboardInput;
            btnG.Click += KeyboardInput;
            btnH.Click += KeyboardInput;
            btnI.Click += KeyboardInput;
            btnJ.Click += KeyboardInput;
            btnK.Click += KeyboardInput;
            btnL.Click += KeyboardInput;
            btnM.Click += KeyboardInput;
            btnN.Click += KeyboardInput;
            btnO.Click += KeyboardInput;
            btnP.Click += KeyboardInput;
            btnQ.Click += KeyboardInput;
            btnR.Click += KeyboardInput;
            btnS.Click += KeyboardInput;
            btnT.Click += KeyboardInput;
            btnU.Click += KeyboardInput;
            btnV.Click += KeyboardInput;
            btnW.Click += KeyboardInput;
            btnX.Click += KeyboardInput;
            btnY.Click += KeyboardInput;
            btnZ.Click += KeyboardInput;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            //Creates a new instance of the settings form and attaches the
            //current form as an instance for reference in the new settings form
            Form frmSettings = new frmSettings(this);
            frmSettings.Show();

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Creates a new instance of the help form and attaches the
            //current form as an instance for reference in the new help form
            Form frmHelp = new frmHelp();
            frmHelp.Show();
        }


        public void redrawWordleForm()
        {
            
            this.BackColor = baseColour;
            lblTitle.ForeColor = textColour;
            btnHelp.ForeColor = baseColour;
            btnSettings.ForeColor = baseColour;
            if (darkMode == true)
            {
                btnHelp.BackgroundImage = Resources.imgHelpIconLight;
                btnSettings.BackgroundImage = Resources.imgSettingsIconLight;
            }
            else
            {
                btnHelp.BackgroundImage = Resources.imgHelpIconDark;
                btnSettings.BackgroundImage = Resources.imgSettingsIconDark;
            }
        }
        private void KeyboardInput(object sender, EventArgs e)
        {
            //Declares clickedButton as the button triggering the event handler
            if (sender is Button clickedButton)
            {
                //Access the button clicked and identifies its letter
                //through its text value, returning the corresponding uppercase
                //letter ('A', 'B', etc)
                input = clickedButton.Text;
                //Error handling for when needing to test physical and
                //onscreen keyboard inputs
                //  MessageBox.Show(input);
            }
        }

        private void frmWordle_KeyDown(object sender, KeyEventArgs e)
        {
            //Switchcase for what keycode has been physically pressed
            //simulates a digital click of one of the onscreen buttons
            //to remove repetitions and more variables
            switch (e.KeyCode)
            {
                case Keys.A:
                    btnA.PerformClick();
                    break;
                case Keys.B:
                    btnB.PerformClick();
                    break;
                case Keys.C:
                    btnC.PerformClick();
                    break;
                case Keys.D:
                    btnD.PerformClick();
                    break;
                case Keys.E:
                    btnE.PerformClick();
                    break;
                case Keys.F:
                    btnF.PerformClick();
                    break;
                case Keys.G:
                    btnG.PerformClick();
                    break;
                case Keys.H:
                    btnH.PerformClick();
                    break;
                case Keys.I:
                    btnI.PerformClick();
                    break;
                case Keys.J:
                    btnJ.PerformClick();
                    break;
                case Keys.K:
                    btnK.PerformClick();
                    break;
                case Keys.L:
                    btnL.PerformClick();
                    break;
                case Keys.M:
                    btnM.PerformClick();
                    break;
                case Keys.N:
                    btnN.PerformClick();
                    break;
                case Keys.O:
                    btnO.PerformClick();
                    break;
                case Keys.P:
                    btnP.PerformClick();
                    break;
                case Keys.Q:
                    btnQ.PerformClick();
                    break;
                case Keys.R:
                    btnR.PerformClick();
                    break;
                case Keys.S:
                    btnS.PerformClick();
                    break;
                case Keys.T:
                    btnT.PerformClick();
                    break;
                case Keys.U:
                    btnU.PerformClick();
                    break;
                case Keys.V:
                    btnV.PerformClick();
                    break;
                case Keys.W:
                    btnW.PerformClick();
                    break;
                case Keys.X:
                    btnX.PerformClick();
                    break;
                case Keys.Y:
                    btnY.PerformClick();
                    break;
                case Keys.Z:
                    btnZ.PerformClick();
                    break;
            }
        }
    }
}
