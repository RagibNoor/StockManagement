using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return categorySetupGateway.GetCategories();
        }

        public List<Company> GetCompanies()
        {
            return companySetupGateway.GetCompanies();
        }

        public List<Item> GetItems(string company)
        {
            return itemSetupGateway.GeItems(company);
        }

        public Item GetReorderAndAmmount(int ItemID)
        {
            return itemSetupGateway.GetReorderAndAmmount(ItemID);
        }

        public int AddItem(Item item)
        {
            return itemSetupGateway.AddItem(item);
        }

        public int UpdateQuantity(Item item)
        {
            return itemSetupGateway.UpdateQuantity(item);
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