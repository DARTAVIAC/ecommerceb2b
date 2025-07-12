using EcommerceB2C.Data;
using System.Net.Http.Json;

public class WeatherService
{
    private readonly HttpClient _http;
    private readonly string apiKey = "2811b06f30a2adddd73323300e348734";
    
    public WeatherService(HttpClient http) => _http = http;
    public async Task<WeatherInfo?> GetWeatherAsync(double lat, double lon) =>
        await _http.GetFromJsonAsync<WeatherInfo>(
            $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=metric");
}
