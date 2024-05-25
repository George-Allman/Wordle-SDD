using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wordle_SDD.Properties;

namespace Wordle_SDD
{
    public partial class frmHelp : Form
    {
        public Color baseColour = Color.FromArgb(20, 20, 20);
        public Color alternateColour = Color.FromArgb(75, 75, 75);
        public Color tertiaryColour = Color.DimGray;
        public Color correctColour = Color.FromArgb(83, 141, 78);
        public Color partialColour = Color.FromArgb(181, 159, 59);
        public Color textColour = Color.White;

        private SoundPlayer soundPlayer = new SoundPlayer(Resources.audioHelpMenuVoiceOver);

        private bool _darkMode = true;
        private bool _highContrastMode = false;
        public bool darkMode
        {
            get { return _darkMode; }
            set
            {
                _darkMode = value;

                this.BackColor = baseColour;

                for (int i = 0; i <= 40; i++)
                {
                    string selectedLetterBox = $"exampleLB{i}";

                    //Searches through all controls on the page
                    foreach (Control control in Controls)
                    {
                        //Runs code once the letterBox that matches the string defined earlier
                        //is found and allows us to use the simple LetterBox name to augment it
                        if (control.Name == selectedLetterBox && control is letterBox letterBox)
                        {
                            //Checks whether the letterBox has already been filled with a letter in
                            //the correct spot (status = 2), thus changing the shade of green to lighter/darker
                            if (letterBox.status == 2)
                            {
                                letterBox.baseColour = correctColour;
                                letterBox.alternateColour = correctColour;
                            }
                            //Checks whether the letterBox has already been filled with a letter in a
                            //partially correct spot (status = 1), thus changing the shade of yellow to lighter/darker
                            else if (letterBox.status == 1)
                            {
                                letterBox.baseColour = partialColour;
                                letterBox.alternateColour = partialColour;
                            }
                            //Checks whether the letterBox has already been filled with a letter in the
                            //incorrect spot (status = 0), thus changing the full colour grey to the lighter/darker
                            else if (letterBox.status == 0)
                            {
                                letterBox.baseColour = alternateColour;
                                letterBox.alternateColour = alternateColour;
                            }
                            //If all other checks have failed the letterbox must not have had a letter entered
                            //into it, thus the colour changes retain the border and the correct text colour
                            else
                            {
                                letterBox.baseColour = baseColour;
                                letterBox.alternateColour = alternateColour;
                                letterBox.textColour = textColour;
                            }
                        }

                        //Runs code when this pass of the search is a label, so all labels receive the same code
                        if (control is Label label)
                        {
                            //Changes the text colour of the label to the appropriate white or black
                            label.ForeColor = textColour;
                        }
                    }
                }

                //Changes the border colour to the correct light/dark for both buttons
                btnClose.ForeColor = baseColour;
                btnVoiceOver.ForeColor = baseColour;

                //Changes the two buttons image to the appropriate light/dark variant
                if (darkMode == true)
                {
                    btnClose.BackgroundImage = Resources.imgCrossIconLight;
                    btnVoiceOver.BackgroundImage = Resources.imgSpeakerDark;
                }
                else
                {
                    btnClose.BackgroundImage = Resources.imgCrossIconDark;
                    btnVoiceOver.BackgroundImage = Resources.imgSpeakerLight;
                }
            }
        }
        public bool highContrastMode
        {
            get { return _highContrastMode; }
            set
            {
                _highContrastMode = value;

                if (highContrastMode == true)
                {
                    correctColour = Colours.highContrastCorrectColour;
                    partialColour = Colours.highContrastPartialColour;
                }
                else if (darkMode == true)
                {
                    correctColour = Colours.darkCorrectColour;
                    partialColour = Colours.darkPartialColour;
                }
                else
                {
                    correctColour = Colours.lightCorrectColour;
                    partialColour = Colours.lightPartialColour;
                }
                //Searches through all controls on the page
                foreach (Control control in Controls)
                {
                    //Calls code only when this iterations control is a letterBox
                    if (control is letterBox letterBox)
                    {
                        //Checks whether the letterBox has already been filled with a letter in
                        //the correct spot (status = 2), thus changing the shade of green to lighter/darker
                        if (letterBox.status == 2)
                        {
                            letterBox.baseColour = correctColour;
                            letterBox.alternateColour = correctColour;
                        }
                        //Checks whether the letterBox has already been filled with a letter in a
                        //partially correct spot (status = 1), thus changing the shade of yellow to lighter/darker
                        else if (letterBox.status == 1)
                        {
                            letterBox.baseColour = partialColour;
                            letterBox.alternateColour = partialColour;
                        }
                        //Checks whether the letterBox has already been filled with a letter in the
                        //incorrect spot (status = 0), thus changing the full colour grey to the lighter/darker
                        else if (letterBox.status == 0)
                        {
                            letterBox.baseColour = alternateColour;
                            letterBox.alternateColour = alternateColour;
                        }
                        //If all other checks have failed the letterbox must not have had a letter entered
                        //into it, thus the colour changes retain the border and the correct text colour
                        else
                        {
                            letterBox.baseColour = baseColour;
                            letterBox.alternateColour = alternateColour;
                            letterBox.textColour = textColour;
                        }
                    }
                }
            }
        }
                
        public frmHelp()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            soundPlayer.Stop();
            this.Hide();
        }

        private void btnVoiceOver_Click(object sender, EventArgs e)
        {
            soundPlayer.Play();
        }
    }
}
