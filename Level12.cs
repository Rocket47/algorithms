using System;
using System.Collections.Generic;

namespace Level1Space
{  
    public static class Level1
    {
        public static int[] UFO(int N, int[] data, bool octal)
        {
            int[] resultArray = new int[data.Length];
            char[] arrayCalculation = new char[] { };
            double result = 0;

            int counter = 0;
            for (int i = 0; i < data.Length; i++)
            {
                arrayCalculation = data[i].ToString().ToCharArray();
                int degree = 0;
                for (int j = arrayCalculation.Length - 1; j >= 0; j--)
                {
                    int test = arrayCalculation[j] - 48;
                    if (!octal)
                    {
                        result = result + (arrayCalculation[j] - 48) * Math.Pow(16, degree);
                        degree++;
                    }
                    else
                    {
                        result = result + (arrayCalculation[j] - 48) * Math.Pow(8, degree);
                        degree++;
                    }
                }
                resultArray[counter] = (int)result;
                counter++;
                result = 0;
            }
            return resultArray;
        }
    }
}

