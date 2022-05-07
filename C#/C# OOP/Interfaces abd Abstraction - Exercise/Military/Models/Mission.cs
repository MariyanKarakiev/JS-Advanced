using Military.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }
        public string CodeName { get; set; }
        public State State { get; set; }

        public void CompleteMission()
        {
            this.State = (State)Enum.Parse(typeof(State), "Finished");
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {State}";
        }
    }
}
