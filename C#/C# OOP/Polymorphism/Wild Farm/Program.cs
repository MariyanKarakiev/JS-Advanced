using System;
using System.Collections.Generic;
using System.Linq;
using Wild_Farm.Model;
using Wild_Farm.Model.Animals.Birds;
using Wild_Farm.Model.Animals.Mammals;
using Wild_Farm.Model.Animals.Mammals.Felines;

namespace Wild_Farm
{
    public class Program
    {
        static void Main(string[] args)
        {
            var animals = new List<Animal>();
            var foods = new List<Food>();

            var inputAnimal = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (inputAnimal[0] != "End")
            {
                var typeOfAnimal = inputAnimal[0];
                var name = inputAnimal[1];
                var weight = double.Parse(inputAnimal[2]);


                var inputFood = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var foodName = inputFood[0];
                var foodQuanitty = int.Parse(inputFood[1]);


                switch (foodName)
                {
                    case "Vegetable":
                        {
                            foods.Add(new Vegetable(foodQuanitty));
                            break;
                        }
                    case "Fruit":
                        {
                            foods.Add(new Fruit(foodQuanitty));
                            break;
                        }
                    case "Meat":
                        {
                            foods.Add(new Meat(foodQuanitty));
                            break;
                        }
                    case "Seeds":
                        {
                            foods.Add(new Seeds(foodQuanitty));
                            break;
                        }
                    default:
                        break;
                }

                var food = foods.LastOrDefault();
                var animal = animals.LastOrDefault();

                switch (typeOfAnimal)
                {
                    case "Owl":
                        {
                            var wings = double.Parse(inputAnimal[3]);

                            animal = new Owl(name, weight, wings);
                            break;
                        }
                    case "Hen":
                        {
                            var wings = double.Parse(inputAnimal[3]);

                            animal = new Hen(name, weight, wings);
                            break;
                        }
                    case "Mouse":
                        {

                            var livingRegion = inputAnimal[3];

                            animal = new Mouse(name, weight, livingRegion);
                            break;
                        }
                    case "Cat":
                        {
                            var livingRegion = inputAnimal[3];
                            var breed = inputAnimal[4];

                            animal = new Cat(name, weight, livingRegion, breed);
                            break;
                        }
                    case "Dog":
                        {
                            var livingRegion = inputAnimal[3];

                            animal = new Dog(name, weight, livingRegion);
                            break;
                        }
                    case "Tiger":
                        {
                            var livingRegion = inputAnimal[3];
                            var breed = inputAnimal[4];

                            animal = new Tiger(name, weight, livingRegion, breed);
                            break;
                        }
                    default:
                        break;
                }

                animal.AskForFood(food, animal.GetType().Name);
                animals.Add(animal);

                inputAnimal = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
            animals.ToList().ForEach(a => Console.WriteLine(a.ToString()));
        }
    }
}
