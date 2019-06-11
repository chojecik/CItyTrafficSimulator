using CItyTrafficSimulator.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CItyTrafficSimulator.Classes
{
    public class StreetList
    {
        private readonly ExperimentWindow _experimentWindow;
        public List<Rectangle> streets;
        public List<int> carsOnTheStreet;

        public StreetList(ExperimentWindow experimentWindow)
        {
            _experimentWindow = experimentWindow;
            streets = new List<Rectangle>();
            streets.Add(_experimentWindow.Pomorska);
            streets.Add(_experimentWindow.Piastowska);
            streets.Add(_experimentWindow.Kolobrzeska);
            streets.Add(_experimentWindow.AlejaZolnierzy1);
            streets.Add(_experimentWindow.Grunwaldzka);
            streets.Add(_experimentWindow.Opacka);
            streets.Add(_experimentWindow.OpataJackaRybinskiego);
            streets.Add(_experimentWindow.Derdkowskiego);
            streets.Add(_experimentWindow.WitaStwosza1);
            streets.Add(_experimentWindow.WitaStwosza2);
            streets.Add(_experimentWindow.WitaStwosza3);
            streets.Add(_experimentWindow.WitaStwosza4);
            streets.Add(_experimentWindow.Bazynskiego);
            streets.Add(_experimentWindow.AlejaZolnierzy2);
            streets.Add(_experimentWindow.Polanki);

            carsOnTheStreet = new List<int>();
            carsOnTheStreet.Add(0); //odcinek Grunwaldzkiej przed pomorska w strone Gdańska
            carsOnTheStreet.Add(0); //odcinek Grunwaldzkiej pomiedzy pomorską i rybinskiego w stronę gdańska
            carsOnTheStreet.Add(0); //odcinek Grunwaldzkiej pomiedzy rybinskiego i bazynskiego w stronę gdańska
            carsOnTheStreet.Add(0); //odcinek Grunwaldzkiej pomiedzy bazynskiego i zolnierzy w stronę gdańska
            carsOnTheStreet.Add(0); //odcinek Grunwaldzkiej przed zolnierzy w stronę sopotu
            carsOnTheStreet.Add(0); //odcinek Grunwaldzkiej pomiedzy zolnierzy i kolobrzeska w stronę sopotu
            carsOnTheStreet.Add(0); //odcinek Grunwaldzkiej pomiedzy kolobrzeska i pomorska w stronę sopotu
            carsOnTheStreet.Add(0); //ilosc samochodow na pomorskiej 
            carsOnTheStreet.Add(0); //ilosc samochodow na opackiej 
            carsOnTheStreet.Add(0); //ilosc samochodow na kolobrzeskiej 
            carsOnTheStreet.Add(0); //ilosc samochodow na zolnierzy wykletych w dol 
            carsOnTheStreet.Add(0); //ilosc samochodow na zolnierzy wykletych w gore 


        }
    }
}
