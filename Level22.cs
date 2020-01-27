using System;
using System.Collections;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static List<string> resultList = new List<string>();
        public static void Main(string[] args)
        {
            Console.WriteLine(BalancedParentheses(3));
            Console.ReadKey();
        }
        public static string BalancedParentheses(int N)
        {
            string result = "";
            DoRecursion(0, 0, N, result);
            foreach (string n in resultList)
            {
                Console.Write(n);
                Console.Write(" ");
            }

            return result;
        }

        public static string DoRecursion(int countOpenBracket, int countCloseBracket, int maxCountOpenBracket, string result)
        {
            if (countCloseBracket < maxCountOpenBracket)
            {
                if (countOpenBracket > countCloseBracket)
                {
                    result += ")";
                    countCloseBracket++;
                    return DoRecursion(countOpenBracket, countCloseBracket, maxCountOpenBracket, result);
                }
                if (countOpenBracket < countCloseBracket)
                {
                    result += "(";
                    countOpenBracket++;
                    return DoRecursion(countOpenBracket++, countCloseBracket++, maxCountOpenBracket, result);
                }
                if (countOpenBracket == countCloseBracket)
                {
                    resultList.Add(result);
                    countOpenBracket++;
                    countOpenBracket++;
                }
                return DoRecursion(countOpenBracket, countCloseBracket, maxCountOpenBracket, result);
            }
            return result;
        }
    }
}
