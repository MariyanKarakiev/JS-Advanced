using System;

namespace CatFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int cats = int.Parse(Console.ReadLine());
            int small = 0;
            int medium = 0;
            int large = 0;
            double sum = 0.0;
            for (int i = 0; i < cats; i++)
            {
                int food = int.Parse(Console.ReadLine());
                sum += food;
                if (food >= 100 && food < 200)
                {
                    small += 1;
                }
                else if (food >= 200 && food < 300)
                {
                    medium += 1;
                }
                else if (food >= 300 && food < 400)
                {
                    large += 1;
                }
            }
            
            Console.WriteLine($"Group 1: {small} cats.");
            Console.WriteLine($"Group 2: {medium} cats.");
            Console.WriteLine($"Group 3: {large} cats.");
            Console.WriteLine($"Price for food per day: {Math.Round(12.45 * (sum/1000), 2):F2} lv.");
        }
    }
}
