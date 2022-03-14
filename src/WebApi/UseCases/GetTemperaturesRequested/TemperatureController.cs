using Application.Boundaries.GetTemperaturesRequested;
using FluentMediator;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace WebApi.UseCases.GetTemperaturesRequested
{

    /// <summary>
    /// Create an instance of <see cref="TemperatureController"/>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class TemperatureController : ControllerBase
    {
        /// <summary>
        ///  Get last requested temperatures.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="presenter"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("history")]
        public async Task<IActionResult> GetSensorStateAsync([FromServices] IMediator mediator,
            [FromServices] GetTemperaturesRequestedPresenter presenter,
            [FromQuery][Required] GetTemperaturesRequestedRequest request)
        {
            var input = new GetTemperaturesRequestedInput(request.PageSize);
            await mediator.PublishAsync(input);
            return presenter.ViewModel;
        }
    }
}
