namespace WebApi.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class TemperatureViewModel
    {
        /// <summary>
        /// Creates an instance of <see cref="TemperatureViewModel"/>
        /// </summary>
        /// <param name="state"></param>
        /// <param name="temperature"></param>
        public TemperatureViewModel(string state, double temperature)
        {
            Temperature = temperature;
            State = state;
        }

        /// <summary>
        /// Gets temperature
        /// </summary>
        public double Temperature { get; }

        /// <summary>
        /// Gets sensor state according to given temperature.
        /// </summary>
        public string State { get; }
    }
}
