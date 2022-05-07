using Military.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military
{
    public interface IEngineer : ISpecialisedSoldier
    {
        ICollection<IRepair> Repairs { get; }
        void AddRepair(IRepair repair);
    }
}
