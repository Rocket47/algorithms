using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {        
        public static bool SherlockValidString(string s)
        {
            bool result = true;
            int savePreviousCount = 0;
            int countErrorCondition = 0;
            Dictionary<char, int> infoSymbols = OccurrenceEachSymbol(s);
            foreach (KeyValuePair<char, int> kvp in infoSymbols)
            {
                if (savePreviousCount == 0)
                {
                    savePreviousCount = kvp.Value;                    
                }
                else if (kvp.Value == savePreviousCount)
                {
                    savePreviousCount = kvp.Value;
                }
                else if ((Math.Abs(kvp.Value - savePreviousCount) == 1) && (countErrorCondition == 0))
                {
                    countErrorCondition = 1;
                }
                else
                {
                    result = false;
                }
            }
            return result;
        }

        public static Dictionary<char, int> OccurrenceEachSymbol(string inputStr)
        {
            Dictionary<char, int> listSymbols = new Dictionary<char, int>();
            while (inputStr.Length > 0)
            {
                int count = 0;
                for (int i = 0; i < inputStr.Length; i++)
                {
                    if (inputStr[0] == inputStr[i])
                    {
                        count++;
                    }
                }
                listSymbols.Add(inputStr[0], count);
                inputStr = inputStr.Replace(inputStr[0].ToString(), "");
            }           
            return listSymbols;
        }
    }
}

