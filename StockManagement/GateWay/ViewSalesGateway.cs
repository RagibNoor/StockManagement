using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagement.Model;

namespace StockManagement.GateWay
{
    public class ViewSalesGateway
    {
        private string ConnectinString =
          WebConfigurationManager.ConnectionStrings["ConnectionStringStockManagementDb"].ConnectionString;

        public List<Item> GetsellItem(string startDate , string endDate)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  ItemStockOutView_tbl where Reason ='s' and StockOutdate between '" + startDate + "' and '" + endDate + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Item> items = new List<Item>();
           
            while (reader.Read())
            {
                Item item = new Item();
                item.ItemName = reader["ItemName"].ToString();
                item.StockOut = Convert.ToInt32(reader["StockOutQuantity"].ToString());
               


                items.Add(item);

            }
            reader.Close();
            con.Close();
            return items;
        }
    }
}