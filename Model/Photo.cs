using System.ComponentModel.DataAnnotations;

namespace vega.Model
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public int VehicleId { get; set; }
    }
}