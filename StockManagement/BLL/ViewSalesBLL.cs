using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
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
        public List<Item> GetLessSellItem(string startDate, string endDate)
        {
            List<Item> items =  viewSalesGateway.GetsellItem(startDate, endDate);
            List<Item> uniqueItem = new List<Item>();
            foreach (var item in items)
            {
                if (uniqueItem==null)
                {
                    uniqueItem.Add(item);
                }
                else
                {
                    int flag = 0;
                    foreach (var data in uniqueItem)
                    {
                        if (data.ItemId == item.ItemId)
                        {
                            data.StockOut += item.StockOut;
                            flag = 1;
                        }
                    }
                    if (flag==0)
                    {
                        uniqueItem.Add(item);
                    }
                }
              
            }
            return uniqueItem;
        }
    }
}