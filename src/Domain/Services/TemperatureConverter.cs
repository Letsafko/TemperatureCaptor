namespace Domain.Services
{
    public sealed class TemperatureConverter : ITemperatureConverter
    {
        public double ToCelsius(double temperature)
        {
            return temperature;
        }
    }
}
