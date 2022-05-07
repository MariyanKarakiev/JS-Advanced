using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly IList<Item> internalItems;

        protected Bag(int capacity)
        {
            Capacity = capacity;
            internalItems = new List<Item>();
            Items = new ReadOnlyCollection<Item>(internalItems);
        }

        public int Capacity { get; set; } = 100;

        public int Load { get => Items.Sum(i => i.Weight); }

        public IReadOnlyCollection<Item> Items { get; }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            internalItems.Add(item);
        }

        public Item GetItem(string name)
        {
            var bagIsNotEmpty = internalItems.Any();

            if (!bagIsNotEmpty)
            {
                throw new InvalidOperationException("Bag is empty!");

            }

            var item = internalItems.FirstOrDefault(i => i.GetType().Name == name);

            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            return item;
        }
    }
}
