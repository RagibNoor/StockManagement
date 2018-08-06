using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StockManagement.GateWay;
using StockManagement.Model;

namespace StockManagement.BLL
{
    public class ViewSalesBLL
    {
        ViewSalesGateway viewSalesGateway = new ViewSalesGateway();

        public List<Item> GetsellItem(string startDate, string endDate)
        {
            return viewSalesGateway.GetsellItem(startDate,endDate);
        }
    }
}