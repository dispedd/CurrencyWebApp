using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class Currency
{
    public double USDPerUnit { get; set; }
    public double UnitsPerUSD { get; set; }
}

public static class CurrencyConverter
{
    private static readonly Dictionary<string, Currency> currencyDictionary = new()
    {
        { "USD", new Currency { USDPerUnit = 1.0, UnitsPerUSD = 1.0 } },
        { "EUR", new Currency { USDPerUnit = 1.07, UnitsPerUSD = 0.9345 } },
        { "JPY", new Currency { USDPerUnit = 0.0067, UnitsPerUSD = 149.25 } },
        { "CNY", new Currency { USDPerUnit = 0.14, UnitsPerUSD = 7.1 } },
        { "INR", new Currency { USDPerUnit = 0.012, UnitsPerUSD = 83.3 } },
        { "GBP", new Currency { USDPerUnit = 1.26, UnitsPerUSD = 0.79 } },
        { "BRL", new Currency { USDPerUnit = 0.20, UnitsPerUSD = 5.0 } },
        { "RUB", new Currency { USDPerUnit = 0.011, UnitsPerUSD = 92 } },
        { "KRW", new Currency { USDPerUnit = 0.00075, UnitsPerUSD = 1330 } },
        { "IDR", new Currency { USDPerUnit = 0.000065, UnitsPerUSD = 15385 } },
        { "MXN", new Currency { USDPerUnit = 0.059, UnitsPerUSD = 17 } },
        { "CAD", new Currency { USDPerUnit = 0.73, UnitsPerUSD = 1.37 } },
        { "AUD", new Currency { USDPerUnit = 0.66, UnitsPerUSD = 1.52 } },
        { "CHF", new Currency { USDPerUnit = 1.1, UnitsPerUSD = 0.91 } },
        { "SEK", new Currency { USDPerUnit = 0.095, UnitsPerUSD = 10.5 } },
        { "NOK", new Currency { USDPerUnit = 0.091, UnitsPerUSD = 11.0 } },
        { "SGD", new Currency { USDPerUnit = 0.74, UnitsPerUSD = 1.35 } },
        { "HKD", new Currency { USDPerUnit = 0.13, UnitsPerUSD = 7.8 } },
        { "TRY", new Currency { USDPerUnit = 0.031, UnitsPerUSD = 32.0 } },
        { "SAR", new Currency { USDPerUnit = 0.27, UnitsPerUSD = 3.75 } },
        { "AED", new Currency { USDPerUnit = 0.27, UnitsPerUSD = 3.67 } },
        { "ZAR", new Currency { USDPerUnit = 0.055, UnitsPerUSD = 18.0 } },
        { "MYR", new Currency { USDPerUnit = 0.21, UnitsPerUSD = 4.75 } },
        { "THB", new Currency { USDPerUnit = 0.028, UnitsPerUSD = 36.0 } },
        { "PLN", new Currency { USDPerUnit = 0.25, UnitsPerUSD = 4.0 } },
        { "EGP", new Currency { USDPerUnit = 0.021, UnitsPerUSD = 47.0 } },
        { "ARS", new Currency { USDPerUnit = 0.0012, UnitsPerUSD = 835.0 } },
        { "PKR", new Currency { USDPerUnit = 0.0036, UnitsPerUSD = 278.0 } },
        { "NGN", new Currency { USDPerUnit = 0.00065, UnitsPerUSD = 1538.0 } },
        { "BDT", new Currency { USDPerUnit = 0.0091, UnitsPerUSD = 110.0 } },
        { "VND", new Currency { USDPerUnit = 0.000042, UnitsPerUSD = 23810 } },
        { "DZD", new Currency { USDPerUnit = 0.0074, UnitsPerUSD = 135.0 } },
        { "KZT", new Currency { USDPerUnit = 0.0022, UnitsPerUSD = 455.0 } },
        { "COP", new Currency { USDPerUnit = 0.00025, UnitsPerUSD = 4000 } },
        { "ILS", new Currency { USDPerUnit = 0.27, UnitsPerUSD = 3.7 } },
        { "CZK", new Currency { USDPerUnit = 0.043, UnitsPerUSD = 23.3 } },
        { "HUF", new Currency { USDPerUnit = 0.0028, UnitsPerUSD = 360 } },
        { "DKK", new Currency { USDPerUnit = 0.14, UnitsPerUSD = 7.1 } },
        { "CLP", new Currency { USDPerUnit = 0.001, UnitsPerUSD = 950 } },
        { "UAH", new Currency { USDPerUnit = 0.026, UnitsPerUSD = 38.0 } },
        { "IQD", new Currency { USDPerUnit = 0.00076, UnitsPerUSD = 1310 } },
        { "QAR", new Currency { USDPerUnit = 0.27, UnitsPerUSD = 3.64 } },
        { "OMR", new Currency { USDPerUnit = 2.6, UnitsPerUSD = 0.385 } },
        { "KWD", new Currency { USDPerUnit = 3.25, UnitsPerUSD = 0.308 } },
        { "BHD", new Currency { USDPerUnit = 2.65, UnitsPerUSD = 0.377 } },
        { "LBP", new Currency { USDPerUnit = 0.000067, UnitsPerUSD = 14950 } },
        { "MAD", new Currency { USDPerUnit = 0.10, UnitsPerUSD = 9.9 } },
        { "TWD", new Currency { USDPerUnit = 0.031, UnitsPerUSD = 32.3 } }
    };

    public static void ShowAvailableCurrencies()
    {
        Console.WriteLine("\nSupported currency codes:");
        foreach (var code in currencyDictionary.Keys.OrderBy(c => c))
        {
            Console.Write(code + " ");
        }
        Console.WriteLine("\n");
    }

    public static string ConvertAmount(string amount, string fromCode, string toCode)
    {
        fromCode = fromCode.Trim().ToUpper();
        toCode = toCode.Trim().ToUpper();

        if (!currencyDictionary.TryGetValue(fromCode, out var fromCurrency))
            return $"Currency '{fromCode}' not found.";

        if (!currencyDictionary.TryGetValue(toCode, out var toCurrency))
            return $"Currency '{toCode}' not found.";

        if (!double.TryParse(amount, out var value))
            return "Invalid amount format.";

        double amountInUSD = value * fromCurrency.USDPerUnit;
        double result = amountInUSD * toCurrency.UnitsPerUSD;

        return $"{value} {fromCode} = {result:F2} {toCode} (local)";
    }

    public static async Task<string> ConvertAmountOnline(string amount, string fromCode, string toCode)
    {
        if (!double.TryParse(amount, out var value))
            return "Invalid amount format.";

        fromCode = fromCode.Trim().ToUpper();
        toCode = toCode.Trim().ToUpper();

        string apiKey = "97da8436fdbaec91fc27e297"; // 🔁 Ganti dengan API key Anda
        string url = $"https://v6.exchangerate-api.com/v6/{apiKey}/pair/{fromCode}/{toCode}/{value}";

        try
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return $"API request failed: {response.StatusCode}";

            string json = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(json);

            if (doc.RootElement.TryGetProperty("conversion_result", out JsonElement resultElement))
            {
                double result = resultElement.GetDouble();
                return $"{value} {fromCode} = {result:F2} {toCode} (real-time)";
            }
            else
            {
                return "❌ API did not return a valid result.";
            }
        }
        catch (Exception ex)
        {
            return $"Error accessing API: {ex.Message}";
        }
    }
}
