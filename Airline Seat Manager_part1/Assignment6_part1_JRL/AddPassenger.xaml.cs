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

namespace Assignment6_part1_JRL
{
    /// <summary>
    /// Interaction logic for AddPassenger.xaml
    /// </summary>
    public partial class AddPassenger : Window
    {
        #region Attributes
        #endregion
        #region Constructor
        /// <summary>
        /// The constructor used for AddPassenger window
        /// </summary>
        public AddPassenger()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        #endregion
        #region Methods
        /// <summary>
        /// A method used for saving passenger information on save click
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnAddPassengerSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // close the window when submitted
                this.Close();
            }
            catch (Exception ex)
            {
                errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// A method used for quitting the Add Passenger window
        /// </summary>
        /// <param name="sender">The sender object</param>
        /// <param name="e">The event args</param>
        private void btnAddPassengerCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // close the window on quit
                this.Close();
            }
            catch (Exception ex)
            {
                errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }


        #endregion
        #region Error Handling
        /// <summary>
        /// A method used for handling errors and displaying them to the programmer
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void errorCheck(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText("C:\\" + System.AppDomain.CurrentDomain.FriendlyName + "Error.txt", Environment.NewLine + "HandleError Exception: " + e.Message);
            }
        }
        #endregion

    }
}
