using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {        
        public static string[] ShopOLAP(int N, string[] items)
        {
            string[] resultArr = new string[N];
            resultArr = СonvertDictionaryToArray(parseStringGetNumber(items));
            return resultArr;
        }
        public static string[] sortingArrByCount(string[] array)
        {
            return new string[] { };
        }

        public static SortedDictionary<string, int> parseStringGetNumber(string[] stringArrForParsing)
        {
            int savePreviousKey = 0;
            SortedDictionary<string, int> sortDictionary = new SortedDictionary<string, int>();
            for (int i = 0; i < stringArrForParsing.Length; i++)
            {
                char[] analyzeArr = new char[] { };
                string stringBeforeSpace = "";
                int сountGood = 0;
                bool activeSaveKey = false;
                analyzeArr = stringArrForParsing[i].ToCharArray();
                stringBeforeSpace = "";
                string createString = "";
                for (int j = 0; j < analyzeArr.Length; j++)
                {
                    if (analyzeArr[j] == ' ')
                    {
                        activeSaveKey = true;
                    }
                    if (activeSaveKey)
                    {
                        createString += Char.ToString(analyzeArr[j]);
                    }
                    else
                    {
                        stringBeforeSpace += analyzeArr[j];
                    }
                }
                сountGood = Convert.ToInt32(createString);
                if (sortDictionary.ContainsKey(stringBeforeSpace))
                {
                    sortDictionary[stringBeforeSpace] += сountGood;
                    continue;
                }
                else
                {
                    sortDictionary.Add(stringBeforeSpace, сountGood);
                }
    
            }

            return sortDictionary;
        }

        public static string[] СonvertDictionaryToArray(SortedDictionary<string, int> dictionary)
        {
            string[] resultArr = new string[dictionary.Count];
            int count = 0;
            int saveValue = 0;
            string saveString = "";
            foreach (KeyValuePair<string, int> kvp in dictionary)
            {                
                string addToArray = kvp.Key + " " + kvp.Value;
                resultArr[count] = addToArray;               
                if (kvp.Value > saveValue && saveValue != 0)
                {
                    count--;
                    resultArr[count] = addToArray;                   
                    count++;
                    resultArr[count] = saveString;
                }
                else
                {
                    saveString = kvp.Key + " " + kvp.Value;
                }
                count++;
                saveValue = kvp.Value;
            }
            
            return resultArr;
        }

        static void printDictionary(SortedDictionary<string, int> sortDictionary)
        {
            foreach (KeyValuePair<string, int> kvp in sortDictionary)
            {

                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }

        static void printArr(string[] arr)
        {
            foreach (string test in arr)
            {
                Console.WriteLine(test);
            }
        }
    }
}


