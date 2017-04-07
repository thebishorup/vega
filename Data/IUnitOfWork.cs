using System;
using vega.Data.Repository;

namespace vega.Data
{
    public interface IUnitOfWork : IDisposable
    {
         IMakeRepository Makes { get; }
         IModelRepository Models { get; }
         IFeatureRepository Features { get; }

         int Complete();
    }
}