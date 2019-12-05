using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {

        public static void Main(string[] args)
        {
            BiggerGreater("вкиб");
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

            Console.WriteLine("You ask: " + searchMinimalWord(magicWords, input));
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


        public static bool compareToWords(string string1, string string2)
        {
            bool result = false;
            try
            {
                char[] s1 = string1.ToCharArray();
                char[] s2 = string2.ToCharArray();
                for (int i = 0; i < string1.Length; i++)
                {
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

        public static string searchMinimalWord(string[] arrForSearching, string srcWord)
        {
            string finalWord = arrForSearching[0];
            try
            {
                for (int i = 1; i < arrForSearching.Length; i++)
                {
                    string test = arrForSearching[i];
                    if (finalWord.CompareTo(srcWord) > 0)
                    {
                        if (compareToWords(finalWord, arrForSearching[i]) == true)
                        {
                            finalWord = arrForSearching[i];
                        }
                    }
                    else
                    {
                        finalWord = arrForSearching[i];
                    }
                }
            }
            catch (NullReferenceException ex)
            {

            }
            return finalWord;
        }
    }
}
