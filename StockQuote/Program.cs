
using StockQuote.Models;

namespace StockQuote
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isFormatted = args.Length == 3;
            if (!isFormatted)
            {
                Console.WriteLine("Formato incorreto. Você deve seguir o seguinte formato: NOME_DA_ACAO PRECO_DE_COMPRA PRECO_DE_VENDA");
                return;
            };

            string name;
            double buyPrice;
            double sellPrice;

            try
            {
                name = args[0];
                buyPrice = Double.Parse(args[1], System.Globalization.CultureInfo.InvariantCulture);
                sellPrice = Double.Parse(args[2], System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                Console.WriteLine("Houve um erro ao tentar formatar os valores. Tente novamente, por favor");
                return;
            }


            Stock stock = new(name, buyPrice, sellPrice);

            Console.WriteLine(stock.Name);
            Console.WriteLine(stock.BuyPrice);
            Console.WriteLine(stock.SellPrice);
        }
    }
}