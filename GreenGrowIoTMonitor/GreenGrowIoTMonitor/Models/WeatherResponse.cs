using System.Text.Json.Serialization;

namespace GreenGrowIoTMonitor.Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("current")]
        public CurrentWeather Current { get; set; }
    }

    public class CurrentWeather
    {
        [JsonPropertyName("time")]
        public string Time { get; set; }

        [JsonPropertyName("temperature_2m")]
        public double Temperature2m { get; set; }

        [JsonPropertyName("relative_humidity_2m")]
        public double RelativeHumidity2m { get; set; }

        [JsonPropertyName("wind_speed_10m")]
        public double WindSpeed10m { get; set; }

        [JsonPropertyName("soil_moisture_0_to_1cm")]
        public double SoilMoisture0To1cm { get; set; }
    }
}