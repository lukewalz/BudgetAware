using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BudgetAware.Dal
{
    public class PurchaseDb
    {
        public int AddPurchase(Purchases purchase)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.AddPurchase";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@CategoryId", SqlDbType.Int, 50).Value = purchase.Fk_CategoryId;
            cmd.Parameters.Add("@Cost", SqlDbType.Money, 50).Value = purchase.Cost;
            cmd.Parameters.Add("@Company", SqlDbType.VarChar, 50).Value = purchase.Company;
            cmd.Parameters.Add("@PurchaseDate", SqlDbType.Date, 50).Value = purchase.PurchaseDate;
            cmd.Parameters.Add("@AccountNumber", SqlDbType.Int, 50).Value = purchase.Fk_AccountNumber;

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

        public List<Purchases> GetPurchasesByAccountId(int Id)
        {
            List<Purchases> purchases = new List<Purchases>();
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.GetPurchasesByAccountId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@AccountId", SqlDbType.Int, 50).Value = Id;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            while (reader.Read())
            {

            }
            sqlConnection.Close();
            return purchases;
        }
    }
}