using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpenseManagerData;

namespace ExpenseManagerDb
{
    public static class DbInteraction
    {
        static string passwordCurrent = "technicise";
        static string dbmsCurrent = "ems";
        // donor, patient, member, todo, wellwisher, event, fund, expense (insert & display), hdbb only display...

        private static MySql.Data.MySqlClient.MySqlConnection OpenDbConnection()
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;

            msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;Password=" + passwordCurrent + ";database=" + dbmsCurrent + ";persist security info=False");

            //open the connection
            if (msqlConnection.State != System.Data.ConnectionState.Open)
                msqlConnection.Open();

            return msqlConnection;
        }

        #region Excredit

        public static int DoRegisterNewExcredit(ExpenseInfo excreditDetails)
        {
            return DoRegisterNewExcreditInDb(excreditDetails);
        }

        private static int DoRegisterNewExcreditInDb(ExpenseInfo excreditDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

               

                msqlCommand.CommandText = "INSERT INTO excredit(id,date,type,description,amount) "
                                                   + "VALUES(@id,@date,@type,@description,@amount)";

                msqlCommand.Parameters.AddWithValue("@id", excreditDetails.id);
                msqlCommand.Parameters.AddWithValue("@date", excreditDetails.date);
                msqlCommand.Parameters.AddWithValue("@type", excreditDetails.type);
                msqlCommand.Parameters.AddWithValue("@description", excreditDetails.description);
                msqlCommand.Parameters.AddWithValue("@amount", excreditDetails.amount);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<ExpenseInfo> GetAllExcreditList()
        {
            return QueryAllExcreditList();
        }

        private static List<ExpenseInfo> QueryAllExcreditList()
        {
            List<ExpenseInfo> ExcreditList = new List<ExpenseInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();


            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                
                msqlCommand.CommandText = "Select * From excredit;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ExpenseInfo Excredit = new ExpenseInfo();

                    Excredit.id = msqlReader.GetString("id");
                    Excredit.date = msqlReader.GetDateTime("date");
                    Excredit.type = (ExpenseType)Enum.Parse(typeof(ExpenseType), msqlReader.GetString("type"), false);
                    Excredit.description = msqlReader.GetString("description");
                    Excredit.amount = msqlReader.GetDouble("amount");


                    ExcreditList.Add(Excredit);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return ExcreditList;

        }

        

    
        public static List<ExpenseInfo> GetDatewiseAllExcreditList(ExpenseInfo expenseInfoObj)
        {
            List<ExpenseInfo> ExcreditList = new List<ExpenseInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                
                DateTime endDatePicker = expenseInfoObj.endDate;
                DateTime startDatePicker = expenseInfoObj.date;
                TimeSpan diff = (TimeSpan)(endDatePicker - startDatePicker);
                msqlCommand.CommandText = "Select * From excredit where date >= DATE_SUB( @enddate, INTERVAL @diff DAY);";
                //"SELECT purchaselist.datePurchase, purchaselist.invoiceNo,purchaselist.vendorId,purchasebilling.quantity,purchasebilling.rate, purchasebilling.amount, purchasebilling.vat,vendors.vendor_name,vendors.vat_no  FROM purchaselist,purchasebilling,vendors WHERE purchaselist.invoiceNo=purchasebilling.invoiceNo  AND date(purchaselist.datePurchase) >= DATE_SUB( @enddate, INTERVAL @diff DAY) AND purchaselist.vendorId = vendors.vendor_id ;";
                msqlCommand.Parameters.AddWithValue("@enddate", endDatePicker);
                msqlCommand.Parameters.AddWithValue("@diff", diff.Days);
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ExpenseInfo Excredit = new ExpenseInfo();

                    Excredit.id = msqlReader.GetString("id");
                    Excredit.date = msqlReader.GetDateTime("date");
                    Excredit.type = (ExpenseType)Enum.Parse(typeof(ExpenseType), msqlReader.GetString("type"), false);
                    Excredit.description = msqlReader.GetString("description");
                    Excredit.amount = msqlReader.GetDouble("amount");


                    ExcreditList.Add(Excredit);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return ExcreditList;

        }

        public static List<ExpenseInfo> GetEachDayExcreditList(ExpenseInfo expenseInfoObj)
        {
            List<ExpenseInfo> ExcreditList = new List<ExpenseInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlConnection.Open();
                //DateTime endDatePicker = expenseInfoObj.endDate;
                //DateTime startDatePicker = expenseInfoObj.date;
                ////TimeSpan diff = (TimeSpan)(endDatePicker - startDatePicker);
                //msqlCommand.CommandText = "Select * From excredit where date = @input;";
                ////"SELECT purchaselist.datePurchase, purchaselist.invoiceNo,purchaselist.vendorId,purchasebilling.quantity,purchasebilling.rate, purchasebilling.amount, purchasebilling.vat,vendors.vendor_name,vendors.vat_no  FROM purchaselist,purchasebilling,vendors WHERE purchaselist.invoiceNo=purchasebilling.invoiceNo  AND date(purchaselist.datePurchase) >= DATE_SUB( @enddate, INTERVAL @diff DAY) AND purchaselist.vendorId = vendors.vendor_id ;";
                //msqlCommand.Parameters.AddWithValue("@input", endDatePicker);
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    ExpenseInfo Excredit = new ExpenseInfo();

                    Excredit.id = msqlReader.GetString("id");
                    Excredit.date = msqlReader.GetDateTime("date");
                    Excredit.type = (ExpenseType)Enum.Parse(typeof(ExpenseType), msqlReader.GetString("type"), false);
                    Excredit.description = msqlReader.GetString("description");
                    Excredit.amount = msqlReader.GetDouble("amount");


                    ExcreditList.Add(Excredit);
                }

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return ExcreditList;
        }


