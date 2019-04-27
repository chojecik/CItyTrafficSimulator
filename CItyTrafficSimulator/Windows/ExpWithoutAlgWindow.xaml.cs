using CItyTrafficSimulator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CItyTrafficSimulator.Windows
{
    /// <summary>
    /// Interaction logic for ExpWithoutAlgWindow.xaml
    /// </summary>
    public partial class ExpWithoutAlgWindow : Window
    {
        private MainWindow _mainWindow;
        private Ellipse ellipse = new Ellipse();
        private double i=20;
        DateTime start = DateTime.UtcNow;

        public ExpWithoutAlgWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            Closed += OnWindowClosed;
            PrepareInterface();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        public void OnWindowClosed(object sender, System.EventArgs e)
        {
            _mainWindow.Show();
        }
        private void PrepareInterface()
        {
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromRgb(0, 0, 153);
            ellipse.Height = 5;
            ellipse.Width = 5;
            ellipse.Fill = mySolidColorBrush;
            ExpWithoutAlgCanvas.Children.Add(ellipse);
            Canvas.SetTop(ellipse, 380);
            Canvas.SetLeft(ellipse, 20);
        }

        private void CompositionTarget_Rendering(object sender, System.EventArgs e)
        {
            DateTime end = DateTime.UtcNow;
           
            i++;
            if(i<1174)
            {
                ellipse.SetValue(Canvas.LeftProperty, i);
                TimeSpan timeDiff = end - start;
                StopWatchLabel.Content = Convert.ToDouble(timeDiff.TotalMilliseconds / 1000.0);
            }
            else
            {
                ellipse = null;
            }
        }



    }
}
