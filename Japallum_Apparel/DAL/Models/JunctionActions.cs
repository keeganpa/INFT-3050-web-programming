using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class JunctionActions
    {
        public void addJunction(int orderID, int productID, double prodPrice, int quantity)
        {
            // Add order to database
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "INSERT into junctionProd_Order (orderID, productID, prodPrice, quantity) VALUES (@orderID, @productID, @prodPrice, @quantity)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@orderID", SqlDbType.Int).Value = orderID;
            cmd.Parameters.Add("@productID", SqlDbType.Int).Value = productID;
            cmd.Parameters.Add("@prodPrice", SqlDbType.Money).Value = prodPrice;
            cmd.Parameters.Add("@quantity", SqlDbType.SmallInt).Value = quantity;
            connection.Open();
            System.Diagnostics.Debug.WriteLine(productID);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}