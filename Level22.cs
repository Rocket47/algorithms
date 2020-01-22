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
            string[] arr = new string[N];
            string openBracket = "(";
            string closeBracket = ")";
            string result = "";
            for (int i = 0; i < N; i++)
            {
                if (N % 2 == 0)
                {
                    arr[i] = openBracket;
                }                        
                else
                {
                    arr[i] = closeBracket; 
                }
            }
            return result;
        }
    }
}
