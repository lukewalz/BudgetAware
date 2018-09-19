using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BudgetAware.Dal
{
    public class AccountDb
    {

        public int AddAccount(Accounts account)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.AddAccount";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@AccountNumber", SqlDbType.Int, 50).Value = account.AccountNumber;
            cmd.Parameters.Add("@AccountType", SqlDbType.VarChar, 50).Value = account.AccountType;
            cmd.Parameters.Add("@Balance", SqlDbType.Money, 50).Value = account.Balance;
            cmd.Parameters.Add("@UserId", SqlDbType.Int, 50).Value = account.Fk_UserId;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            int id = 0;

            while (reader.Read())
            {
                id = Int32.Parse(reader.GetValue(0).ToString());
            }
            sqlConnection.Close();
            return id;
        }
        public Accounts GetAccountsByUserId(int UserId)
        {
            Accounts accounts = new Accounts();
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.GetAccountByUserId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@Id", SqlDbType.Int, 50).Value = UserId;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            while (reader.Read())
            {
                accounts.AccountNumber = Int32.Parse(reader.GetValue(0).ToString());
                accounts.AccountType = reader.GetValue(1).ToString();
                accounts.Balance = Convert.ToDecimal(reader.GetValue(2));
            }
            sqlConnection.Close();
            return accounts;
        }
    }
}