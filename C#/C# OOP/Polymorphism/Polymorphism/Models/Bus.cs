using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuanitity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuanitity, fuelConsumption, tankCapacity)
        {
        }

        public bool IsEmpty { get; set; }

        public override double FuelConsumption => IsEmpty
            ? base.FuelConsumption
            : base.FuelConsumption + 1.4;
    }
}
