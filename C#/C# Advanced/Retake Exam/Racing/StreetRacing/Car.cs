using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
   public class Car
    {
        //        •	Make: string
        //•	Model: string
        //•	LicensePlate: string
        //•	HorsePower: int
        //•	Weight: double


        public string Make { get; set; }

        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double Weight { get; set; }

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            Make = make;
            Model = model;
            LicensePlate = licensePlate;
            HorsePower = horsePower;
            Weight = weight;
        }

        public override string ToString()
        {

            var sb = new StringBuilder();
            sb.Append($"Make: {Make}");
            sb.AppendLine();
            sb.Append($"Model: {Model}");          
            sb.AppendLine();
            sb.Append($"License Plate: {LicensePlate}");
            sb.AppendLine();          
            sb.Append($"Horse Power: {HorsePower}");
            sb.AppendLine();
            sb.Append($"Weight: {Weight}");          

            return sb.ToString();
        }

    }
}
