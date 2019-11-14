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

        public static SortedDictionary<string, int> parseStringGetNumber(string[] stringArrForParsing)
        {            
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
            int numberFowSwap;
            foreach (KeyValuePair<string, int> kvp in dictionary)
            {
                string addToArray = kvp.Key + " " + kvp.Value;
                resultArr[count] = addToArray;
                count++;
            }
            string tmp;
            if (resultArr.Length > 2)
            {
                for (int i = 1; i < resultArr.Length; i++)
                {

                    number1 = Convert.ToInt32(resultArr[i].Substring(resultArr[i].IndexOf(" ") + 1));
                    for (int j = 01; j < resultArr.Length - 1; j++)
                    {

                        number2 = Convert.ToInt32(resultArr[j].Substring(resultArr[j].IndexOf(" ") + 1));
                        numberFowSwap = Convert.ToInt32(resultArr[j + 1].Substring(resultArr[j + 1].IndexOf(" ") + 1));

                        if (number2 < numberFowSwap)
                        {
                            tmp = resultArr[j];
                            resultArr[j] = resultArr[j + 1];
                            resultArr[j + 1] = tmp;
                        }
                    }
                }
            }
            else if (resultArr.Length == 2)
            {
                number1 = Convert.ToInt32(resultArr[0].Substring(resultArr[0].IndexOf(" ") + 1));
                number2 = Convert.ToInt32(resultArr[1].Substring(resultArr[1].IndexOf(" ") + 1));

                if (number1 < number2)
                {
                    string save = resultArr[0];
                    resultArr[0] = resultArr[1];
                    resultArr[1] = save;
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


