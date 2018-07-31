using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockManagement.Model
{
    public class Item
    {
        public String ItemName { get; set; }
        public string ItemCategory { get; set; }
        public string ItemCompany { get; set; }
        public int Reorder { get; set; }
        public int StockIn { get; set; }

        public int StockOut { get; set; }
        public int ItemId { get; set; }
    }
}