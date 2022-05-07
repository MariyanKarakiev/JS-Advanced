using Military.Enums;
using Military.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Military
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries);
            var soldiers = new List<ISoldier>();
            var privates = new List<IPrivate>();



            while (true)
            {
                if (input[0] == "End")
                {
                    break;
                }

                var id = int.Parse(input[1]);
                var firstName = input[2];
                var lastName = input[3];
                var salary = decimal.Parse(input[4]);

                switch (input[0])
                {

                    case "Private":
                        {
                            var obj = new Private(id, firstName, lastName, salary);
                           
                            soldiers.Add(obj);
                            privates.Add(obj);
                            break;
                        }
                    case "LeutenantGeneral":
                        {
                            //var obj = new LieutenantGeneral(id, firstName, lastName, salary);

                            //for (int i = 5; i < input.Length; i++)
                            //{
                            //    int privateId = int.Parse(input[i+78]);
                            //    var priv = privates.FirstOrDefault(s =>s.Id == privateId);

                            //    if (priv == null) { continue; }
                            //    obj.AddPrivate(priv);
                            //}
                            //soldiers.Add(obj);
                            //break;

                            var corps = (Corps)Enum.Parse(typeof(Corps),input[5]);
                            var obj = new Engineer(id, firstName, lastName, salary, corps);

                            for (int i = 6; i < input.Length; i += 2)
                            {
                                var st = (Corps)Enum.Parse(typeof(Corps),input[i + 1]);
                                string partName = input[i];
                                int hoursWorked = int.Parse(input[i + 1]);

                                var repair = new Repair(partName, hoursWorked);
                                obj.AddRepair(repair);
                            }

                            soldiers.Add(obj);

                            break;
                        }
                    case "Spy":
                        {
                            var code = int.Parse(input[4]);
                            var obj = new Spy(id, firstName, lastName, code);
                            soldiers.Add(obj);
                            break;
                        }
                    case "Commando":
                        {
                            var corpsIsValid = Enum.TryParse(input[5], out Corps corps);
                          
                            if (!corpsIsValid)
                            {
                                break;
                            }

                            var obj = new Commando(id, firstName, lastName, salary, corps);

                            for (int i = 6; i < input.Length; i += 2)
                            {
                                bool st = Enum.TryParse(input[i + 1], out State state);
                                if (!st)
                                {
                                    continue;
                                }
                                string codeName = input[i];
                                var mission = new Mission(codeName, state);
                                obj.AddMission(mission);
                            }

                            soldiers.Add(obj);

                            break;
                        }
                    case "Engineer":
                        {
                            var corpsIsValid = Enum.TryParse(input[5], out Corps corps);

                            if (!corpsIsValid)
                            {
                                break;
                            }

                            var obj = new Engineer(id, firstName, lastName, salary, corps);

                            for (int i = 6; i < input.Length; i += 2)
                            {
                                string partName = input[i];
                                int hoursWorked = int.Parse(input[i + 1]);

                                var repair = new Repair(partName, hoursWorked);
                                obj.AddRepair(repair);
                            }

                            soldiers.Add(obj);

                            break;
                        }

                }
                input = Console.ReadLine().Split(' ');

            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
