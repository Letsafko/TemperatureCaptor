namespace WebApi.UseCases.GetSensorState
{
    using Application.Boundaries.GetSensorState;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    ///  Get sensor state presenter.
    /// </summary>
    public sealed class GetSensorStatePresenter : IOutputPort
    {
        /// <summary>
        /// viewmodel
        /// </summary>
        public IActionResult ViewModel { get; private set; }

        /// <summary>
        ///  standard output
        /// </summary>
        /// <param name="output"></param>
        public void Standard(GetSensorStateOutput output)
        {
            ViewModel = new OkObjectResult(output.State);
        }
    }
}
