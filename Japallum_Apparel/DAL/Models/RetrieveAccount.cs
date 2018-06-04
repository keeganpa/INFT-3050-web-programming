using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace DAL.Models
{
    [DataObject(true)]
    public class RetrieveAccount
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Boolean getUserAccount(String email, String password)
        {
            //Check if username and email match database
            //Get User data for matching email address from database
            //Create new User object and apply data to it
            //Put User object in the session
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT * FROM tblCustomer WHERE customerEmail = @email";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            User tempUser = new User();
            while (dr.Read())
            {
                tempUser.ID = Convert.ToInt32(dr["customerID"]);
                tempUser.fName = dr["fName"].ToString();
                tempUser.lName = dr["lName"].ToString();
                tempUser.rAdd = Convert.ToInt32(dr["rAddress"]);
                tempUser.bAdd = Convert.ToInt32(dr["bAddress"]);
                tempUser.eAdd = dr["customerEmail"].ToString();
                tempUser.Password = dr["customerPassword"].ToString();
                tempUser.Active = Convert.ToBoolean(dr["customerActive"]);
            }
            HttpContext.Current.Session["currentUser"] = tempUser;
            return true;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public string getUserPassword(String email, String Password)
        {
            //Check if Email matches one in database
            //Gets Password for said user
            //returns it to BL for emailing
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT customerPassword FROM tblCustomer WHERE customerEmail = @email";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 100).Value = email;
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    Password = dr["customerPassword"].ToString();
                }
            }
            catch
            {

            }
            return Password;
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
                tempAdmin.Active = Convert.ToBoolean(reader["adminActive"]);

            }
            HttpContext.Current.Session["currentAdmin"] = tempAdmin;
            return true;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<User> getUserList()
        {
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT * FROM tblCustomer";
            SqlCommand cmd = new SqlCommand(query, connection);
            connection.Open();
            List<User> users = new List<User>();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                User user = new User(Convert.ToInt32(reader["customerID"]), 
                                    reader["fName"].ToString(), 
                                    reader["lName"].ToString(),
                                    Convert.ToInt32(reader["rAddress"]),
                                    Convert.ToInt32(reader["bAddress"]),
                                    reader["customerEmail"].ToString(),
                                    reader["customerPassword"].ToString(),
                                    Convert.ToBoolean(reader["customerActive"]));
            }
            connection.Close();
            return users;
        }

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}