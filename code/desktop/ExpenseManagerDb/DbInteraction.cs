﻿using System;
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

        #region Excredit

        public static int DoRegisterNewExcredit(ExpenseInfo excreditDetails)
        {
            return DoRegisterNewExcreditInDb(excreditDetails);
        }

        private static int DoRegisterNewExcreditInDb(ExpenseInfo excreditDetails)
        {
            int returnVal = 0;
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;

            msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;Password=" + passwordCurrent + ";database=" + dbmsCurrent + ";persist security info=False");
            try
            {
                //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();

                //define the connection used by the command object
                msqlCommand.Connection = msqlConnection;

                //open the connection
                if (msqlConnection.State != System.Data.ConnectionState.Open)
                    msqlConnection.Open();

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
            MySql.Data.MySqlClient.MySqlConnection msqlConnection = null;

            msqlConnection = new MySql.Data.MySqlClient.MySqlConnection("server=localhost;user id=root;Password=" + passwordCurrent + ";database=" + dbmsCurrent + ";persist security info=False");

            try
            {   //define the command reference
                MySql.Data.MySqlClient.MySqlCommand msqlCommand = new MySql.Data.MySqlClient.MySqlCommand();
                msqlCommand.Connection = msqlConnection;

                msqlConnection.Open();

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

        #endregion 

    }
}
