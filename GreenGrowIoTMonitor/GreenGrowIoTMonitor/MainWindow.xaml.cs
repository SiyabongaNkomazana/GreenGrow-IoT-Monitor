using System;
using System.Collections.Generic;
using System.Windows;
using GreenGrowIoTMonitor.Models;
using GreenGrowIoTMonitor.Services;

namespace GreenGrowIoTMonitor
{
    public partial class MainWindow : Window
    {
        private readonly WeatherApiService _weatherApiService;

        // Stack used to maintain temperature sensor history.
        private readonly Stack<SensorReading> _temperatureHistory;

        public MainWindow()
        {
            InitializeComponent();

            _weatherApiService = new WeatherApiService();

            _temperatureHistory = new Stack<SensorReading>();
        }

        private async void RetrieveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RetrieveButton.IsEnabled = false;

                StatusText.Text = "CONNECTING...";
                StatusText.Foreground =
                    new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Colors.DarkOrange);

                // Retrieve real data from Open-Meteo.
                WeatherResponse weather =
                    await _weatherApiService.GetWeatherAsync();

                double temperature = weather.Current.Temperature2m;
                double humidity = weather.Current.RelativeHumidity2m;
                double windSpeed = weather.Current.WindSpeed10m;

                // Convert soil moisture from m³/m³ to a percentage.
                double soilMoisture =
                    weather.Current.SoilMoisture0To1cm * 100;

                // Display current environmental data.
                TemperatureText.Text = $"{temperature:F1} °C";
                HumidityText.Text = $"{humidity:F0} %";
                WindText.Text = $"{windSpeed:F1} km/h";
                SoilMoistureText.Text = $"{soilMoisture:F1} %";

                // Create a SensorReading object.
                SensorReading temperatureReading =
                    new SensorReading(
                        "Temperature",
                        temperature,
                        "°C",
                        "ONLINE");

                // Add the sensor reading to the Stack.
                _temperatureHistory.Push(temperatureReading);

                // Update the history information.
                UpdateHistoryDisplay();

                // Update system status.
                StatusText.Text = "ONLINE";
                StatusText.Foreground =
                    new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Colors.ForestGreen);

                LastUpdatedText.Text =
                    $"Last updated: {weather.Current.Time}";
            }
            catch (Exception ex)
            {
                StatusText.Text = "OFFLINE";
                StatusText.Foreground =
                    new System.Windows.Media.SolidColorBrush(
                        System.Windows.Media.Colors.Firebrick);

                MessageBox.Show(
                    $"Unable to retrieve weather data.\n\n{ex.Message}",
                    "API Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            finally
            {
                RetrieveButton.IsEnabled = true;
            }
        }

        private void PeekButton_Click(object sender, RoutedEventArgs e)
        {
            if (_temperatureHistory.Count == 0)
            {
                MessageBox.Show(
                    "There are no readings stored in the Stack.",
                    "No Readings",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            // Peek retrieves the latest reading without removing it.
            SensorReading latestReading =
                _temperatureHistory.Peek();

            LatestReadingText.Text =
                $"{latestReading.SensorValue:F1} {latestReading.Unit}";

            ReadingCountText.Text =
                _temperatureHistory.Count.ToString();
        }

        private void PopButton_Click(object sender, RoutedEventArgs e)
        {
            if (_temperatureHistory.Count == 0)
            {
                MessageBox.Show(
                    "There are no readings to remove.",
                    "No Readings",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);

                return;
            }

            // Pop removes the latest reading from the Stack.
            SensorReading removedReading =
                _temperatureHistory.Pop();

            UpdateHistoryDisplay();

            MessageBox.Show(
                $"{removedReading.SensorValue:F1} {removedReading.Unit} was removed from the Stack.",
                "Reading Removed",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        private void UpdateHistoryDisplay()
        {
            if (_temperatureHistory.Count == 0)
            {
                LatestReadingText.Text = "No readings stored";
                ReadingCountText.Text = "0";

                return;
            }

            // Peek is used to display the latest stored reading.
            SensorReading latestReading =
                _temperatureHistory.Peek();

            LatestReadingText.Text =
                $"{latestReading.SensorValue:F1} {latestReading.Unit}";

            ReadingCountText.Text =
                _temperatureHistory.Count.ToString();
        }
    }
}