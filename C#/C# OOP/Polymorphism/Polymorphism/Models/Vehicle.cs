using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism.Models
{
    public class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelConsumption = fuelConsumption;

            if (fuelQuantity <= tankCapacity)
            {
                FuelQuantity = fuelQuantity;
            }
            else
            {
                FuelQuantity = 0;
            }
        }

        public virtual double FuelConsumption { get; set; }
        public double FuelQuantity { get; private set; }
        public double TankCapacity { get; private set; }
        public double DistanceDriven { get; set; }

        public virtual void Refuel(double litersToRefuel)
        {
            if (litersToRefuel <= 0)
            {
                Console.WriteLine($"Fuel must be a positive number");
            }
            else if (TankCapacity - (FuelQuantity + litersToRefuel) < 0)
            {
                Console.WriteLine($"Cannot fit {litersToRefuel} fuel in the tank");
            }
            else
            {
                FuelQuantity += litersToRefuel;
            }
        }

        public bool CanDrive(double kmToDrive)
        {
            if (kmToDrive * FuelConsumption > FuelQuantity)
            {
                return false;
            }

            FuelQuantity -= kmToDrive * FuelConsumption;
            DistanceDriven += kmToDrive;
            return true;

        }
    }
}
