namespace GreenGrowIoTMonitor.Models
{
    public class SensorReading
    {
        public string SensorName { get; set; }

        public double SensorValue { get; set; }

        public string Unit { get; set; }

        public string Status { get; set; }

        public SensorReading(string sensorName, double sensorValue, string unit, string status)
        {
            SensorName = sensorName;
            SensorValue = sensorValue;
            Unit = unit;
            Status = status;
        }
    }
}