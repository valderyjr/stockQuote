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

        public string? FullName { get; set; }
        public int? Price { get; private set; }
        public int BuyPrice { get; set; }
        public int SellPrice { get; set; }

        public Stock(string name, double buyPrice, double sellPrice)
        {
            Name = name;
            BuyPrice = Convert.ToInt32(buyPrice * 100);
            SellPrice = Convert.ToInt32(sellPrice * 100);
        }

        public void UpdateCurentPrice (double price)
        {
            Price = Convert.ToInt32(price * 100);
        }

        public override string ToString()
        {
            return $"O produto {Name} de nome {FullName} possui como seu atual valor {Price}, e valores de compra e venda: {BuyPrice} e {SellPrice}";
        }
    }
}