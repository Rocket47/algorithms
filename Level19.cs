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
            bool result = Level1.SherlockValidString("xxyyz");
            bool expectedResult = true;
        }
    
        public static bool SherlockValidString(string s)
        {
            Dictionary<char, int> countOfEachSymbolList = createDictionaryCountOfEachSymbols(s);
            bool isValid = true;
            int saveActualCount = -1;
            int counter = 0;
            foreach (KeyValuePair<char, int> entry in countOfEachSymbolList)
            {
                if (saveActualCount == -1)
                {
                    saveActualCount = entry.Value;
                }

                if (saveActualCount - entry.Value > 1)
                {
                    counter++;
                }
            }
            if (counter > 1)
            {
                isValid = false;
            }
            return isValid;
        }

        public static LinkedList<char> createDictionaryCountOfEachSymbols(string s)
        {
            char[] arr = s.ToCharArray();
            int saveCount = 0;
            char symbolToCheck;
            LinkedList<char> symbols = new LinkedList<char>(arr);
            for (int i = 0; i < symbols.Count; i++)
            {
                for (int j = 1; j < symbols)
            }
            return symbols;
        }
    }
}

