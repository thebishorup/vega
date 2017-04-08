using System.Collections;
using System.Collections.Generic;
using Vega.Model;

namespace vega.Data.Repository
{
    public interface IMakeRepository : IRepository<Make>
    {
        IEnumerable<Make> GetAllMakesWithModels();
    }
}