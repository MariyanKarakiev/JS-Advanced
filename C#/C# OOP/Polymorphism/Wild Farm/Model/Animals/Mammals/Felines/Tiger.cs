using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Model.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
            FoodsCanBeEaten = new string[] { "Meat" };
        }

        public override double WeightGainPerFoodPiece => 1.00;

        public override void AskForFood(Food food, string animalType)
        {
            Console.WriteLine("ROAR!!!");
            base.AskForFood(food, animalType);
        }
    }
}
