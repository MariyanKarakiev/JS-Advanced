using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Model.Animals.Mammals
{
    public abstract class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed)
            : base(name, weight, livingRegion)
        {
            Breed = breed;
            region = livingRegion;
        }

        public string Breed { get; set; }

        public override string ToString()
        {
            return $"{animalType} [{Name}, {Breed}, {Weight}, {region}, {FoodEaten}]";
        }
    }
}
