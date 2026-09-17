using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using GreenGrowIoTMonitor.Models;

namespace GreenGrowIoTMonitor.Services
{
    public class WeatherApiService
    {
        private readonly HttpClient _httpClient;

        public WeatherApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<WeatherResponse> GetWeatherAsync()
        {
            string url =
                "https://api.open-meteo.com/v1/forecast" +
                "?latitude=-25.7479" +
                "&longitude=28.2293" +
                "&current=temperature_2m,relative_humidity_2m,wind_speed_10m,soil_moisture_0_to_1cm" +
                "&temperature_unit=celsius" +
                "&wind_speed_unit=kmh" +
                "&timezone=Africa/Johannesburg";

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            WeatherResponse weather =
                JsonSerializer.Deserialize<WeatherResponse>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

            return weather;
        }
    }
}