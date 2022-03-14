using Application.Boundaries.GetSensorState;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.UseCases.GetSensorState;
using Xunit;
namespace UnitTest.Application.UseCases.GetSensorState
{
    public class GetSensorStateUseCaseTest
    {
        [Theory]
        [InlineData(-275)]
        [InlineData(-300)]
        [InlineData(101)]
        [InlineData(150)]
        public async Task Should_return_badrequest_if_given_temperature_not_in_right_range(double temperature)
        {
            //arrange
            var input = new GetSensorStateInput(temperature);
            var expectedMessage = "not valid celsius temperature.";
            var useCase = GetSensorStateUseCaseBuilder
                .Instance
                .WithPresenter(out GetSensorStatePresenter presenter)
                .Build();

            //act
            await useCase.ExecuteAsync(input);
            var result = (presenter.ViewModel as BadRequestObjectResult).Value.ToString();

            //assert
            Assert.Equal(expectedMessage, result);
        }


        [Theory]
        [InlineData(21, "COLD")]
        [InlineData(30, "WARM")]
        [InlineData(45, "HOT")]
        public async Task Should_return_right_sensor_state_for_given_temperature(double temperature, string state)
        {
            //arrange
            var input = new GetSensorStateInput(temperature);
            var expectedTemperatureToSave = new Temperature(temperature, state);
            var useCase = GetSensorStateUseCaseBuilder
                .Instance
                .WithAddTemperature(expectedTemperatureToSave)
                .WithPresenter(out GetSensorStatePresenter presenter)
                .Build();

            //act
            await useCase.ExecuteAsync(input);
            var result = (presenter.ViewModel as OkObjectResult).Value.ToString();

            //assert
            Assert.Equal(state, result);
        }
    }
}
