using System.Text.Json;

namespace StockQuote.Utils
{

    public static class FileReader
    {
        public static T ReadFile<T>(string pathToFile)
        {
            try
            {
                using FileStream file = File.OpenRead(@$"{pathToFile}");

                var formattedFile = JsonSerializer.Deserialize<T>(file);


                if (formattedFile == null)
                {
                    throw new Exception("File cannot be null");
                };

                return formattedFile;
            }
            catch (Exception e)
            {
                throw new ConfigurationException(e.Message);
            }

        }
    }
}
