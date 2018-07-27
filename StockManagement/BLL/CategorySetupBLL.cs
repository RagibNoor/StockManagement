using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagement.GateWay;
using StockManagement.Model;

namespace StockManagement.BLL
{
    public class CategorySetupBLL
    {
        CategorySetupGateway categorySetupGateway = new CategorySetupGateway();

        public String Save(Category category)
        {
            if (categorySetupGateway.IsExsit(category.CategoryName))
            {
                return "already exist";
            }
            else
            {
                if (categorySetupGateway.Save(category) > 0)
                {
                    return "save";
                }

                else
                {
                    return "Invalid";
                }
            }
        }

        public List<Category> GetCategories()
        {
            return categorySetupGateway.GetCategories();
        }

        public int Update(Category category)
        {
            return categorySetupGateway.Update(category);
        }
    }
}