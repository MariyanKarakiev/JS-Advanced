using System;

namespace Mid_exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal price = 0.00M;
            decimal total = 0.00M;

         
                for (int i = 1; i <= n; i++)
                {
                    double pricePerCapsule = double.Parse(Console.ReadLine());
                    int daysInMonth = int.Parse(Console.ReadLine());
                    int capsulesCount = int.Parse(Console.ReadLine());

                    price = (decimal)(daysInMonth * capsulesCount * pricePerCapsule);
                    total += price;

                    Console.WriteLine($"The price for the coffee is: ${Math.Round(price, 2):f2}");
                }
                Console.WriteLine($"Total: ${Math.Round(total, 2):f2}");
            
        }
    }
}
