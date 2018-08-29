using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using StockManagement.GateWay;
using StockManagement.Model;

namespace StockManagement.BLL
{
    public class ItemSetupBLL
    {
        CategorySetupGateway categorySetupGateway = new CategorySetupGateway();
        CompanySetupGateway companySetupGateway = new CompanySetupGateway();
        ItemSetupGateway itemSetupGateway = new ItemSetupGateway();

        public List<Category> GetCategories()
        {
            List<Category> categories = categorySetupGateway.GetCategories();
            List<Category> newCategories = new List<Category>();
            Category aCategory = new Category();
            aCategory.CategoryName = "Select All";
            aCategory.CategoryId = 0;
            newCategories.Add(aCategory);

            foreach (var categori in categories)
            {
                newCategories.Add(categori);
            }

            return newCategories;
        }

        public int GetQuantity(int itemID)
        {
            int stockInQuantity = itemSetupGateway.GetStockInQuantity(itemID);
            //foreach (var data in )
            //{
            //    stockInQuantity += data;
            //}
            int stockOutQuantity = itemSetupGateway.GetStockOutQuantity(itemID);
            //foreach (var data in )
            //{
            //    stockOutQuantity += data;
            //}
            return stockInQuantity - stockOutQuantity;
        }
        public List<Company> GetCompanies()
        {
            List<Company> companies = companySetupGateway.GetCompanies();
            List<Company> newCompanies = new List<Company>();
            Company aCompany = new Company();
            aCompany.CompanyName = "Select All";
            aCompany.CompanyId = 0;
            newCompanies.Add(aCompany);
            foreach (var company in companies)
            {
                newCompanies.Add(company);
            }
            return newCompanies;
        }

        public List<Item> GetItems(string company)
        {
            return itemSetupGateway.GeItems(company);
        }

        public Item GetReorderAndAmmount(int ItemID)
        {
            return itemSetupGateway.GetReorderAndAmmount(ItemID);
        }

        public string AddItem(Item item)
        {
            if (itemSetupGateway.IsExsit(item.ItemName))
            {
                return "already exist";
            }
            else
            {
                if (itemSetupGateway.AddItem(item) > 0)
                {
                    return "save";
                }

                else
                {
                    return "Invalid";
                }
            }
          
        }

        public int UpdateStockInQuantity(Item item)
        {
            return itemSetupGateway.UpdateStockInQuantity(item);
        }

        public int StockOut(List<Item> items, string reason)
        {
            return itemSetupGateway.StockOut(items, reason);
        }

        public List<Item> GetSearchItems(int companyId, int categoryId)
        {
            return itemSetupGateway.GetSearchItems(companyId, categoryId);
        }

    }
}