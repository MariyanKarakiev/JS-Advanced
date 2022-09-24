using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_and_Queues___Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] values = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int n = values[0];
            int s = values[1];
            int x = values[2];

            int[] nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> numbers = new Stack<int>(nums);

            for (int i = 0; i < s; i++)
            {
                numbers.Pop();
            }


            if (numbers.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (numbers.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(numbers.Min());
            }
        }
    }
}
