using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static string[] ShopOLAP(int N, string[] items)
        {
            string[] resultArr = new string[] { };
            char[] analyzeArr = new char[] { };
            int value1 = 0;
            int value2 = 0;
            bool resultComparing = true;
            bool activeSaveKey = false;
            bool existValue1 = false;
            for (int i = 0; i < items.Length; i++)
            {
                analyzeArr = items[i].ToCharArray();
                if (!existValue1)
                {
                    for (int j = 0; j < analyzeArr.Length; j++)
                    {
                        if (analyzeArr[j] == ' ')
                        {
                            activeSaveKey = true;
                        }
                        if (activeSaveKey)
                        {
                            value1 += Convert.ToInt32(analyzeArr[i]);
                        }
                        existValue1 = true;
                    }
                }
                else
                {
                    for (int j = 0; j < analyzeArr.Length; j++)
                    {
                        if (analyzeArr[j] == ' ')
                        {
                            activeSaveKey = true;
                        }
                        if (activeSaveKey)
                        {
                            value2 += Convert.ToInt32(analyzeArr[i]);
                        }
                        existValue1 = false;
                    }
                    if (value1 > value2)
                }
            }
            return resultArr;
        }
    }
}


