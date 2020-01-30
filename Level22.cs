using System;
using System.Collections;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        static char[] ResultArr;
        static string result = "";       
        public static string BalancedParentheses(int N)
        {
            Pattern(N);                        
            return result;    
        }

        public static void DoRecursion(int countOpenBracket, int countCloseBracket, int maxCountOpenBracket, int pos,  char[] ResultArr)
        {
            if (countCloseBracket == maxCountOpenBracket)
            {
                foreach (char n in ResultArr)
                {
                    result += n;
                }
                result += " ";
                return;
            }
            else
            {
                if (countOpenBracket > countCloseBracket)
                {
                    ResultArr[pos] = ')';
                    DoRecursion(countOpenBracket, countCloseBracket + 1, maxCountOpenBracket, pos + 1, ResultArr);
                }
                if (countOpenBracket < maxCountOpenBracket)
                {
                    ResultArr[pos] = '(';
                    DoRecursion(countOpenBracket + 1, countCloseBracket, maxCountOpenBracket, pos + 1, ResultArr);
                }
            }
        }

        public static void Pattern(int N)
        {
            ResultArr = new char[N * 2];
            if (N > 0)
            {
                DoRecursion(0, 0, N, 0, ResultArr);
                return;
            }
        }
    }
}

