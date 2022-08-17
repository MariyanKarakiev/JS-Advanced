using System;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int[]> add = numbers => numbers.Select(n => n + 1).ToArray();
            Func<int[], int[]> multiply = numbers => numbers.Select(n => n * 2).ToArray();
            Func<int[], int[]> subtract = numbers => numbers.Select(n => n - 1).ToArray();
            Action<int[]> print = numbers => Console.WriteLine(string.Join(' ', numbers));

            int[] numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                switch (input)
                {
                    case "add":
                        numbers = add(numbers);
                        break;
                    case "multiply":
                        numbers = multiply(numbers);
                        break;
                    case "subtract":
                        numbers = subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
                input = Console.ReadLine();
            }

        }
    }
}
