using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment_5_JRL
{
    /// <summary>
    /// interaction logic for PlayerScore class
    /// used to display the player score at the end of the game
    /// </summary>
    public class PlayerScore : MainWindow
    {
        #region Attributes

        // ----- add XML -----
        /// <summary>
        /// an object to access game window logic
        /// </summary>
        public GameWindow gameWindow;
        /// <summary>
        /// an object to access player information
        /// </summary>
        public Player player;
        /// <summary>
        /// a variable to store player Name
        /// </summary>
        public string Name;
        /// <summary>
        /// A variable to store player age
        /// </summary>
        public int Age;
        /// <summary>
        /// A variable to store number of correct answers
        /// </summary>
        public int numCorrect;
        /// <summary>
        /// a variable to store number of incorrect answers
        /// </summary>
        public int numIncorrect;
        /// <summary>
        /// a variable to store the score of the player based on correct & incorrect
        /// </summary>
        public int Score;
        /// <summary>
        /// a variable to store time spent playing the game, measured in seconds
        /// </summary>
        public int Seconds;
        /// <summary>
        /// a variable to hold the game mode selected by the player
        /// </summary>
        private string gameMode;
        #endregion
        #region Methods
        /// <summary>
        /// A method to fetch player score information to prepare for final window
        /// </summary>
        public void PlayerScoreInfo()
        {
            try
            {

                player.Name = Name;
                player.Age = Age;
                gameWindow.time = Seconds;
                gameWindow.correctAnswers = numCorrect;
                gameWindow.incorrectAnswers = numIncorrect;
                
                if (numCorrect >= 0 && numCorrect <= 4)
                {
                    Score = 1;
                }
                else if (numCorrect >= 5 && numCorrect <= 7 && numIncorrect <= 5)
                {
                    Score = 2;
                }
                else if (numCorrect >= 8 && numCorrect <= 10)
                {
                    Score = 3;
                }
                else
                {
                    Score = 0;
                }
                //player.Seconds = Seconds;
                //player.gameMode = gameMode;
            }
            catch (Exception ex)
            {
                errorCheckPlayer(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                     MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Constructor used for PlayerScore
        /// </summary>
        /// <param name="gameWindow"></param>
        public PlayerScore(GameWindow gameWindow)
        {
            //instantiate the gamewindow object for the finalscore window
            this.gameWindow = gameWindow;
            InitializeComponent();
            this.player = new Player("filler", 0);
            PlayerScoreInfo();
        }
        #endregion
        #region Error Handling
        /// <summary>
        /// A Method used for displaying boundary errors
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Method"></param>
        /// <param name="Message"></param>
        private void errorCheckPlayer(string Class, string Method, string Message)
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
        #endregion
    }
}
