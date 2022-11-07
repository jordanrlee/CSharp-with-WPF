using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for the class clsFlightLogic
    /// </summary>
    public class clsFlightLogic
    {

        #region Attributes
        /// <summary>
        /// Create an object to access the clsDataAccess class
        /// name it clsData
        /// </summary>
        clsDataAccess clsData;
        /// <summary>
        /// Create an object to access the clsSQL class
        /// name it CallSQL
        /// </summary>
        clsSQL CallSQL;
        #endregion
        #region Constructor
        /// <summary>
        /// The constructor used for clsFlightLogic
        /// </summary>
        /// <exception cref="Exception"></exception>
        public clsFlightLogic()
        {
            try
            {
                // instantiate the objects for each class
                clsData = new clsDataAccess();
                CallSQL = new clsSQL(); 
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
        #region Methods
        /// <summary>
        /// create a list of flights (objects) by accessing all of the flights in the Database
        /// </summary>
        /// <returns> flights </returns>
        public List<clsFlight> GetAllFlights()
        {
            // create & instantiate the list object
            List<clsFlight> flights = new List<clsFlight>();
            try
            {

                // instantiate the DataSet
                DataSet ds = new DataSet();
                int iRet = 0;
                // store the SQL into ds
                ds = clsData.ExecuteSQLStatement(CallSQL.GetAllFlights(), ref iRet);

                for (int i = 0; i < iRet; ++i)
                {
                    // output the results from database
                    clsFlight flight = new clsFlight();
                    flight.FlightID = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    flight.FlightNum = Convert.ToInt32(ds.Tables[0].Rows[i][1].ToString());
                    flight.FlightType = ds.Tables[0].Rows[i][2].ToString();
                    flights.Add(flight);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return flights;
        }
        /// <summary>
        /// A method to get the passenger information and display them
        /// </summary>
        /// <param name="flightID"></param>
        /// <returns> passengers </returns>
        /// <exception cref="Exception"></exception>
        public List<clsPassenger> GetFlightPassengers(string flightID)
        {
            // create and instantiate the list object 
            List<clsPassenger> passengers = new List<clsPassenger>();

            try
            {
                // create and instantiate dataset
                DataSet ds = new DataSet();
                int iRet = 0;
                // store the SQL statement
                ds = clsData.ExecuteSQLStatement(CallSQL.GetAllPassengersInFlight(flightID), ref iRet);

                for (int i = 0; i < iRet; ++i)
                {
                    // output the results from the Database
                    clsPassenger passenger = new clsPassenger();
                    passenger.PassengerID = Convert.ToInt32(ds.Tables[0].Rows[i][0].ToString());
                    passenger.FirstName = ds.Tables[0].Rows[i][1].ToString();
                    passenger.LastName = ds.Tables[0].Rows[i][2].ToString();
                    passenger.SeatNumber = Convert.ToInt32(ds.Tables[0].Rows[i][3].ToString());
                    passengers.Add(passenger);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return passengers;
        }
        /// <summary>
        /// A method to get the Passenger information that is in a specific seat
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="seatNum"></param>
        /// <returns> passenger </returns>
        /// <exception cref="Exception"></exception>
        public clsPassenger GetPassengerInSeat(string flightID, string seatNum)
        {
            // create and instantiate the passenger object
            clsPassenger passenger = new clsPassenger();

            try
            {
                // create and instantiate the dataset
                DataSet ds = new DataSet();
                int iRet = 0;
                // store the SQL statement
                ds = clsData.ExecuteSQLStatement(CallSQL.GetPassengersFromSeat(flightID, seatNum), ref iRet);

                // if the table is empty
                if (ds.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                // output the passenger results
                passenger.PassengerID = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                passenger.FirstName = ds.Tables[0].Rows[0][1].ToString();
                passenger.LastName = ds.Tables[0].Rows[0][2].ToString();
                passenger.SeatNumber = Convert.ToInt32(seatNum);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return passenger;
        }
        /// <summary>
        /// A method to update the passenger information in the specific seat
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passengerID"></param>
        /// <param name="seatNum"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool UpdatePassengerSeatNumber(string flightID, string passengerID, string seatNum)
        {
            // set a default for seatChanged
            bool seatChanged = false;

            try
            {

                seatChanged = (GetPassengerInSeat(flightID, seatNum) == null) ? true : false;

                if (seatChanged)
                {
                    clsData.ExecuteNonQuery(CallSQL.UpdatePassengerSeat(flightID, passengerID, seatNum));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return seatChanged;
        }
        /// <summary>
        /// A method to add a passenger to the specific flight 
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passenger"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool InsertPassenger(string flightID, clsPassenger passenger)
        {
            try
            {
                clsData.ExecuteNonQuery(CallSQL.CreatePassenger(passenger));

                passenger.PassengerID = Convert.ToInt32(GetPassengerID(passenger.FirstName, passenger.LastName));

                clsData.ExecuteNonQuery(CallSQL.CreateFlightPassengerLink(flightID, passenger, 0));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return true;
        }
        /// <summary>
        /// A method to get the passenger's full name by using the flightID
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetPassengerID(string first, string last)
        {
            DataSet ds = new DataSet();
            int iRet = 0;

            try
            {
                ds = clsData.ExecuteSQLStatement(CallSQL.GetPassengerID(first, last), ref iRet);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            // return the results
            return ds.Tables[0].Rows[0][0].ToString();
        }
        public void DeletePassenger(string flightID, string passengerID)
        {
            try
            {
                DataSet ds = new DataSet();
                clsData.ExecuteNonQuery(CallSQL.DeleteFlightPassengerLink(flightID, passengerID));;

                int iRet = 0;

                ds = clsData.ExecuteSQLStatement(CallSQL.GetFlightLinksForPassenger(passengerID), ref iRet);

                if (ds.Tables[0].Rows.Count == 0)
                {
                    clsData.ExecuteNonQuery(CallSQL.DeletePassenger(passengerID));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
    }
}
