using Domain.Entity;
using Domain.Repository;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public sealed class SensorRepository : ISensorRepository
    {
        private readonly SqliteContext _context;
        public SensorRepository(SqliteContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddNewSensorAsync(Sensor temperature)
        {
            var sensorDao = new SensorDao { State = temperature.State, Temperature = temperature.Temperature };
            await _context.Sensors.AddAsync(sensorDao);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Sensor>> GetLastMeasuresAsync(int pageSize)
        {
            return _context
                .Sensors
                .OrderByDescending(x => x.Id)
                .Take(pageSize)
                .Select(ConvertFrom)
                .ToList();
        }

        private static Sensor ConvertFrom(SensorDao temperature)
        {
            return new Sensor(temperature.Temperature, temperature.State);
        }
    }
}
