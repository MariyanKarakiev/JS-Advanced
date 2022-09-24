using System;
using System.Collections.Generic;

namespace Party_Softuni
{
    class Program
    {
        static void Main(string[] args)
        {
            bool partyStarted = false;
            HashSet<string> people = new HashSet<string>();
            HashSet<string> peopleVip = new HashSet<string>();

            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "PARTY")
                {
                    partyStarted = true;
                    continue;
                }

                if (partyStarted)
                {
                    if (isVip(command))
                    {
                        peopleVip.Remove(command);
                    }
                    else
                    {
                        people.Remove(command);
                    }
                }

                else
                {
                    if (isVip(command))
                    {
                        peopleVip.Add(command);
                    }
                    else
                    {
                        people.Add(command);
                    }
                }
            }

            Console.WriteLine(people.Count+peopleVip.Count);

            foreach (var item in peopleVip)
            {
                Console.WriteLine(item);
            }

            foreach (var item in people)
            {
                Console.WriteLine(item);
            }
        }
        static bool isVip(string command)
        {
            int num = 0;

            return int.TryParse(command.Substring(0, 1), out num);
        }
    }
}
