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
            showArr();
            Console.ReadKey();
        }

        public static int[] WordSearch(int len, string s, string subs)
        {
            string[] stringAfterSplit = s.Split(' ');
            return null;
        }

        public static void showArr()
        {
            string s = "1) строка разбиваетсяИТестируется на набор строк через выравнивание по заданной ширине.";
            string[] arr = s.Split(' ');
            int lengthStringCounter = 0;
            string resultString = "";
            for (int i = 0; i < arr.Length; i++)
            {

                char[] charArr = arr[i].ToCharArray();
                for (int j = 0; j < charArr.Length; j++)
                {
                    resultString = resultString + charArr[j].ToString();
                    lengthStringCounter++;
                    if (lengthStringCounter >= 12)
                    {
                        resultString = resultString + Environment.NewLine;
                        lengthStringCounter = 0;
                    }
                }
              
                    if ((i < arr.Length - 1) && ((12 - lengthStringCounter) < arr[(i + 1)].Length))
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
            Console.WriteLine(resultString);
        }
    }
}
