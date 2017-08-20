using System.Collections.Generic;

namespace KD.Collections
{
    /// <summary>
    /// Represents a generic collection of keys/values which can be switched to values/keys.
    /// </summary>
    /// <typeparam name="TKey"> The type of keys in the dictionary. </typeparam>
    /// <typeparam name="TValue"> The type of values in the dictionary. </typeparam>
    public interface IBiDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        /// <summary>
        /// Switch Keys and Values and returns it as new BiDictionary.
        /// </summary>
        /// <returns> Returns new Dictionary with switched Keys and Values. </returns>
        BiDictionary<TValue, TKey> Switch();
    }
}