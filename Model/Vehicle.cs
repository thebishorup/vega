using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Vega.Model;

namespace vega.Model
{
    public class Vehicle
    {
        public Vehicle()
        {
            Features = new List<VehicleFeature>();
            Photos = new Collection<Photo>();
        }
        public int Id { get; set; }
        public int ModelId { get; set; }
        public bool IsRegistered { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Updatedby { get; set; }
        public DateTime UpdatedDate { get; set; }

        public Modle Model { get; set; }

        public List<VehicleFeature> Features { get; set; }

        public ICollection<Photo> Photos { get; set; }
    }
}