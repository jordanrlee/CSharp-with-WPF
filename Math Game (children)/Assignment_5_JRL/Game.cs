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
    /// Interaction logic for Game class
    /// </summary>
    public class Game
    {
        #region Attributes
        /// <summary>
        /// Create the first number variable
        /// </summary>
        public int firstNumber;
        /// <summary>
        /// Create the second number variable
        /// </summary>
        public int secondNumber;
        /// <summary>
        /// Create the player answer variable
        /// </summary>
        public int playerAnswer;
        /// <summary>
        /// Create the correct answer variable
        /// </summary>
        public int correctAnswer;
        /// <summary>
        /// Player selects game type variable
        /// Addition = 1
        /// Subraction = 2
        /// Multiply = 3
        /// Division = 4
        /// </summary>
        public int gameMode = 0;
        /// <summary>
        /// create the RNG object
        /// </summary>
        Random randNum = new Random();
        /// <summary>
        /// create the class sharing object
        /// </summary>
        public Player Player;
        /// <summary>
        /// Create the constructor
        /// </summary>
        public Game()
        {

        }
        #endregion Attributes
        #region Methods
        /// <summary>
        /// method for getting both numbers a random integer between 0 and 10
        /// </summary>
        public void getRandomNumbers()
        {
            try
            {
                // first number
                int first = randNum.Next(0, 11);
                firstNumber = first;

                // second number
                int second = randNum.Next(0, 11);
                secondNumber = second;

                if (firstNumber > 11 || firstNumber < 0 || secondNumber > 11 || secondNumber < 0)
                {
                    throw new Exception("Error: first and/or second number exceeded bounds");
                }
            }
            catch (Exception ex)
            {
                errorCheckGame(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        /// <summary>
        /// method for returning the first variable's number
        /// </summary>
        /// <returns> First Number </returns>
        public int getFirstNumber()
        {
            return firstNumber;
        }
        /// <summary>
        /// method for returning the second variable's number
        /// </summary>
        /// <returns> secondNumber </returns>
        public int getSecondNumber()
        {
            return secondNumber;
        }
        /// <summary>
        /// method for addition between both numbers
        /// </summary>
        /// <returns> correctAnswer </returns>
        public int Addition()
        {
            getRandomNumbers();
            return correctAnswer = firstNumber + secondNumber;
        }
        /// <summary>
        /// method for subtraction between both numbers
        /// </summary>
        /// <returns> correctAnswer </returns>
        public int Subtraction()
        {
            getRandomNumbers();
            // avoid negative numbers
            // check which is bigger first
            if (firstNumber > secondNumber)
            {
                return correctAnswer = firstNumber - secondNumber;
            }
            // reverse the number positions
            else
            {
                int temp = secondNumber; // place second number into a temp 
                secondNumber = firstNumber; // place first number into second number
                firstNumber = temp; // restore second number into the new first number position
                return correctAnswer = firstNumber - secondNumber;
            }
        }
        /// <summary>
        /// method for multiplication between both numbers
        /// </summary>
        /// <returns> correctAnswer </returns>
        public int Multiplication()
        {
            getRandomNumbers();
            return correctAnswer = firstNumber * secondNumber;
        }
        /// <summary>
        /// method for division between both numbers
        /// </summary>
        /// <returns> correctAnswer </returns>
        public int Division()
        {
            getRandomNumbers();
            if (firstNumber < 0 || firstNumber > 11) // error scenario
            {
                throw new Exception("Error: first number exceeded bounds");
            }
            else if (secondNumber < 0 || secondNumber > 11)
            {
                throw new Exception("Error: second number exceeded bounds");
            }
            else
            {
            // check for a plausible number to be used for simple division (whole numbers)
            // the answer must be a whole number too
            // create a loop to keep trying until a valid number is found for both numbers
            while (secondNumber == 0 || firstNumber % secondNumber != 0)
            {
                secondNumber = randNum.Next(1, 11);
            }
            return
                correctAnswer = firstNumber / secondNumber;
            }

        }
        /// <summary>
        /// A Method used for displaying boundary errors
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Method"></param>
        /// <param name="Message"></param>
        private void errorCheckGame(string Class, string Method, string Message)
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
    }
    #endregion Methods
}
