using System;
using System.Collections.Generic;
using System.Text;

namespace Military
{
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
