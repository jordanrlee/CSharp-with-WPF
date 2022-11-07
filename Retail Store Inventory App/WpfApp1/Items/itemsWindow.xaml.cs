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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for itemsWindow.xaml
    /// </summary>
    public partial class itemsWindow : Window
    {
        #region Attributes
        /// <summary>
        /// create an object to access clsItemsInfo
        /// </summary>
        private clsItemsInfo ItemsInfo;
        /// <summary>
        /// A string variable to store the item ID
        /// </summary>
        private string selectedItemID;
        /// <summary>
        /// a default boolean set to determine if the row in DataSet
        /// is selected.
        /// </summary>
        private bool isDataRowSelected = false;
        #endregion

        #region Contructor
        public itemsWindow()
        {
            InitializeComponent();
            ItemsInfo = new clsItemsInfo();
            GetItemFromDataSet(); // method
        }
        #endregion

        #region Methods
        /// <summary>
        /// A method to access the Items database and fill
        /// the datagrid with the database information
        /// </summary>
        private void GetItemFromDataSet()
        {
            try
            {
                var dataset = ItemsInfo.GetItems();
            }
            catch (Exception ex)
            { 
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// A method to determine if the textboxes have information in them
        /// check for anything (whitespace or null)
        /// if no information, display an error
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool AllTextBoxHasContent()
        {
            try
            {
                // default values
                var isItemValid = false;
                var isPriceValid = false;
                // idea 1
                //string errorDescription = "No item selected or valid description. ";
                //string errorPrice = "No price selected or valid price. ";
                //string errorNothingSelected = "No values selected. ";
                
                // if both text boxes are empty
                //if (string.IsNullOrWhiteSpace(tBoxDescription.Text) && string.IsNullOrWhiteSpace(tBoxPrice.Text) )
                //{
                //    // display all errors in tboxError (text box)
                //    tBoxError.Text = errorNothingSelected + Environment.NewLine +
                //        errorPrice + Environment.NewLine + errorDescription;
                //}
                // if the Description TextBox is empty

                // idea 2
                if (string.IsNullOrWhiteSpace(tBoxDescription.Text))
                    lblDescError.Visibility = Visibility.Visible;
                // otherwise
                else
                {
                    lblDescError.Visibility = Visibility.Hidden;
                    isItemValid = true;
                }
                // if the Price TextBox is empty
                if (!decimal.TryParse(tBoxPrice.Text, out decimal price))
                    lblPriceError.Visibility = Visibility.Visible;
                // otherwise
                else
                {
                    lblPriceError.Visibility = Visibility.Hidden;
                    isPriceValid = true;
                }
                // return the boolean value for each
                return (isItemValid && isPriceValid);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// An event handler to handle the content of the DataGrid.
        /// Provides information on ID, DESCRIPTION, PRICE, by using the selected row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void SelectionChanged_dGridItems(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                isDataRowSelected = true;
                var ItemSelected = (DataRowView)dGridItems.SelectedItem;

                // check if item selected
                if (ItemSelected == null)
                {
                    // clear out the boxes because nothing selected yet
                    isDataRowSelected = false;
                    tBoxDescription.Text = "";
                    tBoxPrice.Text = "";
                    return;
                }
                // get the ID from the selection
                var id = (int)ItemSelected.Row.ItemArray[0];
                // get the description from the selection
                var description = (string)ItemSelected.Row.ItemArray[1];
                // get the price from the selection (decimal)
                var price = (decimal)ItemSelected.Row.ItemArray[2];
                // display the ID, Description, and Price
                selectedItemID = id.ToString();
                tBoxDescription.Text = description;
                tBoxPrice.Text = price.ToString();
            }


            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// An event handler for when the user clicks the "Add" button in the item window.
        /// The button will use clsItemsInfo to add an item to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void click_AddButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (AllTextBoxHasContent())
                {
                    ItemsInfo.AddItems(tBoxDescription.Text, tBoxPrice.Text);
                    GetItemFromDataSet();
                    // handle the text boxs
                    tBoxDescription.Text = "";
                    tBoxPrice.Text = "";
                }
            }
            catch (Exception ex)
            {

                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// An event handler for when the user clicks the "Change" button.
        /// The button will update a selected item from the database using clsItemsInfo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void click_ChangeButton(object sender, RoutedEventArgs e)
        {
            try
            {
                // possible issue ( which method to call first?)
                if (DataRowSelected() && AllTextBoxHasContent())
                {
                    ItemsInfo.ChangeItems(selectedItemID, tBoxDescription.Text, tBoxPrice.Text);
                    GetItemFromDataSet();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// An event handler for when the user clicks the "Delete" button
        /// the handler will use the clsItemsInfo class to delete an item
        /// from the existing database using the Item ID.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void click_DeleteButton(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DataRowSelected() && DeleteItemCheck())
                {
                    ItemsInfo.DeleteItems(selectedItemID);
                    GetItemFromDataSet();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// A method to check if a row has been selected by the user.
        /// Displays an error label if no item selected.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool DataRowSelected()
        {
            try
            {
                // if no item has been selected at all
                if (isDataRowSelected == false)
                {
                    lblAllError.Visibility = Visibility.Visible;
                }
                // otherwise
                else
                {
                    lblAllError.Visibility = Visibility.Hidden;
                }
                return isDataRowSelected;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        private bool DeleteItemCheck()
        {
            try
            {
                // possible issue. selectedItemID should be the item id maybe.
                var SafeToDelete = ItemsInfo.checkItemsInInvoice(selectedItemID);
                if (SafeToDelete)
                {
                    lblNoDeleteError.Visibility = Visibility.Visible;
                }
                else
                {
                    lblNoDeleteError.Visibility= Visibility.Hidden;
                }
                // return the safe to delete boolean value
                // item is safe to delete from database
                return !SafeToDelete;
            }
            catch (Exception ex)
            { 
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." +
                                                    MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
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
