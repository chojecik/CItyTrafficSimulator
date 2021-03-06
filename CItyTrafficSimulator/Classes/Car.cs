﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace CItyTrafficSimulator.Classes
{
    public class Car
    {
        public int Id { get; set; }
        public double PostionX { get; set; }
        public double PostionY { get; set; }
        public Rectangle Vehicle { get; set; }
        public Route StartingRouteOfCar { get; set; }
        public Route CurrentRouteOfCar { get; set; }
        public Rectangle CurrentStreet { get; set; }
        public Direction? Direction { get; set; }
    }

    public enum Direction
    {
        East,
        West,
        North,
        South
    }
}
