using System;
using System.Linq;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {       
        public static int[] WordSearch(int len, string s, string subs)
        {
            string[] splitArr = s.Split(' ');
            string[] arrayFromString;
            arrayFromString = createStringWithRange(splitArr, len).Split(new char[] { '\r', '\n' });
            arrayFromString = arrayFromString.Where(x => !string.IsNullOrEmpty(x.Trim())).ToArray();           
            return checkWordInLine(arrayFromString, subs);
        }

        public static string createStringWithRange(string[] splitArr, int len)
        {
            int lengthStringCounter = 0;
            string resultString = "";
            for (int i = 0; i < splitArr.Length; i++)
            {
                char[] charArr = splitArr[i].ToCharArray();
                for (int j = 0; j < charArr.Length; j++)
                {
                    resultString = resultString + charArr[j].ToString();
                    lengthStringCounter++;
                    if (lengthStringCounter >= len)
                    {
                        resultString = resultString + Environment.NewLine;
                        lengthStringCounter = 0;
                    }
                }
                if ((i < splitArr.Length - 1) && ((len - lengthStringCounter) < splitArr[(i + 1)].Length))
                {
                    resultString = resultString + Environment.NewLine;
                    lengthStringCounter = 0;
                }
                else
                {
                    resultString = resultString + " ";
                    lengthStringCounter++;
                }
            }
            return resultString;
        }
        public static int[] checkWordInLine(string[] arrWithWords, string wordToBeChecked)
        {
            int counter = 0;
            int[] resultArray = new int[arrWithWords.Length];
            foreach (string searchWord in arrWithWords)
            {
                string[] separateWord = searchWord.Split(' ');
                foreach (string sepWord in separateWord)
                {
                    if (sepWord.Equals(wordToBeChecked))
                    {
                        resultArray[counter] = 1;
                    }
                }
                if (counter < arrWithWords.Length - 1)
                {
                    counter++;
                }
            }
            return resultArray;
        }
    }
}
