using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6AirlineReservation
{
    /// <summary>
    /// Interaction logic for the class clsFlight
    /// </summary>
    public class clsFlight
    {
        #region Attributes
        #endregion
        #region Constructor
        #endregion
        #region Methods
        /// <summary>
        /// A getter/setter for obtaining the Flight ID
        /// </summary>
        public int FlightID { get; set; }

        /// <summary>
        /// A getter/setter for obtaining the Flight Number
        /// </summary>
        public int FlightNum { get; set; }

        /// <summary>
        /// A getter/setter for obtaining the Flight Type (which flight)
        /// </summary>
        public string FlightType { get; set; }

        /// <summary>
        /// Creates a string version of the FlightNum and FlightType
        /// Saves time, converts both by using ToString()
        /// </summary>
        /// <returns>String for flight</returns>
        public override string ToString()
        {
            try
            {
                return FlightNum + " " + FlightType;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion



    }
}
