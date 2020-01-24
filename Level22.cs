using System;
using System.Collections;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static int saveValue = 0;
        public static void Main(string[] args)
        {
            Console.WriteLine(BalancedParentheses(3));
            Console.ReadKey();
        }
        public static string BalancedParentheses(int N)
        {
            string result = "";
            string bothBracket = "()";           
            string closeBracket = ")";
            if (N > 0)
            { 
                if (N > saveValue)
                if (N > 1)
                {
                    result += "(";
                }
                for (int i = 1; i < N; i++)
                {                  
                    result +=  bothBracket;
                }
                if (N > 1)
                {
                   result += closeBracket;
                }
                N = N - 1;
                result += BalancedParentheses(N);
                return result + bothBracket;              
            }
            
            return result;
        }
    }
}
