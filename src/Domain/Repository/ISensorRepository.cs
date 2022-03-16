namespace Domain.Repository
{
    using Domain.Entity;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISensorRepository
    {
        Task<List<Sensor>> GetLastMeasuresAsync(int pageSize);
        Task AddNewSensorAsync(Sensor sensor);
    }
}
