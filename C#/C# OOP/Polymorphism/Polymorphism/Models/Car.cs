using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuanitity, double fuelConsumption, double tankCapacity)
            : base(fuelQuanitity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 0.9;
    }
}

