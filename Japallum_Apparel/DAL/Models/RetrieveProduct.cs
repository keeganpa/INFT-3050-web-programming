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
    public class RetrieveProduct
    {
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
                tempProduct.Type = reader["prodType"].ToString();
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
        public IEnumerable<Clothes> getGenderProducts(String gen)
        {
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT * FROM tblProduct WHERE prodGender = @gen";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@gen", SqlDbType.Char, 3).Value = gen;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Clothes> tempClothes = new List<Clothes>();
            Clothes tempProduct = new Clothes();
            while (reader.Read())
            {
                tempProduct.ID = Convert.ToInt32(reader["productID"]);
                tempProduct.Size = reader["prodSize"].ToString();
                tempProduct.Price = Convert.ToDouble(reader["prodPrize"]);
                tempProduct.Type = reader["prodType"].ToString();
                tempProduct.Description = reader["longDesc"].ToString();
                tempProduct.Gender = reader["prodGender"].ToString();
                tempProduct.Name = reader["shortDesc"].ToString();
                tempProduct.Active = Convert.ToBoolean(reader["active"]);
                tempProduct.ImagePath = reader["imageFile"].ToString();
                tempProduct.StockCount = Convert.ToInt32(reader["prodStock"]);
                tempProduct.LastEdit = Convert.ToInt32(reader["lastEdited"]);
                tempClothes.Add(tempProduct);
            }
            connection.Close();
            HttpContext.Current.Session["genderProductList"] = tempClothes;
            return tempClothes;
        }

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}