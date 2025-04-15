using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== Currency Converter ===");

        CurrencyConverter.ShowAvailableCurrencies();

        Console.Write("Use real-time exchange rates? (y/n): ");
        string useOnline = Console.ReadLine()?.Trim().ToLower() ?? "n";

        Console.Write("Enter amount: ");
        string amount = Console.ReadLine() ?? "";

        Console.Write("From currency code (e.g. USD): ");
        string fromCode = Console.ReadLine()?.Trim().ToUpper() ?? "";

        Console.Write("To currency code (e.g. IDR): ");
        string toCode = Console.ReadLine()?.Trim().ToUpper() ?? "";

        string result;

        if (useOnline == "y")
        {
            result = await CurrencyConverter.ConvertAmountOnline(amount, fromCode, toCode);
        }
        else
        {
            result = CurrencyConverter.ConvertAmount(amount, fromCode, toCode);
        }

        Console.WriteLine("\n" + result);
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
