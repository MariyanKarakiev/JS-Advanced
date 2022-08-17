using System;
using System.Linq;

namespace Equal_Sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            
            bool noNum = false;
            for (int i = 0; i < numbers.Length; i++)
            {

                int sumright = 0;
                for (int p = i + 1; p < numbers.Length; p++)
                {

                    sumright += numbers[p];
                }
                int sumleft = 0;
                for (int k = i-1; k >= 0; k--)
                {

                    sumleft += numbers[k];
                }
                if (sumright == sumleft)
                {
                    
                    Console.WriteLine(i);
                    noNum=true;
                    break;
                }
                



            }
            if (!noNum)
            {
                Console.WriteLine("no");
            }
          
        }
    }
}
