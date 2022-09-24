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

            int bomb = 0;


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    bomb += input[i + 1] - '0';
                    sb.Append(input[i]);
                }
                else if (bomb > 0)
                {
                    bomb -= 1;
                }
                else
                {
                    sb.Append(input[i]);
                }
            }

            Console.WriteLine(sb);
        }
    }
}
