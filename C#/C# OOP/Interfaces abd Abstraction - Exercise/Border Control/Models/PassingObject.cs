using Border_Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Border_Control
{
    public abstract class PassingObject : INamable, IBuyer
    {
        protected PassingObject(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public int Food { get; set; }

        public virtual void BuyFood()
        {

        }    
    }
}

