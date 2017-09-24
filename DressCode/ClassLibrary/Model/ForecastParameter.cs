using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSMHI.Model
{
    public class Parameter
    {
        public string name { get; set; }
        public string levelType { get; set; }
        public int level { get; set; }
        public List<double> values { get; set; }
    }
}
