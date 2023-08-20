using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockQuote.Models
{
    public class Stock
    {
        public string Name { get; set; }
        public int? Price { get; set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }

        public Stock(string name, double buyPrice, double sellPrice)
        {
            Name = name;
            BuyPrice = Convert.ToInt32(buyPrice * 100);
            SellPrice = Convert.ToInt32(sellPrice * 100);
        }
    }
}