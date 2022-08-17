using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Text_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ");
           

            Console.WriteLine(Multiply(input[0],input[1]));
        }
   private static int Multiply(string str1, string str2)
        {
            int sum = 0;
            string str= str1;

            int minLenght = Math.Min(str1.Length, str2.Length);
            int maxLenght = Math.Max(str1.Length, str2.Length);

            if (str1.Length < str2.Length)
            {
                str = str2;
            }
            for (int i = 0; i < minLenght; i++)
            {
                sum += str1[i] * str2[i];
            }
            for (int i = minLenght; i < maxLenght; i++)
            {
                sum += str[i];
            }
            return sum;
        }
    }
}
