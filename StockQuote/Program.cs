
using StockQuote.Models;
using StockQuote.Services;
using StockQuote.Utils;
using System.Net.Mail;

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

                MailSenderService mail = new MailSenderService(from: configuration.MailFrom, to: configuration.MailTo, smtpPort: configuration.SmtpPort, smtpHost: configuration.SmtpHost, smtpPassword: configuration.SmtpPassword);
                Stock stock = new(name, buyPrice, sellPrice);

                while (true)
                {
                    StockMonitoringService stockMonitoringService = new StockMonitoringService(stock, configuration.ApiKey);

                    var stockValue = await stockMonitoringService.GetStockValue();
                    stock.FullName = stockValue.FullName;
                    stock.UpdateCurentPrice(stockValue.Price);

                    var stockStatus = stockMonitoringService.CalculateStockStatus();

                    if (stockStatus == StockStatusEnum.Hold)
                    {
                        Console.WriteLine("Sugerimos que você continue mantendo esta ação.");
                    }
                    else
                    {
                        Console.WriteLine("Estamos enviando um email...");
                        string subject = stockMonitoringService.GetFormattedMailSubject();
                        string body = stockMonitoringService.GetFormattedMailBody(stockStatus);
                        mail.SendMail(subject, body);
                    }

                    Console.WriteLine("Você deseja continuar monitorando esta ação? Se sim, escreva Y/y. Qualquer tecla diferente irá parar a execução do sistema.");

                    var pressedKey = Console.ReadKey();

                    Console.WriteLine();

                    if (pressedKey.Key != ConsoleKey.Y)
                    {
                        Console.WriteLine("Finalizando aplicação...");
                        break;
                    }

                    await Task.Delay(15000);
                }
            }
            catch (ConfigurationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Houve um erro ao tentar formatar os valores. Tente novamente, por favor. \n" + e.Message);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Houve um erro na API. Tente novamente, por favor. \n" + e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Houve um erro nos dados de entrada. Tente novamente, por favor. \n" + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um erro interno. Tente novamente, por favor. \n" + e.Message);
            }


        }
    }
}