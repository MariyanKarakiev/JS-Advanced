using System;
using System.Linq;

namespace Top_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();


            for (int i = 0; i < numbers.Length; i++)
            {
                int top = numbers[numbers.Length-1];
                bool isTop = true;
                for (int p = i+1; p < numbers.Length ; p++)
                {
                    if (numbers[i] > numbers[p])
                    {
                       
                        top = numbers[i];
                    }
                    else
                    {
                        isTop = false;
                        break;
                    }
                }
                if (isTop)
                {
                    Console.Write($"{top} ");
                }
            }
        }
    }
}

