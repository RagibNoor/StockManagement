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

            string query = "insert into Item_tbl(ItemName,CompanyID,CategoryID,Reorder) " +
                           "values(@ItemName,'" + item.CompanyId + "','" + item.CategoryId + "'," + item.Reorder+")";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("ItemName", item.ItemName);
            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }
        public bool IsExsit(string itemName)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Item_tbl where ItemName = @itemName";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("itemName", itemName);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;

        }

        public int GetStockInQuantity(int itemID)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select sum(StockInquantity) from stockIn_tbl  where ItemId = " + itemID + " ";
            SqlCommand cmd = new SqlCommand(query, con);
            //SqlDataReader reader = cmd.ExecuteReader();
            int stockInQuantity = 0;
             
            object value = cmd.ExecuteScalar();
            if (!value.Equals(DBNull.Value))
            {
                stockInQuantity = (int)value;
            }
            //List<int> quantity = new List<int>();
            //quantity.Add(stockInQuantity);
            //while (reader.Read())
            //{
            //    stockInQuantity = (int) reader["StockInquantity"];
            //    quantity.Add(stockInQuantity);
            //}
          //  reader.Close();
            con.Close();
            return stockInQuantity;

        }
        public int GetStockOutQuantity(int itemID)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select sum(StockOutQuantity) From stockOut_tbl where ItemId = " + itemID + "";
            SqlCommand cmd = new SqlCommand(query, con);
          //  SqlDataReader reader = cmd.ExecuteReader();
            int StockOutQuantity = 0;
            object value =  cmd.ExecuteScalar();
            if (!value.Equals(DBNull.Value))
            {
                StockOutQuantity = (int) value;
            }
            //List<int> quantity = new List<int>();
            //quantity.Add(StockOutQuantity);
            //while (reader.Read())
            //{
            //    StockOutQuantity = (int)reader["StockOutQuantity"];
            //    quantity.Add(StockOutQuantity);
            //}
            //reader.Close();
            con.Close();
            return StockOutQuantity;

        }
        public int StockOut(List<Item> items , string reason)
        {
            int rowCount = 0;
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            foreach (var item in items)
            {
                string query = "Insert into stockOut_tbl(ItemId,Reason,StockOutdate,StockOutQuantity)" +
                               "Values( " + item.ItemId + ",'" + reason + "','" + item.StockOutDate + "','"+item.StockOut+"') ";
                SqlCommand cmd = new SqlCommand(query, con);
                rowCount = cmd.ExecuteNonQuery();

            }
            con.Close();
            return rowCount;
        }

        public int UpdateStockInQuantity(Item item)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "Insert into  stockIn_tbl(ItemId,StockInquantity,Date) values ( "+item.ItemId+", "+item.StockIn+" , '"+item.StockInDate+"')";
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
            Item itemD = new Item();
            itemD.ItemName = "----Select----";
            items.Add(itemD);
            while (reader.Read())
            {
                Item item = new Item();    
                item.ItemName = reader["ItemName"].ToString();
                item.CategoryId = Convert.ToInt32(reader["CategoryID"].ToString());
                item.CompanyId = Convert.ToInt32(reader["CompanyID"].ToString());
                item.Reorder = (int)reader["Reorder"];
                item.ItemId = (int) reader["ItemID"];
               

                items.Add(item);

            }
            reader.Close();
            con.Close();
            return items;
        }
        public List<Item> GetSearchItems(int companyId , int categoryId )
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query;
            if (companyId == 0 && categoryId == 0)
            {
                query = "select * from  ItemAllInfo ";
            }
            else if (companyId==0)
            {
                 query = "select * from  ItemAllInfo where CategoryId='" + categoryId + "'";
            }
            else if (categoryId==0)
            {
                query = "select * from  ItemAllInfo where CompanyID ='" + companyId + "'";
                
            }
            else
            {
                query = "select * from  ItemAllInfo where CompanyID ='" + companyId + "' and CategoryId='" + categoryId + "'";
            }
            
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
                item.ItemId = (int)reader["ItemID"];
                int availableQuantity = GetStockInQuantity(item.ItemId) - GetStockOutQuantity(item.ItemId);
                item.AvilableQuantity = availableQuantity;
                item.CompanyName = (string) reader["CompanyName"];
                item.CategoryName = (string) reader["CategoryName"];


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
                item.ItemId = (int)reader["ItemID"];


               

            }
         
            reader.Close();
            con.Close();
            return item;
        }

    }
}