using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.ViewModel
{
    public class VehicleViewModel
    {        
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        public ContactViewModel Contact { get; set; }
        public ICollection<int> Features { get; set; }

        public VehicleViewModel()
        {
            Features = new Collection<int>();
        }
    }
}