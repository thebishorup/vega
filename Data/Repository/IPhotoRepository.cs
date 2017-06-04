using System.Collections.Generic;
using System.Threading.Tasks;
using vega.Model;

namespace vega.Data.Repository
{
    public interface IPhotoRepository : IRepository<Photo>
    {
        Task<IEnumerable<Photo>> GetPhotos(int vehicleId);
    }
}