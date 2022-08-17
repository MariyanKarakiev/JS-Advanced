using System;
using System.Collections.Generic;
using System.Linq;

namespace Bomb_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
              .Split(' ', StringSplitOptions.RemoveEmptyEntries)
              .Select(int.Parse)
              .ToList();

            int[] bombData = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int sum = 0;

            while (numbers.Contains(bombData[0]))
            {
                int bombNum = bombData[0];
                int bombPow = bombData[1];
                int indexStart = 0;
                int count = 2 * bombPow + 1;

                if (bombPow < numbers.FindIndex(a => a == bombNum))
                {
                    indexStart = numbers.FindIndex(a => a == bombNum) - bombPow;
                }

                else
                {
                    count -= bombPow - 1;
                }

                if (numbers.FindIndex(a => a == bombNum) + bombPow > numbers.Count - 1)
                {
                    count -= (numbers.FindIndex(a => a == bombNum) + bombPow) - (numbers.Count - 1);
                }

                if (bombPow >= numbers.Count)
                {
                    count = numbers.Count;
                }

                numbers.RemoveRange(indexStart, count);
            }

            foreach (var item in numbers)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }
    }
}
