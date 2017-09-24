using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSMHI.Model
{
    public class ForeCast
    {
        public string approvedTime { get; set; }
        public string referenceTime { get; set; }
        public Geometry geometry { get; set; }
        public List<TimeSery> timeSeries { get; set; }
    }
}
