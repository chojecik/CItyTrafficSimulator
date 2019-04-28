using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CItyTrafficSimulator.Classes
{
    public class RouteList
    {
        public List<Route> routes;

        public RouteList()
        {
            routes = new List<Route>();

            routes.Add(new Route() {StartPoint = new Point(50,10), EndPoint = new Point(50, 771), OccupancyRate = 2,  )
        }
    }
}
