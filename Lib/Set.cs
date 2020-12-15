using System;
using System.Collections;
using System.Collections.Generic;

namespace Lib
{
    public class Set : IEnumerable
    {
        List<int> Container = new List<int>();

        public int Count
        {
            get 
            { 
                return Container.Count; 
            } 
        }

        public Set()
        {

        }
        // Конструктор для копирования
        public Set(Set set)
        {
            Set t;
            foreach (int item in set)
            {
                t = this + item;
            }
        }
        

        public bool Contains(int value)
        {
            return Container.Contains(value);
        }

        public IEnumerator GetEnumerator()
        {
            return Container.GetEnumerator();
        }

        public static Set operator +(Set a, int value)
        {
            if (a.Contains(value)) return a;
            a.Container.Add(value);
            return a;
        }

        public static Set operator -(Set a, int value)
        {
            a.Container.Remove(value);
            return a;
        }

        public static Set operator-(Set a, Set b)
        {
            var tmp = new Set(a);

            foreach (int item in b)
            {
                tmp -= item;
            }
            return tmp;
        }
        #region Операторы сравнения
        public static bool operator>(Set a,Set b)
        {
            return a.Count > b.Count;
        }

        public static bool operator<(Set a,Set b)
        {
            return a.Count < b.Count;
        }

        public static bool operator==(Set a,Set b)
        {
            return a.Count == b.Count;
        }

        public static bool operator!=(Set a,Set b)
        {
            return !(a.Count == b.Count);
        }
        #endregion

        public override string ToString()
        {
            var res = "{";
            foreach (var value in this)
            {
                res += $"{value}, ";
            }
            res += "}";
            return res;
        }

    }
}
