using KD.Collections;
using System;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Test_BiDictionary();
        }

        static void Test_BiDictionary()
        {
            var biDictionary = new BiDictionary<string, int>();
            biDictionary.Add("1", 1);
            biDictionary["2"] = 2;
            Console.WriteLine(biDictionary["1"]);
            var biDictionarySwtiched = biDictionary.Switch();
            Console.WriteLine(biDictionarySwtiched[2]);

            try
            {
                biDictionary["2"] = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}