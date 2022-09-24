using System;
using System.Text;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
          
            foreach (char letter in word)
            {
                sb.Append((char)(letter + 3));
            }
            
            Console.WriteLine(sb);
        }
    }
}
