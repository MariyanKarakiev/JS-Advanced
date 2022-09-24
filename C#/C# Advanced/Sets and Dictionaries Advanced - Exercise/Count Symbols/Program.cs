using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<char, int> nums = new SortedDictionary<char, int>();
            string input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                if (nums.ContainsKey(input[i]))
                {
                    nums[input[i]]++;
                }

                else
                {
                    nums.Add(input[i], 1);
                }
            }

            foreach (var item in nums)
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
