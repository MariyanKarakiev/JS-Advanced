using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Model.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name,double weight, double wingSize)
            : base(name, weight, wingSize)
        {
            FoodsCanBeEaten = new string[] { "Vegetable", "Fruit", "Seeds", "Meat" };
        }

        public override double WeightGainPerFoodPiece => 0.40;
   
        public override void AskForFood(Food food, string animalType)
        {
            Console.WriteLine("Cluck");
            base.AskForFood(food, animalType);
        }

        public override string ToString()
        {
            return nameof(Hen).ToString() + base.ToString();
        }
    }
}
