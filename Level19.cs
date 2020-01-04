using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1Space
{
    public static class Level1
    {
        static void Main(string[] args)
        {
            Level1.SherlockValidString("xxyyz");
            Console.ReadKey();
        }

        public static bool SherlockValidString(string s)
        {
            Dictionary<char, string> countEachSymbol = new Dictionary<char, string>();
            countEachSymbol = crtDictionaryCountOfEachSymbol(s);
            return false;
        }

        public static Dictionary<char, string> crtDictionaryCountOfEachSymbol(string s)
        {
            char[] arrCharSymbolsFromString = s.ToCharArray();
            Dictionary<char, string> dictionarySaveCountOfElements = new Dictionary<char, string>();
            int counter;
            for (int i = 0; i < arrCharSymbolsFromString.Length - 1; i++)
            {
                counter = 1;
                if (!dictionarySaveCountOfElements.ContainsKey(arrCharSymbolsFromString[i]))
                {
                    for (int j = i + 1; j < arrCharSymbolsFromString.Length; j++)
                    {
                        if (arrCharSymbolsFromString[i] == arrCharSymbolsFromString[j])
                        {
                            counter++;
                        }
                    }
                    dictionarySaveCountOfElements.Add(arrCharSymbolsFromString[i], counter.ToString());                  
                }               
                else
                {
                    continue;
                }
                if ((!dictionarySaveCountOfElements.ContainsKey(arrCharSymbolsFromString[i+1])) && ((i + 1) == arrCharSymbolsFromString.Length - 1))
                {
                    counter = 1;
                    dictionarySaveCountOfElements.Add(arrCharSymbolsFromString[i+1], counter.ToString());
                }
            }

            foreach (KeyValuePair<char, string> kvp in dictionarySaveCountOfElements)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            return dictionarySaveCountOfElements;
        }
    }
}

