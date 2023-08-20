
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

        }
    }
}