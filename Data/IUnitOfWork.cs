using System;
using System.Threading.Tasks;
using vega.Data.Repository;

namespace vega.Data
{
    public interface IUnitOfWork : IDisposable
    {
         IMakeRepository Makes { get; }
         IModelRepository Models { get; }
         IFeatureRepository Features { get; }
         IVehicleRepository Vehicles { get; }

         Task<int> CompleteAsync();
    }
}