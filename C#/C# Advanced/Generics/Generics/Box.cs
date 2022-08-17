using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> items;

        public Box()
        {
            items = new List<T>();
        }

        public int Count => items.Count;

        public void Add(T item)
        {
            items.Add(item);
        }

        public T Remove()
        {
            T result = items.LastOrDefault();
            items.Remove(result);
            return result;
        }
    }
}
