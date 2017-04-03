using System.Collections.Generic;

namespace Vega.DTO
{
    public class VehicleMake
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<VehicleModel> VehicleModels { get; set; }
    }
}