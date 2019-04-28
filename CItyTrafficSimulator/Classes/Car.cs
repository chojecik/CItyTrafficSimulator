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
        private int speed { get; set; }
        private int destination { get; set; }
        private int postionX { get; set; }
        private int postionY { get; set; }
        private Ellipse vehicle { get; set; }
    }
}
