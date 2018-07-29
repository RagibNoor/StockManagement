using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagement.GateWay;
using StockManagement.Model;

namespace StockManagement.BLL
{
    public class CompanySetupBLL
    {
        CompanySetupGateway companySetupGateway = new CompanySetupGateway();

        public String Save(Company company)
        {
            if (companySetupGateway.IsExsit(company.CompanyName))
            {
                return "already exist";
            }
            else
            {
                if (companySetupGateway.Save(company) > 0)
                {
                    return "save";
                }

                else
                {
                    return "Invalid";
                }
            }
        }

        public List<Company> GetCompanies()
        {
            return companySetupGateway.GetCompanies();
        }

        public int Update(Company company)
        {
            return companySetupGateway.Update(company);
        }
    }
}