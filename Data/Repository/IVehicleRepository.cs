using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Model;

namespace vega.Data.Repository
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
         Task<Vehicle> GetVehicleAsync(int id);
         Task<Vehicle> GetAsync(int id);
         Task<IEnumerable<Vehicle>> GetVehiclesAsync(Filter filter);
    }
}