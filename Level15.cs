using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {

        public static void Main(string[] args)
        {
            LineAnalysis("*..*..*..*..*..*..*");
            Console.ReadKey();
        }

        public static bool LineAnalysis(string line)
        {
            int savePosition = 0;
            char[] arrCombination = new char[line.Length];
            char[] convertedStringToCharArr = line.ToCharArray();
            if (convertedStringToCharArr[0] == '*')
            {
                arrCombination[0] = '*';
            }
            for (int i = 1; i < convertedStringToCharArr.Length; i++)
            {

                if (convertedStringToCharArr[i] != '*')
                {
                    arrCombination[i] = convertedStringToCharArr[i];
                }
                else
                {
                    savePosition = i;
                    break;
                }
            }

            Console.WriteLine("Единый шаблон для анализа получен: ");
            foreach (char test in arrCombination)
            {
                Console.Write(test + "");
            }
           

            return true;
        }

    }
}


