using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuanitity, double fuelConsumption, double tankCapacity)
            : base(fuelQuanitity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;


        public override void Refuel(double litersToRefuel)
        {
            if (TankCapacity < (FuelQuantity + litersToRefuel))
            {
                Console.WriteLine($"Cannot fit {litersToRefuel} fuel in the tank");
            }
            else
            {
                base.Refuel(litersToRefuel * 0.95);
            }
        }
    }
}
