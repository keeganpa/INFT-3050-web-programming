using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Methods
{ 
    public class RetrieveAccount
    {
        SqlConnection con = new SqlConnection();
        public void getUserAccount(String email, String password)
        {
            //Check if username and email match database
            //Get User data for matching email address from database
            //Create new User object and apply data to it
            //Put User object in the session

        }

        public void getAdminAccount(String email, String password)
        {
            //Check if username and email match database
            //Get Admin data for matching email address from database
            //Create new Admin object and apply data to it
            //Put Admin object in the session
        }
    }
}