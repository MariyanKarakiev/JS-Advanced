using Military.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMission> _mission;

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            _mission=new List<IMission>();
        }

        public ICollection<IMission> Missions { get; }

        public void AddMission(IMission mission)
        {
            _mission.Add(mission);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Missions:");

            foreach (var mission in _mission)
            {
                sb.AppendLine("  " + mission.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
