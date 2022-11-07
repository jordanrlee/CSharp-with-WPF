/////////////////////////////////////////////////////////////////
/// Jordan Lee
/// 1/28/2022
/// CS3280 
/////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class Form1 : Form
    {
        #region Attributes
        /// <summary>
        /// the display of the die
        /// </summary>
        int face;
        /// <summary>
        /// tracks how many times 1 was displayed
        /// </summary>
        double chance1 = 0;
        /// <summary>
        /// tracks how many times 2 was displayed
        /// </summary>
        double chance2 = 0;
        /// <summary>
        /// tracks how many times 3 was displayed
        /// </summary>
        double chance3 = 0;
        /// <summary>
        /// tracks how many times 4 was displayed
        /// </summary>
        double chance4 = 0;
        /// <summary>
        ///tracks how many times 5 was displayed
        /// </summary>
        double chance5 = 0;
        /// <summary>
        /// tracks how many times 6 was displayed
        /// </summary>
        double chance6 = 0;
        /// <summary>
        /// records how many guesses were made
        /// </summary>
        int totalGuesses = 0;
        /// <summary>
        /// records the player's guess into a variable
        /// </summary>
        int playerGuess;
        /// <summary>
        /// player guesses 1
        /// </summary>
        int guessed1 = 0;
        /// <summary>
        /// player guesses 2
        /// </summary>
        int guessed2 = 0;
        /// <summary>
        /// player guesses 3
        /// </summary>
        int guessed3 = 0;
        /// <summary>
        /// player guesses 4
        /// </summary>
        int guessed4 = 0;
        /// <summary>
        /// player guesses 5
        /// </summary>
        int guessed5 = 0;
        /// <summary>
        /// player guesses 6
        /// </summary>
        int guessed6 = 0;
        /// <summary>
        /// times won
        /// </summary>
        int wins = 0;
        /// <summary>
        /// times lost
        /// </summary>
        int losses = 0;

        //int iResultCheck;
        /// <summary>
        /// random number to store random numbers into
        /// </summary>
        // create the random number object
        Random randomNumber = new Random();

        #endregion

        #region Methods
        public Form1()
        {
            InitializeComponent();
            cmd1.Hide();
            lbl8.Hide();
        }

        /// <summary>
        /// When the roll button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            // the random number created between 1 and 6
            face = randomNumber.Next(1, 7);

            // if/else for the dice
            if (face == 1)
            {
                ++chance1;
                ++totalGuesses;
            }
            else if (face == 2)
            {
                ++chance2;
                ++totalGuesses;
            }
            else if (face == 3)
            {
                ++chance3;
                ++totalGuesses;
            }
            else if (face == 4)
            {
                ++chance4;
                ++totalGuesses;
            }
            else if (face == 5)
            {
                ++chance5;
                ++totalGuesses;
            }
            else // if face is 6
            {
                ++chance6;
                ++totalGuesses;
            }
            // 
            //string f = String.Format("{0,-10}");
            //string fr = String.Format("FREQUENCY");
            //string p = String.Format("PERCENT");
            //string numtg = String.Format("NUMBER OF TIMES GUESSED");
           
            // display the data into the rich text box 
            // FACE, FREQUENCY, PERCENT, NUMBER OF TIMES GUESSED
            rTxtBox1.Text = "FACE\tFREQUENCY\tPERCENT\tNUMBER OF TIMES GUESSED"
               // + Environment.NewLine + f + fr + p + numtg 
                + Environment.NewLine + "1\t" + chance1 + "\t\t" + calcPercent(chance1) + "%\t\t" + guessed1
                + Environment.NewLine + "2\t" + chance2 + "\t\t" + calcPercent(chance2) + "%\t\t" + guessed2
                + Environment.NewLine + "3\t" + chance3 + "\t\t" + calcPercent(chance3) + "%\t\t" + guessed3
                + Environment.NewLine + "4\t" + chance4 + "\t\t" + calcPercent(chance4) + "%\t\t" + guessed4
                + Environment.NewLine + "5\t" + chance5 + "\t\t" + calcPercent(chance5) + "%\t\t" + guessed5
                + Environment.NewLine + "6\t" + chance6 + "\t\t" + calcPercent(chance6) + "%\t\t" + guessed6;
                
            
            
           // rTxtBox1.Text = ("{f}, {fr}, {p}, {numtg}", f, fr, p, numtg);
            
            // calculate wins and losses
            if (playerGuess == face)
            {
                ++wins;
            }
            else
            {
                ++losses;
            }

            //update games played
            lbl5.Text = totalGuesses.ToString();
            lbl6.Text = wins.ToString();
            lbl7.Text = losses.ToString();

            //empty out txtBox (where the player types)
            txtbox1.ResetText();
            // increase the size of the die image
            pBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            // simulate rolling by running a loop
            for (int i = 1; i < 12; i++)
            {
                int picture = randomNumber.Next(1, 7); // the 1-6 die
                pBox1.Image = Image.FromFile("die" + picture.ToString() + ".gif"); // all files must be named properly
                pBox1.Refresh(); // change image
                Thread.Sleep(100); // add delay to simulate die change
            }
        }

        /// <summary>
        /// math to calculate the percantage of guesses
        /// </summary>
        /// <param name="chance"></param>
        /// <returns>the calculated chance in double (2 decimal).</returns>
        private double calcPercent(double chance)
        {
            // arithmitic to calculate the percantage
            chance = (chance / totalGuesses) * 100;
            //math call to round the number to 2 places
            chance = Math.Round(chance, 2);
            //return the calculated chance
            return chance;
        }

        /// <summary>
        /// when the reset button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            // change the variables back to zero for reset
            // chances
            chance1 = 0;
            chance2 = 0;
            chance3 = 0;
            chance4 = 0;
            chance5 = 0;
            chance6 = 0;
            // guesses
            totalGuesses = 0;
            guessed1 = 0;
            guessed2 = 0;
            guessed3 = 0;
            guessed4 = 0;
            guessed5 = 0;
            guessed6 = 0;
            //win/loss
            wins = 0;
            losses = 0;
            // empty out the richTextBox
            rTxtBox1.Clear();
            // empty out the labels
            lbl5.Text = totalGuesses.ToString();
            lbl6.Text = wins.ToString();
            lbl7.Text = losses.ToString();
            //empty out the textBox 
            txtbox1.Clear();
            // hide the roll button until a number is entered
            cmd1.Hide(); // hide the roll button (cmd1)
            lbl8.Hide(); // hide the error message
        }

        /// <summary>
        /// If a player types a number that is out of range.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox1_TextChanged(object sender, EventArgs e)
        {
            // condition for if the player enters a value out of range
            if (!Int32.TryParse(txtbox1.Text, out playerGuess) || playerGuess < 1 || playerGuess > 6 || playerGuess == 0)
            {
                cmd1.Hide(); // hide the Roll button (cmd1)
                lbl8.Show(); // show the error message
            }
            else
            {
                cmd1.Show(); // show the Roll button (cmd1)
                lbl8.Hide(); // hide the error message
            }

            //If the user enters correct input, increment guesses
            if (Int32.TryParse(txtbox1.Text, out playerGuess))
            {
                
                switch (playerGuess)
                {
                    //cases
                    case 1:
                        guessed1++;
                        break;
                    case 2:
                        guessed2++;
                        break;
                    case 3:
                        guessed3++;
                        break;
                    case 4:
                        guessed4++;
                        break;
                    case 5:
                        guessed5++;
                        break;
                    case 6:
                        guessed6++;
                        break;
                }

            }
        }
        #endregion

    }
}
// end Assignment2 logic
