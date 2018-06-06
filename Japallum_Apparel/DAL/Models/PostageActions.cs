using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

namespace DAL.Models
{
    [DataObject(true)]
    public class PostageActions
    {
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void addPostage(String description, Double cost, Boolean active)
        {
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "INSERT into tblPostage VALUES (@description, @cost, @active)";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.Add("@description", SqlDbType.VarChar, 30).Value = description;
            cmd.Parameters.Add("@cost", SqlDbType.Money).Value = cost;
            cmd.Parameters.Add("@active", SqlDbType.Bit).Value = active;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Postage> getPostage()
        {
            SqlConnection connection = new SqlConnection(getConnectionString());
            String query = "SELECT * FROM tblPostage";
            SqlCommand cmd = new SqlCommand(query, connection);
            List<Postage> postageOptions = new List<Postage>();
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Postage postage = new Postage(
                    Convert.ToInt32(reader["postageID"]),
                    reader["postageDesc"].ToString(),
                    Convert.ToDouble(reader["postageCost"]),
                    Convert.ToBoolean(reader["postageActive"])
                    );
                postageOptions.Add(postage);
            }
                return postageOptions;
        }

        public string getConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JapallumConnectionString"].ConnectionString;
        }
    }
}