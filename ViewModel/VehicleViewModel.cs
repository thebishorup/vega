using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace vega.ViewModel
{
    public class VehicleViewModel
    {
        [Required]
        public int Make { get; set; }
        
        public int Model { get; set; }
        public bool IsRegistered { get; set; }
        public List<int> Features { get; set; }
        
        [Required]
        public string ContactName { get; set; }
        
        [Required]
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
    }
}