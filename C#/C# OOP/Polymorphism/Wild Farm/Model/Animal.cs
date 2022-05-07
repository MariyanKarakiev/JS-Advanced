using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Wild_Farm.Model
{
    public abstract class Animal
    {
        protected string animalType;
        protected string region;

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
            FoodEaten = 0;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }

        public abstract double WeightGainPerFoodPiece { get; }
        public string[] FoodsCanBeEaten { get; protected set; }

        public virtual void AskForFood(Food food, string _animalType)
        {
            animalType = _animalType;
            var foodName = food.GetType().Name;

            if (FoodsCanBeEaten.ToList().Contains(foodName))
            {
                FoodEaten += food.Quanitity;
                Weight += food.Quanitity * WeightGainPerFoodPiece;
            }
            else
            {
                Console.WriteLine($"{animalType} does not eat {foodName}!");
            }
        }

        public override string ToString()
        {
            return $"{animalType} [{Name}, {Weight}, {region}, {FoodEaten}]";
        }
    }
}
