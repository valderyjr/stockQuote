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
            int formattedBuyPrice = Convert.ToInt32(buyPrice * 100);
            int formattedSellPrice = Convert.ToInt32(sellPrice * 100);

            ValidateBuyAndSellPrices(formattedBuyPrice, formattedSellPrice);

            Name = name;
            BuyPrice = Convert.ToInt32(buyPrice * 100);
            SellPrice = Convert.ToInt32(sellPrice * 100);
        }
        private void ValidateBuyAndSellPrices(int buyPrice, int sellPrice)
        {
            if (buyPrice <= 0 || sellPrice <= 0)
            {
                throw new ArgumentException("O valor de compra/venda não pode ser negativo ou igual a zero.");
            };

            if (buyPrice > sellPrice)
            {
                throw new ArgumentException("O valor de compra não pode ser maior que o valor de venda.");
            };
        }
        public void UpdateCurentPrice(double price)
        {
            Price = Convert.ToInt32(price * 100);
        }

        public string FormatPriceToUser()
        {
            double price = Price != null ? (double)Price / 100 : 0;
            return price.ToString("N2", System.Globalization.CultureInfo.InvariantCulture);
        }
   
    }
}