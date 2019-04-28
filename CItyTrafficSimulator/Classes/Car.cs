using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CItyTrafficSimulator.Classes
{
    public class Car
    {
        public int Speed { get; set; }
        public int Destination { get; set; }
        public int PostionX { get; set; }
        public int PostionY { get; set; }
        public Ellipse Vehicle { get; set; }
        public Route RouteOfCar { get; set; }

    }
}
