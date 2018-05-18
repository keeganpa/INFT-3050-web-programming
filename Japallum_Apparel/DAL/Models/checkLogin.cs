using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class checkLogin
    {
        //check if connection data are correct
        public Boolean checkCustomerLog(String email, String password)
        {
            String customerPassword = null;
            String sql = "SELECT customerPassword FROM customer WHERE customerEmail=@email";
            var con = ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ToString();
            using (var myCon = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand(sql, myCon);
                cmd.Parameters.AddWithValue("@email", email);
                myCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    customerPassword = reader["customerPassword"].ToString();
                }
                myCon.Close();
            }
            if (customerPassword == password)
            {
                return true;
            } else return false;
        }
    }
}