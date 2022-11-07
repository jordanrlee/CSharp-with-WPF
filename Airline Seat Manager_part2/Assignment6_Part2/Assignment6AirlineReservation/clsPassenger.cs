using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for the class clsPassenger
    /// </summary>
    public class clsPassenger
    {
        #region Attributes

        /// <summary>
        /// A getter/setter to get the Passenger's ID
        /// </summary>
        public int PassengerID { get; set; }

        /// <summary>
        /// A getter/setter to get the passenger's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// A getter/setter to get the passengers last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// A getter/setter to get the seat number
        /// </summary>
        public int SeatNumber { get; set; }

        #endregion
        #region Constructor
        #endregion
        #region Methods

        /// <summary>
        /// An override used to return the passenger's full name as a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            try
            {
                return FirstName + " " + LastName;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }
        /// <summary>
        /// An override used to compare two passenger objects to see if they are the same
        /// Compare Passenger obj 1 and Passenger obj 2
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            try
            {
                if (obj is clsPassenger)
                {
                    // use a cast
                    clsPassenger other = (clsPassenger)obj;
                    return this.PassengerID == other.PassengerID; // equivelent 
                }
                // otherwise
                return false;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }

        }
        #endregion
        #region Event Handlers
        #endregion
        #region Error Handling
        #endregion
    }
}
