namespace WebApi.UseCases.GetTemperaturesRequested
{
    using Application.Boundaries.GetTemperaturesRequested;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using WebApi.ViewModels;

    /// <summary>
    /// Get last requested temperatures presenter
    /// </summary>
    public sealed class GetTemperaturesRequestedPresenter : IOutputPort
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        public IActionResult ViewModel { get; private set; }

        /// <summary>
        ///  standard output
        /// </summary>
        /// <param name="output"></param>
        public void Standard(List<GetTemperaturesRequestedOutput> output)
        {
            ViewModel = new OkObjectResult(new TemperatureCollectionViewModel(output));
        }
    }
}