        public static void EditExpense(ExpenseInfo expenseToEdit)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "UPDATE excredit SET date=@date,type=@type,description=@description,amount=@amount WHERE id=@id";
                msqlCommand.Parameters.AddWithValue("@date", expenseToEdit.date);
                msqlCommand.Parameters.AddWithValue("@type", expenseToEdit.type);
                msqlCommand.Parameters.AddWithValue("@description", expenseToEdit.description);
                msqlCommand.Parameters.AddWithValue("@amount", expenseToEdit.amount);
                msqlCommand.Parameters.AddWithValue("@id", expenseToEdit.id);
                msqlCommand.ExecuteNonQuery();
            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #region Delete Expense

        public static void DeleteExpense(string expenseToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM excredit WHERE id=@expenseToDelete";
                msqlCommand.Parameters.AddWithValue("@expenseToDelete", expenseToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #endregion

        #region Address Book

        public static int DoEnterAddress(AddressInfo NewAddress)
        {
            return DoRegisterNewAddressindb(NewAddress);
        }

        private static int DoRegisterNewAddressindb(AddressInfo NewAddress)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "INSERT INTO address(id,name,mobile,home,office,address,email,note) "
                                    + "VALUES(@id,@name,@mobile,@home,@office,@address,@email,@note)";

                msqlCommand.Parameters.AddWithValue("@id", NewAddress.id);
                msqlCommand.Parameters.AddWithValue("@name", NewAddress.name);
                msqlCommand.Parameters.AddWithValue("@mobile", NewAddress.mobile);
                msqlCommand.Parameters.AddWithValue("@home", NewAddress.home);
                msqlCommand.Parameters.AddWithValue("@office", NewAddress.office);
                msqlCommand.Parameters.AddWithValue("@address", NewAddress.address);
                msqlCommand.Parameters.AddWithValue("@email", NewAddress.email);
                msqlCommand.Parameters.AddWithValue("@note", NewAddress.note);

                msqlCommand.ExecuteNonQuery();

                returnVal = 1;
            }
            catch (Exception er)
            {
                returnVal = 0;
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
            return returnVal;
        }

        public static List<AddressInfo> GetAllAddressList()
        {
            return QueryAllAddressList();
        }

        private static List<AddressInfo> QueryAllAddressList()
        {
            List<AddressInfo> AllAddressList = new List<AddressInfo>();
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;



                msqlCommand.CommandText = "Select * From address;";
                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

                while (msqlReader.Read())
                {
                    AddressInfo Address = new AddressInfo();

                    
                    Address.name = msqlReader.GetString("name");
                    Address.mobile = msqlReader.GetString("mobile");
                    Address.home = msqlReader.GetString("home");
                    Address.office = msqlReader.GetString("office");
                    Address.address = msqlReader.GetString("address");
                    Address.email = msqlReader.GetString("email");
                    Address.note = msqlReader.GetString("note");
                    

                    AllAddressList.Add(Address);
                }
            }

            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }

            return AllAddressList;

        }

        #region Delete Address

        public static void DeleteAddress(string addressToDelete)
        {
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = OpenDbConnection();

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlCommand.CommandText = "DELETE FROM address WHERE id=@addressToDelete";
                msqlCommand.Parameters.AddWithValue("@addressToDelete", addressToDelete);

                MySql.Data.MySqlClient.MySqlDataReader msqlReader = msqlCommand.ExecuteReader();

            }
            catch (Exception er)
            {
            }
            finally
            {
                //always close the connection
                msqlConnection.Close();
            }
        }

        #endregion

        #endregion
    }
}
