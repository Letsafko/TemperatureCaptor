namespace UnitTest.Application.UseCases.GetRequestedTemperatures
{
    using global::Application.Boundaries.GetTemperaturesRequested;
    using global::Domain.Entity;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApi.UseCases.GetTemperaturesRequested;
    using WebApi.ViewModels;
    using Xunit;

    public sealed class GetTemperaturesRequestedUseCaseTest
    {
        [Fact]
        public async Task Should_return_last_requested_temperatures_for_given_pagesize()
        {
            //arrange
            var temperatures = GetRandomTemperatures();
            var input = new GetTemperaturesRequestedInput(15);
            var useCase = GetTemperaturesRequestedUseCaseBuilder
                .Instance
                .WithGetTemperatures(temperatures)
                .WithPresenter(out GetTemperaturesRequestedPresenter presenter)
                .Build();

            //act
            await useCase.ExecuteAsync(input);
            var result = (presenter.ViewModel as OkObjectResult).Value as TemperatureCollectionViewModel;

            //assert
            Assert.NotNull(result);
            Assert.Equal(result.Count, input.PageSize);
            Assert.True(result.Count > 0);
        }

        private static IEnumerable<Sensor> GetRandomTemperatures()
        {
            var random = new Random();
            for (int i = 0; i < 20; i++)
            {
                var temperature = random.Next(15, 100);
                var state = GetState(temperature);
                yield return new Sensor(temperature, state);
            }
        }

        private static string GetState(double temperature)
        {
            return temperature > 40
                ? "HOT"
                : temperature > 22 && temperature <= 40 ? "WARM" : "COLD";
        }
    }
}