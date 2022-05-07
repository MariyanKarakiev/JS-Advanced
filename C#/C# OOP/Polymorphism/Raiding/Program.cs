using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());        
            var heroes = new HashSet<BaseHero>();

            while (heroes.Count < count)
            {
                var name = Console.ReadLine();
                var type = Console.ReadLine();

                switch (type)
                {
                    case "Paladin":
                        heroes.Add(new Paladin(name));
                        break;

                    case "Druid":
                        heroes.Add(new Druid(name));
                        break;

                    case "Rogue":
                        heroes.Add(new Rogue(name));
                        break;

                    case "Warrior":
                        heroes.Add(new Warrior(name));
                        break;

                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }
            }
            heroes
                .ToList()
                .ForEach(h => Console.WriteLine(h.CastAbility()));

            int sumofPower = heroes
                .Sum(h => h.Power);

            var powerOfBoss = int.Parse(Console.ReadLine());


            if (powerOfBoss > sumofPower)
            {
                Console.WriteLine("Defeat...");
            }
            else
            {
                Console.WriteLine("Victory!");
            }
        }
    }
}
