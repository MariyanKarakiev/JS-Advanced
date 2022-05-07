using Military.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military
{
    public interface ISpecialisedSoldier : IPrivate
    {
         Corps Corps { get; }
    }
}
