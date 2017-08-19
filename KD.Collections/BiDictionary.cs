﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KD.Collections
{
    /// <summary>
    /// Bidirectional Dictionary.
    /// </summary>
    /// <typeparam name="TKey"> Key type. </typeparam>
    /// <typeparam name="TValue"> Value type. </typeparam>
    public class BiDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Private internal Dictionary which stores data.
        /// </summary>
        IDictionary<TKey, TValue> InternalDictionary { get; set; }

        /// <summary>
        /// Keys Collection.
        /// </summary>
        public ICollection<TKey> Keys
        {
            get
            {
                return InternalDictionary.Keys;
            }
        }

        /// <summary>
        /// Values Collection.
        /// </summary>
        public ICollection<TValue> Values
        {
            get
            {
                return InternalDictionary.Values;
            }
        }

        /// <summary>
        /// Number of elements in current Dictionary.
        /// </summary>
        public int Count
        {
            get
            {
                return InternalDictionary.Count;
            }
        }

        /// <summary>
        /// Returns if this Dictionary is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return InternalDictionary.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets or sets the element with the specified key.
        /// </summary>
        /// <param name="key"> The key of the element to get or set. </param>
        /// <returns> The element with the specified key. </returns>
        public TValue this[TKey key]
        {
            get
            {
                return InternalDictionary[key];
            }
            set
            {
                TryToSet(key, value);
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BiDictionary()
        {
            this.InternalDictionary = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// Adds an item to the System.Collections.Generic.ICollection.
        /// </summary>
        /// <param name="item"> The object to add to the System.Collections.Generic.ICollection. </param>
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Adds an element with the provided key and value to the System.Collections.Generic.IDictionary.
        /// </summary>
        /// <param name="key"> The object to use as the key of the element to add. </param>
        /// <param name="value"> The object to use as the value of the element to add. </param>
        public void Add(TKey key, TValue value)
        {
            if (InternalDictionary.Keys.Contains(key))
            {
                throw new Exception("Each Key in BiDictionary must be unique. Key: " + key + " - already exists in current BiDictionary.");
            }
            else if (InternalDictionary.Values.Contains(value))
            {
                throw new Exception("Each Value in BiDictionary must be unique. Value: " + value + " - already exists in current BiDictionary.");
            }
            else
            {
                InternalDictionary.Add(key, value);
            }
        }

        /// <summary>
        /// Determines whether the System.Collections.Generic.IDictionary contains an element with the specified key.
        /// </summary>
        /// <param name="key"> The key to locate in the System.Collections.Generic.IDictionary. </param>
        /// <returns> true if the System.Collections.Generic.IDictionary contains an element with the key; otherwise, false. </returns>
        public bool ContainsKey(TKey key)
        {
            return InternalDictionary.ContainsKey(key);
        }

        /// <summary>
        /// Removes the element with the specified key from the System.Collections.Generic.IDictionary.
        /// </summary>
        /// <param name="key"> The key of the element to remove. </param>
        /// <returns> true if the element is successfully removed; otherwise, false. This method also returns false if key was not found in the original System.Collections.Generic.IDictionary. </returns>
        public bool Remove(TKey key)
        {
            return InternalDictionary.Remove(key);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key"> The key whose value to get. </param>
        /// <param name="value"> When this method returns, the value associated with the specified key, if the key is found; otherwise, the default value for the type of the value parameter. This parameter is passed uninitialized. </param>
        /// <returns> true if the object that implements System.Collections.Generic.IDictionary contains an element with the specified key; otherwise, false. </returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return InternalDictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// Removes all items from this System.Collections.Generic.ICollection.
        /// </summary>
        public void Clear()
        {
            InternalDictionary.Clear();
        }

        /// <summary>
        /// Determines whether the System.Collections.Generic.ICollection contains a specific value.
        /// </summary>
        /// <param name="item"> The object to locate in the System.Collections.Generic.ICollection. </param>
        /// <returns> true if item is found in the System.Collections.Generic.ICollection; otherwise, false. </returns>
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return InternalDictionary.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the System.Collections.Generic.ICollection to an System.Array, starting at a particular System.Array index.
        /// </summary>
        /// <param name="array"> The one-dimensional System.Array that is the destination of the elements copied from System.Collections.Generic.ICollection. </param>
        /// <param name="arrayIndex"> The zero-based index in array at which copying begins. </param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            InternalDictionary.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the System.Collections.Generic.ICollection.
        /// </summary>
        /// <param name="item"> The object to remove from the System.Collections.Generic.ICollection. </param>
        /// <returns> true if item was successfully removed from the System.Collections.Generic.ICollection; otherwise, false. </returns>
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return InternalDictionary.Remove(item);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate through the collection. </returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return InternalDictionary.GetEnumerator();
        }

        /// <summary>
        /// Switch Keys and Values and returns it as new BiDictionary.
        /// </summary>
        /// <returns> Returns new Dictionary with switched Keys and Values. </returns>
        public BiDictionary<TValue, TKey> Switch()
        {
            BiDictionary<TValue, TKey> newDic = new BiDictionary<TValue, TKey>();
            InternalDictionary.ToList().ForEach(element => newDic.Add(element.Value, element.Key));
            return newDic;
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns> An System.Collections.IEnumerator object that can be used to iterate through the collection. </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return InternalDictionary.GetEnumerator();
        }

        /// <summary>
        /// Tries to set new Value for specified Key.
        /// </summary>
        /// <param name="key"> Key for which new value is set. </param>
        /// <param name="value"> New value which will be set for specified Key. </param>
        void TryToSet(TKey key, TValue value)
        {
            if (InternalDictionary.Values.Contains(value))
            {
                throw new Exception("Each Value in BiDictionary must be unique. Value: " + value + " - already exists in current BiDictionary.");
            }
            else
            {
                InternalDictionary[key] = value;
            }
        }
    }
}