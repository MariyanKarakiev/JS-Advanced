using System;
using System.Collections.Generic;
using System.Linq;
namespace Reverse_string
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> reversed = new List<string>();
            List<string> normal = new List<string>();

            while (input != "end")
            {

                if (!reversed.Contains(input))
                {
                    normal.Add(input);
                    string reversedstring = new string(input.Reverse().ToArray());
                    reversed.Add(reversedstring);
                }
                input = Console.ReadLine();
            }

            for (int i = 0; i < reversed.Count; i++)
            {
                Console.WriteLine($"{normal[i]} = {reversed[i]}");

            }

        }
    }
}
