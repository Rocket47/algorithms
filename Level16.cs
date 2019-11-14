using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {

        public static void Main(string[] args)
        {


            printArr(ShopOLAP(5, new string[] { "dress1 5", "handbug32 3", "dress2 1", "handbug23 2", "handbug128 4" }));
            Console.ReadKey();
        }
        public static string[] ShopOLAP(int N, string[] items)
        {
            string[] resultArr = new string[N];
            resultArr = СonvertDictionaryToArray(parseStringGetNumber(items));
            return resultArr;
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
            int number1;
            int number2;
            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                string addToArray = kvp.Key + " " + kvp.Value;
                resultArr[count] = addToArray;
                count++;
            }
            string tmp;
            for (int i = 0; i < resultArr.Length - 1; i++)
            {
                
                number1 = Convert.ToInt32(resultArr[i].Substring(resultArr[i].IndexOf(" ") + 1));
                for (int j = i + 1; j < resultArr.Length; j++)
                {
                    
                    number2 = Convert.ToInt32(resultArr[j].Substring(resultArr[j].IndexOf(" ") + 1));
                    if (number1 < number2)
                    {
                        tmp = resultArr[i];
                        resultArr[i] = resultArr[j];                        
                        resultArr[j] = tmp;
                        Console.WriteLine("**************************");                       
                    }
                    Console.WriteLine(resultArr[0]);
                    Console.WriteLine(resultArr[1]);
                    Console.WriteLine(resultArr[2]);
                    Console.WriteLine(resultArr[3]);
                    Console.WriteLine(resultArr[4]);
                    Console.WriteLine("**************************");
                }
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
            foreach (string i in arr)
            {
                Console.WriteLine(i);
            }
        }
    }
}


