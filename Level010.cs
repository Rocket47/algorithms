using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {       
        public static string BigMinus(string s1, string s2)
        {
            double result = 0.0;
            double a1 = Convert.ToDouble(s1) / 10000000000000000;
            double a2 = Convert.ToDouble(s2) / 10000000000000000;
            result = Math.Abs(a1 - a2) * 10000000000000000;
            return result.ToString();  
        }
    }
}

