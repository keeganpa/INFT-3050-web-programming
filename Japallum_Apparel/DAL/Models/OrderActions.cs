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
    public class OrderActions
    {
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void addOrder(DateTime date, double subTotal, double total, int customerID, int customerAddress, double tax)
        {
            // Add order to database
            //setting connection string and sql request
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "INSERT into tblOrder (orderDate, subTotal, orderTotal, customerID, customerAddress, postage, tax) VALUES (@date, @subTotal, @total, @customerID, @customerAddress, @postage, @tax)";
            //paramaters
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            cmd.Parameters.Add("@subTotal", SqlDbType.Money).Value = subTotal;
            cmd.Parameters.Add("@total", SqlDbType.Money).Value = total;
            cmd.Parameters.Add("@customerID", SqlDbType.SmallInt).Value = customerID;
            cmd.Parameters.Add("@customerAddress", SqlDbType.SmallInt).Value = customerAddress;
            cmd.Parameters.Add("@postage", SqlDbType.SmallInt).Value = 1500;
            cmd.Parameters.Add("@tax", SqlDbType.Float).Value = tax;

            //use command
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public int getOrderID(DateTime date, double subTotal, double total, int customerID, int customerAddress, double tax)
        {
            // get ID from order that matches given variables
            int orderID = 0;
            //setting connection string and sql request
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT orderID FROM tblOrder WHERE orderDate = @date AND subTotal = @subTotal AND orderTotal = @total AND customerID = @customerID AND customerAddress = @customerAddress AND tax = @tax";
            //paramaters
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date;
            cmd.Parameters.Add("@subTotal", SqlDbType.Money).Value = subTotal;
            cmd.Parameters.Add("@total", SqlDbType.Money).Value = total;
            cmd.Parameters.Add("@customerID", SqlDbType.SmallInt).Value = customerID;
            cmd.Parameters.Add("@customerAddress", SqlDbType.SmallInt).Value = customerAddress;
            cmd.Parameters.Add("@tax", SqlDbType.Float).Value = tax;

            //use command
            connection.Open();
            orderID = (int)cmd.ExecuteScalar();
            connection.Close();
            return orderID;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Order> getHistory()
        {
            List<Order> orders = new List<Order>();
            //setting connection string and sql request
            String sql = "SELECT * FROM tblOrder JOIN tblCustomer ON tblOrder.customerID = tblCustomer.customerID WHERE customerEmail LIKE @email";
            var con = ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ToString();
            using (var myCon = new SqlConnection(con))
            {
                //paramaters
                SqlCommand cmd = new SqlCommand(sql, myCon);
                cmd.Parameters.AddWithValue("@email", (String)HttpContext.Current.Session["loggedemail"]);

                //use command
                myCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //for each rows of the database corresponding to the request we create an order and add it to the list
                        Order order = new Order(Convert.ToInt32(reader["orderID"]),
                                                Convert.ToDateTime(reader["orderDate"]),
                                                Convert.ToDecimal(reader["orderTotal"]),
                                                Convert.ToInt32(reader["postage"]),
                                                Convert.ToDouble(reader["tax"]),
                                                Convert.ToDecimal(reader["subTotal"]),
                                                Convert.ToInt32(reader["customerAddress"]));
                        orders.Add(order);
                    }
                }
                myCon.Close();
            }
            return orders;
        }

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}