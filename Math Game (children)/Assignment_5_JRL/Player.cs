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
    /// Interaction logic for the Player class
    /// </summary>
    public class Player
    {
        #region Attributes
        /// <summary>
        /// An object used to access main window information
        /// </summary>
        MainWindow mainWindow;
        /// <summary>
        /// a variable to hold the player input for Name
        /// </summary>
        public string Name;
        /// <summary>
        /// a variable to hold the player input for Age
        /// </summary>
        public int Age;
        /// <summary>
        /// a get method for getting the player Name
        /// </summary>
        /// <returns>Name</returns>
        public string getName()
        {
            mainWindow.txtBoxName.Text = Name;
            return Name;
        }
        /// <summary>
        /// a get method for getting the player Age
        /// </summary>
        /// <returns>Age</returns>
        public int getAge()
        {
            return Age;
        }
        /// <summary>
        /// A method for setting the player Name and Age to the class
        /// </summary>
        public Player(string Name, int Age)
        {
            try
            {
                this.Name = Name;
                this.Age = Age;
            }
            catch (Exception ex)
            {
                errorCheckPlayer(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                   MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        /// <summary>
        /// A Method used for displaying boundary errors
        /// </summary>
        /// <param name="Class"></param>
        /// <param name="Method"></param>
        /// <param name="Message"></param>
        #region Error Handling
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

        #endregion Error Handling
        #endregion Attributes
    }
}

