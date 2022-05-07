using System;
using System.Collections.Generic;
using System.Text;

namespace First_and_Reserve_Team
{
    class Team
    {
        public string Name { get; set; }
        public readonly IReadOnlyCollection<Person> MyProperty { get; set; }
    }
}
