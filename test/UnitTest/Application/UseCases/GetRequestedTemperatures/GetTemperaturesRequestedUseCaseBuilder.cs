namespace UnitTest.Application.UseCases.GetRequestedTemperatures
{
    using global::Application.UseCases;
    using global::Domain.Entity;
    using global::Domain.Repository;
    using Infrastructure;
    using Infrastructure.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using WebApi.UseCases.GetTemperaturesRequested;

    internal sealed class GetTemperaturesRequestedUseCaseBuilder
    {
        private readonly GetTemperaturesRequestedPresenter _presenter;
        private ITemperatureRepository _temperatureRepository;
        private readonly SqlLiteContext _sqliteContext;

        private GetTemperaturesRequestedUseCaseBuilder()
        {
            _sqliteContext = SqlLiteContextExtensions.GetInMemoryContext();
            _temperatureRepository = new TemperatureRepository(_sqliteContext);
            _presenter = new GetTemperaturesRequestedPresenter();
        }

        internal static GetTemperaturesRequestedUseCaseBuilder Instance
            => new GetTemperaturesRequestedUseCaseBuilder();

        internal GetTemperaturesRequestedUseCase Build()
        {
            return new GetTemperaturesRequestedUseCase(_temperatureRepository,
                _presenter);
        }

        internal GetTemperaturesRequestedUseCaseBuilder WithGetTemperatures(IEnumerable<Temperature> temperatures)
        {
            AddTemperaturesAsync(_sqliteContext, temperatures).Wait();
            return this;
        }

        internal GetTemperaturesRequestedUseCaseBuilder WithPresenter(out GetTemperaturesRequestedPresenter presenter)
        {
            presenter = _presenter;
            return this;
        }

        private static Task AddTemperaturesAsync(SqlLiteContext sqliteContext,
            IEnumerable<Temperature> temperatures)
        {
            var temperatturesDao = Convert(temperatures);
            sqliteContext
                .Temperatures
                .AddRangeAsync(temperatturesDao);

            return sqliteContext.SaveChangesAsync();
        }

        private static IEnumerable<TemperatureDao> Convert(IEnumerable<Temperature> temperatures)
        {
            foreach (var temp in temperatures)
            {
                yield return new TemperatureDao
                {
                    State = temp.State,
                    Value = temp.Value
                };
            }
        }
    }

    internal sealed class a
    {

    }
}
