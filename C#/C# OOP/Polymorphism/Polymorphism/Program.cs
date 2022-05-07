using Polymorphism.Models;
using System;
using System.Linq;

namespace Polymorphism
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var carInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var truckInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var busInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);


            var car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]), double.Parse(carInput[3]));
            var truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]), double.Parse(truckInput[3]));
            var bus = new Bus(double.Parse(busInput[1]), double.Parse(busInput[2]), double.Parse(busInput[3])); ;

            int numberOfActions = int.Parse(Console.ReadLine());


            for (int i = 0; i < numberOfActions; i++)
            {
                string[] commandLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandLine[0];
                string vehicle = commandLine[1];

                if (command == "DriveEmpty")
                {
                    double kmToDrive = double.Parse(commandLine[2]);
                    bus.IsEmpty = true;
                    Drive(bus, kmToDrive);
                }

                else if (command == "Drive")
                {
                    double kmToDrive = double.Parse(commandLine[2]);

                    if (vehicle is "Car")
                    {
                        Drive(car, kmToDrive);
                    }
                    else if (vehicle == "Truck")
                    {
                        Drive(truck, kmToDrive);
                    }
                    else if (vehicle == "Bus")
                    {
                        Drive(bus, kmToDrive);
                    }
                }


                else if (command == "Refuel")
                {
                    double litersToRefuel = double.Parse(commandLine[2]);
                    if (vehicle == "Car")
                    {
                        car.Refuel(litersToRefuel);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(litersToRefuel);
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.Refuel(litersToRefuel);
                    }
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:F2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }

        public static void Drive(Vehicle vehicle, double kmToDrive)
        {
            if (vehicle.CanDrive(kmToDrive))
            {
                Console.WriteLine($"{vehicle.GetType().Name} travelled {kmToDrive} km");
            }
            else
            {
                Console.WriteLine($"{vehicle.GetType().Name} needs refueling");
            }
        }
    }
}
