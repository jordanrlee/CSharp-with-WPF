using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class clsItemsInfo
    {
        #region Attributes
        #endregion

        #region Contructor
        #endregion

        #region Methods
        /// <summary>
        /// Create and instantiate the clsItemsSQL object
        /// used for accessing the database (access)
        /// </summary>
        public clsItemsSQL ItemsSQL = new clsItemsSQL();
        /// <summary>
        /// Use the clsItemsSQL to retrieve the list of items from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public DataSet GetItems()
        {
            try
            {
                // set a default value
                var iRetVal = 0;
                // store items obtained
                var query = ItemsSQL.GetItems();
                var dataset = ItemsSQL.ExecuteSQLStatement(query, ref iRetVal);

                // return the values gathered from SQL statement and database
                return dataset;
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A method to use the clsItemsSQL to add a new item to the existing database
        /// </summary>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <exception cref="Exception"></exception>
        public void AddItems(string description, string price)
        {
            try
            {
                var query = ItemsSQL.AddItems(description, price);
                ItemsSQL.ExecuteScalarSQL(query);
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A method to use clsItemsSQL to change an item from the existing database
        /// changes ID, Description, Price
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <exception cref="Exception"></exception>
        public void ChangeItems(string id, string description, string price)
        {
            try
            {
                var query = ItemsSQL.ChangeItems(id, description, price);
                ItemsSQL.ExecuteScalarSQL(query);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                   MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }
        /// <summary>
        /// A method to use the class clsItemsSQL to delete an item from the existing database
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="Exception"></exception>
        public void DeleteItems(string id)
        {
            try
            {
                var query = ItemsSQL.DeleteItems(id);
                ItemsSQL.ExecuteScalarSQL(query);
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }
        /// <summary>
        /// A method to access the clsItemsSQL class and check if there is an item
        /// in any invoice in the existing database. Return a true/false.
        /// </summary>
        /// <param name="itemid"></param>
        /// <returns></returns>
        public bool checkItemsInInvoice(string itemid)
        {
            try
            {
                // check
                var query = ItemsSQL.countInvoiceItems(itemid);
                // SQL
                var response = ItemsSQL.ExecuteScalarSQL(query);
                // return the count (any amount)
                var count = Convert.ToInt32(response);
                // if there is any item in any invoice
                if (count != 0)
                {
                    return true;
                }
                // otherwise
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }            
        }
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
