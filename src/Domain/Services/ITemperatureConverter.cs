namespace Domain.Services
{
    public interface ITemperatureConverter
    {
        //TODO: i don't know if it's planned to make conversion between temperatures regarding requirement n° 1
        double ToCelsius(double temperature);
    }
}
