using System;

namespace Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] key = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            foreach (string word in key)
            {
                text = text.Replace(word, new string('*', word.Length));
                
            }
            Console.WriteLine(text);
        }
    } }