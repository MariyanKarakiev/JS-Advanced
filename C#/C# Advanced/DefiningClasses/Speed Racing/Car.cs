using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public string Model { get; set; }
        public decimal FuelAmount { get; set; }
        public decimal FuelConsuprionPerKilometer { get; set; }
        public decimal TravelledDistance { get; set; }

        public Car()
        {
            TravelledDistance = 0;
        }
        public Car(string model, decimal fuelAmount, decimal consuption)
        {
            Model = model;
           FuelAmount = fuelAmount;
            FuelConsuprionPerKilometer = consuption;
            TravelledDistance = 0;
        }

        public void Drive(decimal km)
        {
            var fuelNeed= (decimal)km * FuelConsuprionPerKilometer;

            if (FuelAmount >= fuelNeed)
            {
                TravelledDistance += km;
                FuelAmount -= (decimal)km * FuelConsuprionPerKilometer;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {TravelledDistance}";
        }
    }
}
