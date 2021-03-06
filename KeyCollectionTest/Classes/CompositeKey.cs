﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyCollectionTest.Classes
{
    public class CompositeKey<TKey1, TKey2> : ICompositeKey<TKey1, TKey2>
        where TKey1 : class
        where TKey2 : class
    {

        public TKey1 Id { get; set; }
        public TKey2 Name { get; set; }

        public CompositeKey(TKey1 k1, TKey2 k2)
        {
            Id = k1;
            Name = k2;
        }

        public override int GetHashCode()
        {
            unchecked        
            {
                int hash = 17;
                hash = hash * 23 + Id.GetHashCode();
                hash = hash * 23 + Name.GetHashCode();
                return hash;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            CompositeKey<TKey1, TKey2> compositeKey = obj as CompositeKey<TKey1, TKey2>;
            bool equals = this.Id.Equals(compositeKey.Id) && this.Name == compositeKey.Name;
            return equals;
        }

        public override string ToString()
        {
            return "id = " + Id.ToString()  + ", Name = " + Name.ToString();
        }

        public static bool operator ==(CompositeKey<TKey1, TKey2> item1, CompositeKey<TKey1, TKey2> item2)
        {
            if (System.Object.ReferenceEquals(item1, item2))
                return true;

            if (((object)item1 == null) || ((object)item2 == null))
                return false;

            bool equals = (item1.Id.Equals(item2.Id) && item1.Name == item2.Name);
            return equals;
        }

        public static bool operator !=(CompositeKey<TKey1, TKey2> item1, CompositeKey<TKey1, TKey2> item2)
        {
            bool notEquals = !(item1.Id.Equals(item2.Id) && item1.Name == item2.Name);
            return notEquals;
        }
    }
}
