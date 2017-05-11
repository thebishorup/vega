using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Data.Repository;
using vega.Model;
using Vega.Data;

namespace vega.Persistence.Repository
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DbContext context) : base(context)
        {
        }

        public VegaDbContext VegaDbContext
        {
            get { return context as VegaDbContext; }
        }

        async Task<Vehicle> IVehicleRepository.GetAsync(int id)
        {
            return await VegaDbContext.Vehicles.FindAsync(id);
        }

        async Task<Vehicle> IVehicleRepository.GetVehicleWithFeaturesAsync(int id)
        {
            return await VegaDbContext.Vehicles.Include(f => f.Features).SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}