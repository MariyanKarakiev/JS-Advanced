using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Spy : Soldier, ISpy
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) 
            : base(id, firstName, lastName)
        {
            CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"CodeNumber: {CodeNumber}");
           
            return sb.ToString().Trim();
        }
    }
}
