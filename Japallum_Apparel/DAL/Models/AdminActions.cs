using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    [DataObject(true)]
    public class AdminActions
    {
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void addAdmin(String fName, String lName, String password, String emailAddress, Boolean active)
        {
            // Add user to database
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "INSERT into tblAdmin VALUES (@fName, @lName, @emailAddress, @password, @active)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@fName", SqlDbType.VarChar, 60).Value = fName;
            cmd.Parameters.Add("@lName", SqlDbType.VarChar, 60).Value = lName;
            cmd.Parameters.Add("@emailAddress", SqlDbType.VarChar, 100).Value = emailAddress;
            cmd.Parameters.Add("@password", SqlDbType.VarChar, 60).Value = password;
            cmd.Parameters.Add("@active", SqlDbType.Bit).Value = active;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public int getAdminID()
        {
            // get ID from customer that matches given variables
            int adminID = 0;
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT adminID FROM tblAdmin WHERE adminEmail = @email";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = HttpContext.Current.Session["loggedemail"];
            connection.Open();
            adminID = (int)cmd.ExecuteScalar();
            return adminID;
        }

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}