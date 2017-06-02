using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Data.Repository;
using vega.Extensions;
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

        async Task<QueryResult<Vehicle>> IVehicleRepository.GetVehiclesAsync(VehicleQuery queryObject)
        {
            var result = new QueryResult<Vehicle>();
            var query = VegaDbContext.Vehicles
            .Include(f => f.Features)
                .ThenInclude(vf => vf.Feature)
            .Include(m => m.Model)
                .ThenInclude(m => m.Make)
            .AsQueryable();

            if(queryObject.MakeId.HasValue)
                query = query.Where(v => v.Model.MakeId == queryObject.MakeId.Value);     

            //TODO: Implement sortigLogic here
            var columnMap = new Dictionary<string, Expression<Func<Vehicle, object>>>()
            {
                ["make"] = v => v.Model.Make.Name,
                ["model"] = v => v.Model.Name,
                ["contactName"] = v => v.ContactName
            };

            query = query.ApplyOrdering(queryObject, columnMap);

            //Count the total resultset
            result.TotalItems = await query.CountAsync();

            //Implement pagination
            query = query.ApplyPaging(queryObject);

            result.Items = await query.ToListAsync();    

            return result; 
        }
    }
}