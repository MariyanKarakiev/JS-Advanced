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
            var engines = GetEngines(n);

            int m = int.Parse(Console.ReadLine());
            var cars = GetCars(m,engines);

            Console.WriteLine(string.Join(Environment.NewLine, cars));


        }

        public static List<Engine> GetEngines(int n)
        {
            var engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                engines.Add(new Engine(input[0], int.Parse(input[1])));


                if (input.Length > 2)
                {
                    var isDis = int.TryParse(input[2], out int displasement);

                    if (isDis && input.Length == 4)
                    {
                        engines[i].Displacement = displasement;
                        engines[i].Efficiency = input[3];
                    }
                    else if (isDis && input.Length == 3)
                    {
                        engines[i].Displacement = displasement;
                    }
                    else
                    {
                        engines[i].Efficiency = input[2];
                    }
                }
            }

            return engines;
        }

        public static List<Car> GetCars(int m, List<Engine> engines)
        {
            var cars = new List<Car>();

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                cars.Add(new Car(input[0], engines.Where(e => e.Model == input[1]).FirstOrDefault()));

                if (input.Length > 2)
                {
                    var hasWeight = int.TryParse(input[2], out int weight);

                    if (hasWeight && input.Length == 4)
                    {
                        cars[i].Weight = weight;
                        cars[i].Color = input[3];
                    }
                    else if (hasWeight && input.Length == 3)
                    {
                        cars[i].Weight = weight;
                    }
                    else
                    {
                        cars[i].Color = input[2];
                    }
                }
            }
            return cars;
        }
    }
}
