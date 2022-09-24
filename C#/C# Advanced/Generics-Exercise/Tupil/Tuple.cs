using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    class Tuple<TFirst, Tsecond, TThird>
    {
        public TFirst FirstElement { get; private set; }
        public Tsecond SecondElement { get; private set; }
        public TThird ThirdElement { get; private set; }

        public Tuple(TFirst first, Tsecond second, TThird third)
        {
            FirstElement = first;
            SecondElement = second;
            ThirdElement = third;
        }


    }
}
