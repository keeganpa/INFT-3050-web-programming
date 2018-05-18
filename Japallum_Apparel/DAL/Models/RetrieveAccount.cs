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
            String tempPassword = dr["customerPassword"].ToString();
            if (tempPassword != password)
            {
                return false;
            }
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
            SqlDataReader dr = cmd.ExecuteReader();
            User tempAdmin = new User();
            String tempPassword = dr["adminPassword"].ToString();
            if (tempPassword != password)
            {
                return false;
            }
            while (dr.Read())
            {
                tempAdmin.ID = Convert.ToInt32(dr["adminID"]);
                tempAdmin.fName = dr["fName"].ToString();
                tempAdmin.lName = dr["lName"].ToString();
                tempAdmin.eAdd = dr["adminEmail"].ToString();
                tempAdmin.Password = dr["adminPassword"].ToString();
            }
            HttpContext.Current.Session["currentAdmin"] = tempAdmin;
            return true;
        }
        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}