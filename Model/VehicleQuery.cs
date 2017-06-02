using vega.Extensions;

namespace vega.Model
{
    public class VehicleQuery : IQueryObject
    {
        public int? MakeId { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
    }
}