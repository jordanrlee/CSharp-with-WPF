using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
namespace Assignment_5_JRL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// main constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Game = new Game();

        }
        /// <summary>
        /// (UNUSED) a method used to capture text changed in the text box. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            // this does nothing.
        }
        /// <summary>
        /// Create an object for GameWindow
        /// </summary>
        GameWindow GameWindow;
        /// <summary>
        /// Create an object for Player
        /// </summary>
        Player player;
        /// <summary>
        /// Create an object for the main window
        /// </summary>
        Game Game;
        /// <summary>
        /// (UNUSED) Method for when the player clicks the Start button
        /// </summary>
        private void buttonStart_clicked(object sender, RoutedEventArgs e)
        {
            // this does nothing.
        }
        /// <summary>
        /// A method used to create initial game information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            // ERROR HANDLING
            // use the try/finally handling
            if (txtBoxName.Text == "")
            {
                tBoxError1.Visibility = Visibility.Visible;
                tBoxError1.Text = "Error code 1: Please enter a name.";
            }
            else if (txtBoxAge.Text == "")
            {
                tBoxError1.Visibility = Visibility.Visible;
                tBoxError1.Text = "Error code 3: Please enter your Age (3-10).";
            }
            else if (rButtonAdd.IsChecked == false && rButtonSub.IsChecked == false // next line
                                && rButtonMul.IsChecked == false && rButtonDiv.IsChecked == false)
            {
                // display an error if the player selected no game mode
                tBoxError1.Visibility = Visibility.Visible;
                tBoxError1.Text = "Error code 3: Please select a game.";
            }
            else
            {
                try // handle the start of the game, name, age, radio
                {
                    // if characterse entered are too little
                    if (txtBoxName.Text == "") // check to see how many characters were entered
                    {
                        throw new Exception("Error code 1: Empty field in name textbox");
                    }
                    // if characters entered are too great in length
                    else if (txtBoxName.SelectionLength >= 30)
                    {
                        throw new Exception("Error code 2:Too many characters in name textbox");
                    }
                    // if character entered is not a valid number
                    else if (!Int32.TryParse(txtBoxAge.Text, out int age))
                    {
                        tBoxError1.Visibility = Visibility.Visible;
                        tBoxError1.Text = "Error code 3: Please enter your Age (3-10).";
                        throw new Exception("Error code 3: Character entered was not a valid number");
                    }
                    else if (Int32.TryParse(txtBoxAge.Text, out int correctAge))
                    {
                        if (correctAge < 3 || correctAge > 10)
                        {
                            // display the error label
                            tBoxError1.Visibility = Visibility.Visible;
                            tBoxError1.Text = "Error code 3: Please enter your Age (3-10).";
                            throw new Exception("Error code 4: Character entered was not between 3 and 10");
                        }
                        else
                        {
                            // check if the player has selected any of the game modes to play
                            if (rButtonAdd.IsChecked == false && rButtonSub.IsChecked == false // next line
                                && rButtonMul.IsChecked == false && rButtonDiv.IsChecked == false)
                            {
                                // display an error if the player selected no game mode
                                tBoxError1.Visibility = Visibility.Visible;
                                tBoxError1.Text = "Error code 3: Please select a game.";
                            }
                            // a game mode was selected by the player 
                            else
                            {
                                //Hide the error label
                                tBoxError1.Visibility = Visibility.Hidden;

                                //Assign the game type based on the radio button selected
                                if (rButtonAdd.IsChecked == true)
                                {
                                    //Addition
                                    Game.gameMode = 1;
                                }
                                else if (rButtonSub.IsChecked == true)
                                {
                                    //Subtraction
                                    Game.gameMode = 2;
                                }
                                else if (rButtonMul.IsChecked == true)
                                {
                                    //Multiplication
                                    Game.gameMode = 3;
                                }
                                else
                                {
                                    //Division
                                    Game.gameMode = 4;
                                }


                                // send age and name to the object used for player
                                player = new Player(txtBoxName.Text, correctAge);
                                // instantiate the object used for GameWindow
                                GameWindow = new GameWindow(Game, player);
                                
                                // hide the main menu window
                                this.Hide();
                                //display the game window for the player, hold on window exit
                                GameWindow.ShowDialog();
                                // display the main menu
                                this.Show();
                            }



                        }
                    }
                }
                catch (Exception ex)
                {
                    ////throw ex; // the error message
                    // declaringtype returns the class
                    // getcurrentmethod returns the method used
                    // ex.message throws the message
                    errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                       MethodInfo.GetCurrentMethod().Name, ex.Message);
                }
            }

            

            //}
            // }


        }
        /// <summary>
        /// UNUSED ***
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblError_TextInput(object sender, TextCompositionEventArgs e)
        {
            // this does nothing.
        }
        #region Error Handling
        /// <summary>
        /// A Method used for displaying boundary errors
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Method"></param>
        /// <param name="Message"></param>
        private void errorCheck(string Class, string Method, string Message)
        {
            try
            {
                // build the path for error checking
                MessageBox.Show(Class + "." + Method + " -> " + Message);
            }
            catch (Exception e)
            {
                // write the error to a log for review
                System.IO.File.AppendAllText("C:\\" + System.AppDomain.CurrentDomain.FriendlyName
                    + "errorLog.txt",Environment.NewLine + "ErrorCheck Exception: " + e.Message);
            }
        }
        #endregion Error Handling
    }
}
//}
