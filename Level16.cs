using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {

        public static void Main(string[] args)
        {
            ShopOLAP(2, new string[] { "платье1 5", "сумка32 2", "платье1 1" });
            Console.ReadKey();
        }
        public static string[] ShopOLAP(int N, string[] items)
        {
            string[] resultArr = new string[] { };
            char[] analyzeArr = new char[] { };
            Dictionary<string, int> listForAnalyze = new Dictionary<string, int>();
            string stringBeforeSpace = "";
            int stringAfterSpace = 0;
            bool activeSaveKey = false;           
            for (int i = 0; i < items.Length; i++)
            {
                analyzeArr = items[i].ToCharArray();
                stringBeforeSpace = "";
                stringAfterSpace = 0;
                    for (int j = 0; j < analyzeArr.Length; j++)
                    {                        
                        stringBeforeSpace += analyzeArr[j]; 
                        if (analyzeArr[j] == ' ')
                        {
                            activeSaveKey = true;
                        }
                        if (activeSaveKey)
                        {                       
                        stringAfterSpace += analyzeArr[i] - '0';
                    }                      
                    }
                listForAnalyze.Add(stringBeforeSpace, stringAfterSpace);
            }
            foreach (KeyValuePair<string, int> kvp in listForAnalyze)
            {               
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
            return resultArr;
        }
    }
}


