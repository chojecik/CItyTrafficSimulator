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
        private readonly double distance = 0.4;    //prędkość poruszania się elips
        private DateTime startTimer = DateTime.UtcNow;
        private DateTime start = DateTime.UtcNow;
        private Random random = new Random();
        private List<Car> cars = new List<Car>();
        private int counter = 0;
        private readonly Colours colours;
        private RouteList routeList;
        private DateTime stopTimer;
        private StreetList streetList;
        private TrafficLightsList trafficLights;
        private bool isStart = false;
        private int carIdSetter = 0;

        public ExpWithoutAlgWindow(MainWindow mainWindow)
        {
            colours = new Colours();
            InitializeComponent();
            _mainWindow = mainWindow;
            Closed += OnWindowClosed;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        public void OnWindowClosed(object sender, System.EventArgs e)
        {
            _mainWindow.Show();
        }

        private void SetInitialTrafficLights()  //tutaj oczywiscie nie moze tak byc, poki co tylko dla testow
        {
            trafficLights.AllTraficLights[31].IsGreenLight = true;
            trafficLights.AllTraficLights[31].IsRedLight = false;
            trafficLights.AllTraficLights[29].IsGreenLight = true;
            trafficLights.AllTraficLights[29].IsRedLight = false;
            trafficLights.AllTraficLights[36].IsGreenLight = true;
            trafficLights.AllTraficLights[36].IsRedLight = false;
            trafficLights.AllTraficLights[37].IsGreenLight = true;
            trafficLights.AllTraficLights[37].IsRedLight = false;
            trafficLights.AllTraficLights[21].IsGreenLight = true;
            trafficLights.AllTraficLights[21].IsRedLight = false;
            trafficLights.AllTraficLights[14].IsGreenLight = true;
            trafficLights.AllTraficLights[14].IsRedLight = false;
            trafficLights.AllTraficLights[12].IsGreenLight = true;
            trafficLights.AllTraficLights[12].IsRedLight = false;
            trafficLights.AllTraficLights[1].IsGreenLight = true;
            trafficLights.AllTraficLights[1].IsRedLight = false;
            trafficLights.AllTraficLights[3].IsGreenLight = true;
            trafficLights.AllTraficLights[3].IsRedLight = false;
            trafficLights.AllTraficLights[5].IsGreenLight = true;
            trafficLights.AllTraficLights[5].IsRedLight = false;
            trafficLights.AllTraficLights[7].IsGreenLight = true;
            trafficLights.AllTraficLights[7].IsRedLight = false;
            trafficLights.AllTraficLights[38].IsGreenLight = true;
            trafficLights.AllTraficLights[38].IsRedLight = false;
            trafficLights.AllTraficLights[0].IsGreenLight = false;
            trafficLights.AllTraficLights[0].IsRedLight = true;
            trafficLights.AllTraficLights[30].IsGreenLight = false;
            trafficLights.AllTraficLights[30].IsRedLight = true;
            ColorAllTrafficLights();

        }

        private void ColorAllTrafficLights()
        {
            //ellipse = this.Green;
            trafficLights.AllTraficLights.ForEach(tl =>
            {
                if (tl.IsGreenLight == true)
                {
                    tl.GreenLight.Fill = colours.solidColorBrushes[1];
                    tl.RedLight.Fill = colours.solidColorBrushes[8];
                    tl.YellowLight.Fill = colours.solidColorBrushes[8];
                }
                else if (tl.IsRedLight == true)
                {
                    tl.GreenLight.Fill = colours.solidColorBrushes[8];
                    tl.RedLight.Fill = colours.solidColorBrushes[3];
                    tl.YellowLight.Fill = colours.solidColorBrushes[8];
                }
            });
        }

        private void CompositionTarget_Rendering(object sender, System.EventArgs e)
        {
            if (!isStart)
            {
                routeList = new RouteList(this);
                trafficLights = new TrafficLightsList(this);
                streetList = new StreetList(this);
                SetInitialTrafficLights();                
            }
            else
            {
                ControlTrafficLights();
            }
            if (counter == 30 || !isStart)  //dodajemy nowy samochod kiedy mamy pewnosc, ze nie nalozy sie on na juz istniejaca elipse
            {
                isStart = true;
                Car newCar = new Car();
                Ellipse ellipse = new Ellipse();

                newCar.RouteOfCar = routeList.routes[random.Next(0, routeList.routes.Count)];
                newCar.PostionX = newCar.RouteOfCar.StartPoint.X;
                newCar.PostionY = newCar.RouteOfCar.StartPoint.Y;
                ellipse.Height = 8;
                ellipse.Width = 8;
                ellipse.Fill = colours.solidColorBrushes[random.Next(0, colours.solidColorBrushes.Count)];
                newCar.Vehicle = ellipse;
                newCar.Id = carIdSetter++;
                newCar.CurrentStreet = FindCurrentStreet(newCar);
                cars.Add(newCar);
                ExpWithoutAlgCanvas.Children.Add(newCar.Vehicle);
                Canvas.SetTop(newCar.Vehicle, newCar.PostionY);
                Canvas.SetLeft(newCar.Vehicle, newCar.PostionX);
                counter = 0;
            }
            else
            {
                counter++;
            }
            //testowe
            DateTime end = DateTime.UtcNow;
            TimeSpan timeDiff = end - start;
            StopWatchLabel.Content = Convert.ToDouble(timeDiff.TotalMilliseconds / 1000.0);

            cars.ForEach(car =>
            {
                switch (car.RouteOfCar.Id)
                {
                    case 0:
                        if ((car.PostionY < 320 )  || (car.PostionY > 320  && car.PostionY < 326 && trafficLights.AllTraficLights[0].IsGreenLight.Value) || (car.PostionY > 326 && car.PostionY < 771))
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(routeList.routes[0], car.CurrentStreet);
                            if(!CheckIfThereIsACarNearby(car))
                            {
                                car.PostionY += distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                car.CurrentStreet = FindCurrentStreet(car);
                                //routeList.routes[0].NumberOfCars++;
                            }
                            else if(car.Equals(orderOfCarsOnTheRoute[0]))
                            {
                                car.PostionY += distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                orderOfCarsOnTheRoute.RemoveAt(0);
                            }
                        }
                        else
                        {
                            //routeList.routes[0].NumberOfCars--;
                        }
                        break;
                    //case 2:
                    //    if (car.PostionX < car.RouteOfCar.EndPoint.X)
                    //    {
                    //        car.PostionX += distance;
                    //        car.Vehicle.SetValue(Canvas.LeftProperty, car.PostionX);
                    //    }
                    //    break;
                    //case 3:
                    //    if (car.PostionX > car.RouteOfCar.EndPoint.X)
                    //    {
                    //        car.PostionX -= distance;
                    //        car.Vehicle.SetValue(Canvas.LeftProperty, car.PostionX);
                    //    }
                    //    break;
                    case 4:
                        if (car.PostionY > 405 || (car.PostionY < 405 && car.PostionY > 400 && trafficLights.AllTraficLights[30].IsGreenLight.Value) || (car.PostionY < 400 && car.PostionY > 10))
                        {
                            if (!CheckIfThereIsACarNearby(car))
                            {
                                car.PostionY -= distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                //routeList.routes[4].NumberOfCars++;
                            }
                        }
                        else
                        {
                            //routeList.routes[4].NumberOfCars--;
                        }
                        break;
                    default:
                        break;
                }
            });
        }

        private Rectangle FindCurrentStreet(Car car)
        {
            Rectangle street = new Rectangle();
            streetList.streets.ForEach(st =>
            {
                
                if(car.PostionX >= Canvas.GetLeft(st) && (car.PostionX <= Canvas.GetLeft(st) + st.Width) && car.PostionY >= Canvas.GetTop(st) && (car.PostionY <= Canvas.GetTop(st) + st.Height))
                {
                    street = st;
                }
            });
            return street;
        }
        private bool CheckIfThereIsACarNearby(Car car)
        {
            var carsOnTheSameRoute = cars.Where(c => c.RouteOfCar == car.RouteOfCar && c.Id != car.Id);

            return carsOnTheSameRoute.Any(c => Math.Sqrt(Math.Pow(c.PostionX - car.PostionX, 2) + Math.Pow(c.PostionY - car.PostionY, 2)) < 10);    //wyliczanie odleglosci pomiedzy dwoma autami
        }

        private List<Car> CalculateOrderOnRoute(Route route, Rectangle street)
        {
            return cars.Where(c => c.RouteOfCar == route && c.CurrentStreet == street).OrderByDescending(pos => pos.PostionY).ToList();
            //tutaj order bedzie rozny w zaleznosci od trasy
        }
        public void ControlTrafficLights()
        {
            stopTimer = DateTime.UtcNow;
            TimeSpan timeDiff = stopTimer - startTimer;

            if(timeDiff.TotalSeconds > 20)
            {
                //tutaj moze wstawic metode wykonywana dla wszystkich swiatel z listy i ustawiac je na przeciwna wartosc
                trafficLights.AllTraficLights[31].IsGreenLight = !trafficLights.AllTraficLights[31].IsGreenLight;
                trafficLights.AllTraficLights[31].IsRedLight = !trafficLights.AllTraficLights[31].IsRedLight;
                trafficLights.AllTraficLights[29].IsGreenLight = !trafficLights.AllTraficLights[29].IsGreenLight;
                trafficLights.AllTraficLights[29].IsRedLight = !trafficLights.AllTraficLights[29].IsRedLight;
                trafficLights.AllTraficLights[36].IsGreenLight = !trafficLights.AllTraficLights[36].IsGreenLight;
                trafficLights.AllTraficLights[36].IsRedLight = !trafficLights.AllTraficLights[36].IsRedLight;
                trafficLights.AllTraficLights[37].IsGreenLight = !trafficLights.AllTraficLights[37].IsGreenLight;
                trafficLights.AllTraficLights[37].IsRedLight = !trafficLights.AllTraficLights[37].IsRedLight;
                trafficLights.AllTraficLights[21].IsGreenLight = !trafficLights.AllTraficLights[21].IsGreenLight;
                trafficLights.AllTraficLights[21].IsRedLight = !trafficLights.AllTraficLights[21].IsRedLight;
                trafficLights.AllTraficLights[14].IsGreenLight = !trafficLights.AllTraficLights[14].IsGreenLight;
                trafficLights.AllTraficLights[14].IsRedLight = !trafficLights.AllTraficLights[14].IsRedLight;
                trafficLights.AllTraficLights[12].IsGreenLight = !trafficLights.AllTraficLights[12].IsGreenLight;
                trafficLights.AllTraficLights[12].IsRedLight = !trafficLights.AllTraficLights[12].IsRedLight;
                trafficLights.AllTraficLights[1].IsGreenLight = !trafficLights.AllTraficLights[1].IsGreenLight;
                trafficLights.AllTraficLights[1].IsRedLight = !trafficLights.AllTraficLights[1].IsRedLight;
                trafficLights.AllTraficLights[3].IsGreenLight = !trafficLights.AllTraficLights[3].IsGreenLight;
                trafficLights.AllTraficLights[3].IsRedLight = !trafficLights.AllTraficLights[3].IsRedLight;
                trafficLights.AllTraficLights[5].IsGreenLight = !trafficLights.AllTraficLights[5].IsGreenLight;
                trafficLights.AllTraficLights[5].IsRedLight = !trafficLights.AllTraficLights[5].IsRedLight;
                trafficLights.AllTraficLights[7].IsGreenLight = !trafficLights.AllTraficLights[7].IsGreenLight;
                trafficLights.AllTraficLights[7].IsRedLight = !trafficLights.AllTraficLights[7].IsRedLight;
                trafficLights.AllTraficLights[38].IsGreenLight = !trafficLights.AllTraficLights[38].IsGreenLight;
                trafficLights.AllTraficLights[38].IsRedLight = !trafficLights.AllTraficLights[38].IsRedLight;
                trafficLights.AllTraficLights[0].IsGreenLight = !trafficLights.AllTraficLights[0].IsGreenLight;
                trafficLights.AllTraficLights[0].IsRedLight = !trafficLights.AllTraficLights[0].IsRedLight;
                trafficLights.AllTraficLights[30].IsGreenLight = !trafficLights.AllTraficLights[30].IsGreenLight;
                trafficLights.AllTraficLights[30].IsRedLight = !trafficLights.AllTraficLights[30].IsRedLight;
                ColorAllTrafficLights();
                startTimer = DateTime.UtcNow;
            }
            
        }

    }
}
