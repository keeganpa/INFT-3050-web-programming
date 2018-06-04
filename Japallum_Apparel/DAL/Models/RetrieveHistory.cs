using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class RetrieveHistory
    {
        public List<Order> getHistory()
        {
            List<Order> orders = new List<Order>();
            String sql = "SELECT * FROM tblOrder JOIN tblCustomer ON tblOrder.customerID = tblCustomer.customerID WHERE customerEmail LIKE @email";
            var con = ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ToString();
            using (var myCon = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand(sql, myCon);
                cmd.Parameters.AddWithValue("@email", (String)HttpContext.Current.Session["loggedemail"]);
                System.Diagnostics.Debug.WriteLine(cmd);
                myCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("sql");
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

        public List<Product> getProducts(int id)
        {
            List<Product> products = new List<Product>();
            String sql = "SELECT * FROM tblOrder JOIN (tblProduct JOIN junctionProd_Order AS junction ON tblProduct.productID = junction.productID)"
                        + "ON tblOrder.orderID = junction.orderID WHERE tblOrder.orderID = @id";
            var con = ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ToString();
            using (var myCon = new SqlConnection(con))
            {
                SqlCommand cmd = new SqlCommand(sql, myCon);
                cmd.Parameters.AddWithValue("@id", id);

                myCon.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        System.Diagnostics.Debug.WriteLine("sql");
                        Product product = new Product((int)reader["productID"],
                                                (String)reader["prodSize"],
                                                (decimal)reader["prodPrice"],
                                                (String)reader["shortDesc"],
                                                (String)reader["longDesc"],
                                                (String)reader["prodGender"],
                                                (Boolean)reader["active"],
                                                (String)reader["imageFile"],
                                                (int)reader["prodStock"],
                                                (int)reader["lastEdited"]);
                        product.Quantity = (Int16)reader["Quantity"];
                        products.Add(product);
                    }
                }
                myCon.Close();
            }
            return products;
        }
    }
}