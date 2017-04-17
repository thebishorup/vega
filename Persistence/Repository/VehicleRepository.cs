using Microsoft.EntityFrameworkCore;
using vega.Data.Repository;
using vega.Model;

namespace vega.Persistence.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DbContext context) : base(context)
        {
        }
    }
}