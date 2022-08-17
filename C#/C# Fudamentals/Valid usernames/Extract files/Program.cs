using System;
using System.Linq;

namespace Extract_files
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ', '\\', '.').ToArray();
            Console.WriteLine($"File name: {input[input.Length - 2]}");
            Console.WriteLine($"File extension: {input[input.Length-1]}");
        }
    }
}
