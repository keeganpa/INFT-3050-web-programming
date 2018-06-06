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
    public class ProductActions
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public void addItem(String size, decimal price, String shortDesc, String longDesc, String gender, String imagePath, int prodStock, int date)
        {
            // Add item to database
            // INSERT INTO tblProduct VALUES()
            Boolean active;
            if (price == -1 || prodStock == -1 || prodStock == 0) { active = false; } else { active = true; }
            SqlConnection connection = new SqlConnection(getConnectionString());
            String column = makeColumn(size, price, shortDesc, longDesc, gender, imagePath, prodStock);
            //System.Diagnostics.Debug.WriteLine(column);
            String parameter = makeParameter(size, price, shortDesc, longDesc, gender, imagePath, prodStock);
            //System.Diagnostics.Debug.WriteLine(parameter);
            String query = "INSERT into tblProduct (" + column + ", lastEdited, active) VALUES (" + parameter + ", @date, @active)";
            System.Diagnostics.Debug.WriteLine(query);
            SqlCommand cmd = new SqlCommand(query, connection);
            if (size != null) { cmd.Parameters.Add("@size", SqlDbType.Char, 3).Value = size; }
            cmd.Parameters.Add("@price", SqlDbType.Money).Value = price;
            if (shortDesc != null) { cmd.Parameters.Add("@shortDesc", SqlDbType.VarChar, 100).Value = shortDesc; }
            if (longDesc != null) { cmd.Parameters.Add("@longDesc", SqlDbType.VarChar, 100).Value = longDesc; }
            if (gender != null) { cmd.Parameters.Add("@gender", SqlDbType.Char, 3).Value = gender; }
            if (imagePath != null) { cmd.Parameters.Add("@imagePath", SqlDbType.VarChar, 300).Value = imagePath; }
            cmd.Parameters.Add("@date", SqlDbType.SmallInt).Value = date;
            cmd.Parameters.Add("@prodStock", SqlDbType.SmallInt).Value = prodStock;
            cmd.Parameters.Add("@active", SqlDbType.Bit).Value = active;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> searchItem(int productID, String prodSize, decimal price, String shortDesc, String longDesc, String gender, String imagePath, int prodStock)
        {
            // search item to database
            List<Product> products = new List<Product>();
            SqlConnection connection = new SqlConnection(getConnectionString());
            String parameter = makeParameter(productID, prodSize, price, shortDesc, longDesc, gender, imagePath, prodStock);
            String query = "SELECT * FROM tblProduct WHERE (" + parameter + ")";
            SqlCommand cmd = new SqlCommand(query, connection);
            if (prodSize != "") { cmd.Parameters.Add("@prodSize", SqlDbType.Char, 3).Value = prodSize; }
            if (price != -1) { cmd.Parameters.Add("@prodPrice", SqlDbType.Money).Value = price; }
            if (shortDesc != "") { cmd.Parameters.Add("@shortDesc", SqlDbType.VarChar, 100).Value = shortDesc; }
            if (longDesc != "") { cmd.Parameters.Add("@longDesc", SqlDbType.VarChar, 100).Value = longDesc; }
            if (gender != "") { cmd.Parameters.Add("@prodGender", SqlDbType.Char, 3).Value = gender; }
            if (imagePath != "") { cmd.Parameters.Add("@imageFile", SqlDbType.VarChar, 300).Value = imagePath; }
            if (productID != -1) { cmd.Parameters.Add("@productID", SqlDbType.SmallInt).Value = productID; }
            if (prodStock != -1) { cmd.Parameters.Add("@prodStock", SqlDbType.SmallInt).Value = prodStock; }
            connection.Open();
            System.Diagnostics.Debug.WriteLine(query);
            SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product((int)reader["productID"],
                                            (String)reader["prodSize"].ToString(),
                                            (decimal)reader["prodPrice"],
                                            (String)reader["shortDesc"].ToString(),
                                            (String)reader["longDesc"].ToString(),
                                            (String)reader["prodGender"].ToString(),
                                            (Boolean)reader["active"],
                                            (String)reader["imageFile"].ToString(),
                                            (int)reader["prodStock"],
                                            (int)reader["lastEdited"]);
                System.Diagnostics.Debug.WriteLine("yolo");
                System.Diagnostics.Debug.WriteLine(product);
                products.Add(product);
                }
            connection.Close();
            return products;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public Clothes getProduct(int ID)
        {
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT * FROM tblProduct WHERE productID = @ID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            Clothes tempProduct = new Clothes();
            while (reader.Read())
            {
                tempProduct.ID = Convert.ToInt32(reader["productID"]);
                tempProduct.Size = reader["prodSize"].ToString();
                tempProduct.Price = Convert.ToDouble(reader["prodPrize"]);
                tempProduct.Description = reader["longDesc"].ToString();
                tempProduct.Gender = reader["prodGender"].ToString();
                tempProduct.Name = reader["shortDesc"].ToString();
                tempProduct.Active = Convert.ToBoolean(reader["active"]);
                tempProduct.ImagePath = reader["imageFile"].ToString();
                tempProduct.StockCount = Convert.ToInt32(reader["prodStock"]);
                tempProduct.LastEdit = Convert.ToInt32(reader["lastEdited"]);
            }
            HttpContext.Current.Session["currentProduct"] = tempProduct;
            return tempProduct;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Product> getProductsForHistory(int id)
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

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Clothes> getGenderProducts(String gen)
        {
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT * FROM tblProduct WHERE prodGender = @gen";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@gen", SqlDbType.Char, 3).Value = gen;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Clothes> tempClothes = new List<Clothes>();
            while (reader.Read())
            {
                int ID = Convert.ToInt32(reader["productID"]);
                String Size = reader["prodSize"].ToString();
                Double Price = Convert.ToDouble(reader["prodPrice"]);
                String Description = reader["longDesc"].ToString();
                String Gender = reader["prodGender"].ToString();
                String Name = reader["shortDesc"].ToString();
                Boolean Active = Convert.ToBoolean(reader["active"]);
                String ImagePath = reader["imageFile"].ToString();
                int StockCount = Convert.ToInt32(reader["prodStock"]);
                int LastEdit = Convert.ToInt32(reader["lastEdited"]);
                Clothes tempProduct = new Clothes(Name, ID, Size, Price, Description, Gender, ImagePath, StockCount, LastEdit);
                tempClothes.Add(tempProduct);
            }
            connection.Close();
            HttpContext.Current.Session["genderProductList"] = tempClothes;
            return tempClothes;
        }

        public String makeColumn(String size, decimal price, String shortDesc, String longDesc, String gender, String imagePath, int prodStock)
        {
            Boolean first = true;
            String res = "";
            if (!(size == null))
            {
                first = false;
                res = res + "prodSize";
            }
            if (first == false) { res = res + ", "; }
            res = res + "prodPrice";
            if (!(shortDesc == null))
            {
                res = res + ", " + "shortDesc";
            }
            if (!(longDesc == null))
            {
                res = res + ", " + "longDesc";
            }
            if (!(gender == null))
            {
                res = res + ", " + "prodGender";
            }
            if (!(imagePath == null))
            {
                res = res + ", " + "imageFile";
            }
            res = res + ", " + "prodStock";
            return res;
        }

        public String makeParameter(String size, decimal price, String shortDesc, String longDesc, String gender, String imagePath, int prodStock)
        {
            Boolean first = true;
            String res = "";
            if (!(size == null))
            {
                first = false;
                res = res + "@size";
            }
            if (first == false) { res = res + ", "; }
            res = res + "@price";
            if (!(shortDesc == null))
            {
                res = res + ", " + "@shortDesc";
            }
            if (!(longDesc == null))
            {
                res = res + ", " + "@longDesc";
            }
            if (!(gender == null))
            {
                res = res + ", " + "@gender";
            }
            if (!(imagePath == null))
            {
                res = res + ", " + "@imagePath";
            }
            res = res + ", " + "@prodStock";
            return res;
        }

        public String makeParameter(int id, String size, decimal price, String shortDesc, String longDesc, String gender, String imagePath, int prodStock)
        {
            String res = "";
            Boolean first = true;
            if (id != -1)
            {
                res = res + "productID = @productID";
                first = false;
            }
            if (!(size == ""))
            {
                if (first == false) { res = res + " AND "; }
                res = res + "prodSize = @prodSize";
                first = false;
            }
            if (price != -1)
            {
                if (first == false) { res = res + " AND "; }
                res = res + "prodPrice = @prodPrice";
                first = false;
            }
            if (!(shortDesc == ""))
            {
                if (first == false) { res = res + " AND "; }
                res = res + "shortDesc = @shortDesc";
                first = false;
            }
            if (!(longDesc == ""))
            {
                if (first == false) { res = res + " AND "; }
                res = res + "longDesc = @longDesc";
                first = false;
            }
            if (!(gender == ""))
            {
                if (first == false) { res = res + " AND "; }
                res = res + "prodGender = @prodGender";
                first = false;
            }
            if (!(imagePath == ""))
            {
                if (first == false) { res = res + " AND "; }
                res = res + "imageFile = @imageFile";
                first = false;
            }
            if (prodStock != -1)
            {
                if (first == false) { res = res + " AND "; }
                res = res + "prodStock = @prodStock";
                first = false;
            }
            return res;
        }

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}