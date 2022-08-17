using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Tire
    {
        public int Tire1Age { get; set; }
        public double Tire1Pressure { get; set; }
       
        public Tire(int tire1Age, double tire1Pressure)
        {
            Tire1Age = tire1Age;
            Tire1Pressure = tire1Pressure;
        }
    }
}
