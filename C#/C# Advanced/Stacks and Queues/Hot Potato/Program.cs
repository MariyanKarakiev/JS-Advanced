using System;
using System.Collections;
using System.Collections.Generic;

namespace Hot_Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            var n = int.Parse(Console.ReadLine());

            Queue<string> game = new Queue<string>(kids);

            while (game.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    game.Enqueue(game.Dequeue());
                }
                Console.WriteLine($"Removed {game.Dequeue()}");
            }

            Console.WriteLine($"Last is {game.Dequeue()}");
        }
    }
}
