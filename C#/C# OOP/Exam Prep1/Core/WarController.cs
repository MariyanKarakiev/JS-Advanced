using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
    {
        private readonly List<Character> charactersParty;
        private readonly Stack<Item> itemPool;

        public WarController()
        {
            charactersParty = new List<Character>();
            itemPool = new Stack<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            switch (characterType)
            {
                case nameof(Warrior):
                    {
                        charactersParty.Add(new Warrior(name));
                        return string.Format(SuccessMessages.JoinParty, name);
                    }

                case nameof(Priest):
                    {
                        charactersParty.Add(new Priest(name));
                        return string.Format(SuccessMessages.JoinParty, name);
                    }

                default:
                    throw new ArgumentException(string.Format
                        (ExceptionMessages.InvalidCharacterType, characterType));
            }
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];


            switch (itemName)
            {
                case nameof(FirePotion):
                    {
                        itemPool.Push(new FirePotion());
                        return string.Format(SuccessMessages.AddItemToPool, itemName);
                    }

                case nameof(HealthPotion):
                    {
                        itemPool.Push(new HealthPotion());
                        return string.Format(SuccessMessages.AddItemToPool, itemName);
                    }

                default:
                    throw new ArgumentException(string.Format
                        (ExceptionMessages.InvalidItem, itemName));
            }
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            var character = charactersParty.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (itemPool.Count == 0)
            {
                throw new InvalidOperationException(string.Format
                    (ExceptionMessages.ItemPoolEmpty));
            }

            var itemToPick = itemPool.Pop();

            character.Bag.AddItem(itemToPick);

            return string.Format(SuccessMessages.PickUpItem, characterName, itemToPick.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];


            var character = charactersParty.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.CharacterNotInParty, characterName));
            }

            var item = character.Bag.GetItem(itemName);

            if (item == null)
            {
                throw new ArgumentException(string.Format
                  (ExceptionMessages.ItemNotFoundInBag, itemName));
            }
            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            var result = new StringBuilder();

            var sortedCharacters = charactersParty
                  .OrderByDescending(c => c.IsAlive)
                  .OrderByDescending(c => c.Health)
                  .ToList();

            foreach (var c in sortedCharacters)
            {
                result.AppendLine(string.Format(SuccessMessages.CharacterStats,
                     c.Name, c.Health, c.BaseHealth, c.Armor, c.BaseArmor, c.Status));
            }

            return result.ToString();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];

            var attacker = charactersParty.FirstOrDefault(c => c.Name == attackerName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (!(attacker is IAttacker))
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.AttackFail, attackerName));
            }

            string recieverName = args[1];

            var reciever = charactersParty.FirstOrDefault(c => c.Name == recieverName);

            if (reciever == null)
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.CharacterNotInParty, recieverName));
            }

            Warrior warrior = (Warrior)attacker;

            warrior.Attack(reciever);

            var result = new StringBuilder()
                .AppendLine(string
                .Format(SuccessMessages.AttackCharacter,
                warrior.Name, reciever.Name, warrior.AbilityPoints, reciever.Name, reciever.Health
                , reciever.BaseHealth, reciever.Armor, reciever.BaseArmor));

            if (!reciever.IsAlive)
            {
                result.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, reciever.Name));
            }

            return result.ToString().Trim();
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];

            var healer = charactersParty.FirstOrDefault(c => c.Name == healerName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (!(healer is IHealer))
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.HealerCannotHeal, healerName));
            }

            string recieverName = args[1];

            var reciever = charactersParty.FirstOrDefault(c => c.Name == recieverName);

            if (reciever == null)
            {
                throw new ArgumentException(string.Format
                    (ExceptionMessages.CharacterNotInParty, recieverName));
            }

            Priest priest = (Priest)healer;

            priest.Heal(reciever);

            return string
               .Format(SuccessMessages.HealCharacter,
               healer.Name, reciever.Name, healer.AbilityPoints, reciever.Name, reciever.Health);
        }
    }
}
