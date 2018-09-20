using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BudgetAware.Dal
{
    public class UsersDb
    {
        public Users GetUserByEmail(string emailAddress)
        {
            Users user = new Users();
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.GetUserByEmailAddress";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = emailAddress;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            while (reader.Read())
            {
                user.Id = Int32.Parse(reader.GetValue(0).ToString());
                user.FirstName = reader.GetValue(1).ToString();
                user.LastName = reader.GetValue(2).ToString();
                user.EmailAddress = reader.GetValue(3).ToString();
                user.Password = reader.GetValue(4).ToString();
            }
            sqlConnection.Close();
            return user;
        }

        public int AddUser(Users user)
        {
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.AddUser";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = user.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = user.LastName;
            cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = user.EmailAddress;
            cmd.Parameters.Add("@Password", SqlDbType.VarChar, 50).Value = user.Password;
            cmd.Parameters.Add("@Birthday", SqlDbType.Date, 50).Value = user.Birthday;

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

        public Users GetUserById(int Id)
        {
            Users user = new Users();
            SqlConnection sqlConnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DataModel"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;

            cmd.CommandText = "dbo.GetUserById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = sqlConnection;

            cmd.Parameters.Add("@Id", SqlDbType.VarChar, 50).Value = Id;

            sqlConnection.Open();

            reader = cmd.ExecuteReader();
            // Data is accessible through the DataReader object here.

            while (reader.Read())
            {
                user.Id = Int32.Parse(reader.GetValue(0).ToString());
                user.FirstName = reader.GetValue(1).ToString();
                user.LastName = reader.GetValue(2).ToString();
                user.EmailAddress = reader.GetValue(3).ToString();
                user.Birthday = reader.GetDateTime(5);
            }
            sqlConnection.Close();
            return user;
        }

    }
}