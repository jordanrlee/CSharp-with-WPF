using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// interaction logic for the class clsSQL
    /// </summary>
    public class clsSQL
    {
        #region Attributes
        #endregion
        #region Constructor
        #endregion
        #region Methods
        #region SQL Queries
        /// <summary>
        /// A query to select flights from the database
        /// </summary>
        /// <returns></returns>
        public string GetAllFlights()
        {
            // SELECT Flight_ID, Flight_Number, Aircraft_Type
            // FROM FLIGHT

            try
            {
                string sSQL = "SELECT Flight_ID, Flight_Number, Aircraft_Type FROM FLIGHT";
                return sSQL;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }

        }
        /// <summary>
        /// A query to get all the passengers in the flight from the database
        /// </summary>
        /// <param name="flightID"></param>
        /// <returns></returns>
        public string GetAllPassengersInFlight(string flightID)
        {

            // SELECT (Passenger.Passenger_ID, First_Name, Last_Name, FPL.Seat_Number)
            // FROM Passenger, Flight_Passenger_Link FPL
            // WHERE Passenger.Passenger_ID = FPL.Passenger_ID AND Flight_ID = 0;

            try
            {
                string sSQL = string.Format("SELECT Passenger.Passenger_ID, First_Name, Last_Name, FPL.Seat_Number " +
              "FROM Passenger, Flight_Passenger_Link FPL " +
              "WHERE Passenger.Passenger_ID = FPL.Passenger_ID AND " +
              "Flight_ID = {0}", flightID);

                return sSQL;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        public string GetPassengersFromSeat(string flightID, string seatNum)
        {
            try
            {
                // SELECT (p.Passenger_ID, First_Name, Last_Name)
                // FROM Passenger AS p
                // INNER JOIN (Flight_Passenger_Link AS fpl) ON (p.Passenger_ID = fpl.Passenger_ID)
                // WHERE Flight_ID = 0 AND Seat_Number = 1;

                string sSQL = string.Format("SELECT p.Passenger_ID, First_Name, Last_Name " +
                "FROM Passenger AS p " +
                "INNER JOIN Flight_Passenger_Link AS fpl " +
                "ON p.Passenger_ID = fpl.Passenger_ID " +
                "WHERE Flight_ID = {0} " +
                "AND Seat_Number = '{1}'", flightID, seatNum);
                return sSQL;
            }
            catch (Exception ex)
            {

               throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A query get any flights that are linked to a specific passenger ID
        /// </summary>
        /// <param name="passengerID"></param>
        /// <returns></returns>
        public string GetFlightLinksForPassenger(string passengerID)
        {
            // SELECT (Flight_ID, Passenger_ID, Seat_Number)
            // FROM Flight_Passenger_Link
            // WHERE Passenger_ID = 0;
            try
            {
                string sSQL = string.Format("SELECT Flight_ID, Passenger_ID, Seat_Number " +
                            "FROM Flight_Passenger_Link " +
                            "WHERE Passenger_ID = {0}", passengerID);
                return sSQL;
            }
            catch (Exception ex)
            {

               throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A query to get the passenger ID from the database
        /// </summary>
        /// <param name="first"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string GetPassengerID(string first, string last)
        {
            // use a select modifier for passenger ID
            // SELECT TOP 1 Passenger_ID
            // FROM Passenger
            // WHERE First_Name like {0} AND Last_Name like {1} // index

            try
            {
                string sSQL = string.Format("SELECT TOP 1 Passenger_ID " +
                            "FROM Passenger " +
                            "WHERE First_Name like '{0}' " +
                            "AND Last_Name like '{1}'", first, last);
                return sSQL;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A query to update seat number for the passenger in the flight from database
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passengerID"></param>
        /// <param name="seatNum"></param>
        /// <returns></returns>
        public string UpdatePassengerSeat(string flightID, string passengerID, string seatNum)
        {
            // UPDATE Flight_Pasenger_Link
            // SET Seat_Number = 0
            // WHERE Passenger_ID = 1 AND Flight_ID = 2;
            try
            {
                string sSQL = string.Format("UPDATE Flight_Passenger_Link " +
                            "SET Seat_Number = {0} " +
                            "WHERE Passenger_ID = {1} " +
                            "AND Flight_ID = {2}", seatNum, passengerID, flightID);
                return sSQL;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A query to add a passenger to the database
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns></returns>
        public string CreatePassenger(clsPassenger passenger)
        {
            // INSERT INTO Passenger(First_Name, Last_Name)
            // VALUES ({0}, {1})
            
            try
            {
                string sSQL = string.Format("INSERT INTO Passenger(First_Name, Last_Name) " +
                            "VALUES('{0}', '{1}')", passenger.FirstName, passenger.LastName);
                return sSQL;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A query to link flight to the passenger and seat number
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passenger"></param>
        /// <param name="seatNum"></param>
        /// <returns></returns>
        public string CreateFlightPassengerLink(string flightID, clsPassenger passenger, int seatNum)
        {
            // INSERT INTO Flight_Passenger_Link(Flight_ID, Passenger_ID, Seat_Number)
            // VALUES 0, 1, 2 ;
            // index
            try
            {
                string sSQL = string.Format("INSERT INTO Flight_Passenger_Link(Flight_ID, Passenger_ID, Seat_Number) " +
                            "VALUES({0}, {1}, {2})", flightID, passenger.PassengerID, seatNum);
                return sSQL;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A query to delete the passenger from the flight in database by using passenger ID
        /// </summary>
        /// <param name="passengerID"></param>
        /// <returns></returns>
        public string DeletePassenger(string passengerID)
        {
            try
            {
                // DELETE FROM (Passenger)
                // WHERE Passenger_ID = 0;
                // index
                string sSQL = string.Format("DELETE FROM Passenger " +
                            "WHERE Passenger_ID = {0}", passengerID);
                return sSQL;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A query to delete the link between specified passenger ID and flight ID
        /// </summary>
        /// <param name="flightID"></param>
        /// <param name="passengerID"></param>
        /// <returns></returns>
        public string DeleteFlightPassengerLink(string flightID, string passengerID)
        {
            // DELETE FROM Flight_Passenger_Link
            // WHERE Flight_ID = 0 AND Passenger_ID = 1
            // index
            try
            {
                string sSQL =string.Format("DELETE FROM Flight_Passenger_Link " +
                            "WHERE Flight_ID = {0} " +
                            "AND Passenger_ID = {1}", flightID, passengerID);
                return sSQL;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
        #endregion

        #region Event Handlers
        #endregion
        #region Error Handling
        #endregion
    }
}
