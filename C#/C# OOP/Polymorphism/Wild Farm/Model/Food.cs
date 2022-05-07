using System;
using System.Collections.Generic;
using System.Text;

namespace Wild_Farm.Model
{
    public abstract class Food
    {
        public Food(int quantity)
        {
            Quanitity = quantity;
        }

        public int Quanitity { get; set; }
    }
}
