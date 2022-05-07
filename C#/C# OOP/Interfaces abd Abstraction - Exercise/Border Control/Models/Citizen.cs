using Border_Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control
{
    public class Citizen : PassingObject, ICitizen
    {
        public Citizen(string name, int age, string id, DateTime birthdate)
            : base(name, age)
        {
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }

        public string Id { get; set; }
        public DateTime Birthdate { get; set; }


        public override void BuyFood()
        {
            Food += 10;
        }
    }
}
