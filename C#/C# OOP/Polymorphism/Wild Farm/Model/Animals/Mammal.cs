using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Model.Animals
{
    public abstract class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion)
            : base(name, weight)
        {
            LivingRegion = livingRegion;
            region = livingRegion;
        }

        public string LivingRegion { get; set; }
    }
}

