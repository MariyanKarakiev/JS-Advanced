using Border_Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Rebel : PassingObject
    {
        public Rebel(string name, int age, string group) : base(name,age)
        {
            Age = age;
            Group = group;
            Food = 0;
        }

        public string Group { get; set; }
        public override void BuyFood()
        {
           Food += 5;
        }
    }
}
