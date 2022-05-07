using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Model.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            FoodsCanBeEaten = new string[] { "Vegetable", "Fruit" };
        }

        public override double WeightGainPerFoodPiece => 0.10;

        public override void AskForFood(Food food, string animalType)
        {
            Console.WriteLine($"Squeak");
            base.AskForFood(food, animalType);
        }
    }
}
