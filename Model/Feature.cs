using System.Collections.Generic;
using vega.Model;

namespace Vega.Model 
{
    public class Feature
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public List<VehicleFeature> VehicleFeatures { get; set; }
    }
}