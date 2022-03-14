using Domain.Entity;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public sealed class TemperatureRepository : ITemperatureRepository
    {
        public Task AddTemperatureAsync(Temperature temperature)
        {
            throw new NotImplementedException();
        }

        public Task<List<Temperature>> GetTemperaturesAsync(int pageSize = 15)
        {
            throw new NotImplementedException();
        }
    }
}
