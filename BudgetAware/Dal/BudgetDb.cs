using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BudgetAware.Dal
{
    public class BudgetDb
    {
        public void AddBudget(Budget budget)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.AddBudget";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@UserId", SqlDbType.Int, 50).Value = budget.Fk_UserId;
            cmd.Parameters.Add("@Amount", SqlDbType.Money, 50).Value = budget.Amount;
            cmd.Parameters.Add("@CategoryId", SqlDbType.Int, 50).Value = budget.Fk_CategoriesId;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            int id = 0;

            sqlConnection.Close();
        }

        public void UpdateBudget(Budget budget)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.UpdateBudget";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@UserId", SqlDbType.Int, 50).Value = budget.Fk_UserId;
            cmd.Parameters.Add("@Amount", SqlDbType.Money, 50).Value = budget.Amount;
            cmd.Parameters.Add("@CategoryId", SqlDbType.Int, 50).Value = budget.Fk_CategoriesId;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            sqlConnection.Close();
        }

        public List<Budget> GetBudgetByUserId(int UserId)
        {
            List<Budget> budgetList = new List<Budget>();
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.GetBudgetByUserId";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@UserId", SqlDbType.Int, 50).Value = UserId;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            while (reader.Read())
            {
                Budget budget = new Budget();
                budget.Id = Int32.Parse(reader.GetValue(0).ToString());
                budget.Amount = Convert.ToDecimal(reader.GetValue(1).ToString());
                budget.Categories = new Categories();
                budget.Categories.Name = reader.GetValue(2).ToString();
                budgetList.Add(budget);
            }
            sqlConnection.Close();
            return budgetList;
        }
    }
}