using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadJSONFromFile.Models
{
    public class MarkCalculation
    {
        public double Min { get; set; }
        public double Max { get; set; }
        public double Avg { get; set; }
    }

      
    
    public class Section
    {
        public double Math1 { get; set; }
        public double His { get; set; }
        public double Geo { get; set; }
        public double Eng { get; set; }
    }

}
