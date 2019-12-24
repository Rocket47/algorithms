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
        }

        public static bool SherlockValidString(string s)
        {
            bool isValid = false;
            Dictionary<int, char> countOfEachSymbolList = createDictionaryCountOfEachSymbols(s);

            return isValid;
        }

        public static Dictionary<int, char> createDictionaryCountOfEachSymbols(string s)
        {            
            char[] arr = s.ToCharArray();
            Dictionary<int, char> listHasCountOfEachSymbols = new Dictionary<int, char>();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int counter = 0;
                if (listHasCountOfEachSymbols.ContainsValue(arr[i]))
                {
                    continue;
                }
                for (int j = 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        counter++;
                    }
                }
                if (!listHasCountOfEachSymbols.ContainsValue(arr[i]))
                {
                    listHasCountOfEachSymbols.Add(counter, arr[i]);
                }
            }
            return listHasCountOfEachSymbols;
        }
    }
}

