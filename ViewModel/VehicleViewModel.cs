using System.Collections.Generic;

namespace vega.ViewModel
{
    public class VehicleViewModel
    {        
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        public ContactViewModel Contact { get; set; }
        public List<int> Features { get; set; }
    }
}