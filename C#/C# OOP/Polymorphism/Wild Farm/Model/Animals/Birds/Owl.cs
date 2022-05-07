using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Model.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            FoodsCanBeEaten = new string[] { "Meat" };
        }

        public override double WeightGainPerFoodPiece => 0.25;

        public override void AskForFood(Food food, string animalType)
        {
            Console.WriteLine($"Hoot Hoot");
            base.AskForFood(food, animalType);
        }
    }
}
