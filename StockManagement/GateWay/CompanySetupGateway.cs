using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagement.Model;

namespace StockManagement.GateWay
{
    public class CompanySetupGateway
    {
        private string ConnectinString =
            WebConfigurationManager.ConnectionStrings["ConnectionStringStockManagementDb"].ConnectionString;

        public int Save(Company company)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();

            string query = "insert into Company_tbl(CompanyName) values('" + company.CompanyName + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;
        }
        public bool IsExsit(string companyName)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Company_tbl where CompanyName = '" + companyName + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            return false;

        }

        public List<Company> GetCompanies()
        {
            //SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-NQGNJQ07\SQLEXPRESS;Initial Catalog=StockManagement;Integrated Security=True");
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "select * from  Company_tbl";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Company> companies= new List<Company>();
            while (reader.Read())
            {
                Company company = new Company();
                company.CompanyName = reader["CompanyName"].ToString();
                company.CompanyId = Convert.ToInt32(reader["CompanyID"]);

                companies.Add(company);

            }
            reader.Close();
            con.Close();
            return companies;
        }

        public int Update(Company company)
        {
            SqlConnection con = new SqlConnection(ConnectinString);
            con.Open();
            string query = "Update   Company_tbl set CompanyName = '" + company.CompanyName + "' where CompanyId='" + company.CompanyId + "'";
            SqlCommand cmd = new SqlCommand(query, con);

            int rowCount = cmd.ExecuteNonQuery();
            con.Close();
            return rowCount;

        }
    }


}