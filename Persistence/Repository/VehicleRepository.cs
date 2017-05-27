using System;
using System.Collections.Generic;
using System.Linq;
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

        async Task<Vehicle> IVehicleRepository.GetVehicleAsync(int id)
        {
            return await VegaDbContext.Vehicles
            .Include(f => f.Features)
                .ThenInclude(vf => vf.Feature)
            .Include(m => m.Model)
                .ThenInclude(m => m.Make)
            .SingleOrDefaultAsync(v => v.Id == id);
        }

        async Task<IEnumerable<Vehicle>> IVehicleRepository.GetVehiclesAsync(Filter filter)
        {

            var query = VegaDbContext.Vehicles
            .Include(f => f.Features)
                .ThenInclude(vf => vf.Feature)
            .Include(m => m.Model)
                .ThenInclude(m => m.Make)
            .AsQueryable();

            if(filter.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == filter.MakeId.Value);       

            return await query.ToListAsync();     
        }
    }
}