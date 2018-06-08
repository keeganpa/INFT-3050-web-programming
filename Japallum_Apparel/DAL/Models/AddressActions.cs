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
    public class AddressActions
    {
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void addAddress(String sNum, String sName, String city, String state, int pCode)
        {
            // Add address to database
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "INSERT into tblAddress VALUES (@sNum, @sName, @city, @state, @pCode)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@sNum", SqlDbType.VarChar, 10).Value = sNum;
            cmd.Parameters.Add("@sName", SqlDbType.VarChar, 255).Value = sName;
            cmd.Parameters.Add("@city", SqlDbType.VarChar, 255).Value = city;
            cmd.Parameters.Add("@state", SqlDbType.VarChar, 30).Value = state;
            cmd.Parameters.Add("@pCode", SqlDbType.SmallInt).Value = pCode;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int getAddressID(String sNum, String sName, int pCode)
        {
            // get ID from address that matches given variables
            int addressID = 0;
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT * FROM tblAddress WHERE streetNum = @sNum AND streetName = @sName AND postCode = @pCode";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@sNum", SqlDbType.VarChar, 50).Value = sNum;
            cmd.Parameters.Add("@sName", SqlDbType.VarChar, 255).Value = sName;
            cmd.Parameters.Add("@pcode", SqlDbType.SmallInt).Value = pCode;
            connection.Open();
            addressID = (int)cmd.ExecuteScalar();
            //SqlDataReader dr = cmd.ExecuteReader();
            //User tempUser = new User();
            //String tempPassword = dr["customerPassword"].ToString();
            return addressID;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int getAddressID(String customerEmail)
        {
            // get ID from address that matches given variables
            int addressID = 0;
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT rAddress FROM tblCustomer WHERE customerEmail = @customerEmail";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@customerEmail", SqlDbType.VarChar, 50).Value = customerEmail;
            connection.Open();
            System.Diagnostics.Debug.WriteLine(cmd.ExecuteScalar());
            addressID = (int)cmd.ExecuteScalar();
            //SqlDataReader dr = cmd.ExecuteReader();
            //User tempUser = new User();
            //String tempPassword = dr["customerPassword"].ToString();
            connection.Close();
            return addressID;
        }


        //Gets Data from databse for Order email by checking the addressID
        [DataObjectMethod(DataObjectMethodType.Select)]
        public void getUserAddress(int addressID, ref string strNum,ref string strNam,ref string suburb,ref string state,ref string postCode)
        {
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT streetNum, streetName, suburb, addressState, postCode FROM tblAddress WHERE addressID = @aID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@aID", SqlDbType.Int).Value = addressID;
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            int intPost = 0;
            while (dr.Read())
            {
                strNum = dr["streetNum"].ToString();
                strNam = dr["streetName"].ToString();
                suburb = dr["suburb"].ToString();
                state = dr["addressState"].ToString();
                intPost = Convert.ToInt32(dr["postCode"]);
            }
            postCode = Convert.ToString(intPost);
            return;
        }
        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}