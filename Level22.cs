using System;
using System.Collections;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(BalancedParentheses(3));
            Console.ReadKey();
        }
        public static string BalancedParentheses(int N)
        {
            int SaveValue = N;
            
            return result;
        }

        public static string DoRecursion(int countOpenBracket, int countCloseBracket, int maxCountOpenBracket)
        {
            string result = "";
            if (countCloseBracket < maxCountOpenBracket)
            {
                if (countOpenBracket > countCloseBracket)
                {
                    result += ")";
                    return DoRecursion(countOpenBracket - 1, countCloseBracket, maxCountOpenBracket);
                }
                if (countOpenBracket < countCloseBracket)
                {
                    result += "(";
                    return DoRecursion(countOpenBracket, countCloseBracket - 1, maxCountOpenBracket);
                }
                if (countOpenBracket == countCloseBracket)
                {

                }
                return DoRecursion(countOpenBracket, countCloseBracket, maxCountOpenBracket);
            }
           
        }


       
    }
}
