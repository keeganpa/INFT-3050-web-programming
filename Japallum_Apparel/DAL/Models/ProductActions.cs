using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    public class ProductActions
    {
        public void addItem(String size, decimal price, String shortDesc, String gender, String imagePath, int prodStock, int date)
        {
            // Add item to database
            // INSERT INTO tblProduct VALUES()
            Boolean active;
            if (price == -1 || prodStock == -1 || prodStock == 0) { active = false; } else { active = true; }
            SqlConnection connection = new SqlConnection(getConnectionString());
            String column = makeColumn(size, price, shortDesc, gender, imagePath, prodStock);
            //System.Diagnostics.Debug.WriteLine(column);
            String parameter = makeParameter(size, price, shortDesc, gender, imagePath, prodStock);
            //System.Diagnostics.Debug.WriteLine(parameter);
            String query = "INSERT into tblProduct (" + column + ", lastEdited, active) VALUES (" + parameter + ", @date, @active)";
            System.Diagnostics.Debug.WriteLine(query);
            SqlCommand cmd = new SqlCommand(query, connection);
            if (size != null) { cmd.Parameters.Add("@size", SqlDbType.Char, 3).Value = size; }
            cmd.Parameters.Add("@price", SqlDbType.Money).Value = price;
            if (shortDesc != null) { cmd.Parameters.Add("@shortDesc", SqlDbType.VarChar, 100).Value = shortDesc; }
            if (gender != null) { cmd.Parameters.Add("@gender", SqlDbType.Char, 3).Value = gender; }
            if (imagePath != null) { cmd.Parameters.Add("@imagePath", SqlDbType.VarChar, 300).Value = imagePath; }
            cmd.Parameters.Add("@date", SqlDbType.SmallInt).Value = date;
            cmd.Parameters.Add("@prodStock", SqlDbType.SmallInt).Value = prodStock;
            cmd.Parameters.Add("@active", SqlDbType.Bit).Value = active;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public String makeColumn(String size, decimal price, String shortDesc, String gender, String imagePath, int prodStock)
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

        public String makeParameter(String size, decimal price, String shortDesc, String gender, String imagePath, int prodStock)
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

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}