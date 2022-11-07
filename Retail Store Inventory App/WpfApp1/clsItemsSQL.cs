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

namespace WpfApp1
{
    public class clsItemsSQL
    {
        #region Attributes
        /// <summary>
        /// The connection string used for the database
        /// </summary>
        private string sConnectionString;

        #endregion

        #region Contructor
        /// <summary>
        /// The contructor for itemsSQL
        /// </summary>
        public clsItemsSQL()
        {
            try
            {
                sConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data source= " + Directory.GetCurrentDirectory() + "\\Invoice.mdb";

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }
        #endregion

        #region Methods
        #region Database Methods
        /// <summary>
        /// The SQL method that takes a SQL statement passed in and executes it
        /// using the DataSet. Number of rows are returned from the query are
        /// placed into iRetVal.
        /// </summary>
        /// <param name="sSQL"></param>
        /// <param name="iRetVal"></param>
        /// <returns></returns>
        public DataSet ExecuteSQLStatement(string sSQL, ref int iRetVal)
        {
            try
            {
                //Create a new DataSet
                DataSet ds = new DataSet();

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        //Open the connection to the database
                        conn.Open();

                        //Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Fill up the DataSet with data
                        adapter.Fill(ds);
                    }
                }

                //Set the number of values returned
                iRetVal = ds.Tables[0].Rows.Count;

                //return the DataSet
                return ds;
            }
            catch (Exception ex)
            {
                // throw the exception error
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A method for taking an SQL statement and executing it on the database.
        /// The information passed will be returned as a string
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public string ExecuteScalarSQL(string sSQL)
        {
            try
            {
                //Holds the return value
                object obj;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter())
                    {

                        //Open the connection to the database
                        conn.Open();

                        //Add the information for the SelectCommand using the SQL statement and the connection object
                        adapter.SelectCommand = new OleDbCommand(sSQL, conn);
                        adapter.SelectCommand.CommandTimeout = 0;

                        //Execute the scalar SQL statement
                        obj = adapter.SelectCommand.ExecuteScalar();
                    }
                }

                //See if the object is null
                if (obj == null)
                {
                    //Return empty if so
                    return "";
                }
                // if test pass
                else
                {
                    //Return the value
                    return obj.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A method that takes the SQL statement that is NON-QUERY type and
        /// executes it on the database.
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int ExecuteNonQuery(string sSQL)
        {
            try
            {
                //Number of rows affected
                int iNumRows;

                using (OleDbConnection conn = new OleDbConnection(sConnectionString))
                {
                    //Open the connection to the database
                    conn.Open();

                    //Add the information for the SelectCommand using the SQL statement and the connection object
                    OleDbCommand cmd = new OleDbCommand(sSQL, conn);
                    cmd.CommandTimeout = 0;

                    //Execute the non query SQL statement
                    iNumRows = cmd.ExecuteNonQuery();
                }

                //return the number of rows affected
                return iNumRows;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        #endregion
        #region SQL Statements
        /// <summary>
        /// A Query to return all items stored in the database.
        /// SELECT *
        /// FROM Items ;
        /// </summary>
        /// <returns></returns>
        public string GetItems()
        {
            try
            {
                return "SELECT * FROM ItemDesc";
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }

        }
        /// <summary>
        /// A query to add an item to the database.
        /// INSERT INTO ITEMS (Description, Price)
        /// VALUES (Description, Price)
        /// </summary>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public string AddItems(string description, string price)
        {
            try
            {
                return $"INSERT INTO ItemDesc (ItemDesc, Cost) VALUES ('{description}', '{price}')";
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }
        /// <summary>
        /// A query to change an item stored in the database
        /// UPDATE Items
        /// SET Description = Description,
        /// Price = Price
        /// WHERE ID = (ID);
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public string ChangeItems(string id, string description, string price)
        {
            try
            {
                return $"UPDATE ItemDesc SET ItemDesc = '{description}', Cost = {price} WHERE ItemCode = '{id}'";

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }

        }
        /// <summary>
        /// A query to delete an item stored in the database
        /// DELETE FROM Items
        /// WHERE ID = "";
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string DeleteItems(string id)
        {
            try
            {
                return $"DELETE FROM ItemDesc WHERE ItemCode = '{id}'";

            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }
        /// <summary>
        /// A query to return a count of all items in the database
        /// SELECT COUNT(ItemId)
        /// FROM InvoiceItems
        /// WHERE ItemId = "";
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string countInvoiceItems(string id)
        {
            try
            {
                return $"SELECT COUNT(InvoiceNum) FROM LineItems WHERE ItemCode = '{id}'";
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
