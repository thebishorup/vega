using System.Collections.Generic;

namespace Vega.ViewModel 
{
    public class MakeViewModel : KeyValuePairViewModel
    {
        public MakeViewModel()
        {
            Models = new List<KeyValuePairViewModel>();
        }
        public List<KeyValuePairViewModel> Models { get; set; }
    }
}