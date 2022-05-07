using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Model.Animals
{
    public abstract class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize)
            : base(name, weight)
        {
            WingSize = wingSize;
            region = wingSize.ToString();
        }

        public double WingSize { get; set; }

        public override string ToString()
        {
            return $"{animalType} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
