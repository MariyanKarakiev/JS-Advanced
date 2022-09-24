using System;
using System.Collections.Generic;

namespace Softuni_Parking
{
    class Program
    {
        static void Main(string[] args)
        {
            var reservations = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = input[0];
              
                if (command == "register")
                {
                    string name = input[1];
                    string number = input[2];

                    if (reservations.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: already registered with plate number {number}");
                    }
                    else
                    {
                        Console.WriteLine($"{name} registered {number} successfully");
                        reservations.Add(name, number);
                    }
                }
                else if (command == "unregister")
                {
                    string name = input[1];                    

                    if (!reservations.ContainsKey(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        reservations.Remove(name);
                        Console.WriteLine($"{name} unregistered successfully");
                    }
                }
            }
            foreach (var reservation in reservations)
            {
                Console.WriteLine($"{reservation.Key} => {reservation.Value}");
            }
        }
    }
}

