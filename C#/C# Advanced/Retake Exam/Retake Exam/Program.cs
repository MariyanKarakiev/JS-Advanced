using System;
using System.Collections.Generic;
using System.Linq;

namespace Retake_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> guests = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).Reverse());

            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int food = 0;

            while (guests.Any() && plates.Any())
            {
                int guest = guests.Pop();

                int plate = plates.Pop();

                guest -= plate;

                if (guest <= 0)
                {
                    food -= guest;
                }
                else
                {
                    guests.Push(guest);
                }
            }

            if (guests.Any())
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            else
            {
                if (plates.Any())
                {
                    Console.WriteLine($"Plates: {string.Join(" ", plates)}");
                }
            }

            Console.WriteLine($"Wasted grams of food: {food}");
        }

    }
}
