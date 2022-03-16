using Application.Boundaries.GetTemperaturesRequested;
using FluentMediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApi.ViewModels;

namespace WebApi.UseCases.GetTemperaturesRequested
{

    /// <summary>
    /// Create an instance of <see cref="SensorController"/>
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public sealed class SensorController : ControllerBase
    {
        /// <summary>
        ///  Get last requested meseaures.
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="presenter"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet("history")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TemperatureCollectionViewModel))]
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
