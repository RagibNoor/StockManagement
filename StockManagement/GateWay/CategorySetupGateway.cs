using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagement.Model;

namespace StockManagement.GateWay
{
    public class CategorySetupGateway
    {
        private string ConnectinString =
            WebConfigurationManager.ConnectionStrings["ConnectionStringStockManagementDb"].ConnectionString;
        public int Save(Category category)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();

            string query = "insert into Category_tbl(CategoryName) values('" + category.CategoryName + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }

        public bool IsExsit(string categoryName)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            con.Open();
            string query = "select * from  Category_tbl where CategoryName = '" + categoryName + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;

        }

        public List<Category> GetCategories()
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Category_tbl";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
               category.CategoryName = reader["CategoryName"].ToString();
               category.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                
                categories.Add(category);

            }
            reader.Close();
            con.Close();
            return categories;
        } 
    }
}