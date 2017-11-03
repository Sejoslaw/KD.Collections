using System.Collections.Generic;

namespace KD.Collections.Data
{
    /// <summary>
    /// Object which holds some data.
    /// This interface provides only an abstract definition of an object in which You can access any variable on any kind of abstraction layer.
    /// </summary>
    public interface IDataHolder : IEnumerable<KeyValuePair<string, object>>
    {
        /// <summary>
        /// Returns value by given key; null if key is wrong or value is empty.
        /// </summary>
        object this[string key] { get; }
    }
}