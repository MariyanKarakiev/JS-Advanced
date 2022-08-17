using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();
            int entry = int.Parse(Console.ReadLine());
            string str = Console.ReadLine();

            long left = 0;
            long right = 0;
            long bigger;


            for (int i = 0; i < entry; i++)
            {
                left += numbers[i];
            }
            for (int i = entry; i < numbers.Length; i++)
            {
                right += numbers[i];
            }

            if (right >= numbers[entry])
            {
                bigger = right;
            }
            else
            {
                bigger = left;

            }

            switch (str)
            {
                case "cheap":
                    {
                        if (left < numbers[entry] || left < right)
                        {
                            Console.WriteLine($"Left - {left}");
                            break;
                        }
                        else if (left == right)
                        {
                            Console.WriteLine($"Left - {left}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Right - {right}");
                            break;
                        }
                    }
                case "expensive":
                    {
                        if (right >= numbers[entry] || right > left)
                        {
                            Console.WriteLine($"Right - {right}");
                            break;
                        }
                        else if (left == right)
                        {
                            Console.WriteLine($"Left - {left}");
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Left - {left}");
                            break;
                        }
                    }
            }
        }
    }
}