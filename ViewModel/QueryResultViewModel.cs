using System.Collections.Generic;

namespace vega.ViewModel
{
    public class QueryResultViewModel<T>
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}