﻿
using StockQuote.Models;
using StockQuote.Services;
using StockQuote.Utils;

namespace StockQuote
{
    public class Program
    {
        static async Task Main(string[] args)
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
            Configuration configuration;

            try
            {
                configuration = FileReader.ReadFile<Configuration>("./AppConfig.json");
                name = args[0];
                buyPrice = Double.Parse(args[1], System.Globalization.CultureInfo.InvariantCulture);
                sellPrice = Double.Parse(args[2], System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (ConfigurationException e) 
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um erro ao tentar formatar os valores. Tente novamente, por favor");
                return;
            }


            Stock stock = new(name, buyPrice, sellPrice);
            StockMonitoringService stockMonitoringService = new StockMonitoringService(stock, configuration.ApiKey);

            try
            {
                var stockValue = await stockMonitoringService.GetStockValue();
                Console.WriteLine(stockValue.FullName);
                Console.WriteLine(stockValue.Price);    
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Houve um erro na API. Tente novamente, por favor. " + e.Message);
            }
            catch(Exception e) { 
                Console.WriteLine("Houve um erro na interno. Tente novamente, por favor. " + e.Message);
            }


        }
    }
}