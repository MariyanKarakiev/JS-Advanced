using System;
using System.Collections.Generic;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Inventory;

namespace WarCroft.Entities.Characters
{
    public class Warrior : Character, IAttacker
    {
        public Warrior(string name)
            : base(name, 100D, 50D, 40D, new Satchel())
        {
        }

        public void Attack(Character character)
        {
            EnsureAlive();

            if (Name == character.Name)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            character.TakeDamage(this.AbilityPoints);
        }
    }
}
