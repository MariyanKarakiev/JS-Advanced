using Military.Enums;
using Military.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military
{
    public interface ICommando : ISpecialisedSoldier
    {     
        ICollection<IMission> Missions { get; }
        void AddMission(IMission mission);
    }
}
