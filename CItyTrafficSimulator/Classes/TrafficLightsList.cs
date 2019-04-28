using CItyTrafficSimulator.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CItyTrafficSimulator.Classes
{
    public class TrafficLightsList
    {
        public List<TrafficLights> AllTraficLights;
        private ExpWithoutAlgWindow _expWithoutAlgWindow;

        public TrafficLightsList(ExpWithoutAlgWindow expWithoutAlgWindow)
        {
            _expWithoutAlgWindow = expWithoutAlgWindow;
            AllTraficLights = new List<TrafficLights>();

            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green, RedLight = _expWithoutAlgWindow.Red, YellowLight = _expWithoutAlgWindow.Yellow, TimeOfGreenLight = 30, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Pomorskiej z Grunwaldzka
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green1, RedLight = _expWithoutAlgWindow.Red1, YellowLight = _expWithoutAlgWindow.Yellow1, TimeOfGreenLight = 60, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Grunwaldzkiej z Pomorska w stronę Sopotu
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green2, RedLight = _expWithoutAlgWindow.Red2, YellowLight = _expWithoutAlgWindow.Yellow2, TimeOfGreenLight = 30, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Piastowskiej z Grunwaldzka
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green3, RedLight = _expWithoutAlgWindow.Red3, YellowLight = _expWithoutAlgWindow.Yellow3, TimeOfGreenLight = 60, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Grunwaldzkiej z Piastowską w stronę Sopotu
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green4, RedLight = _expWithoutAlgWindow.Red4, YellowLight = _expWithoutAlgWindow.Yellow4, TimeOfGreenLight = 45, TimeOfRedLight = 45, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Kołobrzeskiej z Grunwaldzką
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green5, RedLight = _expWithoutAlgWindow.Red5, YellowLight = _expWithoutAlgWindow.Yellow5, TimeOfGreenLight = 45, TimeOfRedLight = 45, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Grunwaldzkiej z Kołobrzeską w stronę Sopotu
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green6, RedLight = _expWithoutAlgWindow.Red6, YellowLight = _expWithoutAlgWindow.Yellow6, TimeOfGreenLight = 60, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Aleji Żołnierzy Wyklętych z Grunwaldzką w stronę Niedźwiednika
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green7, RedLight = _expWithoutAlgWindow.Red7, YellowLight = _expWithoutAlgWindow.Yellow7, TimeOfGreenLight = 60, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Grunwaldzkiej z Aleją Żołnierzy Wyklętych w stronę Sopotu
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green8, RedLight = _expWithoutAlgWindow.Red8, YellowLight = _expWithoutAlgWindow.Yellow8, TimeOfGreenLight = 60, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Aleji Żołnierzy Wyklętych z Grunwaldzką w stronę Zaspy
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green9, RedLight = _expWithoutAlgWindow.Red9, YellowLight = _expWithoutAlgWindow.Yellow9, TimeOfGreenLight = 60, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Aleji Żołnierzy Wyklętych z Polanki w stronę Zaspy
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green10, RedLight = _expWithoutAlgWindow.Red10, YellowLight = _expWithoutAlgWindow.Yellow10, TimeOfGreenLight = 30, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Polanki z Aleją Żołnierzy Wyklętych
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green11, RedLight = _expWithoutAlgWindow.Red11, YellowLight = _expWithoutAlgWindow.Yellow11, TimeOfGreenLight = 60, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Aleji Żołnierzy Wyklętych z Polanki w stronę Niedźwiednika
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green12, RedLight = _expWithoutAlgWindow.Red12, YellowLight = _expWithoutAlgWindow.Yellow12, TimeOfGreenLight = 60, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Grunwaldzkiej z Aleją Żołnierzy Wyklętych w stronę Gdańska
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green13, RedLight = _expWithoutAlgWindow.Red13, YellowLight = _expWithoutAlgWindow.Yellow13, TimeOfGreenLight = 30, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Wita Stwosza z Grunwaldzką
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green14, RedLight = _expWithoutAlgWindow.Red14, YellowLight = _expWithoutAlgWindow.Yellow14, TimeOfGreenLight = 60, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Grunwaldzkiej z Wita Stwosza
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green15, RedLight = _expWithoutAlgWindow.Red15, YellowLight = _expWithoutAlgWindow.Yellow15, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Polanki z Bażyńskiego w stronę Sopotu
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green16, RedLight = _expWithoutAlgWindow.Red16, YellowLight = _expWithoutAlgWindow.Yellow16, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Polanki z Bażyńskiego w stronę Gdańska
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green17, RedLight = _expWithoutAlgWindow.Red17, YellowLight = _expWithoutAlgWindow.Yellow17, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Bażyńskiego z Polanki
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green18, RedLight = _expWithoutAlgWindow.Red18, YellowLight = _expWithoutAlgWindow.Yellow18, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Wita Stwosza z Bażyńskiego w stronę Gdańska
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green19, RedLight = _expWithoutAlgWindow.Red19, YellowLight = _expWithoutAlgWindow.Yellow19, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Wita Stwosza z Bażyńskiego w stronę Sopotu
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green20, RedLight = _expWithoutAlgWindow.Red20, YellowLight = _expWithoutAlgWindow.Yellow20, TimeOfGreenLight = 30, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Bażyńskiego z Grunwaldzką
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green21, RedLight = _expWithoutAlgWindow.Red21, YellowLight = _expWithoutAlgWindow.Yellow21, TimeOfGreenLight = 60, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Grunwaldzkiej z Bażyńskiego
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green22, RedLight = _expWithoutAlgWindow.Red22, YellowLight = _expWithoutAlgWindow.Yellow22, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Bażyńskiego z Wita Stwosza w stronę Niedźwiednika
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green23, RedLight = _expWithoutAlgWindow.Red23, YellowLight = _expWithoutAlgWindow.Yellow23, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Wita Stwosza z Derdowskiego w Stronę Sopotu
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green24, RedLight = _expWithoutAlgWindow.Red24, YellowLight = _expWithoutAlgWindow.Yellow24, TimeOfGreenLight = 30, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Derdowskiego z Grunwaldzką
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green25, RedLight = _expWithoutAlgWindow.Red25, YellowLight = _expWithoutAlgWindow.Yellow25, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Wita Stwosza z Derdowskiego w stronę Gdańska
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green26, RedLight = _expWithoutAlgWindow.Red26, YellowLight = _expWithoutAlgWindow.Yellow26, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Polanki z Opata Jacka Rybińskiego
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green27, RedLight = _expWithoutAlgWindow.Red27, YellowLight = _expWithoutAlgWindow.Yellow27, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Opata Jacka Rybinskiego z Polanki
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green28, RedLight = _expWithoutAlgWindow.Red28, YellowLight = _expWithoutAlgWindow.Yellow28, TimeOfGreenLight = 30, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Opata Jacka Rybinskiego z Grunwaldzką
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green29, RedLight = _expWithoutAlgWindow.Red29, YellowLight = _expWithoutAlgWindow.Yellow29, TimeOfGreenLight = 60, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Grunwaldzkiej z Piastowską w stronę Gdańska
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green30, RedLight = _expWithoutAlgWindow.Red30, YellowLight = _expWithoutAlgWindow.Yellow30, TimeOfGreenLight = 30, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Opackiej z Grunwaldzką
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green31, RedLight = _expWithoutAlgWindow.Red31, YellowLight = _expWithoutAlgWindow.Yellow31, TimeOfGreenLight = 30, TimeOfRedLight = 60, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Grunwaldzkiej z Opacką
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green32, RedLight = _expWithoutAlgWindow.Red32, YellowLight = _expWithoutAlgWindow.Yellow32, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Bażyńskiego z Wita Stwosza w stronę Zaspy
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green33, RedLight = _expWithoutAlgWindow.Red33, YellowLight = _expWithoutAlgWindow.Yellow33, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Derdowskiego z Wita Stwosza w stronę Zaspy
            AllTraficLights.Add(new TrafficLights() { GreenLight = _expWithoutAlgWindow.Green34, RedLight = _expWithoutAlgWindow.Red34, YellowLight = _expWithoutAlgWindow.Yellow34, TimeOfGreenLight = 30, TimeOfRedLight = 30, TimeOfYellowLight = 2 }); //światła na skrzyżowaniu Derdowskiego z Wita Stwosza w stronę Niedźwiednika





































        }
    }
}
