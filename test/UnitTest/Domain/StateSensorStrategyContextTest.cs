namespace UnitTest.Domain
{
    using global::Domain.Strategy;
    using System;
    using Xunit;
    public sealed class StateSensorStrategyContextTest
    {
        [Theory]
        [InlineData(45)]
        [InlineData(30)]
        [InlineData(15)]
        public void Should_throw_invalidOperationException_if_strategy_not_found_for_given_temperature(double temperature)
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                StateSensorStrategyContextBuilder
                    .Instance
                    .Build()
                    .GetStrategy(temperature);
            })
            .Message
            .Equals("state sensor strategy not found");
        }


        [Theory]
        [InlineData(45, "HOT", typeof(HotSensorStrategy))]
        [InlineData(30, "WARM", typeof(WarmSensorStrategy))]
        [InlineData(15, "COLD", typeof(ColdSensorStrategy))]
        public void Should_return_right_strategy_for_given_temperature(double temperature, string temperatureState, Type strategyType)
        {
            //arrange
            var builder = StateSensorStrategyContextBuilder
                .Instance
                .WithStrategy(new WarmSensorStrategy(TemperatureConfigurationExtensions.GetWarmTemperatureRange()))
                .WithStrategy(new ColdSensorStrategy(TemperatureConfigurationExtensions.GetColdTemperature()))
                .WithStrategy(new HotSensorStrategy(TemperatureConfigurationExtensions.GetHotTemperature()))
                .Build();

            //act
            var strategy = builder.GetStrategy(temperature);

            //assert
            Assert.Equal(temperatureState, strategy.GetSensorState());
            Assert.Equal(strategyType, strategy.GetType());
        }
    }
}
