using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {

        public static void Main(string[] args)
        {
            BiggerGreater("вибк");
            Console.ReadKey();
        }

        public static string BiggerGreater(string input)
        {
            string result = "";
            int counter = 0;
            int lengthArr = factorial_Recursion(input.Length) / (factorial_Recursion(input.Length - 2));
            string[] magicWords = new string[lengthArr];
            char[] arrPerSymbols = input.ToCharArray();
            for (int i = 0; i < arrPerSymbols.Length; i++)
            {
                for (int j = i + 1; j < arrPerSymbols.Length; j++)
                {
                    if (arrPerSymbols[i] != arrPerSymbols[j])
                    {
                        char tmp = arrPerSymbols[i];
                        arrPerSymbols[i] = arrPerSymbols[j];
                        arrPerSymbols[j] = tmp;
                        string word = new string(arrPerSymbols);
                        magicWords[counter] = word;
                        Array.Clear(arrPerSymbols, 0, arrPerSymbols.Length);
                        arrPerSymbols = input.ToCharArray();
                        counter++;
                    }
                }                
            }
            foreach (string test in magicWords)
            {
                Console.WriteLine(test);
            }
            return result;
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
    }
}
