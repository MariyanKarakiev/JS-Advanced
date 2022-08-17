using System;

namespace LeftRightSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int left = 0;
            int right = 0;
            for (int i = 0; i < n * 2; i++)
            {
               // Console.WriteLine(i % 2);
                int num = int.Parse(Console.ReadLine());
                if (i <n*2/2)
                {
                   
                    left += num;
                }
                else
                {
                    right += num;
                }
            }
            if (left == right)
            {
                Console.WriteLine($"Yes, sum = {left}");
            }
            else
            {
               
                Console.WriteLine($"No, diff = {Math.Max(left,right)-Math.Min(left,right)}");
            }
        }
    }
}
