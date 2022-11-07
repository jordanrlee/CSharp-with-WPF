using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Assignment6_part1_JRL
{
    /// <summary>
    /// Interaction logic for the Database class that stores data information
    /// </summary>
    public class Database
    {
        #region Attributes
        /// <summary>
        /// the connection string used for access
        /// </summary>
        private string connectString;
        #endregion
        #region Constructor
        /// <summary>
        /// A constructor used for the class Database
        /// Also used to set the connection to the database
        /// </summary>
        public Database()
        {
            try
            {
                // open ReservationSystem.mdb placed into the exe directory. (obj)
                connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\ReservationSystem.mdb";

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
        /// A Method for executing SQL commands passed to a DataSet object. 
        /// </summary>
        /// <param name="SQL"></param>
        /// <param name="RetVal"></param>
        /// <returns></returns>
        public DataSet ExecuteSQLStatement(string SQL, ref int RetVal)
        {
            try
            {
                // create a dataset
                DataSet ds = new DataSet();
                using (OleDbConnection connection = new OleDbConnection(connectString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        // opens the database connection
                        connection.Open();
                        // create a select command using the object for SQL
                        adapter.SelectCommand = new OleDbCommand(SQL, connection);
                        // set the timeout to prevent lockup
                        adapter.SelectCommand.CommandTimeout = 0;
                        // fill DataSet with information pulled
                        adapter.Fill(ds);
                    }
                }
                RetVal = ds.Tables[0].Rows.Count;
                // return the filled DataSet
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        
        /// <summary>
        /// A method for taking SQL statements and executing them.
        /// Should return a string of the SQL
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string ExecuteScalarSQL(string SQL)
        {
            try
            {
                // create a temp to hold the value in a object type
                object temp;
                using (OleDbConnection connection = new OleDbConnection(connectString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {
                        // opens the database connection
                        connection.Open();
                        // create a select command using the object for SQL
                        adapter.SelectCommand = new OleDbCommand(SQL, connection);
                        // set the timeout to prevent lockup
                        adapter.SelectCommand.CommandTimeout = 0;
                        // execute scalar for SQL command
                        temp = adapter.SelectCommand.ExecuteScalar();
                    }
                }
                if (temp == null)
                {
                    // return empty string
                    return "";
                }
                else
                {
                    // return a value obtained
                    return temp.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        
        /// <summary>
        /// A method for executing SQL statements that are not a query
        /// </summary>
        /// <param name="SQL"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int ExecuteNonQuery(string SQL)
        {
            try
            {
                // create row number variable
                int rowNum;
                using (OleDbConnection connection = new OleDbConnection(connectString))
                {
                    // opens the database connection
                    connection.Open();
                    // create a select command using the object for SQL
                    OleDbCommand command = new OleDbCommand(SQL, connection);
                    // set the timeout to prevent lockup
                    command.CommandTimeout = 0;
                    // use the non query SQL command
                    rowNum = command.ExecuteNonQuery(); 
                }
                // return rows that were altered
                return rowNum;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        
        #endregion
        #region Error Handling
        /// <summary>
        /// A method used for displaying an error to the programmer
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
