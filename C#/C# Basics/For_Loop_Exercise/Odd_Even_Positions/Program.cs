using System;

namespace Odd_Even_Positions
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double OddMax = double.MinValue;
            double OddMin = double.MaxValue;
            double OddSum = 0;
            double EvenMax = double.MinValue;
            double EvenMin = double.MaxValue;
            double EvenSum = 0;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (i % 2 == 0)
                {
                    EvenSum += num;
                    if (num > EvenMax)
                    {
                        EvenMax = num;
                    }
                    if (num < EvenMin)
                    {
                        EvenMin = num;
                    }
                }
                if (i % 2 != 0)
                {
                    OddSum += num;
                    if (num > OddMax)
                    {
                        OddMax = num;
                    }
                    if (num < OddMin)
                    {
                        OddMin = num;
                    }
                }
            }
            Console.WriteLine($"OddSum={OddSum:F2},");
            if (OddMin != double.MaxValue)
            {
                Console.WriteLine($"OddMin={OddMin:F2},");
            }
            else
            {
                Console.WriteLine("OddMin=No,");
            }
            if (OddMax != double.MinValue)
            {
                Console.WriteLine($"OddMax={OddMax:F2},");
            }
            else
            {
                Console.WriteLine("OddMax=No,");
            }
            Console.WriteLine($"EvenSum={EvenSum:F2},");
            if (EvenMin != double.MaxValue)
            {
                Console.WriteLine($"EvenMin={EvenMin:F2},");
            }
            else
            {
                Console.WriteLine("EvenMin=No,");
            }
            if (EvenMax != double.MinValue)
            {
                Console.WriteLine($"EvenMax={EvenMax:F2}");
            }
         else
            {
                Console.WriteLine("EvenMax=No");
            }
        }
    }
}
        
    

