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
            return resultArr;
        }

        public static string[] sortingArrByCount(string[] array)
        {
            return new string[] { };
        }

        public static int parseStringGetNumber(string stringForParsing)
        {
            char[] analyzeArr = new char[] { };
            string stringBeforeSpace = "";
            int сountGood = 0;
            bool activeSaveKey = false;
            analyzeArr = stringForParsing.ToCharArray();
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
            return сountGood;
        }
    }
}


