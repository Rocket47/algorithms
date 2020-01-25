using System;
using System.Collections;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(BalancedParentheses(2));
            Console.ReadKey();
        }
        public static string BalancedParentheses(int N)
        {
            int SaveValue = N;
            string result = DoRecursion(N, SaveValue);
            return result;
        }


        public static string DoRecursion(int N, int SaveValue)
        {
            string result = "";
            string bothBracket = "()";
            string closeBracket = ")";
            if (N > 0)
            {
                if (N > 1)
                {
                    result += "(";
                }
                for (int i = 1; i < N; i++)
                {
                    result += bothBracket;
                }                
                if (N > 1)
                {
                    result += closeBracket;
                    for (int i = 0; i < SaveValue - N; i++)
                    {
                        result += bothBracket;
                    }
                }
                N = N - 1;
                result += DoRecursion(N, SaveValue);
                return result + bothBracket;
            }
            return result;
        }
    }
}
