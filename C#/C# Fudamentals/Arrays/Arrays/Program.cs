﻿using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days =
            {
                "Monday", "Tuesday", "Wednesdey",
                "Thursday", "Friday", "Saturday",
                "Sunday"
            };
            int day = int.Parse(Console.ReadLine());
            if (day < 1 || day > 7)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(days[day - 1]);
            }
        }
    }
}

