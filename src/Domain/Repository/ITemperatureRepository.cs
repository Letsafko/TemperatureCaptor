namespace Domain.Repository
{
    using Domain.Entity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITemperatureRepository
    {
        Task<List<Temperature>> GetLastTemperaturesAsync(int pageSize);
        Task AddTemperatureAsync(Temperature temperature);
    }
}
