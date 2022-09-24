using System;

namespace For_Loop_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int max = int.MinValue;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                sum += num;
                if (num > max)
                {
                    max = num;
                }
            }       
            if (sum-max == max)
                {
                    Console.WriteLine($"Yes\nSum = {max}");
                }
                else 
                {
                    Console.WriteLine($"No\nDiff = {Math.Abs(max - (sum-max))}");
                }
            }
        }
    }

