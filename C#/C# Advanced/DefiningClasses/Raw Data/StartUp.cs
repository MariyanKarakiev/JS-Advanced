using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = input[0];

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];


                var tires = new Tire[]
                {
                      new Tire(int.Parse(input[6]), double.Parse(input[5])),
                     new Tire(int.Parse(input[8]), double.Parse(input[7])),
                     new Tire(int.Parse(input[10]), double.Parse(input[9])),
                     new Tire(int.Parse(input[12]), double.Parse(input[11]))
            };

                cars.Add(new Car(model, new Engine(engineSpeed, enginePower), new Cargo(cargoWeight, cargoType), tires));
            }

            var cargo = Console.ReadLine();


            if (cargo == "fragile")
            {
                cars
               .Where(c => c.Cargo.CargoType == "fragile" && c.Tires.Any(t => t.Tire1Pressure < 1))
               .ToList()
               .ForEach(c => Console.WriteLine(c));
            }
            else if (cargo == "flamable")
            {
                cars
               .Where(c => c.Cargo.CargoType == "flamable" && c.Engine.EnginePower > 250)
               .ToList()
               .ForEach(c => Console.WriteLine(c.ToString()));
            }
        }
    }
}
