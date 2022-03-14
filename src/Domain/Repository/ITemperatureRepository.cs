namespace Domain.Repository
{
    using Domain.Entity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITemperatureRepository
    {
        Task<List<Temperature>> GetTemperaturesAsync(int pageSize = 15);
        Task AddTemperatureAsync(Temperature temperature);
    }
}
