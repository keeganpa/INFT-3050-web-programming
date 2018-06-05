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

        [DataObjectMethod(DataObjectMethodType.Select)]
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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Boolean getAdminAccount(String email, String password)
        {
            //Check if username and email match database
            //Get Admin data for matching email address from database
            //Create new Admin object and apply data to it
            //Put Admin object in the session
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT * FROM tblAdmin WHERE adminEmail = @email";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Admin tempAdmin = new Admin();
            while (reader.Read())
            {
                tempAdmin.ID = Convert.ToInt32(reader["adminID"]);
                tempAdmin.fName = reader["fName"].ToString();
                tempAdmin.lName = reader["lName"].ToString();
                tempAdmin.eAdd = reader["adminEmail"].ToString();
                tempAdmin.Password = reader["adminPassword"].ToString();
            }
            if (tempAdmin.eAdd == email)
            {
                HttpContext.Current.Session["currentAdmin"] = tempAdmin;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}