using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Model.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
            FoodsCanBeEaten = new string[] { "Meat" };
        }

        public override double WeightGainPerFoodPiece => 0.40;

        public override void AskForFood(Food food, string animalType)
        {
            Console.WriteLine("Woof!");
            base.AskForFood(food, animalType);
        }
    }
}
