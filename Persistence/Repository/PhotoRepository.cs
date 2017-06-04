using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vega.Data.Repository;
using vega.Model;
using Vega.Data;

namespace vega.Persistence.Repository
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(DbContext context) : base(context)
        {
        }

        public VegaDbContext VegaDbContext
        {
            get { return context as VegaDbContext; }
        }

        public async Task<IEnumerable<Photo>> GetPhotos(int vehicleId)
        {
            return await VegaDbContext.Photos
                .Where(p => p.VehicleId == vehicleId)
                .ToListAsync();
        }
    }
}