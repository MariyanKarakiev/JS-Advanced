using System;
using System.Collections.Generic;
using System.Linq;

namespace Enigma
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string command = Console.ReadLine();


            while (command != "Decode")
            {

                string[] token = command.Split('|');

                switch (token[0])
                {
                    case "Move":
                        string symbols = message.Substring(0, int.Parse(token[1]));
                        message.Substring();
                        break;

                    case "Insert":
                        message.Insert(int.Parse(token[2]), token[1]);
                        break;
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", message));
        }
    }
}
