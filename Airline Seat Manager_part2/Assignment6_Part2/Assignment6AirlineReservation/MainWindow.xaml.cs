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

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes
        /// <summary>
        /// An object used to access the wndAddPassenger window
        /// </summary>
        wndAddPassenger wndAddPass;
        /// <summary>
        /// an object used to access clsFlightLogic
        /// </summary>
        clsFlightLogic flightLogic;
        /// <summary>
        /// A list of seats 
        /// </summary>
        List<Label> seats;
        /// <summary>
        /// a string of the current flightID
        /// </summary>
        string currentFlightID;
        /// <summary>
        /// an object to represent the currently selected passenger
        /// </summary>
        clsPassenger selectedPassenger;
        /// <summary>
        /// an object to add a passenger
        /// </summary>
        clsPassenger addPassenger;
        /// <summary>
        /// A boolean default for the seat being changed
        /// </summary>
        bool changeSeat = false;
        /// <summary>
        /// a boolean default for adding a passenger to the flight
        /// </summary>
        bool addingPassenger = false;
        #region Brush colors
        // for simplicity in calling the colors for the flight

        /// <summary>
        /// The Red color brush
        /// </summary>
        SolidColorBrush Red;

        /// <summary>
        /// The Green color brush
        /// </summary>
        SolidColorBrush Green;

        /// <summary>
        /// The Blue color brush
        /// </summary>
        SolidColorBrush Blue;

        #endregion
        #endregion

        #region Constructor
        /// <summary>
        /// The constructor for MainWindow
        /// </summary>
        public MainWindow()
        {
            try
            {
                // create Red
                Red = new SolidColorBrush(Color.FromRgb(253, 0, 0));
                // create Green
                Green = new SolidColorBrush(Color.FromRgb(0, 253, 0));
                // create Blue
                Blue = new SolidColorBrush(Color.FromRgb(0, 35, 253));


                InitializeComponent();
                Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;

                // fixed
                // instantiate flightLogic object
                flightLogic = new clsFlightLogic();
                // fill list with all flights
                List<clsFlight> flights = flightLogic.GetAllFlights();
                // for each
                flights.ForEach(flight => cbChooseFlight.Items.Add(flight));

            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// An event handler to handle the user choosing a flight by using Selection Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChooseFlight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            { 
                // fixed
                cbChoosePassenger.Items.Clear();

                currentFlightID = ((clsFlight)cbChooseFlight.SelectedItem).FlightID.ToString();
                cbChoosePassenger.IsEnabled = true;
                gPassengerCommands.IsEnabled = true;
                cmdChangeSeat.IsEnabled = false;
                cmdDeletePassenger.IsEnabled = false;

                if (currentFlightID == "1") // first flight
                {
                    // create the seats in flight 1
                    seats = new List<Label>{    SeatA1, SeatA2, SeatA3, SeatA4, SeatA5,
                                                SeatA6, SeatA7, SeatA8, SeatA9, SeatA10,
                                                SeatA11, SeatA12, SeatA13, SeatA14, SeatA15,
                                                };
                    CanvasA380.Visibility = Visibility.Visible;
                    Canvas767.Visibility = Visibility.Hidden;
                }
                else
                {
                    // create the seats in flight 2
                    seats = new List<Label>{    Seat1, Seat2, Seat3, Seat4, Seat5,
                                                Seat6, Seat7, Seat8, Seat9, Seat10,
                                                Seat11, Seat12, Seat13, Seat14, Seat15,
                                                Seat16, };
                    Canvas767.Visibility = Visibility.Visible;
                    CanvasA380.Visibility = Visibility.Hidden;
                }
                // call the method to update the database and the user display
                UpdatePassengersList();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// An event handler to handle when the user selects a passenger from the combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbChoosePassenger_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // seat and passenger selected
                cmdChangeSeat.IsEnabled = true;
                cmdDeletePassenger.IsEnabled = true;

                // check for null
                if (selectedPassenger != null)
                {
                    // handle seat
                    seats[selectedPassenger.SeatNumber - 1].Background = Red;
                }
                // selected seat or item
                selectedPassenger = (clsPassenger)cbChoosePassenger.SelectedItem;
                // check again for null
                if (selectedPassenger != null)
                {
                    // seat selected
                    seats[selectedPassenger.SeatNumber - 1].Background = Green;
                    // update the seat
                    lblPassengersSeatNumber.Content = selectedPassenger.SeatNumber;
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// An event handler for when the user clicks the Add Passenger button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdAddPassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                wndAddPass = new wndAddPassenger(this);
                wndAddPass.ShowDialog();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// An event handler to handle when the user selects a seat from the flight list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void lblSeat_Click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                // cast 
                Label seat = (Label)sender;
                // change seat
                if (changeSeat)
                {
                    // store seat information into clickedPassenger
                    clsPassenger clickedPassenger = flightLogic.GetPassengerInSeat(currentFlightID, seat.Content.ToString());
                    // check if null
                    if (clickedPassenger == null)
                    {
                        if (addingPassenger)
                        {
                            flightLogic.InsertPassenger(currentFlightID, addPassenger);

                            addingPassenger = false;

                            flightLogic.UpdatePassengerSeatNumber(currentFlightID, addPassenger.PassengerID.ToString(), seat.Content.ToString());
                        }
                        else
                        {
                            flightLogic.UpdatePassengerSeatNumber(currentFlightID, selectedPassenger.PassengerID.ToString(), seat.Content.ToString());
                        }
                        // use exit change seat method to handle the GUI
                        ExitChangeSeatGUI();
                        // store into selectedPassenger
                        selectedPassenger = flightLogic.GetPassengerInSeat(currentFlightID, seat.Content.ToString());
                        // update display
                        UpdatePassengersList();

                        lblSeat_Click(sender, null);
                    }
                }
                // otherwise
                else
                {
                    clsPassenger clickedPassenger = flightLogic.GetPassengerInSeat(currentFlightID, seat.Content.ToString());
                    if (clickedPassenger != null)
                    {
                        cbChoosePassenger.SelectedIndex = cbChoosePassenger.Items.IndexOf(clickedPassenger);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// An event handler to handle when the user selects the Change Seat Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdChangeSeat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbChoosePassenger.Text))
                {
                    return;
                }
                // call change seat mode for GUI handling
                EnterChangeSeatGUI();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// An event handler to handle when the user clicks the Delete Passenger button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDeletePassenger_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbChoosePassenger.Text))
                {
                    return;
                }
                // delete the passenger and information by using flightLogic 
                flightLogic.DeletePassenger(currentFlightID, selectedPassenger.PassengerID.ToString());
                // set to null
                selectedPassenger = null;
                // update the display
                UpdatePassengersList();
            }
            catch (Exception ex)
            {
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                    MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// A method to handle the transition for adding a passenger
        /// </summary>
        /// <param name="passenger"></param>
        /// <exception cref="Exception"></exception>
        public void AddPassenger(clsPassenger passenger)
        {
            try
            {
                // store passenger 
                addPassenger = passenger;
                // set addingPassenger to true to begin 
                addingPassenger = true;
                // select the seat from GUI
                EnterChangeSeatGUI();
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A method to simulate GUI selection for changing a seat
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void EnterChangeSeatGUI()
        {
            try
            {
                // set the change seat to true so we can change
                changeSeat = true;
                // set focus by visually prompting user to select a seat
                // disallow selections of other interfaces until a seat is chosen
                cmdChangeSeat.IsEnabled = false;
                cmdAddPassenger.IsEnabled = false;
                cmdDeletePassenger.IsEnabled = false;
                cbChooseFlight.IsEnabled = false;
                cbChoosePassenger.IsEnabled = false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A method to exit the GUI simulation
        /// </summary>
        private void ExitChangeSeatGUI()
        {
            try
            {
                // return change seat state to false
                changeSeat = false;
                // allow user to select all interface again
                cmdChangeSeat.IsEnabled = true;
                cmdAddPassenger.IsEnabled = true;
                cmdDeletePassenger.IsEnabled = true;
                cbChooseFlight.IsEnabled = true;
                cbChoosePassenger.IsEnabled = true;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A method to update the passenger list and paint the seats
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void UpdatePassengersList()
        {
            try
            {
                cbChoosePassenger.Items.Clear();
                // store the flight's passenger into list
                List<clsPassenger> passengers = flightLogic.GetFlightPassengers(currentFlightID);
                // add 
                passengers.ForEach(passenger => cbChoosePassenger.Items.Add(passenger));
                // handle the seats in the flight for the changes
                // using a for each
                seats.ForEach(seat =>
                {
                    // create the seats full object
                    List<int> seatsFull = new List<int>();
                    // fill the list with the full seats
                    passengers.ForEach(passenger => seatsFull.Add(passenger.SeatNumber));
                    // paint the seats conditionally
                    if (seatsFull.Contains(Convert.ToInt32(seat.Content)))
                    {
                        seat.Background = Red;
                    }
                    else
                    {
                        seat.Background = Blue;
                    }
                });
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion

        #region Error Handling

        /// <summary>
        /// A method used for Error Handling
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (System.Exception ex)
            {
                System.IO.File.AppendAllText(@"C:\Error.txt", Environment.NewLine + "HandleError Exception: " + ex.Message);
            }
        }
        #endregion
    }
}
