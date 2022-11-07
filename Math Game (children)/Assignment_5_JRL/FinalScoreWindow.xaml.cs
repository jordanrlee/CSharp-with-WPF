using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment_5_JRL
{

    
    /// <summary>
    /// Interaction logic for FinalScoreWindow.xaml
    /// </summary>
    public partial class FinalScoreWindow : Window
    {
        #region Attributes
        /// <summary>
        /// A Player object created for accessing Player class
        /// </summary>
        Player player;
        /// <summary>
        /// A playerScore object used to access PlayerScore class
        /// </summary>
        PlayerScore playerScore;
        /// <summary>
        /// A variable used to store the player's score
        /// </summary>
        public int score;
        /// <summary>
        /// a variable used to store time
        /// </summary>
        public int time;
        /// <summary>
        /// A variable for GameWindow object
        /// </summary>
        GameWindow gameWindow;
        /// <summary>
        /// a variable to store player amount of correct submissions
        /// </summary>
        private int playerCorrectAnswers;
        /// <summary>
        /// a variable to store player amount of incorrect submissions
        /// </summary>
        private int playerIncorrectAnswers;
        #endregion Attributes
        #region Methods
        /// <summary>
        /// A method used to create the final score window object
        /// </summary>
        /// <param name="gameWindow"></param>
        /// <param name="playerScore"></param>
        public FinalScoreWindow(GameWindow gameWindow,PlayerScore playerScore)
        {
            
            InitializeComponent();
            // play the audio (wav) file for the Score Window
            System.Media.SoundPlayer mPlayer = new System.Media.SoundPlayer(@"C:\Users\jorda\Documents\School\CS3280 - C#\Homework\Assignment_5_JRL\Assignment_5_JRL\tmnt_scores.wav");
            //ImageBrush mybrush = new ImageBrush(new BitmapImage(new Uri(@"C:\Users\jorda\Documents\School\CS3280 - C#\Homework\Assignment_5_JRL\Assignment_5_JRL\Images/tmnt_lose.jpg", UriKind.Relative)));
            mPlayer.Play();
            // instantiate the object
            this.playerScore = playerScore;
            playerScore.PlayerScoreInfo();
            updateFields();
            
            

        }
        /// <summary>
        /// A method used to close the window and play the main menu music
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\Users\jorda\Documents\School\CS3280 - C#\Homework\Assignment_5_JRL\Assignment_5_JRL\tmnt_main.wav");
            player.Play();
            this.Close();
        }
        /// <summary>
        /// A method used to update the labels in FinalScoreWindow with the values obtained in PlayerScore
        /// </summary>
        public void updateFields()
        {
            try
            {
                lblNameScores.Content = "Name: " + playerScore.Name; // player's name from mainwindow
                lblAgeScores.Content = "Age: " + playerScore.Age; // need age from mainwindow
                //playerScore.Seconds = time;

                score = playerScore.Score;
                // update the image depicting the player score
                if (score < 0 || score > 3)
                {
                    throw new Exception("Error: Score was invalid and zero.");
                }

                else if (score == 1)
                {
                    lblFinalScore_Image1.Visibility = Visibility.Visible;
                }
                else if (score == 2)
                {
                    lblFinalScore_Image2.Visibility = Visibility.Visible;
                }
                else if (score == 3)
                {
                    lblFinalScore_Image3.Visibility = Visibility.Visible;
                }
                lblTime.Content = "Total Time: " + playerScore.Seconds;
                // display the number of correct answers 
                lblCorrect.Content = "Number of Correct Answers: " + playerScore.numCorrect;
                // display the number of incorrect answers 
                lblIncorrect.Content = "Number of Incorrect Answers: " + playerScore.numIncorrect;

            }
            catch (Exception ex)
            {
                errorCheckFinalScore(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);

            }
            
        }


        #endregion Methods
        #region Error Handling
        /// <summary>
        /// A Method used for displaying boundary errors
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Method"></param>
        /// <param name="Message"></param>
        private void errorCheckFinalScore(string Class, string Method, string Message)
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
