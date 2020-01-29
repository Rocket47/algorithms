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
            BalancedParentheses(2);
            foreach (string n in resultList)
            {
                Console.Write(n);
                Console.Write(" ");
            }
            Console.ReadKey();
        }
        public static string BalancedParentheses(int N)
        {
            string result = "";
            if (N > 0)
            {                
                N = N - 1;
                return DoRecursion(0, 0, N, result);              
            }            
            return BalancedParentheses(N);
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
                if (countOpenBracket < maxCountOpenBracket)
                {
                    result += "(";
                    countOpenBracket++;
                    return DoRecursion(countOpenBracket, countCloseBracket, maxCountOpenBracket, result);
                }                
            }
            if (countOpenBracket == countCloseBracket)
            {
                resultList.Add(result);                                
            }
            return result;
        }
    }
}
