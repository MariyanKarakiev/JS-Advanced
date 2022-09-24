using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        //         Model
        // Power
        // Displacement
        // Efficiency
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"  {Model}:");
            sb.AppendLine();

            sb.Append($"    Power: {Power}");
            sb.AppendLine();

            sb.Append(Displacement == 0 ? $"    Displacement: n/a" : $"    Displacement: {Displacement}");
            sb.AppendLine();

            sb.Append(Efficiency == null ? $"  Efficiency: n/a" : $"    Efficiency: {Efficiency}");


            return sb.ToString();
        }
    }
}
