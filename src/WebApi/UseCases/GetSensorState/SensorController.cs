namespace WebApi.UseCases.GetSensorState
{
    using Application.Boundaries.GetSensorState;
    using Application.Services;
    using FluentMediator;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using WebApi.ViewModels;

    /// <summary>
    /// Create an instance of <see cref="SensorController"/>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class SensorController : ControllerBase
    {
        /// <summary>
        ///  Get sensor state.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="presenter"></param>
        /// <param name="temperatureCaptor">temperature captor</param>
        /// <returns></returns>
        [HttpGet("state")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemperatureViewModel))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> GetNewSensorStateAsync
            ([FromServices] IMediator mediator,
            [FromServices] GetSensorStatePresenter presenter,
            [FromServices] ITemperatureCaptor temperatureCaptor)
        {
            var temperataure = temperatureCaptor.GenerateNewTemperature();
            var input = new GetSensorStateInput(temperataure);
            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }
    }
}
