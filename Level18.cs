using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        static List<string> resultList = new List<string>();
        public static string BiggerGreater(string input)
        {
            string result = "";
            permute(input, 0, input.Length - 1);
            resultList.RemoveAt(0);
            foreach (string test in resultList)
            {
                Console.WriteLine(test);
            }

            Console.WriteLine("You ask: " + searchMinimalWord(resultList, input));
            return result;
        }

        public static void permute(string str, int startIndex, int endIndex)
        {
            if (startIndex == endIndex)
            {
                resultList.Add(str);                              
            }
            else
            {
                for (int i = startIndex; i <= endIndex; i++)
                {
                    str = swap(str, startIndex, i);
                    permute(str, startIndex + 1, endIndex);
                    str = swap(str, startIndex, i);
                }
            }
        }


        public static string swap(string inputString, int i, int j)
        {
            char temp;
            char[] charArray = inputString.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string str = new string(charArray);
            return str;
        }

        public static int factorial_Recursion(int number)
        {
            if (number == 0)
            {
                return 1;
            }
            if (number == 1)
                return 1;
            else
                return number * factorial_Recursion(number - 1);
        }


        public static bool compareToWords(string string1, string string2)
        {
            bool result = false;
            try
            {
                char[] s1 = string1.ToCharArray();
                char[] s2 = string2.ToCharArray();
                for (int i = 0; i < string1.Length; i++)
                {
                    char test1 = s1[i];
                    char test2 = s2[i];
                    if (s1[i].CompareTo(s2[i]) > 0)
                    {
                        result = true;
                        break;
                    }

                    else if (s1[i].CompareTo(s2[i]) < 0)
                    {
                        break;
                    }
                }
            }
            catch (NullReferenceException e)
            {

            }
            return result;
        }

        public static string searchMinimalWord(List<string> arrForSearching, string srcWord)
        {
            string finalWord = "";
            List<string> listWithMoreThenSrcWord = new List<string>();
            for (int i = 0; i < arrForSearching.Count; i++)
            {
                string test = arrForSearching[i];
                if ((string.Compare(srcWord, arrForSearching[i]) < 0))
                {
                    listWithMoreThenSrcWord.Add(arrForSearching[i]);
                }
            }
            if (listWithMoreThenSrcWord.Count != 0)
            {
                finalWord = listWithMoreThenSrcWord[0];
                for (int j = 1; j < listWithMoreThenSrcWord.Count; j++)
                {
                    if (compareToWords(finalWord, listWithMoreThenSrcWord[j]) == true)
                    {
                        finalWord = listWithMoreThenSrcWord[j];
                    }
                }
            }

            return finalWord;
        }
    }
}
