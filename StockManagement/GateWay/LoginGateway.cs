using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagement.Model;

namespace StockManagement.GateWay
{
    public class LoginGateway
    {
        private string ConnectinString =
            WebConfigurationManager.ConnectionStrings["ConnectionStringStockManagementDb"].ConnectionString;
        public bool CheckUserNamePassword(Users user)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
           // SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            con.Open();
            string query = "select * from  User_tbl where UserName = '" + user.UserName + "'AND Password ='"+user.Password+"'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;
        }
    }
}