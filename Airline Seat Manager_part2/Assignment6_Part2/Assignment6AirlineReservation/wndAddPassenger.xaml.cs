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

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for wndAddPassenger.xaml
    /// </summary>
    public partial class wndAddPassenger : Window
    {
        #region Attributes
        /// <summary>
        /// An object used to access MainWindow
        /// </summary>
        MainWindow mainWindow;
        /// <summary>
        /// An object used to access clsPassenger
        /// </summary>
        clsPassenger passenger;
        #endregion
        #region Constructor
        /// <summary>
        /// constructor for the add passenger window
        /// </summary>
        public wndAddPassenger(MainWindow window)
        {
            try
            {
                // pass the parameter
                mainWindow = window;
                InitializeComponent();
                passenger = new clsPassenger();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
        #region Event Handlers

        /// <summary>
        /// An event handler to only allow the user to use appropriate keys
        /// A-Z, Backspace, Delete, Enter, Numbers
        /// </summary>
        /// <param name="sender">sent object</param>
        /// <param name="e">key argument</param>
        private void txtLetterInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //Only allow letters to be entered
                if (!(e.Key >= Key.A && e.Key <= Key.Z))
                {
                    //Allow the user to use the backspace, delete, tab and enter
                    if (!(e.Key == Key.Back || e.Key == Key.Delete || e.Key == Key.Tab || e.Key == Key.Enter))
                    {
                        //No other keys allowed besides numbers, backspace, delete, tab, and enter
                        e.Handled = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// An event handler to handle when the user clicks the save button
        /// Close the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //const int MaxLength = 1;
                //if (txtFirstName.SelectionLength >= MaxLength )
                //{
                //    lblError.Content = "Name entered exceeds character limit";
                //    lblError.Visibility = Visibility.Visible;
                //    return;
                //}
                lblError.Visibility = Visibility.Collapsed;

                // store the entered information
                passenger.FirstName = txtFirstName.Text;
                passenger.LastName = txtLastName.Text;
                // call the addPassenger and store passenger
                mainWindow.AddPassenger(passenger);
                // close the window
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// An event handler to handle when the user selects the cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion
        #region Error Handling
        /// <summary>
        /// exception handler that shows the error
        /// </summary>
        /// <param name="sClass">the class</param>
        /// <param name="sMethod">the method</param>
        /// <param name="sMessage">the error message</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
        #endregion


    }
}
