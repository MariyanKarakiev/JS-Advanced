using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());
            List<string> num = new List<string>();

            int remainder = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = number[i] - '0';
                digit *= multiplier;
                digit += remainder;

                if (digit < 10)
                {
                    remainder = 0;
                    num.Add((digit).ToString());
                }
                else
                {
                    num.Add(((digit % 10).ToString()));
                    remainder = digit / 10;
                }
            }
            if (remainder > 0)
            {
                num.Add(remainder.ToString());
            }

            num.Reverse();

            Console.WriteLine(string.Concat(num));
        }
    }
}
