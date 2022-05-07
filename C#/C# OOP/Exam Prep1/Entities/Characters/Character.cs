using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters
{
    public abstract class Character
    {
        // TODO: Implement the rest of the class.
        private string _name;

        public Character(string name, double health, double armor,
            double abilityPoints, Bag bag)

        {
            _name = name;
            Health = health;
            BaseHealth = health;
            Armor = armor;
            BaseArmor = armor;
            AbilityPoints = abilityPoints;
            Bag = bag;
            IsAlive = true;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                _name = value;
            }
        }
        public double BaseHealth { get; set; }
        public double Health { get; set; }
        public double BaseArmor { get; set; }
        public double Armor { get; set; }
        public double AbilityPoints { get; set; }
        public IBag Bag { get; set; }
        public bool IsAlive { get; set; }
        public string Status => IsAlive ? "Alive" : "Dead";

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }
        public void TakeDamage(double hitPoints)
        {
            EnsureAlive();

            Armor -= hitPoints;

            if (Armor < 0)
            {
                Health += Armor;
                Armor = 0;
            }

            if (Health <= 0)
            {
                IsAlive = false;
                Health = 0;
            }
        }
        public void UseItem(Item item)
        {
            item.AffectCharacter(this);
        }
    }
}