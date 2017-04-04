using System.Collections.Generic;

namespace Vega.Model
{
    public class Make
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Modle> Models { get; set; }
    }
}