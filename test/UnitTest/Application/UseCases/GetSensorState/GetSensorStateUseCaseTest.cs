using Application.Boundaries.GetSensorState;
using Domain.Entity;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
namespace UnitTest.Application.UseCases.GetSensorState
{
    public class GetSensorStateUseCaseTest
    {
        [Theory]
        [InlineData(21, "COLD")]
        [InlineData(30, "WARM")]
        [InlineData(45, "HOT")]
        public async Task Should_return_right_sensor_state_for_given_temperature(double temperature, string state)
        {
            //arrange
            var mocks = new List<Mock>();
            var input = new GetSensorStateInput(temperature);
            var expectedTemperatureToSave = new Temperature(temperature, state);
            var expectedSensorState = new GetSensorStateOutput(state);
            var useCase = GetSensorStateUseCaseBuilder
                .Instance
                .WithAddTemperature(expectedTemperatureToSave)
                .WithPresenter(expectedSensorState)
                .Build(mocks);

            //act
            await useCase.ExecuteAsync(input);

            //assert
            VerifyAll(mocks);
        }

        private static void VerifyAll(List<Mock> mocks)
        {
            foreach (var mock in mocks)
            {
                mock.Verify();
            }
        }
    }
}
