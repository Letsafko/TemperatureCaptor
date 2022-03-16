namespace UnitTest.Application.UseCases.GetRequestedTemperatures
{
    using global::Application.UseCases;
    using global::Domain.Entity;
    using global::Domain.Repository;
    using Infrastructure;
    using Infrastructure.Models;
    using System.Collections.Generic;
    using WebApi.UseCases.GetTemperaturesRequested;

    internal sealed class GetTemperaturesRequestedUseCaseBuilder
    {
        private readonly GetTemperaturesRequestedPresenter _presenter;
        private readonly ISensorRepository _temperatureRepository;
        private readonly SqliteContext _sqliteContext;

        private GetTemperaturesRequestedUseCaseBuilder()
        {
            _sqliteContext = SqlLiteContextExtensions.GetInMemoryContext();
            _temperatureRepository = new SensorRepository(_sqliteContext);
            _presenter = new GetTemperaturesRequestedPresenter();
        }

        internal static GetTemperaturesRequestedUseCaseBuilder Instance
            => new GetTemperaturesRequestedUseCaseBuilder();

        internal GetTemperaturesRequestedUseCase Build()
        {
            return new GetTemperaturesRequestedUseCase(_temperatureRepository,
                _presenter);
        }

        internal GetTemperaturesRequestedUseCaseBuilder WithGetTemperatures(IEnumerable<Sensor> temperatures)
        {
            AddTemperatures(_sqliteContext, temperatures);
            return this;
        }

        internal GetTemperaturesRequestedUseCaseBuilder WithPresenter(out GetTemperaturesRequestedPresenter presenter)
        {
            presenter = _presenter;
            return this;
        }

        private static void AddTemperatures(SqliteContext sqliteContext,
            IEnumerable<Sensor> temperatures)
        {
            var temperatturesDao = Convert(temperatures);
            sqliteContext
                .Sensors
                .AddRange(temperatturesDao);

            sqliteContext.SaveChanges();
        }

        private static IEnumerable<SensorDao> Convert(IEnumerable<Sensor> temperatures)
        {
            foreach (var temp in temperatures)
            {
                yield return new SensorDao
                {
                    State = temp.State,
                    Temperature = temp.Temperature
                };
            }
        }
    }
}
