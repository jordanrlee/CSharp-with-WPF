using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment6_part1_JRL
{
    /// <summary>
    /// interaction logic for the class Flight
    /// </summary>
    class Flight
    {

        #region Attributes
        /// <summary>
        /// create a object of class Database to store query information
        /// </summary>
        Database data = new Database();
        #endregion
        #region Constructor
        /// <summary>
        ///  the constructor used for Flight class
        /// </summary>
        public Flight()
        {
            // default
        }
        #endregion
        #region Methods
        /// <summary>
        /// A Method to return the passenger seat that is reserved on the flight
        /// </summary>
        /// <param name="table"></param>
        /// <param name="Ret"></param>
        /// <returns></returns>
        public DataSet getTableContents(string table, ref int Ret)
        {
            DataSet ds = null;

            try
            {
                Ret = 0;
                ds = data.ExecuteSQLStatement(String.Format("SELECT * FROM {0}", table), ref Ret);
            }
            catch (Exception ex)
            {
                errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            return ds;
        }
        /// <summary>
        /// A method to obtain the flight identification (ID) by using the name and type of flight
        /// </summary>
        /// <param name="flightName"></param>
        /// <returns></returns>
        public int getFlightID(string flightName)
        {
            DataSet ds = null;
            try
            {
                int Ret = 0;
                ds = data.ExecuteSQLStatement(string.Format("SELECT Flight_ID FROM Flight WHERE Flight_Number = '{0}';", flightName.Substring(0, 3)), ref Ret);
            }
            catch (Exception ex)
            {
                errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

            // then
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }
        /// <summary>
        /// A method to retrieve the passengers that have a reservation on the flight
        /// </summary>
        /// <param name="flightName"></param>
        /// <param name="Ret"></param>
        /// <returns></returns>
        public DataSet getPassengers(string flightName, ref int Ret)
        {
            DataSet ds = null;

            try
            {
                Ret = 0;
                int flightID = getFlightID(flightName);
                ds = data.ExecuteSQLStatement(string.Format("SELECT p.Passenger_ID, First_Name, Last_Name FROM Passenger p INNER JOIN Flight_Passenger_Link l ON p.Passenger_ID = l.Passenger_ID WHERE Flight_ID = {0};", flightID), ref Ret);
            }
            catch (Exception ex)
            {
                errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            return ds;
        }
        /// <summary>
        /// A method to retrieve the passenger seat number from the flight
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Ret"></param>
        /// <returns></returns>
        public int getPassengerSeat(string name, ref int Ret)
        {
            DataSet ds = null;
            try
            {
                Ret = 0;
                ds = data.ExecuteSQLStatement(string.Format("SELECT Seat_Number FROM Flight_Passenger_Link l INNER JOIN Passenger p ON l.Passenger_ID = p.Passenger_ID WHERE First_Name & ' ' & Last_Name = '{0}'", name), ref Ret);
            }
            catch (Exception ex)
            {
                errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            // return the seat number information
            return Convert.ToInt32(ds.Tables[0].Rows[0][0]);
        }
        /// <summary>
        /// A method to retrieve the seats that are full/unavailable
        /// </summary>
        /// <param name="flightName"></param>
        /// <param name="Ret"></param>
        /// <returns></returns>
        public List<int> getSeatsFull(string flightName, ref int Ret)
        {
            List<int> results = new List<int>();
            try
            {
                DataSet ds;
                Ret = 0;
                ds = data.ExecuteSQLStatement(string.Format("SELECT Seat_Number FROM Flight_Passenger_Link WHERE Flight_ID = {0}", getFlightID(flightName)), ref Ret);
                // create a loop
                for (int i = 0; i < Ret; ++i)
                {
                    results.Add(Convert.ToInt32(ds.Tables[0].Rows[i][0]));
                }
            }
            catch (Exception ex)
            {
                errorCheck(MethodInfo.GetCurrentMethod().DeclaringType.Name,
                            MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
            return results;
        }
        #endregion
        #region Error Handling
        /// <summary>
        /// A method used to handle errors throws by the system
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
