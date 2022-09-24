using System;

namespace CalorieCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string sex = Console.ReadLine();
            double weight = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            int years = int.Parse(Console.ReadLine());
            string active = Console.ReadLine();
            height *= 100;
            if (sex=="m")
            {
                
                double BNM = 66 +(13.7 * weight)+(5 * height)-(6.8 * years);
                switch (active)
                {
                    case "sedentary":
                        BNM *= 1.2;
                        break;
                    case "lightly active":
                        BNM *= 1.375;
                        break;
                    case "moderately active":
                        BNM *= 1.55;
                        break;
                    case "very active":
                        BNM *= 1.725;
                        break;
                }
                Console.WriteLine($"To maintain your current weight you will need {Math.Ceiling(BNM)} calories per day.");
            }
            if (sex == "f")
            {
              double  BNM = 655 + (9.6 * weight) + (1.8 * height) - (4.7 * years);
                switch (active)
                {
                    case "sedentary":
                        BNM *= 1.2;
                        break;
                    case "lightly active":
                        BNM *= 1.375;
                        break;
                    case "moderately active":
                        BNM *= 1.55;
                        break;
                    case "very active":
                        BNM *= 1.725;
                        break;
                }
                Console.WriteLine($"To maintain your current weight you will need {Math.Ceiling(BNM)} calories per day.");
            }
        }
    }
}
