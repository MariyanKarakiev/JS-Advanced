using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Model.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            FoodsCanBeEaten = new string[] { "Meat", "Vegetable" };
        }

        public override double WeightGainPerFoodPiece => 0.30;

        public override void AskForFood(Food food, string animalType)
        {
            Console.WriteLine("Meow");
            base.AskForFood(food, animalType);
        }
    }
}
