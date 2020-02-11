using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void Main(string[] args)
        {
            Keymaker(5);
            Console.ReadKey();
        }
        public static string Keymaker(int k)
        {
            string result = "";
            Dictionary<int, bool> ListDoors = new Dictionary<int, bool>();
            for (int i = 1; i <= k; i++)
            {
                ListDoors.Add(i, false);
            }
            Console.WriteLine("Intiialize program...");            
            ShowDictionary(ListDoors);
            return result;
        }

        public static void ShowDictionary(Dictionary<int, bool> Dictionary)
        {
            foreach (KeyValuePair<int, bool> kvp in Dictionary)
            {               
                Console.WriteLine("Door = {0}, Status = {1}", kvp.Key, kvp.Value);
            }
        } 
    }
}
    
