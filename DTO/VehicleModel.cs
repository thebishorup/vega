namespace Vega.DTO
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int VehicleMakeId { get; set; }
        public VehicleMake VehicleMake { get; set; }
    }
}