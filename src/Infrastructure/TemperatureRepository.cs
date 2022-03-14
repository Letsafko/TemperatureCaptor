using Domain.Entity;
using Domain.Repository;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public sealed class TemperatureRepository : ITemperatureRepository
    {
        private readonly SqlLiteContext _context;
        public TemperatureRepository(SqlLiteContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddTemperatureAsync(Temperature temperature)
        {
            var tempDao = new TemperatureDao { State = temperature.State, Value = temperature.Value };
            await _context.Temperatures.AddAsync(tempDao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Temperature>> GetLastTemperaturesAsync(int pageSize)
        {
            return _context
                .Temperatures
                .OrderByDescending(x => x.Id)
                .Take(pageSize)
                .Select(ConvertFrom)
                .ToList();
        }

        private static Temperature ConvertFrom(TemperatureDao temperature)
        {
            return new Temperature(temperature.Value, temperature.State);
        }
    }
}
