using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment6_part1_JRL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Main window is named Airline Flight Reservation System 
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes
        /// <summary>
        /// create the flight object to access the flight class
        /// </summary>
        Flight flight = new Flight();
        /// <summary>
        /// a list using stack panel to simulate the flight seats
        /// </summary>
        List<StackPanel> seats;
        /// <summary>
        /// an int variable to store the current seat selected by the user
        /// </summary>
        int currentSeatSelected = 1;
        /// <summary>
        /// a string variable to store the name of the flight
        /// </summary>
        string flightName;
        #endregion
        #region Constructor
        /// <summary>
        /// constructor used to instantiate the Main Window
        /// </summary>
        public MainWindow()
        {
            try
            {
                InitializeComponent();

                //seats = new List<StackPanel> { spnl1, spnl2, spnl3, spnl4, spnl5,
                //    spnl6, spnl7, spnl8, spnl9, spnl10, spnl11, spnl12, spnl13,
                //    spnl14, spnl15, spnl16, spnl17, spnl18, spnl19, spnl20, spnl21,
                //    spnl22, spnl23, spnl24 };

                int Ret = 0;
                DataSet ds = flight.getTableContents("Flight", ref Ret);

                for (int i = 0; i < Ret; ++i)
                {
                    cboChooseFlight.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
                }

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
        /// A method to handle when the user selects a flight from the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flightSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox cBox = (ComboBox)sender;
                spFlights.Visibility = Visibility.Visible;
                cboChoosePassenger.IsEnabled = true;
                flightName = cBox.SelectedItem.ToString();
                int Ret = 0;
                // update the label for Flight Number when a flight is chosen from combo box
                if (cBox.SelectedIndex == 0)
                {
                    lblFlightNumber.Content = "Flight: F737";
                    lblFlightNumber.Visibility = Visibility.Visible;

                    seats = new List<StackPanel> { spnl1, spnl2, spnl3, spnl4, spnl5,
                    spnl6, spnl7, spnl8, spnl9, spnl10, spnl11, spnl12, spnl13,
                    spnl14, spnl15, spnl16, spnl17, spnl18, spnl19, spnl20, spnl21,
                    spnl22, spnl23, spnl24 };

                    // reveal seats if hidden

                    spnl17.Visibility = Visibility.Visible;
                    spnl18.Visibility = Visibility.Visible;
                    spnl19.Visibility = Visibility.Visible;
                    spnl20.Visibility = Visibility.Visible;
                    spnl21.Visibility = Visibility.Visible;
                    spnl22.Visibility = Visibility.Visible;
                    spnl23.Visibility = Visibility.Visible;
                    spnl24.Visibility = Visibility.Visible;

                }
                else
                {
                    lblFlightNumber.Content = "Flight: F660";
                    lblFlightNumber.Visibility = Visibility.Visible;
                    seats = new List<StackPanel> { spnl1, spnl2, spnl3, spnl4, spnl5,
                    spnl6, spnl7, spnl8, spnl9, spnl10, spnl11, spnl12, spnl13,
                    spnl14, spnl15, spnl16 };
                    
                    // ugly hide seats 


                    spnl17.Visibility = Visibility.Collapsed;
                    spnl18.Visibility = Visibility.Collapsed;
                    spnl19.Visibility = Visibility.Collapsed;
                    spnl20.Visibility = Visibility.Collapsed;
                    spnl21.Visibility = Visibility.Collapsed;
                    spnl22.Visibility = Visibility.Collapsed;
                    spnl23.Visibility = Visibility.Collapsed;
                    spnl24.Visibility = Visibility.Collapsed;


                }
                // implement a switch case for the flight options
                switch (flightName)
                {
                    case "MIAMI F737":
                        // handle the seats
                        for (int i = 16; i < 24; ++i)
                        {
                            seats[i].Visibility = Visibility.Hidden;
                        }
                        break;
                    case "LAX F660":
                        // handle the seats
                        for (int i = 16; i < 24; ++i)
                        {
                            seats[i].Visibility= Visibility.Hidden;
                        }
                        flight.getPassengers(flightName, ref Ret);
                        break;
                    default:
                        break;
                }
                DataSet ds;
                Ret = 0;
                ds = flight.getPassengers(flightName, ref Ret);
                // access the items control and use clear()
                cboChoosePassenger.Items.Clear();
                // loop for the passengers
                // rows from table
                for (int i = 0; i < Ret; ++i)
                {
                    cboChoosePassenger.Items.Add(ds.Tables[0].Rows[i][1].ToString() + " " + ds.Tables[0].Rows[i].ItemArray[2].ToString());
                }
                Ret = 0;
                List<int> seatsFull = flight.getSeatsFull(flightName, ref Ret);
                // paint the seats to represent full or empty
                for (int i = 0; i < seats.Count; ++i)
                {
                    if (seatsFull.Contains(i + 1))
                    {
                        seats[i].Background = new SolidColorBrush(Color.FromRgb(0xF0, 0x17, 0x17));
                    }
                    else
                    {
                        seats[i].Background = new SolidColorBrush(Color.FromRgb(0x2B, 0x17, 0xF0)); 
                    }
                }
                btnAddPassenger.IsEnabled = true;
                btnChangeSeat.IsEnabled = false;
                btnDeletePassenger.IsEnabled = false;
            }
            catch (Exception ex)
            {
                errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }
        /// <summary>
        /// A method to handle when the user selects a passenger on the flight
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void passengerChooseSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBox cBox = (ComboBox)sender;

                if (cBox.SelectedItem == null)
                {
                    seats[currentSeatSelected - 1].Background = new SolidColorBrush(Color.FromRgb(0x2B, 0x17, 0xF0));
                    currentSeatSelected = 1;
                    txtPassengersSeat.Text = "";
                    return;
                }
                string passengerName = cBox.SelectedItem.ToString();

                int Ret = 0;
                int seatNum = flight.getPassengerSeat(passengerName, ref Ret);

                Ret = 0;
                List<int> seatsFull = flight.getSeatsFull(flightName, ref Ret);

                if (seatsFull.Contains(currentSeatSelected))
                {
                    seats[currentSeatSelected - 1].Background = new SolidColorBrush(Color.FromRgb(0xF0, 0x17, 0x17));
                    currentSeatSelected = 1;
                }
                else
                {
                    seats[currentSeatSelected - 1].Background = new SolidColorBrush(Color.FromRgb(0x2B, 0x17, 0xF0)); 
                }

                currentSeatSelected = seatNum;
                txtPassengersSeat.Text = "" + currentSeatSelected;

                seats[seatNum - 1].Background = new SolidColorBrush(Color.FromRgb(0x00, 0xFF, 0x00));

                btnChangeSeat.IsEnabled = true;
                btnDeletePassenger.IsEnabled = true;
            }
            catch (Exception ex)
            {
                errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// A method to handle when the user clicks the Add Passenger button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddPassenger addPassenger = new AddPassenger();
                addPassenger.ShowDialog();
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
        /// A method used to display an error from the user to the programmer
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
