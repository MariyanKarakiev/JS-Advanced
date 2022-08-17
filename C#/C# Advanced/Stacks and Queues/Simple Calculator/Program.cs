using System;
using System.Collections.Generic;
using System.Linq;

namespace Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse().ToArray();
            int sum = 0;
            Stack<string> numbers = new Stack<string>();

            foreach (var num in input)
            {
                numbers.Push(num);
            }

            bool sums = true;

           while(numbers.Count>1)
            {
                var num1 = int.Parse(numbers.Pop());
                string op = numbers.Pop();
                var num2= int.Parse(numbers.Pop());
              
                if (op == "+")
                {
                    numbers.Push((num1 + num2).ToString());                  
                }
                else if (op == "-")
                {
                    numbers.Push((num1 - num2).ToString());
                }
            }

            Console.WriteLine(sum);
        }
    }
}
