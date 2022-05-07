using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Animal
    {
        private string name;
        private int age;
        private string gender;
        
        
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException();
                }
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }
                this.age = value;
            }
        }
        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                if (value == String.Empty)
                {
                    throw new ArgumentException();
                }
               this.gender = value;
            }
        }

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public virtual string ProduceSound()
        {
            return " ";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
        
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine($"{ProduceSound()}");
            return sb.ToString();
        }
    }
}
