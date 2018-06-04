using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class UserActions
    {
        public void addUser(String fName, String lName, int rAddress, int bAddress, String emailAddress, String password, Boolean active)
        {
            // Add user to database
            // INSERT INTO tblCustomer VALUES()
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "INSERT into tblCustomer VALUES (@fName, @lName, @rAddress, @bAdress, @emailAddress, @password, @active)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@fName", SqlDbType.VarChar, 60).Value = fName;
            cmd.Parameters.Add("@lName", SqlDbType.VarChar, 60).Value = lName;
            cmd.Parameters.Add("@rAddress", SqlDbType.Int).Value = rAddress;
            cmd.Parameters.Add("@bAddress", SqlDbType.Int).Value = bAddress;
            cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar, 100).Value = emailAddress;
            cmd.Parameters.Add("@password", SqlDbType.VarChar, 60).Value = password;
            cmd.Parameters.Add("@active", SqlDbType.Bit).Value = active;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public int getUserID()
        {
            // get ID from customer that matches given variables
            int userID = 0;
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT customerID FROM tblCustomer WHERE customerEmail = @email";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = HttpContext.Current.Session["loggedemail"];
            connection.Open();
            userID = (int)cmd.ExecuteScalar();
            //SqlDataReader dr = cmd.ExecuteReader();
            //User tempUser = new User();
            //String tempPassword = dr["customerPassword"].ToString();
            /*using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    //userID = (int)reader["orderID"];
                }
            }*/
            return userID;
        }

        public void updateUserActive(Boolean active, int id)
        {
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "UPDATE tblCustomer SET customerActive = @active WHERE customerID = @id";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@active", SqlDbType.Bit).Value = active;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}