using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control.Interfaces
{
    public interface ICitizen : IBirthable, INamable,IBuyer
    {
        int Age { get; }
        string Id { get; }
    }
}
