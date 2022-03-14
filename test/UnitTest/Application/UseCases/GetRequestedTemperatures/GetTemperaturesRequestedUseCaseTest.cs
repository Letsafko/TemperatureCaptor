namespace UnitTest.Application.UseCases.GetRequestedTemperatures
{
    using global::Application.Boundaries.GetTemperaturesRequested;
    using global::Domain.Entity;
    using Moq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public sealed class GetTemperaturesRequestedUseCaseTest
    {
        [Fact]
        public async Task Should_return_last_requested_temperatures_for_given_pagesize()
        {
            //arrange
            var mocks = new List<Mock>();
            const string Cold = "COLD";
            const int temperature = 18;
            var expectedTemperatures = new List<Temperature> { new Temperature(temperature, Cold) };
            var expectedTemperaturesOutput = new List<GetTemperaturesRequestedOutput> { new GetTemperaturesRequestedOutput(Cold, $"{temperature} °c") };
            var input = new GetTemperaturesRequestedInput(15);
            var useCase = GetTemperaturesRequestedUseCaseBuilder
                .Instance
                .WithGetTemperatures(input.PageSize, expectedTemperatures)
                .WithPresenter(expectedTemperaturesOutput)
                .Build(mocks);

            //act
            await useCase.ExecuteAsync(input);

            //act
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
