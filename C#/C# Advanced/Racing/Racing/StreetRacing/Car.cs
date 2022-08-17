using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    public class Car
    {
        private string make;
        private string model;
        private string licensePlate;
        private int horsePower;
        private double weight;

        public Car(string make, string model, string licensePlate, int horsePower, double weight)
        {
            this.make = make;
            this.model = model;
            this.licensePlate = licensePlate;
            this.horsePower = horsePower;
            this.weight = weight;
        }

        public string Make { get => make; set => make = value; }

        public string Model { get => model; set => model = value; }

        public string LicensePlate { get => licensePlate; set => licensePlate = value; }

        public int HorsePower { get => horsePower; set => horsePower = value; }

        public double Weight { get => weight; set => weight = value; }

        public override string ToString()
        {
            return $"Make: {make}\n"
                + $"Model: {model}\n"
                + $"License Plate: {licensePlate}\n"
                + $"Horse Power: {horsePower}\n"
                + $"Weight: {weight}";
        }
    }
}
