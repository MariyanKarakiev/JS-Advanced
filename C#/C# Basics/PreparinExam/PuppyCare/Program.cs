using System;

namespace PuppyCare
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodKg = int.Parse(Console.ReadLine());
            foodKg *= 1000;
            string input = Console.ReadLine();
            bool isEnough = false;
            while (input != "Adopted")
            {
                int food = int.Parse(input);
                foodKg -= food;

                if (foodKg < 0)
                {
                    isEnough = true;
                }

                input = Console.ReadLine();
            }
            if (input == "Adopted")
            {
                if (isEnough)
                {
                    Console.WriteLine($"Food is not enough. You need {Math.Abs(foodKg)} grams more.");
                }
                else
                {
                    Console.WriteLine($"Food is enough! Leftovers: {foodKg} grams.");
                }
            }
        }
    }
}
