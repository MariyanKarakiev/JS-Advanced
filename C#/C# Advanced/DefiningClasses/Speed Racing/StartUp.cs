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
            HashSet<Car> cars = new HashSet<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] input1 = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                cars.Add(new Car(input1[0], decimal.Parse(input1[1]), decimal.Parse(input1[2])));
            }

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                cars.Where(c => c.Model == input[1]).ToList().ForEach(c => c.Drive(decimal.Parse(input[2])));

                input = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(Environment.NewLine, cars)); ;
        }
    }
}
