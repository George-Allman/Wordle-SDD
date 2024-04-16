using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        private Color _tertiaryColour = Color.DimGray;
        private Color _correctColour = Color.FromArgb(83, 141, 78);
        private Color _partialColour = Color.FromArgb(181, 159, 59);

        private Color _textColour = Color.White;
        private bool _darkMode = true;
        private bool _highContrastMode = false;
        private bool _onScreenKeyboard = true;
        private int currentRow = 0;
        private int currentColumn = 0;
        private char[,] letterGrid = new char[5, 6];

        private char[] correctWordArray = new char[4];
        private string correctWord = "";

        private char[] currentWordArray = new char[4];
        private string currentWord = "";

        private int[] resultArray = new int[5];
        private int numberCorrectLetters = 0;
        private int animationLength = 2;

        private string[] allWords; 

        private Color lightCorrectColour = Color.FromArgb(106, 170, 100);
        private Color darkCorrectColour = Color.FromArgb(83, 141, 78);

        private Color lightPartialColour = Color.FromArgb(201, 180, 88);
        private Color darkPartialColour = Color.FromArgb(181, 159, 59);

        private Color lightAlternateColour = Color.FromArgb(150, 150, 150);
        private Color darkAlternateColour = Color.FromArgb(75, 75, 75);

        private Color lightTextColour = Color.Black;
        private Color darkTextColour = Color.White;

        //Declares the local only variables
        private string input;
        //Publicly declares all universal variables,
        //with their initial values set to the local variant
        public Color baseColour
        {
            get { return _baseColour; }
            set { _baseColour = value;}
        }
        public Color alternateColour
        {
            get { return _alternateColour; }
            set { _alternateColour = value;}
        }
        public Color tertiaryColour
        {
            get { return _tertiaryColour; }
            set { _tertiaryColour = value; }
        }

        public Color textColour
        {
            get { return _textColour; }
            set { _textColour = value;}
        }
        public Color correctColour
        {
            get { return _correctColour; }
            set { _correctColour = value; }
        }
        public Color partialColour
        {
            get { return _partialColour; }
            set { _partialColour = value; }
        }

        public bool darkMode
        {
            get { return _darkMode; }
            set { 
                _darkMode = value;
                btnHelp.ForeColor = baseColour;
                btnSettings.ForeColor = baseColour;
                this.BackColor = baseColour;
                lblTitle.ForeColor = textColour;
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
                for (int i = 0; i <= 4; i++)
                {
                    for (int j = 0; j <= 5; j++)
                    {
                        string selectedLetterBox = $"letterBox{i:D1}{j:D1}";
                        foreach (Control control in Controls)
                        {
                            if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
                            {
                                if (letterBox.baseColour == lightCorrectColour || letterBox.baseColour == darkCorrectColour)
                                {
                                    letterBox.baseColour = correctColour;
                                    letterBox.alternateColour = correctColour;
                                }
                                else if (letterBox.baseColour == lightPartialColour || letterBox.baseColour == darkPartialColour)
                                {
                                    letterBox.baseColour = partialColour;
                                    letterBox.alternateColour = partialColour;
                                }
                                else if (letterBox.baseColour == lightAlternateColour || letterBox.baseColour == darkAlternateColour)
                                {
                                    letterBox.baseColour = alternateColour;
                                    letterBox.alternateColour = alternateColour;
                                }
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
                foreach (Control control in Controls)
                {
                    if (control is Button button) // Assuming letterboxes are TextBox controls
                    {
                        if (button.Name.StartsWith("btn") &&
                           (button.Name.Length == 4 || // Single character buttons (btnA to btnZ)
                            button.Name == "btnEnter" || // Special buttons
                            button.Name == "btnDelete")) // Special buttons
                        {
                            if (button.BackColor == lightCorrectColour || button.BackColor == darkCorrectColour)
                            {
                                button.BackColor = correctColour;
                                button.ForeColor = darkTextColour;
                            }
                            else if (button.BackColor == lightPartialColour || button.BackColor == darkPartialColour)
                            {
                                button.BackColor = partialColour;
                                button.ForeColor = darkTextColour;
                            }
                            else if (button.BackColor == lightAlternateColour || button.BackColor == darkAlternateColour)
                            {
                                button.BackColor = alternateColour;
                                button.ForeColor = darkTextColour;
                            }
                            else
                            {
                                button.BackColor = tertiaryColour;
                                button.ForeColor = textColour;
                            }
                            button.FlatAppearance.BorderColor = alternateColour;
                            
                        }
                    }
                }
            }
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
            btnEnter.Click += KeyboardInput;
            btnDelete.Click += KeyboardInput;
            this.ForeColor = Color.White;
            allWords = Properties.Resources.wordList.Split(',');
            correctWord = generateCorrectWord();
            Console.WriteLine(allWords);
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
                if (input != "Enter" && input != "Delete" && currentColumn < 5 && currentRow < 6)
                {
                    appendLetter(input);
                }
                else if (input == "Delete" && currentColumn > 0)
                {
                    deleteLetter();
                }
                else if (input == "Enter" && currentColumn == 5)
                {
                    enterWord();
                }
            }
        }
       
        private async void keyPressAnimation(int col, int row)
        {
            string selectedLetterBox = $"letterBox{col:D1}{row:D1}";
            foreach (Control control in Controls)
            {
                if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
                {
                    for (int i = 0; i <= animationLength; i++)
                    {
                        letterBox.Size = new Size(
                            letterBox.Size.Width+2, 
                            letterBox.Size.Height+2
                            );
                        letterBox.Location = new Point(
                            letterBox.Location.X-1, 
                            letterBox.Location.Y-1
                            );
                        await Task.Delay(1);
                    }

                    for (int i = 0; i <= animationLength; i++)
                    {
                        letterBox.Size = new Size(
                        letterBox.Size.Width - 2,
                        letterBox.Size.Height - 2
                             );
                        letterBox.Location = new Point(
                            letterBox.Location.X + 1,
                            letterBox.Location.Y + 1
                            );
                        await Task.Delay(1);
                    }
                }
            }
        }

        private async void correctWordAnimation(int row)
        {
            for (int i = 0; i <= 5; i++)
            {
                string selectedLetterBox = $"letterBox{i:D1}{row:D1}";
                foreach (Control control in Controls)
                {
                    if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
                    {
                        letterBox.baseColour = correctColour;
                        letterBox.alternateColour = correctColour;
                        letterBox.textColour = Color.White;
                        char[] currentWordArray = currentWord.ToCharArray();
                        colourButton(currentWordArray[i], correctColour);
                        for (int j = 0; j <= animationLength * 3; j++)
                        {
                            letterBox.Location = new Point(
                                letterBox.Location.X,
                                letterBox.Location.Y - 2
                                );
                            await Task.Delay(1);
                        }
                        for (int j = 0; j <= animationLength * 3; j++)
                        {
                            letterBox.Location = new Point(
                                letterBox.Location.X,
                                letterBox.Location.Y + 2
                                );
                            await Task.Delay(1);
                        }
                    }
                }
            }
        }

        private async void enteredWordAnimation(int col, int row)
        {
            string selectedLetterBox = $"letterBox{col:D1}{row:D1}";
            foreach (Control control in Controls)
            {
                if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
                {
                    for (int i = 0; i <= animationLength; i++)
                    {
                        letterBox.Size = new Size(
                            letterBox.Size.Width + 2,
                            letterBox.Size.Height + 2
                            );
                        letterBox.Location = new Point(
                            letterBox.Location.X - 1,
                            letterBox.Location.Y - 1
                            );
                        await Task.Delay(1);
                    }

                    for (int i = 0; i <= animationLength; i++)
                    {
                        letterBox.Size = new Size(
                        letterBox.Size.Width - 2,
                        letterBox.Size.Height - 2
                             );
                        letterBox.Location = new Point(
                            letterBox.Location.X + 1,
                            letterBox.Location.Y + 1
                            );
                        await Task.Delay(1);
                    }
                }
            }    
        }

        private async void invalidWordAnimation(int col, int row)
        {
            string selectedLetterBox = $"letterBox{col:D1}{row:D1}";
            foreach (Control control in Controls)
            {
                if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
                {
                    for (int i = 0; i <= animationLength; i++)
                    {
                        letterBox.Location = new Point(
                            letterBox.Location.X - 1,
                            letterBox.Location.Y
                            );
                        await Task.Delay(1);
                    }

                    for (int i = 0; i <= animationLength; i++)
                    {
                        letterBox.Location = new Point(
                            letterBox.Location.X + 2,
                            letterBox.Location.Y
                            );
                        await Task.Delay(1);
                    }
                    for (int i = 0; i <= animationLength; i++)
                    {
                        letterBox.Location = new Point(
                            letterBox.Location.X - 1,
                            letterBox.Location.Y
                            );
                        await Task.Delay(1);
                    }
                }
            }
        }

        private void appendLetter(string input)
        {
            letterGrid[currentColumn, currentRow] = Convert.ToChar(input);
            string selectedLetterBox = $"letterBox{currentColumn:D1}{currentRow:D1}";
            // Iterate through the Controls collection to find the desired letterbox
            foreach (Control control in Controls)
            {
                if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
                {
                    letterBox.letter = input;
                    break; // Exit the loop once the letterbox is found and updated
                }
            }
            keyPressAnimation(currentColumn, currentRow);
            currentColumn++;
        }

        private void deleteLetter()
        {
            letterGrid[currentColumn - 1, currentRow] = Convert.ToChar(" ");
            string selectedLetterBox = $"letterBox{currentColumn - 1:D1}{currentRow:D1}";
            foreach (Control control in Controls)
            {
                if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
                {
                    letterBox.letter = "";
                    break; // Exit the loop once the letterbox is found and updated
                }
            }
            keyPressAnimation(currentColumn - 1, currentRow);
            currentColumn--;
        }

        private void enterWord()
        {
            currentWord = convertRowOf2DCharGridToString(letterGrid, currentRow);
            
            if (checkValidWord(currentWord))
            {
                keyPressAnimation(0, currentRow);
                keyPressAnimation(1, currentRow);
                keyPressAnimation(2, currentRow);
                keyPressAnimation(3, currentRow);
                keyPressAnimation(4, currentRow);
                resultArray = checkEnteredRow(currentWord.ToCharArray(), correctWord.ToCharArray());
                if (numberCorrectLetters == 5)
                {
                    gameWon(currentRow);
                }
                else
                {
                    colourCompleteWord(resultArray, currentRow, currentWord.ToCharArray());
                }
                Array.Clear(resultArray, 0, resultArray.Length);
                currentRow++;
                if (currentRow > 5)
                {
                    gameLost(correctWord);
                }
                currentColumn = 0;
                numberCorrectLetters = 0;
            }
            else
            {
                invalidWordAnimation(0, currentRow);
                invalidWordAnimation(1, currentRow);
                invalidWordAnimation(2, currentRow);
                invalidWordAnimation(3, currentRow);
                invalidWordAnimation(4, currentRow);
            }
        }

        private void gameWon(int row)
        {
            correctWordAnimation(row);
            MessageBox.Show("You won after " + (row + 1) + " guesses");
        }

        private void gameLost(string correctWord)
        {
            string word = correctWord.ToLower();
            word = (word.Substring(0, 1)).ToUpper() + word.Substring(1,4);
            
            MessageBox.Show("You failed to guess the correct word in 6 guesses. \nThe correct word was '" + word + "'.");
        }

        private int[] checkEnteredRow(char[] currentWordArray, char[] correctWordArray)
        {
            bool[] alreadyChecked = new bool[5];
            for (int i = 0; i <= 4; i++)
            {
                if (currentWordArray[i] == correctWordArray[i]) 
                {
                    resultArray[i] = 2;
                    alreadyChecked[i] = true;
                    numberCorrectLetters++;
                }
            }

            for (int i = 0; i <= 4; ++i)
            {
                if (resultArray[i] == 0)
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        if ((alreadyChecked[j] == false) && (i != j))
                        {
                            if (currentWordArray[i] == correctWordArray[j])
                            {
                                resultArray[i] = 1;
                                alreadyChecked[j] = true;
                                break;
                            }
                        }
                    }
                }
            }
            return resultArray;
        }

        private void colourCompleteWord(int[] resultArray, int row, char[] currentWordArray)
        {
            for (int i = 0; i <= 4; i++)
            {
                string selectedLetterBox = $"letterBox{i:D1}{row:D1}";
                foreach (Control control in Controls)
                {
                    if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
                    {
                        //If the letter is in the correct letter and correct spot, if number of correct letters is 5,
                        //the word is correct and the letterboxes will be coloured sequentially in the animation
                        letterBox.textColour = Color.White;
                        if (resultArray[i] == 2 && numberCorrectLetters != 5)
                        {
                            letterBox.baseColour = correctColour;
                            letterBox.alternateColour = correctColour;
                            colourButton(currentWordArray[i], correctColour);
                        }
                        //if the letter is correct, although in the wrong location
                        else if (resultArray[i] == 1)
                        {
                            letterBox.baseColour = partialColour;
                            letterBox.alternateColour = partialColour;
                            colourButton(currentWordArray[i], partialColour);
                        }
                        else
                        {
                            letterBox.baseColour = alternateColour;
                            colourButton(currentWordArray[i], alternateColour);
                        }
                    }
                }
            }
        }

        private void colourButton(char letter, Color colour)
        {
            string selectedButton = $"btn{letter:D1}";
            foreach (Control control in Controls)
            {
                if (control.Name == selectedButton && control is Button button) // Assuming letterboxes are TextBox controls
                {
                    if (button.BackColor != correctColour)
                    {
                        button.BackColor = colour;
                        button.ForeColor = darkTextColour;
                    }
                }
            }
        }

        private string generateCorrectWord()
        {
            string[] correctWordPool = {
                "HOUSE", "PLACE", "RIGHT", "SMALL", "LARGE", "WATER", "WHERE", "AFTER", "UNDER",
                "WHILE", "NEVER", "OTHER", "ABOUT", "THESE", "WOULD", "COULD", "SHOULD", "THEIR",
                "THERE", "WHERE", "WHICH", "THOSE", "AGAIN", "WORLD", "THREE", "GREAT", "STILL",
                "EVERY", "FOUND", "MIGHT", "FIRST", "THOSE", "AFTER", "COULD", "EVERY", "WHERE",
                "NEVER", "OTHER", "UNDER", "ABOUT", "WOULD", "THERE", "WHICH", "WHERE", "WORLD",
                "RIGHT", "LARGE", "SMALL", "PLACE", "IRATE", "AUDIO", "ARISE"
            };
            Random random = new Random();
            int wordsNumber = correctWordPool.Length;
            correctWord = correctWordPool[random.Next(0, wordsNumber)];
            Console.WriteLine(correctWord);
            return correctWord;
        }

        private string convertRowOf2DCharGridToString(char[,] grid, int row)
        {
            return (
                grid[0, row].ToString() +
                grid[1, row].ToString() +
                grid[2, row].ToString() +
                grid[3, row].ToString() +
                grid[4, row].ToString()
                );
        }

        private bool checkValidWord(string word)
        {
            return Array.Exists(allWords, element => element.Equals(word, StringComparison.OrdinalIgnoreCase));
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
                case Keys.Enter:
                    btnEnter.PerformClick();
                    break;
                case Keys.Delete:
                    btnDelete.PerformClick();
                    break;
                case Keys.Back:
                    btnDelete.PerformClick();
                    break;
            }
        }
    }
}
