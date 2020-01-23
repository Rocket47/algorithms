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
            string openBracket = "(";
            string closeBracket = ")";
            string result = "";            
            if (N > 0)
            {
                N = N - 1;
                result =  RepeatString(N);
                return result;
            }
            return result;
        }

        public static string RepeatString(int N)
        {
            string result = "()";
            for (int i = 0; i < N; i++)
            {
                result += "(" +  result + ")";
            }
            return result;
        }
    }
}
