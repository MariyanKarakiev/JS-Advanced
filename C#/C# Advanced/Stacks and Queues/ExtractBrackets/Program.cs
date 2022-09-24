using System;
using System.Collections.Generic;

namespace ExtractBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> brakets = new Stack<int>();


            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    brakets.Push(i);
                }
                if (input[i] == ')')
                {
                    int index = brakets.Pop();

                    Console.WriteLine(input.Substring(index, i-index+1));
                }
            }
        }
    }
}
