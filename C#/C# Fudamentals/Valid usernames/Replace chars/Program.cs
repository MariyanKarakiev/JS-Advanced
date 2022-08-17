using System;
using System.Linq;
using System.Text;

namespace Replace_chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            char last = '\0';

            foreach (char letter in input)
            {
                if (letter != last)
                {
                    sb.Append(letter);
                    last = letter;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
