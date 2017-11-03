using KD.Collections.Data;
using System;

namespace Test_DataHolder_Example
{
    /// <summary>
    /// Class which demonstrates how to use the DataHolder conecpt.
    /// </summary>
    public class Account : BasicDataHolder
    {
        /// <summary>
        /// Internal class which contains fields of Account class.
        /// </summary>
        public static class Fields
        {
            public static readonly string Id = "Id";
            public static readonly string Name = "Name";
            public static readonly string Age = "Age";
        }

        // Account properties

        public Guid Id
        {
            get
            {
                return (Guid)this[Fields.Id];
            }
            set
            {
                this[Fields.Id] = value;
            }
        }

        public string Name
        {
            get
            {
                return (string)this[Fields.Name];
            }
            set
            {
                this[Fields.Name] = value;
            }
        }

        public int Age
        {
            get
            {
                return (int)this[Fields.Age];
            }
            set
            {
                this[Fields.Age] = value;
            }
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            // Test of DataHolder concept.

            var acc = new Account()
            {
                Id = Guid.NewGuid(),
                Age = 23,
                Name = "Chris"
            };

            // Get data using Account property
            Console.WriteLine($"Account[Id = { acc.Id }, Name = { acc.Name }, Age = { acc.Age }]");

            // Get data using IDataHolder concept
            IDataHolder dataHolder = acc as IDataHolder;
            Console.WriteLine($"Account[Id = { dataHolder[Account.Fields.Id] }, Name = { dataHolder[Account.Fields.Name] }, Age = { dataHolder[Account.Fields.Age] }]");

            Console.ReadKey();
        }
    }
}