using Military.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military
{
    public interface IMission
    {
         string CodeName { get; }
         State State { get; }
        void CompleteMission();
    }
}
