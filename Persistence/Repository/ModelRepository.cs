using vega.Data.Repository;
using Vega.Data;
using Vega.Model;

namespace vega.Persistence.Repository
{
    public class ModelRepository : Repository<Modle>, IModelRepository
    {
        public ModelRepository(VegaDbContext context) : base(context)
        {
        }

        public VegaDbContext VegaDbContext
        {
            get { return context as VegaDbContext; }
        }
    }
}