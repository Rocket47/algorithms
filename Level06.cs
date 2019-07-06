using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level06
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "1) строка разбиваетсяИТестируется на набор строк через выравнивание по заданной ширине.";
            int[] testOutPutArray =  WordSearch(12, s, "через");
            Console.WriteLine("[{0}]", string.Join(", ", testOutPutArray));
            Console.ReadKey();
        }
        public static int[] WordSearch(int len, string s, string subs)
        {
            string[] splitArr = s.Split(' ');
            string[] resultArray;
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

            resultArray = new[] { resultString };
            foreach(string n in resultArray)
            {
                Console.WriteLine(n);
            }
            return checkWord(resultArray, subs);
        }

        public static int[] checkWord(string[] arrWithWords, string word)
        {
            int counter = 0;
            int[] resultArray = new int[arrWithWords.Length]; 
            foreach (string searchWord in arrWithWords)
            {
                if (searchWord.Equals(word))
                {
                    resultArray[counter] = 1;
                }
                else
                {
                    resultArray[counter] = 0;
                }
            }
            return resultArray;
        }
    }
}
