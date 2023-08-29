using System.Text.Json.Serialization;

namespace StockQuote.Utils
{
    public class ConfigurationException : Exception
    {

        public ConfigurationException()
        {
        }
        public ConfigurationException(string message)
            : base("Configuração inválida. Leia o arquivo README.md e atualize as suas configurações, por favor. \n" + message)
        {

        }

        public ConfigurationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public record class Configuration(
   [property: JsonPropertyName("apiKey")] string ApiKey,
   [property: JsonPropertyName("mailFrom")] string MailFrom,
   [property: JsonPropertyName("mailTo")] string MailTo,
   [property: JsonPropertyName("smtpPort")] int SmtpPort,
   [property: JsonPropertyName("smtpHost")] string SmtpHost,
   [property: JsonPropertyName("smtpPassword")] string SmtpPassword);
}
