using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Assign4_JRL_WPF
{
    class TicTacToe
    {

        #region Attributes
        /// <summary>
        /// a boolean value to check if the game has begun or ended
        /// </summary>
        Boolean gameStarted = false;
        /// <summary>
        /// a boolean value to keep track of which players turn it is
        /// </summary>
        Boolean Player1Turn = true;
        /// <summary>
        /// the Tic Tac Toe game board in the form of an array of type int
        /// </summary>
        int[] board = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        /// <summary>
        /// an abstact used to access TicTacAbstract
        /// </summary>
        InterfaceTTTWindow ticTacToePass;
        /// <summary>
        /// an array of type String to store the various game statuses used to display what state the game is.
        /// </summary>
        String[] statuses = new String[] { "Player 1 wins!" + Environment.NewLine + "How about another match Player 2? Click Start Game.", "Player 2 wins!" + Environment.NewLine + "How about another match Player 1? Click Start Game.", "Its a tie!" + Environment.NewLine + "Oof! Try again players! Click Start Game.", "Player 1's turn", "Player 2's turn" };
        /// <summary>
        /// a value to keep count of Player 1 wins
        /// </summary>
        public int player1Wins = 0;
        /// <summary>
        /// a value to keep count of Player 2 wins
        /// </summary>
        public int player2Wins = 0;
        /// <summary>
        /// a value to keep count of ties between the players
        /// </summary>
        public int playerTies = 0;

        #endregion Attributes

        #region Methods
        /// <summary>
        /// a method used to combine functionality between forms
        /// </summary>
        /// <param name="pass1"
        public void SetWindow(MainWindow pass1) // main window or interface window?
        {
            ticTacToePass = (InterfaceTTTWindow)pass1;
        }
        /// <summary>
        /// a method to clean the board to prepare for Tic Tac Toe begin (again)
        /// </summary>
        public void StartGame()
        {
            ticTacToePass.Reset(); // used to clean the board
            Player1Turn = true; // set player 1
            ticTacToePass.UpdateGameStatus(statuses[3]); // the game status array
            board = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // default value to clean
            gameStarted = true; // begin the game
        }
        /// <summary>
        /// A method used to display the player's symbols (X and O)
        /// </summary>
        public int PlayerChoose(System.Windows.Controls.Button sender)
        {
            int location = buttonSpot(sender);

            if (board[location] != 0 || !gameStarted)
            {
                return -1;
            }
            //.Background = System.Windows.Media.Brushes.White;
            board[location] = (Player1Turn) ? 1 : 2;
            sender.Background = (Player1Turn) ? System.Windows.Media.Brushes.Blue : System.Windows.Media.Brushes.Red; // Blue player 1, Red Player 2
            sender.Content = (Player1Turn) ? "X" : "O"; // X for player 1, O for player 2
            if (checkIfWin() > 0) // if there is a win value 
            {
                return 3;
            }
            if (checkIfTie()) // if checkTie returns 
            {
                return 4;
            }
            Player1Turn = !Player1Turn; // change player
            int turn = (Player1Turn) ? 3 : 4; // player change
            ticTacToePass.UpdateGameStatus(statuses[turn]);
            return (!Player1Turn) ? 1 : 2; // player change
        }
        /// <summary>
        /// a method used to assign squares when a player chooses a button
        /// </summary>
        private int buttonSpot(Button btn)
        {
            switch (btn.Name)
            {
                // using the name of the buttons as the convention
                case "button1":
                    return 0;
                case "button2":
                    return 1;
                case "button3":
                    return 2;
                case "button4":
                    return 3;
                case "button5":
                    return 4;
                case "button6":
                    return 5;
                case "button7":
                    return 6;
                case "button8":
                    return 7;
                case "button9":
                    return 8;
                default:
                    return 0;
            }

        }
        #region Conditional Checks for Win/Tie
        /// <summary>
        /// check for a win between either player
        /// </summary>
        private int checkIfWin()
        {
            int winner = 0;
            int result;

            result = checkHorizontal();
            if (result > 0)
            {
                winner = result;
            }
            result = checkVertical();
            if (result > 0)
            {
                winner = result;
            }
            result = checkDiagonal();
            if (result > 0)
            {
                winner = result;
            }
            // so then
            if (winner > 0)
            {
                ticTacToePass.UpdateGameStatus(statuses[winner - 1]);
                gameStarted = false;
                switch (winner)
                {
                    case 1:
                        ++player1Wins;
                        break;

                    case 2:
                        ++player2Wins;
                        break;
                    default:
                        break;
                }
                ticTacToePass.UpdateStatistics();
            }
            return winner;
        }
        /// <summary>
        /// check for a player Tie
        /// </summary>
        private Boolean checkIfTie()
        {
            foreach (int i in board)
            {
                if (i == 0)
                    return false;
            }

            ticTacToePass.UpdateGameStatus(statuses[2]); // the game status array
            ++playerTies; // increment ties
            gameStarted = false; // end the game
            ticTacToePass.UpdateStatistics(); // update the win/tie count
            return true;
        }
        /// <summary>
        /// the method for determining a horizontal win
        /// </summary>
        private int checkHorizontal()
        {
            if (board[0] > 0 && board[0] == board[1] && board[1] == board[2])
            {
                ticTacToePass.WinningSquares(new int[] { 0, 1, 2 }); // first row
                return board[0];
            }
            if (board[3] > 0 && board[3] == board[4] && board[4] == board[5])
            {
                ticTacToePass.WinningSquares(new int[] { 3, 4, 5 }); // second row
                return board[3];
            }
            if (board[6] > 0 && board[6] == board[7] && board[7] == board[8])
            {
                ticTacToePass.WinningSquares(new int[] { 6, 7, 8 }); // third row
                return board[6];
            }

            return 0;
        }
        /// <summary>
        /// the method for determining a vertical win
        /// </summary>
        private int checkVertical()
        {
            if (board[0] > 0 && board[0] == board[3] && board[3] == board[6])
            {
                ticTacToePass.WinningSquares(new int[] { 0, 3, 6 }); // first column
                return board[0];
            }
            if (board[1] > 0 && board[1] == board[4] && board[4] == board[7])
            {
                ticTacToePass.WinningSquares(new int[] { 1, 4, 7 }); // second column
                return board[1];
            }
            if (board[2] > 0 && board[2] == board[5] && board[5] == board[8])
            {
                ticTacToePass.WinningSquares(new int[] { 2, 5, 8 }); // third column
                return board[2];
            }

            return 0;
        }
        /// <summary>
        /// the method for determining a diagonal win
        /// </summary>
        private int checkDiagonal()
        {
            int result = 0;
            if (board[0] > 0 && board[0] == board[4] && board[4] == board[8])
            {
                ticTacToePass.WinningSquares(new int[] { 0, 4, 8 }); // top left to bottom right
                result = board[0];
            }
            if (board[2] > 0 && board[2] == board[4] && board[4] == board[6])
            {
                ticTacToePass.WinningSquares(new int[] { 2, 4, 6 }); // top right to bottom left
                result = board[2];
            }

            if (result > 0)
            {
                return result;
            }

            return 0;
        }
        #endregion


    }
    #endregion Methods


}

//}
