using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CurrencyController : ControllerBase
{
    [HttpGet("convert")]
    public async Task<IActionResult> Convert(string from, string to, double amount)
    {
        string apiKey = "97da8436fdbaec91fc27e297"; // Ganti dengan API key dari exchangerate-api.com
        string url = $"https://v6.exchangerate-api.com/v6/{apiKey}/pair/{from}/{to}/{amount}";

        using HttpClient client = new();
        try
        {
            string json = await client.GetStringAsync(url);
            using JsonDocument doc = JsonDocument.Parse(json);

            if (doc.RootElement.TryGetProperty("conversion_result", out JsonElement result))
            {
                return Ok(new
                {
                    From = from.ToUpper(),
                    To = to.ToUpper(),
                    Amount = amount,
                    Result = result.GetDouble()
                });
            }

            return BadRequest("API response error.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }
}