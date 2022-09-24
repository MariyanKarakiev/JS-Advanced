using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericsExercise
{
    public class Box<T> : IComparable<T> where T : IComparable
    {
        public T Element { get; }
        public List<T> List { get; }
        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> list)
        {
            List = list;
        }

        public void SwapElements(List<T> list, int index1, int index2)
        {
            T firstElement = list[index1];
            list[index1] = list[index2];
            list[index2] = firstElement;
        }

        public int CompareTo(T comparer) => Element.CompareTo(comparer);


        public int CountOf<T>(List<T> list, T readLine) where T : IComparable 
            => list.Count(e => e.CompareTo(readLine) > 0);


        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var element in List)
            {
                sb.Append($"{element.GetType()}: {element}");
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}
