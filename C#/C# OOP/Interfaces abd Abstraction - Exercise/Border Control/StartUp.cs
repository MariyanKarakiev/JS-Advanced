using Border_Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Border_Control
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            int food = 0;
            List<PassingObject> objs = new List<PassingObject>();
            HashSet<PassingObject> objectsWithName = new HashSet<PassingObject>();

            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine().Split(' ');

                if (input.Length == 4)
                {
                    var citizen = new Citizen(input[0], int.Parse(input[1]), input[2], DateTime.Parse(input[3], new CultureInfo("fr-FR", false), DateTimeStyles.None));
                    objs.Add(citizen);
                }
                else if (input.Length == 3)
                {
                    var rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    objs.Add(rebel);
                }
            }

            var nameInput = Console.ReadLine();

            while (true)
            {
                if (nameInput == "End")
                {
                    break;
                }

                var obj = objs.FirstOrDefault(o => o.Name == nameInput);

                if (obj == null)
                {
                    nameInput = Console.ReadLine();
                    continue;
                }
                obj.BuyFood();
                objectsWithName.Add(obj);
                nameInput = Console.ReadLine();
            }

            objectsWithName.ToList().ForEach(o =>food+=o.Food);

            Console.WriteLine(food);
        }
    }
}
