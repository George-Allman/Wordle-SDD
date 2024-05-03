
//Student Name: George Allman  Grade: Twelve
//Assesment Task: Two          Year: 2024

//Declaration:
//I hereby certify that this assignment is entirely my own work,
//except where i have acknowledged all material and sources used
//in the preparation of the assignment. I certify 'that all
//typing/keystrokes have been done by me.

//I also certify that the material contained in this assignment has not been previously 'submitted by me for assessment in any formal course of study, and that i have not copied 'in part or whole, or otherwise plagiarised the work of other students and/or persons.

//This program is designed as a free user friendly, interactive and recreational product.

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
		private int currentRow = 0;
		private int currentColumn = 0;
		private char[,] letterGrid = new char[5, 6];
		private string correctWord = "";
		private string currentWord = "";
		private int[] resultArray = new int[5];
		private int numberCorrectLetters = 0;
		private int animationLength = 2;
		private string[] wordListArray;
		private string input;

		private Color lightCorrectColour = Color.FromArgb(106, 170, 100);
		private Color darkCorrectColour = Color.FromArgb(83, 141, 78);

		private Color lightPartialColour = Color.FromArgb(201, 180, 88);
		private Color darkPartialColour = Color.FromArgb(181, 159, 59);

		private Color lightAlternateColour = Color.FromArgb(150, 150, 150);
		private Color darkAlternateColour = Color.FromArgb(75, 75, 75);

		private Color lightTextColour = Color.Black;
		private Color darkTextColour = Color.White;


		//Declares the public variables, they will be accessed by the frmSettings so thus need to be public
		public Color baseColour = Color.FromArgb(20, 20, 20);
		public Color alternateColour = Color.FromArgb(75, 75, 75);
		public Color tertiaryColour = Color.DimGray;
		public Color correctColour = Color.FromArgb(83, 141, 78);
		public Color partialColour = Color.FromArgb(181, 159, 59);
		public Color textColour = Color.White;
		public bool highContrastMode = false;
		public bool onScreenKeyboard = true;

		private frmHelp FrmHelp = new frmHelp();

		//Declares a local variable of _darkMode to assign the initial value of the unUnderScored darkMode to true
		private bool _darkMode = true;

		//Declares the public darkMode variable, using the get & set method to enable
		//both a value to be received (get) and code to play when the value is altered (set)
		//This allows all of the visual augments of swapping between darkmode and lightmode
		//to be intuitively ran whenever the boolean is swapped.
		public bool darkMode
		{
			get { return _darkMode; }
			set { 
				//Alters the private variable to the new value that has just been passed
				_darkMode = value;
				//Assigns the unique controls(all controls that are not the onscreen keyboard or letterBoxes) to the relevant colour
				btnHelp.ForeColor = baseColour;
				btnSettings.ForeColor = baseColour;
				lblTitle.ForeColor = textColour;
				this.BackColor = baseColour;
				
				//Changes the two icon-buttons to the appropriate img out of the resources file
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
                    if (control is Button button) // Assuming letterboxes are TextBox controls
                    {
                        //This if condition differentiates the buttons of the onscreen keyboard
                        //from the navigation buttons and inherited button properties of the letterBoxes
                        if (button.Name.StartsWith("btn") &&
                           (button.Name.Length == 4 || // Single character buttons (btnA to btnZ)
                            button.Name == "btnEnter" || // Special buttons
                            button.Name == "btnDelete")) // Special buttons
                        {
                            //Checks whether the button has already been filled with a colour to represent its
                            //correct status in the grid, thus changing the shade of green to lighter/darker
                            if (button.BackColor == lightCorrectColour || button.BackColor == darkCorrectColour)
                            {
                                button.BackColor = correctColour;
                                button.ForeColor = darkTextColour;
                            }
                            //Checks whether the button has already been filled with a colour to represent its
                            //partially correct status in the grid, thus changing the shade of yellow to lighter/darker
                            else if (button.BackColor == lightPartialColour || button.BackColor == darkPartialColour)
                            {
                                button.BackColor = partialColour;
                                button.ForeColor = darkTextColour;
                            }
                            //Checks whether the button has already been filled with a colour to represent its
                            //incorrect status in the grid, thus changing the shade of grey to lighter/darker
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
                            //All buttons have the same border colour thus it gets excluded from the if statement
                            button.FlatAppearance.BorderColor = alternateColour;

                        }
                    }
                }

				FrmHelp.textColour = textColour;
                FrmHelp.correctColour = correctColour;
				FrmHelp.partialColour = partialColour;
				FrmHelp.baseColour = baseColour;
				FrmHelp.alternateColour = alternateColour;
				FrmHelp.darkMode = darkMode;
            }
		}

		public frmWordle()
		{
			//Calls the constructor
			InitializeComponent();

			//Sets the forms icon to the logo.ico file in the resources
			//folder so it is continous across devices
			this.Icon = Resources.wordleLogo;

			//Attaches any physical keypresses to the event handler
			//KeyPreview enables key presses to be interpretted at
			//the form level, enabling the use of btn.performClick,
			//unifying the two keyboards under the same code
			this.KeyDown += frmWordle_KeyDown;
			this.KeyPreview = true;
			//Attaches all of the onscreen keys to the event handler 'KeyboardInput'
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

            //Calls the extractWordList method to convert the text file to a usable array
            wordListArray = extractWordList(Resources.wordList);

            //assigns this games correctWord through a return statement in the GenerateCorrectWord function
            correctWord = generateCorrectWord();
            //Produces the correct word in the console for skipping and debug purposes
            Console.WriteLine(correctWord);

        }

		private void KeyboardInput(object sender, EventArgs e)
		{
			//Removes the focus on the button just pressed to prevent unwanted actions
            this.ActiveControl = null;
            //Declares clickedButton as the button triggering the event handler
            if (sender is Button clickedButton)
			{
				//Accesses the clicked buttons text to identify whether it is a letter, delete or enter
				input = clickedButton.Text;

				//Checks if the button was Delete and that there are letters
				//before it (not in the first position in the row)
				if (input == "Delete" && currentColumn > 0)
				{
					deleteLetter();
				}
				//Checks if the button was Enter and that the row is a full word
				else if (input == "Enter" && currentColumn == 5)
				{
					enterWord();
				}
				//Checks if the button was a key and that the row has spots available for another letter
                else if (input != "Enter" && input != "Delete" && currentColumn < 5)
                {
                    appendLetter(input, currentColumn, currentRow);
                }				
            }
		}
	    
		//Async void is useful here as there is no return statement and the "await Task.Delay" function allows for smooth animations
		private async void keyPressAnimation(int col, int row)
		{
			//Declares a string in the format of letterBoxCR with CR representing the desired location in the grid
			string selectedLetterBox = $"letterBox{col:D1}{row:D1}";

			//Searches through all controls on the page
			foreach (Control control in Controls)
			{
				//Runs code once the letterBox that matches the string defined earlier
				//is found and allows us to use the simple LetterBox name to augment it
				if (control.Name == selectedLetterBox && control is letterBox letterBox)
				{
					//Expand

					//For loop runs for the universal animation length constant
					for (int i = 0; i <= animationLength*1.5; i++)
					{
						//Increases size of letterbox by 2 pixels down and right each iteration
						letterBox.Size = new Size(
							letterBox.Size.Width+2, 
							letterBox.Size.Height+2
							);
						//When increasing size, it expands from the bottom right, moving
						//it to the top left by 1 pixel each iteration keeps the control static
						letterBox.Location = new Point(
							letterBox.Location.X-1, 
							letterBox.Location.Y-1
							);
						//Creates a 1 millisecond gap between each iteration of the for loop
						await Task.Delay(1);
					}

                    //Shrink

                    for (int i = 0; i <= animationLength* 1.5; i++)
					{
						//The signs on both size and location are reversed
						//to cause the opposite effect to expanding
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
                    //Exits the foreach Loop as it is no longer needed
                    break;
                }
			}
		}

		private async void invalidWordAnimation(int col, int row)
		{
            //Declares a string in the format of letterBoxCR with CR representing the desired location in the grid
            string selectedLetterBox = $"letterBox{col:D1}{row:D1}";

            //Searches through all controls on the page
            foreach (Control control in Controls)
			{
                //Runs code once the letterBox that matches the string defined earlier
                //is found and allows us to use the simple LetterBox name to augment it
                if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
				{
					//Moves the letterBox to the left by 1 pixel every iteration
					for (int i = 0; i <= animationLength; i++)
					{
						letterBox.Location = new Point(
							letterBox.Location.X - 1,
							letterBox.Location.Y
							);
						await Task.Delay(1);
					}

					//Moves the letterBox to the right by 2 pixel every iteration so it ends up offset to the right
					for (int i = 0; i <= animationLength; i++)
					{
						letterBox.Location = new Point(
							letterBox.Location.X + 2,
							letterBox.Location.Y
							);
						await Task.Delay(1);
					}
					
					//Moves the letterBox to the left by 1 pixel every iteration so it returns to the center, completing the 'bounce' effect
					for (int i = 0; i <= animationLength; i++)
					{
						letterBox.Location = new Point(
							letterBox.Location.X - 1,
							letterBox.Location.Y
							);
						await Task.Delay(1);
					}
                    //Exits the foreach Loop as it is no longer needed
                    break;
                }
			}
		}

        private async void correctWordAnimation(int row, char[] currentWordArray)
        {
            //For loop for each letterBox in the row
            for (int i = 0; i <= 5; i++)
            {
                //Declares a string in the format of letterBoxCR with CR representing the desired
				//location in the grid, in this case the iteration in the for loop is the column
				//and the row is constant and defined by a parameter
                string selectedLetterBox = $"letterBox{i:D1}{row:D1}";
                //Searches through all controls on the page
                foreach (Control control in Controls)
                {
                    //Runs code once the letterBox that matches the string defined earlier
                    //is found and allows us to use the simple LetterBox name to augment it
                    if (control.Name == selectedLetterBox && control is letterBox letterBox) // Assuming letterboxes are TextBox controls
                    {
						//Completes the green colour change inside the animation to give the 1 by 1 effect of jumping and colouring.
                        letterBox.baseColour = correctColour;
                        letterBox.alternateColour = correctColour;
                        letterBox.textColour = Color.White;    
						
						//Colours the button that has the same letter as the square being animated, passing the desired letter through
						//with currentWordArray[i] and the correctColour as this function is used elsewhere for both partial and incorrect
                        colourButton(currentWordArray[i], correctColour);
						//Same for loops as the other two animation, however multiplying animation length by 3 to make the animation more striking and pronounced
                        for (int j = 0; j <= animationLength * 3; j++)
                        {
							//Moves the square up two pixels each iteration
                            letterBox.Location = new Point(
                                letterBox.Location.X,
                                letterBox.Location.Y - 2
                                );
                            await Task.Delay(1);
                        }
                        for (int j = 0; j <= animationLength * 3; j++)
                        {
                            //Moves the square down two pixels each iteration
                            letterBox.Location = new Point(
                                letterBox.Location.X,
                                letterBox.Location.Y + 2
                                );
                            await Task.Delay(1);
                        }
                        //Exits the foreach Loop as it is no longer needed
                        break;
                    }
                }
            }
        }


        private void appendLetter(string input, int col, int row)
		{
			//Adds the letter to the internal 2D array
			letterGrid[currentColumn, currentRow] = Convert.ToChar(input);

            //Declares a string in the format of letterBoxCR with CR representing the desired location in the grid
            string selectedLetterBox = $"letterBox{col:D1}{row:D1}";

            //Searches through all controls on the page
            foreach (Control control in Controls)
			{
                //Runs code once the letterBox that matches the string defined earlier
                //is found and allows us to use the simple LetterBox name to augment it
                if (control.Name == selectedLetterBox && control is letterBox letterBox)
				{
					//Changes the public 'letter' variable on the letterBox to the input, which will then display it in the center of the square
					letterBox.letter = input;
					//Exits the foreach Loop as it is no longer needed
					break;
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
			//Uses the custom function to get the string "currentWord" from the current row of the 2D char array
			currentWord = convertRowOf2DCharGridToString(letterGrid, currentRow);
			
			//Checks if the word is a valid word out of the word pool
			if (checkValidWord(currentWord))
			{
				//Plays the key press animation for all 5 letter boxes simultaneously when word is entered
				keyPressAnimation(0, currentRow);
				keyPressAnimation(1, currentRow);
				keyPressAnimation(2, currentRow);
				keyPressAnimation(3, currentRow);
				keyPressAnimation(4, currentRow);

				//Calls the checkEnteredRow function which handles the wordle Logic for which square is correct, partially correct and incorrect.
				//Additionally, The functions and logic that handle the colouring of the squares and onscreen keyboard are children of this function.
				resultArray = checkEnteredRow(currentWord.ToCharArray(), correctWord.ToCharArray());

				//Checks if the row was completely correct and thus the game has been won
				if (numberCorrectLetters == 5)
				{
					//Calls the gameWon function, passing the number of guesses it took to win as a parameter.
					//Unlike the other two pathways, this does not call the colouring function as it is handled by the Victory animation
					gameWon(currentRow);
					//Return statement to exit out of the two if statements and prevent the four lines below the else from being called
					return;
				}
				//If the game has not been won (First condition above) and it is on Row 5 the game has been lost
				else if (currentRow == 5)
				{
					//Calls the colouring functions, passing the resultArray, row and current word through as parameters
					colourCompleteWord(resultArray, currentRow, currentWord.ToCharArray());

					//Calls the gameLost function passing through the word that was failed to be guessed through as a parameter
					gameLost(correctWord);

                    //Return statement to exit out of the two IF statements and prevent the four lines at the bottom from being called
                    return;
				}
				else
				{
                    //Calls the colouring functions, passing the resultArray, row and current word through as parameters
                    colourCompleteWord(resultArray, currentRow, currentWord.ToCharArray());
				}
				//Clears the result array ready for the next word
				Array.Clear(resultArray, 0, resultArray.Length);
				//increments the current row
				currentRow++;
				//Resets the current column to the start
				currentColumn = 0;
				//Resets the number of correct letters as it is a new row
				numberCorrectLetters = 0;
			}
			//The word was thus invalid and not contained in the assigned wordList
			else
			{
				//Plays the invalidWordAnimation for all 5 letterBoxes in the row, giving a side to side wall shake effect
				invalidWordAnimation(0, currentRow);
				invalidWordAnimation(1, currentRow);
				invalidWordAnimation(2, currentRow);
				invalidWordAnimation(3, currentRow);
				invalidWordAnimation(4, currentRow);
			}
		}

		private void gameWon(int row)
		{
			//Plays the correct word animation, passing through the row and currentWord
			//the current word is needed as a parameter as the colouring is done by the animation
			correctWordAnimation(row, currentWord.ToCharArray());

			//Returns a victory message to the user, telling them how many guesses it took them
			MessageBox.Show("You won after " + (row + 1) + " guesses");

			//Calls the reset function to allow the user to continue playing with a new word
			gameReset();
		}

		private void gameLost(string correctWord)
		{
			//Changes the correctWord from all uppercase to just a 
			string word = correctWord.ToLower();
			word = (word.Substring(0, 1)).ToUpper() + word.Substring(1,4);
			
			//Returns a defeat message to the user, telling them what the word they failed to guess was
			MessageBox.Show("You failed to guess the correct word in 6 guesses. \nThe correct word was '" + word + "'.");

            //Calls the reset function to allow the user to continue playing with a new word
            gameReset();
		}

		private void gameReset()
		{
			//Generates a new correctWord
			correctWord = generateCorrectWord();

			//Writes in the newly generated word in the console for the developer/debugging
			Console.WriteLine(correctWord);

			//Resets column and row to 0 to return to the first place in the grid
			currentColumn = 0;
			currentRow = 0;

			//Resets the number of correct letters
			numberCorrectLetters = 0;

			//Fully clears the letterGrid and resultArray, ready for a new game
			Array.Clear(letterGrid, 0, letterGrid.Length);
			Array.Clear(resultArray, 0, resultArray.Length);

            //Searches through all controls on the page
			//The letterBoxes and buttons need to be reset so we can use the same foreach loop to search through the controls and use if statements to tell when they are
            foreach (Control control in Controls)
			{
				//Checks whether the control is a letterBox
				if (control is letterBox letterBox) 
				{
					//Resets the square's letter to nothing
					letterBox.letter = "";
					//Resets the letterBox inner colour to normal grey/white
					letterBox.baseColour = baseColour;
					//Resets the border colour to grey
					letterBox.alternateColour = alternateColour;
				}
				//Checks whether the control is a button
				else if (control is Button button)
				{ 
					//Checks whether the button is a key, like btnX (length 4) or btnEnter or btnDelete, this differentiates
					//it from the navigation buttons, and the letterBoxes which inherit their button status
					if (button.Name.Length == 4 || 
						button.Name == "btnEnter" || 
						button.Name == "btnDelete") 
					{
						//Resets the inside colour to grey/white
						button.BackColor = tertiaryColour;
						//Resets the text colour to white/black
						button.ForeColor = textColour;
					}
				}
			}
		}

		private int[] checkEnteredRow(char[] currentWordArray, char[] correctWordArray)
		{
			//Declares a boolean array with bounds 5
			bool[] alreadyChecked = new bool[5];

            //	Check for correct  \\ 

            //Create for loop with 5 iterations, one for each column
            for (int i = 0; i <= 4; i++)
			{
				//Check if the current word matches the correct word at the specific position defined by the iteration of the for loop, if they match the position i is correct
				if (currentWordArray[i] == correctWordArray[i]) 
				{
					//Assigns a 2 to the respective position in the resultArray, meaning a correct
					//This will be used later for colouring
					resultArray[i] = 2;
					//Swaps the respective position in the already checked array to true
					alreadyChecked[i] = true;
					//Increments the number of correct letters
					numberCorrectLetters++;
				}
			}

            //	Check for partially correct  \\

			//Create for loop with 5 iterations, one for each column
            for (int i = 0; i <= 4; ++i)
			{
				//Checks that the current position hasnt already been assigned correct
				if (resultArray[i] == 0)
				{
					//Creates a second for loop to search the other 4 squares
					for (int j = 0; j <= 4; j++)
					{
						//Checks whether the j position has not already been partially or
						//correctly paired to another square. This is the check that prevents double or triple letter
						//guesses or double letter answers from breaking and showing an extra partial or some other malfunction in logic
						if ((alreadyChecked[j] == false))
						{
							if (currentWordArray[i] == correctWordArray[j])
							{
								//Sets this positions array to 1, meaning a partially correct
								resultArray[i] = 1;
								//Sets the j position, the square paired to the i position to already checked to prevent double up
								alreadyChecked[j] = true;
								//Exits out of both for loops to prevent the i position from finding another pairing, which would be incorrect
								break;
							}
						}
					}
				}
			}
			//Returns the result array to the parent function
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
							//Sets the letterBoxes status to 2 so the program can tell what colour it is later
							letterBox.status = 2;
						}
						//if the letter is correct, although in the wrong location
						else if (resultArray[i] == 1)
						{
							letterBox.baseColour = partialColour;
							letterBox.alternateColour = partialColour;
							colourButton(currentWordArray[i], partialColour);
                            //Sets the letterBoxes status to 1 so the program can tell what colour it is later
                            letterBox.status = 1;
                        }
						else
						{
							letterBox.baseColour = alternateColour;
							colourButton(currentWordArray[i], alternateColour);
                            //Sets the letterBoxes status 0 so the program can tell what colour it is later
                            letterBox.status = 0;
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
			//Declares the correctWordPool, a far condensed version of wordList.txt that only includes common words
			string[] correctWordPool = {
				"HOUSE", "PLACE", "RIGHT", "SMALL", "LARGE", "WATER", "WHERE", "AFTER", "UNDER",
				"WHILE", "NEVER", "OTHER", "ABOUT", "THESE", "WOULD", "COULD", "THEIR", "ARISE",
                "THERE", "WHERE", "WHICH", "THOSE", "AGAIN", "WORLD", "THREE", "GREAT", "STILL",
				"EVERY", "FOUND", "MIGHT", "FIRST", "THOSE", "AFTER", "COULD", "EVERY", "WHERE",
				"NEVER", "OTHER", "UNDER", "ABOUT", "WOULD", "THERE", "WHICH", "WHERE", "WORLD",
				"RIGHT", "LARGE", "SMALL", "PLACE", "IRATE", "AUDIO", 
			};
			Random random = new Random();
			//Returns a random word from the correctWordPool
			return correctWordPool[random.Next(0, correctWordPool.Length)];
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
			return Array.Exists(wordListArray, element => element.Equals(word, StringComparison.OrdinalIgnoreCase));
		}

		private string[] extractWordList(string wordList)
		{
            //Creates and returns an array out of the given text file
            return wordList.Split(',');
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Removes the focus from the button just pressed
            this.ActiveControl = null;
            //Creates a new instance of the help form and attaches the
            //current form as an instance for reference in the new help form
            Form frmHelp = new frmHelp();
            frmHelp.Show();
        }

        private void btnSettings_Click(object sender, EventArgs e)
		{
            //Removes the focus from the button just pressed
            this.ActiveControl = null;
			//Creates a new instance of the settings form and attaches the
			Form frmSettings = new frmSettings(this);
			frmSettings.Show();

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

        private void frmWordle_Load(object sender, EventArgs e)
        {

        }
    }
}