using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumToCall)
        {
            if (!phoneNumToCall.All(s => char.IsDigit(s)))
            {
                throw new NumberExeption();
            }

            return $"Dialing... {phoneNumToCall}";
        }
    }
}
