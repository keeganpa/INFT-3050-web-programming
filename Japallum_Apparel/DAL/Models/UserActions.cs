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

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}