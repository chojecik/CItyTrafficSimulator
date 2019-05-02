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
        ExpWithoutAlgWindow _expWithoutAlgWindow;
        public List<Rectangle> streets;

        public StreetList(ExpWithoutAlgWindow expWithoutAlgWindow)
        {
            _expWithoutAlgWindow = expWithoutAlgWindow;
            streets = new List<Rectangle>();
            streets.Add(_expWithoutAlgWindow.Pomorska);
            streets.Add(_expWithoutAlgWindow.Piastowska);
            streets.Add(_expWithoutAlgWindow.Kolobrzeska);
            streets.Add(_expWithoutAlgWindow.AlejaZolnierzy1);
            streets.Add(_expWithoutAlgWindow.Grunwaldzka);
            streets.Add(_expWithoutAlgWindow.Opacka);
            streets.Add(_expWithoutAlgWindow.OpataJackaRybinskiego);
            streets.Add(_expWithoutAlgWindow.Derdkowskiego);
            streets.Add(_expWithoutAlgWindow.WitaStwosza1);
            streets.Add(_expWithoutAlgWindow.WitaStwosza2);
            streets.Add(_expWithoutAlgWindow.WitaStwosza3);
            streets.Add(_expWithoutAlgWindow.WitaStwosza4);
            streets.Add(_expWithoutAlgWindow.Bazynskiego);
            streets.Add(_expWithoutAlgWindow.AlejaZolnierzy2);
            streets.Add(_expWithoutAlgWindow.Polanki);

            
        }
    }
}
