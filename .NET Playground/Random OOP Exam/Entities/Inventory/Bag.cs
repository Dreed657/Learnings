using System;
using System.Collections.Generic;
using System.Linq;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> _items;
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this._items = new List<Item>();
        }

        public int Capacity { get; set; }

        public int Load => this.Items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this._items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this._items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this._items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            var item = this._items.FirstOrDefault(x => nameof(x) == name);

            if (item == null)
            {
                throw new ArgumentException(ExceptionMessages.ItemNotFoundInBag);
            }

            this._items.Remove(item);
            return item;
        }
    }
}
