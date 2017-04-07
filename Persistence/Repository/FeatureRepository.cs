using vega.Data.Repository;
using Vega.Data;
using Vega.Model;

namespace vega.Persistence.Repository
{
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        public FeatureRepository(VegaDbContext context) : base(context)
        {
        }

        public VegaDbContext VegaDbContext
        {
            get { return context as VegaDbContext; }
        }
    }
}