using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagement.Model
{
    [Serializable]
    public class Item 
    {
        public String ItemName { get; set; }
        public int CategoryId { get; set; }
        public int CompanyId { get; set; }
        public int Reorder { get; set; }
        public int StockIn { get; set; }

        public int StockOut { get; set; }
        public int ItemId { get; set; }
        public string CompanyName { get; set; }
        public string CategoryName { get; set; }
        public string StockOutDate { get; set; }

        public string StockInDate { get; set; }
        public int  AvilableQuantity { get; set; }
    }
}