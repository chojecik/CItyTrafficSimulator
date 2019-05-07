using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CItyTrafficSimulator.Classes
{
    public class TrafficLights
    {
        public bool IsRedLight { get; set; }
        public bool? IsYellowLight { get; set; }
        public bool IsGreenLight { get; set; }
        public int TimeOfRedLight { get; set; }
        public int TimeOfYellowLight { get; set; }
        public int TimeOfGreenLight { get; set; }
        public Ellipse RedLight { get; set; }
        public Ellipse YellowLight { get; set; }
        public Ellipse GreenLight { get; set; }
    }
}
