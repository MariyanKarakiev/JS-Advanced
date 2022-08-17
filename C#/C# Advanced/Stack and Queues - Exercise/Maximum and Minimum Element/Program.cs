using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> numbs = new Stack<int>();


            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                switch (input[0])
                {

                    case 1:
                        {
                            numbs.Push(input[1]);
                            break;
                        }
                    case 2:
                        {
                            numbs.Pop();
                            break;
                        }
                    case 3:
                        {
                            if (numbs.Count>0)
                            {
                                Console.WriteLine(numbs.Max());
                            }
                            break;
                        }
                    case 4:
                        {
                            if (numbs.Count > 0)
                            {
                                Console.WriteLine(numbs.Min());
                            }
                            break;
                        }
                }
            }
            Console.WriteLine(string.Join(", ", numbs));
        }
    }
}
