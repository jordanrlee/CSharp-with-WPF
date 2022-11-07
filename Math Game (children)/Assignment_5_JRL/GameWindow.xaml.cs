using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Assignment_5_JRL
{

    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        #region Attributes
        /// <summary>
        /// create the player score object
        /// </summary>
        PlayerScore playerScore;
        /// <summary>
        /// Create the Timer object.
        /// </summary>
        //public Timer Timer;
        // WPF version
        //System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        DispatcherTimer myTimer;
        /// <summary>
        /// Create the Game object.
        /// </summary>
        public Game Game;

        /// <summary>
        /// a counter variable for rounds played
        /// </summary>
        int rounds = 1;

        /// <summary>
        /// a time variable for displaying the time played in seconds
        /// </summary>
        public int time;

        /// <summary>
        /// a counter variable for keeping count of correct answers made by the Player
        /// </summary>
        public int correctAnswers = 0;

        /// <summary>
        /// a counter variable for keeping count of incorrect answers made by the Player
        /// </summary>
        public int incorrectAnswers = 0;
        #endregion Attributes
        #region Methods
        /// <summary>
        /// a contructor used for GameWindow
        /// </summary>
        /// <param name="game"></param>
        public GameWindow(Game game, Player player)
        {
            Game = game;
            playerScore = new PlayerScore(this);
            playerScore.Name = player.Name;
            playerScore.Age = player.Age;
            InitializeComponent();
            // play the audio (wav) file for GameWindow
            //System.Media.SoundPlayer mPlayer = new System.Media.SoundPlayer(@"C:\Users\jorda\Documents\School\CS3280 - C#\Homework\Assignment_5_JRL\Assignment_5_JRL\tmnt_GameWindow.wav");
            //play the sound for correct answer achieved
            //MediaPlayer bMusic = new MediaPlayer();
            //bMusic.Open(new Uri(@"C:\Users\jorda\Documents\School\CS3280 - C#\Homework\Assignment_5_JRL\Assignment_5_JRL\tmnt_GameWindow.wav"));
            //bMusic.Play();
            //mPlayer.Play();

            // instantiate the object used for time
            myTimer = new DispatcherTimer();
            myTimer.Interval = TimeSpan.FromSeconds(1);
            myTimer.Tick += MyTimer_Tick;
            myTimer.Start();
            numOfRounds();
            GameStart();
            
        }
        /// <summary>
        /// A method used to simulate a timer for player game duration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyTimer_Tick(object sender, EventArgs e)
        {
            // when the timer goes off
            time++;
            //lblSeconds.Content = DateTime.Now.ToString();
            lblSeconds.Content = TimeSpan.FromSeconds(time);
            //lblSeconds.Content = time;
        }

        
        /// <summary>
        /// a method for when the player clicks the quit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonQuit_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\jorda\Documents\School\CS3280 - C#\Homework\Assignment_5_JRL\Assignment_5_JRL\tmnt_main.wav");
            player.Play();
            this.Close();
        }
        /// <summary>
        /// A method used for capturing the "Enter" key being pressed and simulating behavior for submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void enterKeyPressed(object sender, KeyEventArgs e)
        {
            // check for enter key
            if (e.Key == Key.Enter)
            {
                // Enter key pressed
                try
                {
                    if (rounds > 11)
                    {
                        throw new Exception("Error: Rounds exceeded limit of 10/10");
                    }
                    else
                    {
                        if (rounds < 11)
                        {
                            // compare player answer and the correct answer
                            if (txtBoxGameWindow.Text == Game.correctAnswer.ToString())
                            {
                                // increment the counter
                                correctAnswers++;
                                this.playerScore.Seconds = time;
                                this.playerScore.numCorrect = correctAnswers;
                                System.Media.SoundPlayer clipPlayer = new System.Media.SoundPlayer(@"C:\Users\jorda\Documents\School\CS3280 - C#\Homework\Assignment_5_JRL\Assignment_5_JRL\tmnt_correct.wav");
                                clipPlayer.Play();
                                //play the sound for correct answer achieved
                                // MediaPlayer cClip = new MediaPlayer();
                                // cClip.Open(new Uri(@"C:\Users\jorda\Documents\School\CS3280 - C#\Homework\Assignment_5_JRL\Assignment_5_JRL\tmnt_correct.wav"));
                                // cClip.Play();
                                lblAnswerFeedback.Content = "Correct!";
                                lblAnswerFeedback.Background = new SolidColorBrush(Colors.Green);
                            }
                           
                            // the answer is incorrect
                            else
                            {
                                // increment the counter
                                incorrectAnswers++;
                                this.playerScore.Seconds = time;
                                this.playerScore.numIncorrect = incorrectAnswers;
                                lblAnswerFeedback.Content = "Incorrect!";
                                lblAnswerFeedback.Background = new SolidColorBrush(Colors.Red);
                            }
                            rounds++;
                            if (rounds != 11)
                            {
                                // call the rounds method to display the round count
                                numOfRounds();
                                // begin the game
                                GameStart();

                            }
                        }
                        // the game has reached the final round
                        //else
                        //{
                            if (rounds == 11)
                            {
                                this.Hide();
                                // stop the timer
                                //myTimer.Stop();
                                // send player scores the correct/incorrect answers
                                this.playerScore.Seconds = time;
                                this.playerScore.numCorrect = correctAnswers;
                                this.playerScore.numIncorrect = incorrectAnswers;
                                // Instantiate the final score object to pass GameWindow information
                                FinalScoreWindow finalScoreWindow = new FinalScoreWindow(this, this.playerScore);
                                // display the final score window to the player, wait for player to close window after
                                finalScoreWindow.ShowDialog();
                            }
                        //}
                    }


                }
                catch (Exception ex)
                {
                    ////throw ex; // the error message
                    // declaringtype returns the class
                    // getcurrentmethod returns the method used
                    // ex.message throws the message
                    errorCheckGameWindow(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                       MethodInfo.GetCurrentMethod().Name, ex.Message);
                }
            }

        }
        /// <summary>
        ///  A method for when the player clicks the submit button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                if (rounds > 11)
                {
                    throw new Exception("Error: Rounds exceeded limit of 10/10");
                }
                else
                {
                    if (rounds < 11)
                    {
                        // compare player answer and the correct answer
                        if (txtBoxGameWindow.Text == Game.correctAnswer.ToString())
                        {
                            // increment the counter
                            correctAnswers++;
                            this.playerScore.Seconds = time;
                            this.playerScore.numCorrect = correctAnswers;
                            System.Media.SoundPlayer clipPlayer = new System.Media.SoundPlayer(@"C:\Users\jorda\Documents\School\CS3280 - C#\Homework\Assignment_5_JRL\Assignment_5_JRL\tmnt_correct.wav");
                            clipPlayer.Play();
                            //play the sound for correct answer achieved
                            //MediaPlayer cClip = new MediaPlayer();
                            //cClip.Open(new Uri(@"C:\Users\jorda\Documents\School\CS3280 - C#\Homework\Assignment_5_JRL\Assignment_5_JRL\tmnt_correct.wav"));
                            //cClip.Play();
                            lblAnswerFeedback.Content = "Correct!";
                            lblAnswerFeedback.Background = new SolidColorBrush(Colors.Green);
                        }
                        // the answer is incorrect
                        else
                        {
                            // increment the counter
                            incorrectAnswers++;
                            this.playerScore.Seconds = time;
                            this.playerScore.numIncorrect = incorrectAnswers;
                            lblAnswerFeedback.Content = "Incorrect!";
                            lblAnswerFeedback.Background = new SolidColorBrush(Colors.Red);
                        }
                        // increment the counter for rounds
                        rounds++;
                        if (rounds != 11)
                        {
                            // call the rounds method to display the round count
                            numOfRounds();
                            // begin the game
                            GameStart();
                            
                        }

                    }
                    // the game has reached the final round
                    if (rounds == 11)
                    {
                        this.Hide();
                        // stop the timer
                        //myTimer.Stop();
                        // send player scores the correct/incorrect answers
                        this.playerScore.Seconds = time;
                        this.playerScore.numCorrect = correctAnswers;
                        this.playerScore.numIncorrect = incorrectAnswers;
                        // Instantiate the final score object to pass GameWindow information
                        FinalScoreWindow finalScoreWindow = new FinalScoreWindow(this, this.playerScore);
                        // display the final score window to the player, wait for player to close window after
                        finalScoreWindow.ShowDialog();
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                ////throw ex; // the error message
                // declaringtype returns the class
                // getcurrentmethod returns the method used
                // ex.message throws the message
                errorCheckGameWindow(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                   MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
  
        }
        /// <summary>
        /// A method to display the number of rounds to the player
        /// </summary>
        private void numOfRounds()
        {
            try
            {
                if (rounds == 11)
                {
                    return;
                }
                if (rounds < 0 || rounds > 11)
                {
                    throw new Exception("Error: rounds exceeded bounds");
                }
                else
                {
                    //display the number of rounds
                    lblRound.Content = "Round " + rounds.ToString() + "/10";
                }

            }
            catch (Exception ex)
            {

                errorCheckGameWindow(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                   MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        /// <summary>
        /// a method to display the math problem to the player
        /// </summary>
        private void GameStart()
        {
            try
            {
                if (Game.gameMode > 4 || Game.gameMode < 1)
                {
                    throw new Exception("Error: Game mode exceeded bounds");
                }
                else
                {
                    // clear the text box
                    txtBoxGameWindow.Text = "";
                    // use the game object to call the game mode that the player selected previously
                    if (Game.gameMode == 1) // addition
                    {
                        Game.Addition();
                        // display the text for the math question to the player
                        lblQuestionGameWindow.Content = Game.getFirstNumber().ToString() + " + " +
                            Game.getSecondNumber().ToString() + " = ";
                    }
                    // if subraction was chosen as the game mode
                    else if (Game.gameMode == 2)
                    {
                        Game.Subtraction();
                        // display the text for the math question to the player
                        lblQuestionGameWindow.Content = Game.getFirstNumber().ToString() + " - " +
                            Game.getSecondNumber().ToString() + " = ";
                    }
                    // if multiplication was chosen as the game mode
                    else if (Game.gameMode == 3)
                    {
                        Game.Multiplication();
                        // display the text for the math question to the player
                        lblQuestionGameWindow.Content = Game.getFirstNumber().ToString() + " * " +
                            Game.getSecondNumber().ToString() + " = ";
                    }
                    // division was chosen as the game mode
                    else
                    {
                        Game.Division();
                        // display the text for the math question to the player
                        lblQuestionGameWindow.Content = Game.getFirstNumber().ToString() + " / " +
                            Game.getSecondNumber().ToString() + " = ";
                    }
                }
            }
                
            catch (Exception ex)
            {
                errorCheckGameWindow(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                   MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            
        }
        #region Error Handling
        /// <summary>
        /// A Method used for displaying boundary errors
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Method"></param>
        /// <param name="Message"></param>
        private void errorCheckGameWindow(string Class, string Method, string Message)
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
                    + "errorLog.txt", Environment.NewLine + "ErrorCheck Exception: " + e.Message);
            }
        }
        #endregion Error Handling
        
            }
        }
   // }
    #endregion Methods
//}