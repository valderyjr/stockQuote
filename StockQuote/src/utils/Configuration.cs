using System.Text.Json.Serialization;

namespace StockQuote.Utils
{
    public class ConfigurationException : Exception
    {

        public ConfigurationException(string message)
            : base("Invalid configuration. Please see the README.md file and update your configs: " + message)
        {

        }
    }
    public record class Configuration(
   [property: JsonPropertyName("apiKey")] string ApiKey);
}
