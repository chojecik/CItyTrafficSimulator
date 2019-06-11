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
    /// Interaction logic for ExperimentWindow.xaml
    /// </summary>
    public partial class ExperimentWindow : Window
    {
        private MainWindow _mainWindow;
        private readonly double distance = 0.4;    //prędkość poruszania się elips
        private DateTime startTimer = DateTime.UtcNow;
        private DateTime start = DateTime.UtcNow;
        private DateTime experimentTime;
        private TimeSpan carTimeDiff;
        private Random random = new Random();
        private List<Car> cars = new List<Car>();
        private int counter;
        private readonly Colours colours;
        private RouteList routeList;
        private DateTime stopTimer;
        private StreetList streetList;
        private TrafficLightsList trafficLights;
        private bool isStart;
        private int carIdSetter;
        private List<Car> carsToRemove = new List<Car>();
        private bool isAlgorithm;
        public int experimentCarId = -1;
        private bool experimentStarted = false;

        public ExperimentWindow(MainWindow mainWindow, bool isAlgorithm)
        {
            colours = new Colours();
            InitializeComponent();
            _mainWindow = mainWindow;
            Closed += OnWindowClosed;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            this.isAlgorithm = isAlgorithm;
        }

        public void OnWindowClosed(object sender, System.EventArgs e)
        {
            _mainWindow.Show();
        }

        private void ColorAllTrafficLights()
        {
            trafficLights.AllTraficLights.ForEach(tl =>
            {
                if (tl.IsGreenLight)
                {
                    tl.GreenLight.Fill = colours.solidColorBrushes[1];
                    tl.RedLight.Fill = colours.solidColorBrushes[0];
                    tl.YellowLight.Fill = colours.solidColorBrushes[0];
                }
                else if (tl.IsRedLight)
                {
                    tl.GreenLight.Fill = colours.solidColorBrushes[0];
                    tl.RedLight.Fill = colours.solidColorBrushes[3];
                    tl.YellowLight.Fill = colours.solidColorBrushes[0];
                }
            });
        }

        private void CompositionTarget_Rendering(object sender, System.EventArgs e)
        {
            DateTime end = DateTime.UtcNow;
            TimeSpan timeDiff = end - start;
            if (experimentStarted)
            {
                carTimeDiff = end - experimentTime;
                TimeOfCarLabel.Content = Convert.ToDouble(carTimeDiff.TotalMilliseconds / 1000.0);
            }
            
            StopWatchLabel.Content = Convert.ToDouble(timeDiff.TotalMilliseconds / 1000.0);
           

            if (!isStart)
            {
                routeList = new RouteList(this);
                trafficLights = new TrafficLightsList(this);
                streetList = new StreetList(this);
                ColorAllTrafficLights();
            }
            else
            {
                ControlTrafficLights();
            }

            if (counter == 30 || !isStart)  //dodajemy nowy samochod kiedy mamy pewnosc, ze nie nalozy sie on na juz istniejaca elipse
            {
                isStart = true;
                Car newCar = new Car();
                Rectangle rectangle = new Rectangle();

                newCar.StartingRouteOfCar = routeList.routes[random.Next(0, routeList.routes.Count)];
                newCar.CurrentRouteOfCar = newCar.StartingRouteOfCar;
                newCar.PostionX = newCar.CurrentRouteOfCar.StartPoint.X;
                newCar.PostionY = newCar.CurrentRouteOfCar.StartPoint.Y;
                rectangle.Height = 8;
                rectangle.Width = 8;
                rectangle.Fill = colours.solidColorBrushes[random.Next(0, colours.solidColorBrushes.Count)];
                newCar.Vehicle = rectangle;
                newCar.Id = carIdSetter++;
                newCar.CurrentStreet = FindCurrentStreet(newCar);
                newCar.Direction = newCar.CurrentRouteOfCar.StartingDirection;
                

                if(newCar.StartingRouteOfCar.Id == 9 && timeDiff.TotalSeconds > 100 && !experimentStarted)
                {
                    newCar.Vehicle.Fill = new SolidColorBrush() { Color = Color.FromRgb(255, 0, 102) };
                    experimentCarId = newCar.Id;
                    experimentTime = DateTime.UtcNow;
                    experimentStarted = true;
                }

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
           


            cars.ForEach(c =>
            {
                if((int)c.PostionX == (int)c.CurrentRouteOfCar.EndPoint.X && (int)c.PostionY == (int)c.CurrentRouteOfCar.EndPoint.Y)
                {
                    carsToRemove.Add(c);

                    if(c.Id == experimentCarId)
                    {
                        if (!isAlgorithm)
                        {
                            _mainWindow.TimeWithout.Content = Convert.ToDouble(carTimeDiff.TotalMilliseconds / 1000.0);
                            this.Close();
                            _mainWindow.Show();
                        }
                        else
                        {
                            _mainWindow.TimeWith.Content = Convert.ToDouble(carTimeDiff.TotalMilliseconds / 1000.0);
                            this.Close();
                            _mainWindow.Show();

                        }
                    }
                }
            });

            carsToRemove.ForEach(c =>
            {
                ExpWithoutAlgCanvas.Children.Remove(c.Vehicle);
                cars.Remove(c);
            });
            carsToRemove.Clear();

            cars.ForEach(car =>
            {
                switch (car.CurrentRouteOfCar.Id)
                {
                    case 0:
                        if ((car.PostionY <= 320 )  || (car.PostionY > 320  && car.PostionY <= 326 && trafficLights.AllTraficLights[0].IsGreenLight) || car.PostionY > 326)
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if(!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                    car.PostionY += distance;
                                    car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                    car.CurrentStreet = FindCurrentStreet(car);
                                    car.Direction = Direction.South;
                            }
                        }
                        break;
                    case 1:
                        if((car.PostionY <= 320) || (car.PostionY > 320 && car.PostionY <= 326 && trafficLights.AllTraficLights[0].IsGreenLight) || (car.PostionY > 326 && car.PostionY <330))
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                car.PostionY += distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.South;
                            }
                        }
                        else if(car.PostionY >= 330)
                        {
                            car.CurrentRouteOfCar = routeList.routes[3];
                        }
                        break;
                    case 2:
                        if((car.StartingRouteOfCar.Id == 7 || car.StartingRouteOfCar.Id == 15) && car.PostionX > 549 && car.PostionX < 550)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 7);
                        }
                        else if(car.StartingRouteOfCar.Id == 22 && car.PostionX > 945)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 17);
                        }
                        else if (car.StartingRouteOfCar.Id == 23 && car.PostionX > 990)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 16);
                        }
                        else if (car.PostionX < 40 || (car.PostionX >= 40 && car.PostionX <= 45 && trafficLights.AllTraficLights[31].IsGreenLight) || (car.PostionX > 45 && car.PostionX <= 120) || (car.PostionX > 120 && car.PostionX <= 125 && trafficLights.AllTraficLights[29].IsGreenLight) || (car.PostionX > 125 && car.PostionX <= 167) || (car.PostionX > 167 && car.PostionX <= 172 && trafficLights.AllTraficLights[36].IsGreenLight) || (car.PostionX > 172 && car.PostionX <= 285) || (car.PostionX > 285 && car.PostionX <= 293 && trafficLights.AllTraficLights[37].IsGreenLight) || (car.PostionX > 293 && car.PostionX <= 493) || (car.PostionX > 493 && car.PostionX <= 499 && trafficLights.AllTraficLights[21].IsGreenLight) || (car.PostionX > 499 && car.PostionX <= 756) || (car.PostionX > 756 && car.PostionX <= 764 && trafficLights.AllTraficLights[14].IsGreenLight) || (car.PostionX > 764 && car.PostionX <= 930) || (car.PostionX > 930 && car.PostionX <= 935 && trafficLights.AllTraficLights[12].IsGreenLight) || car.PostionX > 935)
                        { 
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                car.PostionX += distance;
                                car.Vehicle.SetValue(Canvas.LeftProperty, car.PostionX);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.East;
                            }
                        }
                        break;
                    case 3:
                        if (car.StartingRouteOfCar.Id == 14 && car.PostionX > 549 && car.PostionX < 550)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 7);
                        }
                        else if (car.PostionX >= 1030 || (car.PostionX < 1030 && car.PostionX >= 1025 && trafficLights.AllTraficLights[7].IsGreenLight) || (car.PostionX < 1025 && car.PostionX >= 808) || (car.PostionX < 808 && car.PostionX >= 803 && trafficLights.AllTraficLights[39].IsGreenLight) || (car.PostionX < 803 && car.PostionX >= 564) || (car.PostionX < 564 && car.PostionX >= 559 && trafficLights.AllTraficLights[5].IsGreenLight) || (car.PostionX < 559 && car.PostionX >= 323) || (car.PostionX < 323 && car.PostionX >= 318 && trafficLights.AllTraficLights[38].IsGreenLight) || (car.PostionX < 318 && car.PostionX >= 204) || (car.PostionX < 204 && car.PostionX >= 199 && trafficLights.AllTraficLights[40].IsGreenLight) || (car.PostionX < 199 && car.PostionX >= 154) || (car.PostionX < 154 && car.PostionX >= 149 && trafficLights.AllTraficLights[3].IsGreenLight) || (car.PostionX < 149 && car.PostionX >= 76) || (car.PostionX < 76 && car.PostionX >= 71 && trafficLights.AllTraficLights[1].IsGreenLight) || car.PostionX < 71)
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                car.PostionX -= distance;
                                car.Vehicle.SetValue(Canvas.LeftProperty, car.PostionX);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.West;
                            }
                        }
                        break;
                    case 4:
                        if (car.PostionY > 405 || (car.PostionY < 405 && car.PostionY > 400 && trafficLights.AllTraficLights[30].IsGreenLight) || car.PostionY < 400)
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute) )
                            {
                                car.PostionY -= distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.North;
                            }
                        }
                        break;
                    case 7:
                        if ((car.PostionY <= 320 && car.PostionX == 50) || (car.PostionY > 320 && car.PostionY <= 326 && trafficLights.AllTraficLights[0].IsGreenLight && car.PostionX == 50) || (car.PostionY > 326 && car.PostionY < 370 && car.PostionX == 50))
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                car.PostionY += distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.South;
                            }
                        }
                        else if (car.PostionY >= 370 && car.PostionX == 50)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 2);
                        }
                        else
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                car.PostionY -= distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.North;
                            }
                        }
                        break;
                    case 9:
                        if ((car.PostionY <= 320) || (car.PostionY > 320 && car.PostionY <= 326 && trafficLights.AllTraficLights[0].IsGreenLight) || (car.PostionY > 326 && car.PostionY < 370))
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                car.PostionY += distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.South;
                            }
                        }
                        else if (car.PostionY >= 370)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 2);
                        }
                        break;
                    case 12:
                        if ((car.PostionY <= 320) || (car.PostionY > 320 && car.PostionY <= 326 && trafficLights.AllTraficLights[4].IsGreenLight) || (car.PostionY > 326 && car.PostionY <= 370))
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                car.PostionY += distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.South;
                            }
                        }
                        else if(car.PostionY > 370)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 2);
                        }

                        break;
                    case 13:
                        if ((car.PostionY <= 320) || (car.PostionY > 320 && car.PostionY <= 326 && trafficLights.AllTraficLights[4].IsGreenLight) || (car.PostionY > 326 && car.PostionY <= 330))
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                car.PostionY += distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.South;
                            }
                        }
                        else if (car.PostionY > 330)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 3);
                        }

                        break;
                    case 14:
                        car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 3);
                        break;
                    case 15:
                        car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 2);
                        break;
                    case 16:
                        if (car.StartingRouteOfCar.Id == 20 && car.PostionY < 330)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 3);
                        }
                        else if (car.StartingRouteOfCar.Id == 21 && car.PostionY < 370)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 2);
                        }
                        else if ((car.PostionY > 760) || (car.PostionY <= 760 && car.PostionY > 755 && trafficLights.AllTraficLights[9].IsGreenLight) || (car.PostionY <= 755 && car.PostionY > 405) || (car.PostionY <= 405 && car.PostionY > 400 && trafficLights.AllTraficLights[8].IsGreenLight) || car.PostionY <= 400)
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                car.PostionY -= distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.North;
                            }
                        }
                        break;
                    case 17:
                        if(car.StartingRouteOfCar.Id == 18 && car.PostionY > 330)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 3);
                        }
                        else if(car.StartingRouteOfCar.Id == 19 && car.PostionY > 370)
                        {
                            car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 2);
                        }
                        else if ((car.PostionY <= 320) || (car.PostionY > 320 && car.PostionY <= 326 && trafficLights.AllTraficLights[0].IsGreenLight) || (car.PostionY > 326 && car.PostionY <= 700) || (car.PostionY > 700 && car.PostionY <=703 && trafficLights.AllTraficLights[11].IsGreenLight) || car.PostionY > 703)
                        {
                            var orderOfCarsOnTheRoute = CalculateOrderOnRoute(car);
                            if (!CheckIfThereIsACarAhead(car, orderOfCarsOnTheRoute))
                            {
                                car.PostionY += distance;
                                car.Vehicle.SetValue(Canvas.TopProperty, car.PostionY);
                                car.CurrentStreet = FindCurrentStreet(car);
                                car.Direction = Direction.South;
                            }
                        }
                        break;
                    case 18:
                        car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 17);
                        break;
                    case 19:
                        car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 17);
                        break;
                    case 20:
                        car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 16);
                        break;
                    case 21:
                        car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 16);
                        break;
                    case 22:
                        car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 2);
                        break;
                    case 23:
                        car.CurrentRouteOfCar = routeList.routes.Find(r => r.Id == 2);
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
        private bool CheckIfThereIsACarAhead(Car car, List<Car> order)
        {
            int carPositionInOrder = order.FindIndex(c => c == car);

            if (carPositionInOrder == 0)
            {
                return false;
            }
            else
            {
                return (Math.Sqrt(Math.Pow(order[carPositionInOrder-1].PostionX - car.PostionX, 2) + Math.Pow(order[carPositionInOrder-1].PostionY - car.PostionY, 2))) < 10;
            }
        }

        private List<Car> CalculateOrderOnRoute(Car car)
        {
            switch(car.Direction)
            {
                case Direction.East:
                    return cars.Where(c => c.CurrentStreet.Equals(car.CurrentStreet) && c.Direction.Equals(car.Direction)).OrderByDescending(pos => pos.PostionX).ToList();
                case Direction.North:
                    return cars.Where(c => c.CurrentStreet.Equals(car.CurrentStreet) && c.Direction.Equals(car.Direction)).OrderBy(pos => pos.PostionY).ToList();
                case Direction.South:
                    return cars.Where(c => c.CurrentStreet.Equals(car.CurrentStreet) && c.Direction.Equals(car.Direction)).OrderByDescending(pos => pos.PostionY).ToList();
                case Direction.West:
                    return cars.Where(c => c.CurrentStreet.Equals(car.CurrentStreet) && c.Direction.Equals(car.Direction)).OrderBy(pos => pos.PostionX).ToList();
                default:
                    return null;
            }
        }
        public void ControlTrafficLights()
        {
            stopTimer = DateTime.UtcNow;
            TimeSpan timeDiff = stopTimer - startTimer;

            if (!isAlgorithm)
            {
                if (timeDiff.TotalSeconds > 30)
                {
                    trafficLights.AllTraficLights.ForEach(tl =>
                    {
                        tl.IsRedLight = !tl.IsRedLight;
                        tl.IsGreenLight = !tl.IsGreenLight;
                    });

                    ColorAllTrafficLights();
                    startTimer = DateTime.UtcNow;
                }
            }
            else
            {
                CountNumberOfCarsOnTheStreets();

                if (timeDiff.TotalSeconds > 10)
                {
                    if (streetList.carsOnTheStreet[0] + streetList.carsOnTheStreet[6] > streetList.carsOnTheStreet[7] + streetList.carsOnTheStreet[8])
                    {
                        trafficLights.AllTraficLights[31].IsGreenLight = true;
                        trafficLights.AllTraficLights[31].IsRedLight = false;
                        trafficLights.AllTraficLights[1].IsGreenLight = true;
                        trafficLights.AllTraficLights[1].IsRedLight = false;
                        trafficLights.AllTraficLights[3].IsGreenLight = true;
                        trafficLights.AllTraficLights[3].IsRedLight = false;
                        trafficLights.AllTraficLights[0].IsGreenLight = false;
                        trafficLights.AllTraficLights[0].IsRedLight = true;
                        trafficLights.AllTraficLights[30].IsGreenLight = false;
                        trafficLights.AllTraficLights[30].IsRedLight = true;
                    }
                    else
                    {
                        trafficLights.AllTraficLights[31].IsGreenLight = false;
                        trafficLights.AllTraficLights[31].IsRedLight = true;
                        trafficLights.AllTraficLights[1].IsGreenLight = false;
                        trafficLights.AllTraficLights[1].IsRedLight = true;
                        trafficLights.AllTraficLights[3].IsGreenLight = false;
                        trafficLights.AllTraficLights[3].IsRedLight = true;
                        trafficLights.AllTraficLights[0].IsGreenLight = true;
                        trafficLights.AllTraficLights[0].IsRedLight = false;
                        trafficLights.AllTraficLights[30].IsGreenLight = true;
                        trafficLights.AllTraficLights[30].IsRedLight = false;
                    }

                    if (streetList.carsOnTheStreet[2] + streetList.carsOnTheStreet[5] > streetList.carsOnTheStreet[9])
                    {
                        trafficLights.AllTraficLights[21].IsGreenLight = true;
                        trafficLights.AllTraficLights[21].IsRedLight = false;
                        trafficLights.AllTraficLights[5].IsGreenLight = true;
                        trafficLights.AllTraficLights[5].IsRedLight = false;
                        trafficLights.AllTraficLights[4].IsGreenLight = false;
                        trafficLights.AllTraficLights[4].IsRedLight = true;
                    }
                    else
                    {
                        trafficLights.AllTraficLights[21].IsGreenLight = false;
                        trafficLights.AllTraficLights[21].IsRedLight = true;
                        trafficLights.AllTraficLights[5].IsGreenLight = false;
                        trafficLights.AllTraficLights[5].IsRedLight = true;
                        trafficLights.AllTraficLights[4].IsGreenLight = true;
                        trafficLights.AllTraficLights[4].IsRedLight = false;
                    }

                    if (streetList.carsOnTheStreet[3] + streetList.carsOnTheStreet[4] > streetList.carsOnTheStreet[10] + streetList.carsOnTheStreet[11])
                    {
                        trafficLights.AllTraficLights[12].IsGreenLight = true;
                        trafficLights.AllTraficLights[12].IsRedLight = false;
                        trafficLights.AllTraficLights[7].IsGreenLight = true;
                        trafficLights.AllTraficLights[7].IsRedLight = false;
                        trafficLights.AllTraficLights[8].IsGreenLight = false;
                        trafficLights.AllTraficLights[8].IsRedLight = true;
                        trafficLights.AllTraficLights[6].IsGreenLight = false;
                        trafficLights.AllTraficLights[6].IsRedLight = true;
                    }
                    else
                    {
                        trafficLights.AllTraficLights[12].IsGreenLight = false;
                        trafficLights.AllTraficLights[12].IsRedLight = true;
                        trafficLights.AllTraficLights[7].IsGreenLight = false;
                        trafficLights.AllTraficLights[7].IsRedLight = true;
                        trafficLights.AllTraficLights[8].IsGreenLight = true;
                        trafficLights.AllTraficLights[8].IsRedLight = false;
                        trafficLights.AllTraficLights[6].IsGreenLight = true;
                        trafficLights.AllTraficLights[6].IsRedLight = false;
                    }
                    startTimer = DateTime.UtcNow;
                }

                ColorAllTrafficLights();
            }
            
            
        }

        public void CountNumberOfCarsOnTheStreets()
        {
            streetList.carsOnTheStreet[0] = cars.Where(c => c.CurrentStreet == streetList.streets[4] && c.PostionX < 46 && c.Direction == Direction.East).Count();
            streetList.carsOnTheStreet[1] = cars.Where(c => c.CurrentStreet == streetList.streets[4] && c.PostionX > 46 && c.PostionX < 172 && c.Direction == Direction.East).Count();
            streetList.carsOnTheStreet[2] = cars.Where(c => c.CurrentStreet == streetList.streets[4] && c.PostionX > 172 && c.PostionX < 499 && c.Direction == Direction.East).Count();
            streetList.carsOnTheStreet[3] = cars.Where(c => c.CurrentStreet == streetList.streets[4] && c.PostionX > 499 && c.PostionX < 935 && c.Direction == Direction.East).Count();
            streetList.carsOnTheStreet[4] = cars.Where(c => c.CurrentStreet == streetList.streets[4] && c.PostionX > 1025 && c.Direction == Direction.West).Count();
            streetList.carsOnTheStreet[5] = cars.Where(c => c.CurrentStreet == streetList.streets[4] && c.PostionX < 1025 && c.PostionX > 559 && c.Direction == Direction.West).Count();
            streetList.carsOnTheStreet[6] = cars.Where(c => c.CurrentStreet == streetList.streets[4] && c.PostionX < 559 && c.PostionX > 71 && c.Direction == Direction.West).Count();
            streetList.carsOnTheStreet[7] = cars.Where(c => c.CurrentStreet == streetList.streets[0] && c.Direction == Direction.South).Count();
            streetList.carsOnTheStreet[8] = cars.Where(c => c.CurrentStreet == streetList.streets[5] && c.Direction == Direction.North).Count();
            streetList.carsOnTheStreet[9] = cars.Where(c => c.CurrentStreet == streetList.streets[2] && c.Direction == Direction.South).Count();
            streetList.carsOnTheStreet[10] = cars.Where(c => c.CurrentStreet == streetList.streets[3] && c.Direction == Direction.South).Count();
            streetList.carsOnTheStreet[11] = cars.Where(c => c.CurrentStreet == streetList.streets[13] && c.Direction == Direction.North).Count();

        }

       
    }
}
