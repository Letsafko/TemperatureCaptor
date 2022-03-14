namespace WebApi.ViewModels
{
    public sealed class GetTemperaturesRequestedViewModel
    {
        public GetTemperaturesRequestedViewModel(string state, string temperature)
        {
            Temperature = temperature;
            State = state;
        }

        public string Temperature { get; }
        public string State { get; }
    }
}
