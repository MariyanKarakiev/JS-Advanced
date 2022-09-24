using System;

namespace SmartLili
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double pricePeralnq = double.Parse(Console.ReadLine());
            double priceToys = double.Parse(Console.ReadLine());
            double evenBirthday = 0;
            int oddBirthday = 0;
            double sumCollected = 0.00d;
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    evenBirthday += 1;
                    sumCollected += 10.00 * evenBirthday;                    
                }
               
                else
                {                                        
                   oddBirthday += 1;
                }
            }
            sumCollected -= evenBirthday * 1.00;
            sumCollected += oddBirthday * priceToys;
            sumCollected = Math.Round(sumCollected,2);
            if (sumCollected >= pricePeralnq)
            {
                Console.WriteLine($"Yes! {Math.Max(sumCollected, pricePeralnq) - Math.Min(sumCollected, pricePeralnq)}");
            }
            else
            {
                Console.WriteLine($"No! {Math.Max(sumCollected, pricePeralnq) - Math.Min(sumCollected, pricePeralnq)}");
            }
        }
    }
}
