using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CItyTrafficSimulator.Classes
{
    public class Colours
    {
        public List<SolidColorBrush> solidColorBrushes;

        public Colours()
        {
            solidColorBrushes = new List<SolidColorBrush>();
            solidColorBrushes.Add(new SolidColorBrush() { Color = Color.FromRgb(0, 0, 0) });    //black
            solidColorBrushes.Add(new SolidColorBrush() { Color = Color.FromRgb(0, 204, 0) });    //green
            solidColorBrushes.Add(new SolidColorBrush() { Color = Color.FromRgb(0, 0, 255) });    //blue
            solidColorBrushes.Add(new SolidColorBrush() { Color = Color.FromRgb(255, 0, 0) });    //red
            solidColorBrushes.Add(new SolidColorBrush() { Color = Color.FromRgb(255, 255, 0) });    //yellow
            solidColorBrushes.Add(new SolidColorBrush() { Color = Color.FromRgb(255, 0, 102) });    //pink
            solidColorBrushes.Add(new SolidColorBrush() { Color = Color.FromRgb(102, 51, 0) });    //brown
            solidColorBrushes.Add(new SolidColorBrush() { Color = Color.FromRgb(153, 153, 102) });    //grey
            //solidColorBrushes.Add(new SolidColorBrush() { Color = Color.FromRgb(255, 255, 255) });    //white


        }
    }
}
