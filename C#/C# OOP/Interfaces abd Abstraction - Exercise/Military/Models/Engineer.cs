using Military.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private readonly List<IRepair> _repairs;

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            _repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs => _repairs.AsReadOnly();

        public void AddRepair(IRepair repair)
        {
            _repairs.Add(repair);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            sb.AppendLine($"Corps: {Corps}");
            sb.AppendLine($"Repairs:");

            foreach (var repair in _repairs)
            {
                sb.AppendLine("  " + repair.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
