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
            string result = "()";            
            if (N >= 2)
            {
                N = N - 1;               
                return result += BalancedParentheses(N);
            }
            return result;
        }               
    }
}
