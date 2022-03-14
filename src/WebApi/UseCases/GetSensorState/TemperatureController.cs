namespace WebApi.UseCases.GetSensorState
{
    using Application.Boundaries.GetSensorState;
    using FluentMediator;
    using Microsoft.AspNetCore.Mvc;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    /// <summary>
    /// Create an instance of <see cref="TemperatureController"/>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class TemperatureController : ControllerBase
    {
        /// <summary>
        ///  Get and set sensor state.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="presenter"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("state")]
        public async Task<IActionResult> GetSensorStateAsync([FromServices] IMediator mediator,
            [FromServices] GetSensorStatePresenter presenter,
            [FromBody][Required] GetSensorStateRequest request)
        {
            var input = new GetSensorStateInput(request.Temperature);
            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }
    }
}
