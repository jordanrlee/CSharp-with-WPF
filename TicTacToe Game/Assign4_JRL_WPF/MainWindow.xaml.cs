using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Assign4_JRL_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, InterfaceTTTWindow
    {
        #region Methods
        TicTacToe theTicTacToe = new TicTacToe();

        /// <summary>
        /// the default constructor for initialize and instantiate
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            theTicTacToe.SetWindow(this);
        }
        #region Button Clicks
        /// <summary>
        /// Player clicking a square. Logic across buttons 1-9
        /// </summary>
        /// <param name="sender">Which square was pressed</param>
        /// <param name="e">Event args</param>
        private void buttonClick(object sender, RoutedEventArgs e)
        {
            Button btnSender = (Button)sender;
            if (theTicTacToe.PlayerChoose(btnSender) < 0)
            {
                return;
            }
        }

        /// <summary>
        /// player clicking Start Game button. logic for button 10
        /// </summary>
        /// <param name="sender">The button clicked</param>
        /// <param name="e">Event args</param>
        private void buttonStartGameClick(object sender, RoutedEventArgs e)
        {
            theTicTacToe.StartGame();
        }
        #endregion Button Clicks
        /// <summary>
        /// Update the textBlock1 inside of groupBox2 with the game statuses
        /// </summary>
        /// <param name="status"></param>
        public void UpdateGameStatus(string status)
        {
            textBlock1.Text = status;
        }

        /// <summary>
        /// reset the game window for the player to begin the game. 
        /// </summary>
        public void Reset()
        {
            // empty the content inside of the buttons (squares)
            button1.Content = "";
            button2.Content = "";
            button3.Content = "";
            button4.Content = "";
            button5.Content = "";
            button6.Content = "";
            button7.Content = "";
            button8.Content = "";
            button9.Content = "";

            // set the backgrounds to white
            button1.Background = System.Windows.Media.Brushes.White;
            button2.Background = System.Windows.Media.Brushes.White;
            button3.Background = System.Windows.Media.Brushes.White;
            button4.Background = System.Windows.Media.Brushes.White;
            button5.Background = System.Windows.Media.Brushes.White;
            button6.Background = System.Windows.Media.Brushes.White;
            button7.Background = System.Windows.Media.Brushes.White;
            button8.Background = System.Windows.Media.Brushes.White;
            button9.Background = System.Windows.Media.Brushes.White;
        }

        /// <summary>
        /// update the labels to reflect the game Wins/Ties. Labels 4-6
        /// </summary>
        public void UpdateStatistics()
        {
            label4.Content = theTicTacToe.player1Wins;
            label5.Content = theTicTacToe.player2Wins;
            label6.Content = theTicTacToe.playerTies;
        }

        /// <summary>
        /// When a winning group is chosen, highlight the winning squares in Green.
        /// </summary>
        /// <param name="squares"></param>
        public void WinningSquares(int[] squares)
        {
            foreach (int i in squares)
            {
                Button btn;
                switch (i)
                {
                    case 0:
                        btn = button1;
                        break;
                    case 1:
                        btn = button2;
                        break;
                    case 2:
                        btn = button3;
                        break;
                    case 3:
                        btn = button4;
                        break;
                    case 4:
                        btn = button5;
                        break;
                    case 5:
                        btn = button6;
                        break;
                    case 6:
                        btn = button7;
                        break;
                    case 7:
                        btn = button8;
                        break;
                    case 8:
                        btn = button9;
                        break;
                    default:
                        btn = button1;
                        break;
                }
                // highlight the squares in Green by changing the background to Green
                btn.Background = System.Windows.Media.Brushes.Green;
                
            }
        }
        #endregion Methods
    }
}
