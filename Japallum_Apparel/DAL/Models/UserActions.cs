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
    public class UserActions
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public void addUser(String fName, String lName, int rAddress, int bAddress, String emailAddress, String password, Boolean active)
        {
            // Add user to database
            // INSERT INTO tblCustomer VALUES()
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "INSERT into tblCustomer VALUES (@fName, @lName, @rAddress, @bAddress, @emailAddress, @password, @active)";
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

        [DataObjectMethod(DataObjectMethodType.Select)]
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
            return userID;
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
            
                while (dr.Read())
                {
                    Password = dr["customerPassword"].ToString();
                }
            
            
            return Password;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
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
            if (tempUser.eAdd == email)
            {
                HttpContext.Current.Session["currentUser"] = tempUser;
                return true;
            }
            else
            {
                return false;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<User> getUserList()
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
                users.Add(user);
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