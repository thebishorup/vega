using vega.Data.Repository;
using Vega.Data;
using Vega.Model;

namespace vega.Persistence.Repository
{
    public class MakeRepository : Repository<Make>, IMakeRepository
    {
        public MakeRepository(VegaDbContext context) : base(context)
        {
        }

        public VegaDbContext VegaDbContext
        {
            get { return context as VegaDbContext; }
        }
    }
}