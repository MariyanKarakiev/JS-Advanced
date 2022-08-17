using System;
using System.Collections.Generic;
using System.Linq;

namespace Sets_and_Dictionaries_Advanced___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int num;
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();
            int biggerLenght = Math.Max(size[0], size[1]);
            int smallerLenght = Math.Min(size[0], size[1]);

            for (int i = 0; i < size[0]; i++)
            {
                num = int.Parse(Console.ReadLine());
                first.Add(num);
            }
            for (int i = 0; i < size[1]; i++)
            {

                num = int.Parse(Console.ReadLine());
                second.Add(num);
            }

            List<int> nums = new List<int>();

            foreach (var number in first)
            {
                if (second.Contains(number))
                {
                    Console.Write($"{number} ");
                }
            }
        }
    }
}

