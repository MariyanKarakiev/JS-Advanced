using System;
using System.Text;

namespace Digits__letters_and_others
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder others= new StringBuilder();

           string input = Console.ReadLine();

            foreach (char item in input)
            {
                if (char.IsDigit(item))
                {
                    digits.Append(item);
                }
                else if (char.IsLetter(item))
                {
                    letters.Append(item);
                }
                else
                {
                    others.Append(item);
                }
            }
            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}
