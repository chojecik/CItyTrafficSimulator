using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CItyTrafficSimulator.Classes
{
    public class Route
    {
        public int Id { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public int OccupancyRate { get; set; }      //im wyższy współczynnik tym bardziej uczęszczana trasa
        public List<TrafficLights> TrafficLightsOnRoute { get; set; }
    }
}
