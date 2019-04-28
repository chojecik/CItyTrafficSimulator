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
        private double distance = 1;
        DateTime start = DateTime.UtcNow;
        private Random random = new Random();
        private List<Car> cars = new List<Car>();

        public ExpWithoutAlgWindow(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            Closed += OnWindowClosed;
            PrepareSimulation();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        public void OnWindowClosed(object sender, System.EventArgs e)
        {
            _mainWindow.Show();
        }

        private void PrepareSimulation()
        {
            Colours colours = new Colours();
            RouteList routeList = new RouteList(this);

            for (int i=0; i<30; i++)
            {
                Car newCar = new Car();
                Ellipse ellipse = new Ellipse();

                newCar.RouteOfCar = routeList.routes[random.Next(0, routeList.routes.Count)];
                newCar.PostionX = newCar.RouteOfCar.StartPoint.X;
                newCar.PostionY = newCar.RouteOfCar.StartPoint.Y;
                ellipse.Height = 8;
                ellipse.Width = 8;
                ellipse.Fill = colours.solidColorBrushes[random.Next(0, colours.solidColorBrushes.Count)];
                newCar.Vehicle = ellipse;

                cars.Add(newCar);
                ExpWithoutAlgCanvas.Children.Add(cars[i].Vehicle);
                Canvas.SetTop(newCar.Vehicle, newCar.PostionY);
                Canvas.SetLeft(newCar.Vehicle, newCar.PostionX);
            }
        }

        private void CompositionTarget_Rendering(object sender, System.EventArgs e)
        {
           
            DateTime end = DateTime.UtcNow;

            //i++;
            //if(i<1174)
            //{
            //    ellipse.SetValue(Canvas.LeftProperty, i);
            //    TimeSpan timeDiff = end - start;
            //    StopWatchLabel.Content = Convert.ToDouble(timeDiff.TotalMilliseconds / 1000.0);
            //}
            //else
            //{
            //    ellipse = null;
            //}

            //Car car = MakeNewCar();

            for (int i=0; i<cars.Count; i++)
            {
                switch (cars[i].RouteOfCar.Id)
                {
                    case 0:
                        if (cars[i].PostionY < cars[i].RouteOfCar.EndPoint.Y)
                        {
                            cars[i].Vehicle.SetValue(Canvas.TopProperty, cars[i].PostionY + distance);
                            cars[i].PostionY += distance;
                        }
                        else
                        {
                            
                        }
                        break;
                    case 2:
                        if (cars[i].PostionX < cars[i].RouteOfCar.EndPoint.X)
                        {
                            cars[i].Vehicle.SetValue(Canvas.LeftProperty, cars[i].PostionX + distance);
                            cars[i].PostionX += distance;
                        }
                        else
                        {
                            
                        }
                        break;
                    case 3:
                        if (cars[i].PostionX > cars[i].RouteOfCar.EndPoint.X)
                        {
                            cars[i].Vehicle.SetValue(Canvas.LeftProperty, cars[i].PostionX - distance);
                            cars[i].PostionX -= distance;
                        }
                        else
                        {
                            
                        }
                        break;
                    case 4:
                        if (cars[i].PostionY > cars[i].RouteOfCar.EndPoint.Y)
                        {
                            cars[i].Vehicle.SetValue(Canvas.TopProperty, cars[i].PostionY - distance);
                            cars[i].PostionY -= distance;
                        }
                        else
                        {

                        }
                        break;
                    default:
                        break;
                }
            }
        }



    }
}
