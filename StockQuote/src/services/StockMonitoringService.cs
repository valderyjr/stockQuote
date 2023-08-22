using StockQuote.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StockQuote.Services
{
    public record class StockMonitoringResponseItem(
    [property: JsonPropertyName("longName")] string FullName,
    [property: JsonPropertyName("regularMarketPrice")] double Price);
    public record class StockMonitoringResponse(
        [property: JsonPropertyName("results")] IEnumerable<StockMonitoringResponseItem> Results);
    public class StockMonitoringService
    {
        private readonly Stock _stock;
        private readonly string _stockQuoteApiUrl = "https://brapi.dev/api";
        private readonly string _stockQuoteApiToken;
        public StockMonitoringService(Stock stock, string stockQuoteApiToken)
        {
            _stock = stock;
            _stockQuoteApiToken = stockQuoteApiToken;
        }

        public async Task<StockMonitoringResponseItem> GetStockValue()
        {
            if (_stock == null)
            {
                throw new Exception("Stock is not provided");
            }

            if (_stockQuoteApiToken == null)
            {
                throw new Exception("Stock API Token is not provided");
            }

            using (var httpClient = new HttpClient())
            {
                await using Stream responseStockValue = await httpClient.GetStreamAsync($"{_stockQuoteApiUrl}/quote/{_stock.Name}?token={_stockQuoteApiToken}");


                var formattedContent =
                    await JsonSerializer.DeserializeAsync<StockMonitoringResponse>(responseStockValue);


                if (formattedContent == null)
                {
                    throw new Exception("Não conseguimos encontrar este item. Tente novamente, por favor.");
                }

                return formattedContent.Results.First();
            }


        }
    }
}
