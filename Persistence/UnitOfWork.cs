using System;
using vega.Data;
using vega.Data.Repository;
using vega.Persistence.Repository;
using Vega.Data;

namespace vega.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaDbContext context;
        public UnitOfWork(VegaDbContext context)
        {
            this.context = context;
            Makes = new MakeRepository(this.context);
            Models = new ModelRepository(this.context);
            Features = new FeatureRepository(this.context);
        }
        public IMakeRepository Makes { get; private set; }

        public IModelRepository Models { get; private set; }

        public IFeatureRepository Features { get; private set; }        

        int IUnitOfWork.Complete()
        {
            return this.context.SaveChanges();
        }

        void IDisposable.Dispose()
        {
            this.context.Dispose();
        }

    }
}