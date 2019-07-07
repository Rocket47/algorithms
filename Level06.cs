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
            string s = "1) строка разбиваетсяИТестируется на набор строк через строка выравнивание по заданной ширине. строка";
            int[] testOutPutArray = WordSearch(12, s, "строка");
            Console.WriteLine("[{0}]", string.Join(", ", testOutPutArray));
            Console.ReadKey();
        }
        public static int[] WordSearch(int len, string s, string subs)
        {
            string[] splitArr = s.Split(' ');          
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


            string[] lines = resultString.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string n in lines)
            {
                Console.WriteLine(n);
            }
            return checkWord(lines, subs);
        }

        public static int[] checkWord(string[] arrWithWords, string word)
        {
            int counter = 0;
            int[] resultArray = new int[arrWithWords.Length];
            foreach (string searchWord in arrWithWords)
            {
                string[] separateWord = searchWord.Split(' ');
                foreach (string sepWord in separateWord)
                {
                    if (sepWord.Equals(word))
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
