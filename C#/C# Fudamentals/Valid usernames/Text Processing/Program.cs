using System;
using System.Collections.Generic;
using System.Linq;

namespace Text_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine().Split(", ").ToList();
            List<string> valid = new List<string>();

            foreach (string password in input)
            {
                bool isValid = true;

                foreach (char symbol in password)
                {
                    if (password.Length < 3 || password.Length > 16 || !char.IsDigit(symbol) || !char.IsNumber(symbol) || symbol != '-' || symbol != '_')
                    {
                        isValid = false;
                        break;
                    }

                }
                if (isValid)
                {
                    valid.Add(password);
                }
            }
            Console.WriteLine(string.Join('\n', valid));
        }
    }
}
