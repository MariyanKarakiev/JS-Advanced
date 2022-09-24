using System;
using System.Collections.Generic;

namespace Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> chr = new Stack<string>();
            string[] input = Console.ReadLine().ToLower().Split(' ');
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                chr.Push(input[i]);
            }

            while (input[0] != "end")
            {
                if (input[0]=="add")
                {
                    chr.Push(input[1]);
                    chr.Push(input[2]);
                }
                else if (input[0] == "remove")
                {
                    for (int i = 0; i < int.Parse(input[1]); i++)
                    {
                        chr.Pop();
                    }
                }
               input = Console.ReadLine().ToLower().Split(' ');
            }

            while (chr.Count>0)
            {
                sum += int.Parse(chr.Pop());
            }
            Console.WriteLine(sum);
        }
    }
}
