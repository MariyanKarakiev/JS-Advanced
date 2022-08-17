using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
   public class Family
    {
        public readonly HashSet<Person> members;

        public Family()
        {
            this.members = new HashSet<Person>();
        }

        public void AddMember(Person member)
        {
            this.members.Add(member);
        }

        public Person GetOldestMember() => members.OrderByDescending(n => n.Age).FirstOrDefault();

        public HashSet<Person> GetAllPeopleAbove30() => members.Where(m => m.Age > 30).OrderBy(m => m.Name).ToHashSet();
        

        
    }
}
