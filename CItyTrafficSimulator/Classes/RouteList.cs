using CItyTrafficSimulator.Windows;
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
        private ExpWithoutAlgWindow _expWithoutAlgWindow;
        private TrafficLightsList trafficLightsList;
        public RouteList(ExpWithoutAlgWindow expWithoutAlgWindow)
        {
            _expWithoutAlgWindow = expWithoutAlgWindow;
            routes = new List<Route>();
            trafficLightsList = new TrafficLightsList(_expWithoutAlgWindow);

            routes.Add(new Route() { Id = 0, StartPoint = new Point(50, 10), EndPoint = new Point(50, 771), OccupancyRate = 2, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[0] } }); //Trasa Pomorska - Opacka
            routes.Add(new Route() { Id = 1, StartPoint = new Point(50, 10), EndPoint = new Point(10, 330), OccupancyRate = 2, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[0] } }); //Pomorska - Grunwaldzka w stronę Sopotu
            routes.Add(new Route() { Id = 2, StartPoint = new Point(10, 370), EndPoint = new Point(1174, 370), OccupancyRate = 2, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[31], trafficLightsList.AllTraficLights[29], trafficLightsList.AllTraficLights[36], trafficLightsList.AllTraficLights[37], trafficLightsList.AllTraficLights[21], trafficLightsList.AllTraficLights[14], trafficLightsList.AllTraficLights[12] } }); //Trasa Grunwaldzka w stronę Gdanska jeden pas
            routes.Add(new Route() { Id = 3, StartPoint = new Point(1174, 330), EndPoint = new Point(10, 330), OccupancyRate = 2, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[7], trafficLightsList.AllTraficLights[5], trafficLightsList.AllTraficLights[38], trafficLightsList.AllTraficLights[3], trafficLightsList.AllTraficLights[1] } }); //Trasa Grunwaldzka w stronę Sopotu
            routes.Add(new Route() { Id = 4, StartPoint = new Point(65, 771), EndPoint = new Point(65, 10), OccupancyRate = 2, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[30] } }); //Trasa Opacka - Pomorska
            routes.Add(new Route() { Id = 5, StartPoint = new Point(50, 10), EndPoint = new Point(177, 771), OccupancyRate = 2, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[0], trafficLightsList.AllTraficLights[29] } }); //Trasa Pomorska - Opata Jacka Rybińskiego
            routes.Add(new Route() { Id = 6, StartPoint = new Point(50, 10), EndPoint = new Point(940, 771), OccupancyRate = 4, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[0], trafficLightsList.AllTraficLights[29], trafficLightsList.AllTraficLights[36], trafficLightsList.AllTraficLights[35], trafficLightsList.AllTraficLights[16], trafficLightsList.AllTraficLights[10] } }); //Trasa Pomorska - Aleja Żołnierzy wyklętych przez Opata Jacka Rybińskiego oraz Polanki
            routes.Add(new Route() { Id = 7, StartPoint = new Point(50, 10), EndPoint = new Point(527, 10), OccupancyRate = 5, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[0], trafficLightsList.AllTraficLights[29], trafficLightsList.AllTraficLights[36], trafficLightsList.AllTraficLights[37], trafficLightsList.AllTraficLights[21] } }); //Trasa Pomorska - Kołobrzeska wyklętych przez Grunwaldzką
            routes.Add(new Route() { Id = 8, StartPoint = new Point(50, 10), EndPoint = new Point(970, 10), OccupancyRate = 5, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[0], trafficLightsList.AllTraficLights[29], trafficLightsList.AllTraficLights[36], trafficLightsList.AllTraficLights[37], trafficLightsList.AllTraficLights[21], trafficLightsList.AllTraficLights[14], trafficLightsList.AllTraficLights[12] } }); //Trasa Pomorska - Aleja Żołnierzy wyklętych w stronę Zaspy przez Grunwaldzką
            routes.Add(new Route() { Id = 9, StartPoint = new Point(50, 10), EndPoint = new Point(1174, 355), OccupancyRate = 7, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[0], trafficLightsList.AllTraficLights[29], trafficLightsList.AllTraficLights[36], trafficLightsList.AllTraficLights[37], trafficLightsList.AllTraficLights[21], trafficLightsList.AllTraficLights[14], trafficLightsList.AllTraficLights[12] } }); //Trasa Pomorska - Grunwaldzka w stronę Gdańska
            routes.Add(new Route() { Id = 10, StartPoint = new Point(50, 10), EndPoint = new Point(970, 771), OccupancyRate = 6, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[0], trafficLightsList.AllTraficLights[29], trafficLightsList.AllTraficLights[36], trafficLightsList.AllTraficLights[37], trafficLightsList.AllTraficLights[21], trafficLightsList.AllTraficLights[14], trafficLightsList.AllTraficLights[12], trafficLightsList.AllTraficLights[11] } }); //Trasa Pomorska - Aleja Żołnierzy wyklętych w stronę Niedźwiednika przez Grunwaldzką
            //routes.Add(new Route() { Id = 11, StartPoint = new Point(10, 385), EndPoint = new Point(1174, 385), OccupancyRate = 2, TrafficLightsOnRoute = new List<TrafficLights>() { trafficLightsList.AllTraficLights[31], trafficLightsList.AllTraficLights[29], trafficLightsList.AllTraficLights[36], trafficLightsList.AllTraficLights[37], trafficLightsList.AllTraficLights[21], trafficLightsList.AllTraficLights[14], trafficLightsList.AllTraficLights[12] } }); //Trasa Grunwaldzka w stronę Gdanska drugi pas







        }
    }
}
