using System;
using System.Collections.Generic;
using vega.Model;
using Vega.ViewModel;

namespace vega.ViewModel
{
    public class VehicleViewModel
    {
        public VehicleViewModel()
        {
            Features = new List<KeyValuePairViewModel>();
        }
        public int Id { get; set; }
        public bool IsRegistered { get; set; }
        public ContactViewModel Contact { get; set; }
        public DateTime UpdatedDate { get; set; }
        public KeyValuePairViewModel Model { get; set; }
        public KeyValuePairViewModel Make { get; set; }
        public List<KeyValuePairViewModel> Features { get; set; }
    }
}