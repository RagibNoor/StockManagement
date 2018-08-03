using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagement.Model;

namespace StockManagement.GateWay
{
    public class ItemSetupGateway
    {
        private string ConnectinString =
           WebConfigurationManager.ConnectionStrings["ConnectionStringStockManagementDb"].ConnectionString;
        public int AddItem(Item item)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();

            string query = "insert into Item_tbl(ItemName,CompanyID,CategoryID,Stockin,StockOut,Reorder) " +
                           "values('" + item.ItemName + "','" + item.CompanyId + "','" + item.CategoryId + "'," + item.StockIn + "," + item.StockOut + "," + item.Reorder+")";

            SqlCommand cmd = new SqlCommand(query, con);
            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }

        public int UpdateQuantity(Item item)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "Update   Item_tbl set Stockin =" + item.StockIn + " where ItemID=" + item.ItemId;
            SqlCommand cmd = new SqlCommand(query, con);

            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }

        public List<Item> GeItems(string companyID)

        {
            int companyId = Convert.ToInt32(companyID);
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Item_tbl where CompanyID ='"+companyId+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Item> items = new List<Item>();
            while (reader.Read())
            {
                Item item = new Item();
                item.ItemName = reader["ItemName"].ToString();
                item.CategoryId = Convert.ToInt32(reader["CategoryID"].ToString());
                item.CompanyId = Convert.ToInt32(reader["CompanyID"].ToString());
                item.Reorder = (int)reader["Reorder"];
                item.StockIn = (int)reader["StockIn"];
                item.StockOut = (int)reader["StockOut"];
                item.ItemId = (int) reader["ItemID"];
               

                items.Add(item);

            }
            reader.Close();
            con.Close();
            return items;
        }
        public Item GetReorderAndAmmount(int itemId)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Item_tbl where ItemID =" + itemId + ";";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            Item item = new Item();
            while (reader.Read())
            {
                
                item.ItemName = reader["ItemName"].ToString();
                
                item.Reorder = (int)reader["Reorder"];
                item.StockIn = (int)reader["StockIn"];
                item.StockOut = (int)reader["StockOut"];
                item.ItemId = (int)reader["ItemID"];


               

            }
         
            reader.Close();
            con.Close();
            return item;
        }

    }
}