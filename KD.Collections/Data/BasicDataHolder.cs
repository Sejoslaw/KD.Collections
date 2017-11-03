using System.Collections;
using System.Collections.Generic;

namespace KD.Collections.Data
{
    /// <summary>
    /// Basic implementation of <see cref="IDataHolder"/> concept.
    /// </summary>
    public class BasicDataHolder : IDataHolder
    {
        /// <summary>
        /// Get and Set values in internal collection of keys and values.
        /// </summary>
        public object this[string key]
        {
            get
            {
                return this.InternalData[key];
            }
            set
            {
                this.InternalData[key] = value;
            }
        }

        /// <summary>
        /// <see cref="Dictionary{TKey, TValue}"/> which stores internal data of an <see cref="IDataHolder"/>.
        /// </summary>
        private Dictionary<string, object> InternalData { get; set; }

        public BasicDataHolder()
        {
            this.InternalData = new Dictionary<string, object>();
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.InternalData.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}