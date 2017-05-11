using System.Threading.Tasks;
using vega.Model;

namespace vega.Data.Repository
{
    public interface IVehicleRepository : IRepository<Vehicle>
    {
         Task<Vehicle> GetVehicleWithFeaturesAsync(int id);
         Task<Vehicle> GetAsync(int id);
    }
}