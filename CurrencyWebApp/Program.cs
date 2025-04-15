using System.Net.Http;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", async (HttpContext context) =>
{
    var request = context.Request;
    var from = request.Query["from"];
    var to = request.Query["to"];
    var amount = request.Query["amount"];

    string resultHtml = "";

    if (!string.IsNullOrWhiteSpace(from) && !string.IsNullOrWhiteSpace(to) && !string.IsNullOrWhiteSpace(amount))
    {
        string apiKey = "97da8436fdbaec91fc27e297"; // 🔁 GANTI DI SINI DENGAN API KEY ANDA
        string url = $"https://v6.exchangerate-api.com/v6/{apiKey}/pair/{from}/{to}/{amount}";

        try
        {
            using HttpClient client = new();
            var json = await client.GetStringAsync(url);
            using JsonDocument doc = JsonDocument.Parse(json);

            if (doc.RootElement.TryGetProperty("conversion_result", out JsonElement resultElement))
            {
                double result = resultElement.GetDouble();
                resultHtml = $"<div class='alert alert-success mt-4'>💱 <strong>{amount} {from.ToString().ToUpper()}</strong> = <strong>{result:F2} {to.ToString().ToUpper()}</strong></div>";
            }
            else
            {
                resultHtml = "<div class='alert alert-danger mt-4'>❌ API did not return a valid result.</div>";
            }
        }
        catch (Exception ex)
        {
            resultHtml = $"<div class='alert alert-danger mt-4'>❌ Error: {ex.Message}</div>";
        }
    }

    return Results.Content($@"
<!DOCTYPE html>
<html>
<head>
    <meta charset='UTF-8'>
    <title>Currency Converter</title>
    <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css' rel='stylesheet'>
</head>
<body class='container mt-5'>
    <h2 class='mb-4'>💱 Currency Converter</h2>
    <form method='get' action='/' class='row g-3'>
        <div class='col-md-3'>
            <input name='from' class='form-control' placeholder='From (e.g. USD)' value='{from}' required />
        </div>
        <div class='col-md-3'>
            <input name='to' class='form-control' placeholder='To (e.g. IDR)' value='{to}' required />
        </div>
        <div class='col-md-3'>
            <input name='amount' class='form-control' placeholder='Amount' value='{amount}' required />
        </div>
        <div class='col-md-3'>
            <button type='submit' class='btn btn-primary w-100'>Convert</button>
        </div>
    </form>
    {resultHtml}
</body>
</html>
", "text/html");
});

app.Run();
