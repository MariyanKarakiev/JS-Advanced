using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        private List<Car> participants = new List<Car>();
        private string name;
        private string type;
        private int laps;
        private int capacity;
        private int maxHorsePower;

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.name = name;

            this.type = type;

            this.laps = laps;

            this.capacity = capacity;

            this.maxHorsePower = maxHorsePower;
        }

        public int MaxHorsePower { get => maxHorsePower; set => maxHorsePower = value; }

        public int Capacity { get => capacity; set => capacity = value; }

        public int Laps { get => laps; set => laps = value; }

        public string Type { get => type; set => type = value; }

        public string Name { get => name; set => name = value; }

        public List<Car> Participants { get => participants; set => participants = value; }

        public int Count { get => participants.Count; }

        public void Add(Car car)
        {
            if (!participants.Any(a => a.LicensePlate == car.LicensePlate) && car.HorsePower < maxHorsePower + 1)
            {
                participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            return participants.Any(a => a.LicensePlate == licensePlate) && participants.Remove(participants.First(a => a.LicensePlate == licensePlate));
        }

        public Car FindParticipant(string licensePlate)
        {
            return participants.Any(a => a.LicensePlate == licensePlate) ? participants.First(a => a.LicensePlate == licensePlate) : null;
        }

        public Car GetMostPowerfulCar()
        {
            if (participants.Count == 0)
            {
                return null;
            }

            Car car = participants[0];

            for (int i = 1; i < participants.Count; i++)
            {
                if (participants[i].HorsePower > car.HorsePower)
                {
                    car = participants[i];
                }
            }

            return car;

            return participants.Any() ? participants.OrderByDescending(a => a.HorsePower).First() : null;
        }

        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Race: {name} - Type: {type} (Laps: {laps})");

            for (int i = 0; i < participants.Count; i++)
            {
                stringBuilder.AppendLine(participants[i].ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
