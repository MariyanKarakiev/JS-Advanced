using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Military.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private readonly List<IPrivate> privates;

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.privates = new List<IPrivate>();
        }

        public IReadOnlyCollection<IPrivate> Privates => this.privates.AsReadOnly();

        public void AddPrivate(IPrivate priv)
        {
            this.privates.Add(priv);
        }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (var priv in Privates)
            {
                sb.AppendLine($"  {priv}");
            }

            return sb.ToString().Trim();
        }
    }
}
