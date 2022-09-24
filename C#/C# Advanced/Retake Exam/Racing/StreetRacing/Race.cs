using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        //        •	Name: string
        //•	Type: string
        //•	Laps: int
        //•	Capacity: int - the maximum allowed number of participants in the race
        //•	MaxHorsePower: int - the maximum allowed Horse Power of a Car in the Race

        public List<Car> Participants;

        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count;


        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
            Participants = new List<Car>();
        }

        public void Add(Car car)
        {
            if ((!Participants.Exists(p => p.LicensePlate == car.LicensePlate)) && car.HorsePower > MaxHorsePower && Participants.Count >= Participants.Capacity)
            {
                
            }
            else
            {
                Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            if (Participants.Exists(p => p.LicensePlate == licensePlate))
            {
                Participants.Remove(Participants.FirstOrDefault(p => p.LicensePlate == licensePlate));
                return true;
            }
            else
            {
                return true;
            }
        }//OK
        public Car FindParticipant(string licensePlate)
        {
            if (Participants.Exists(p => p.LicensePlate == licensePlate))
            {
                return Participants.FirstOrDefault(p => p.LicensePlate == licensePlate);
            }
            else
            {
                return null;
            }
        }//OK

        public Car GetMostPowerfulCar()
        {
            if (Participants.Any())
            {
                return Participants.FirstOrDefault(p => p.HorsePower == Participants.Max(x => x.HorsePower));
            }
            else
            {
                return null;
            }
        }//OK

        public string Report()
        {
            var sb = new StringBuilder();

            sb.Append($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            sb.AppendLine();

            foreach (var car in Participants)
            {
                sb.Append(car.ToString());
                sb.AppendLine();
            }
            return sb.ToString();
        }//OK
    }
}
