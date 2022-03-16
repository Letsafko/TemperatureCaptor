namespace WebApi.ViewModels
{
    using Application.Boundaries.GetTemperaturesRequested;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public sealed class TemperatureCollectionViewModel : List<TemperatureViewModel>
    {
        /// <summary>
        /// Creates an instance of <see cref="TemperatureCollectionViewModel"/>
        /// </summary>
        /// <param name="temperatures"></param>
        public TemperatureCollectionViewModel(IEnumerable<GetTemperaturesRequestedOutput> temperatures)
        {
            foreach (var temp in temperatures)
            {
                Add(new TemperatureViewModel(temp.State, temp.Temperature));
            }
        }
    }
}
