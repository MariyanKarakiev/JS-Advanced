using System;

namespace SumOfNums
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int sum = 0;
            while (sum < n)
            {
               int n2 = int.Parse(Console.ReadLine());
                sum += n2;
            }
            Console.WriteLine(sum);
        }
    }
}
