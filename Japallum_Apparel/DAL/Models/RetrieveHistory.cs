using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UL.Classes;

namespace DAL.Models
{
    public class RetrieveHistory
    {
        public List<Order> getHistory()
        {
            List<Order> orders = new List<Order>();
            String sql = "SELECT * FROM tblOrder JOIN tblCustomer ON tblOrder.customerID = tblCustomer.customerID WHERE customerEmail LIKE 'Lkins@gmail.com'";
            var con = ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ToString();
            using (var myCon = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand(sql, myCon);
                //cmd.Parameters.AddWithValue("@email", (String)HttpContext.Current.Session["loggedemail"]);

                myCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Order order = new Order((int)reader["orderID"],
                                                (DateTime)reader["orderDate"],
                                                (decimal)reader["orderTotal"],
                                                (int)reader["postage"],
                                                (double)reader["tax"],
                                                (decimal)reader["subTotal"],
                                                (int)reader["customerAddress"]);
                        orders.Add(order);
                    }
                }
                myCon.Close();
            }
            return orders;
        }
    }
}