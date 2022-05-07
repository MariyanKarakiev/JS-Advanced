using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();
            string input = Console.ReadLine();

            while (input != "Beast!")
            {
                var tokens = Console.ReadLine().Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string gender = tokens[2];

                try
                {
                    switch (input)
                    {
                        case "Dog":
                            var dog = new Dog(name, age, gender);
                            animals.Add(dog);
                            break;

                        case "Cat":
                            var cat = new Cat(name, age, gender);
                            animals.Add(cat);
                            break;

                        case "Frog":
                            var frog = new Frog(name, age, gender);
                            animals.Add(frog);
                            break;

                        case "Tomcat":
                            var tomCat = new Tomcat(name, age);
                            animals.Add(tomCat);
                            break;

                        case "Kitten":
                            var kittens = new Kitten(name, age);
                            animals.Add(kittens);
                            break;
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType());
                Console.Write(animal.ToString());
            }
        }
    }
}
