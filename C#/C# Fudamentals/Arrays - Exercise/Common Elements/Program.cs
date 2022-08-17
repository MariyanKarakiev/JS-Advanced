using System;
using System.Linq;

namespace Common_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string[] input2 = Console.ReadLine().Split(' ').ToArray();

            string[] common = new string[input1.Length];
           
            for (int i = 0; i < input1.Length; i++)
            {
                for (int p = 0; p < input2.Length; p++)
                {
                    if (input1[i] == input2[p])
                    {
                        common[i] = input1[i];
                    }            
                }
            }
         
            common = common.Where(c => c != null).ToArray();
            Console.WriteLine(string.Join(" ",common));
        }
    }
}
