using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {       
        public static bool TransformTransform(int[] A, int N)
        {
            bool result = false;
            List<int> B = new List<int>();
            B = Converter(Converter(A).ToArray());
            int sum = SumElementList(B.ToArray());
            if (sum % 2 == 0)
            {
                result = true;
            }
            return result;
        }
        public static List<int> Converter(int[] arr)
        {
            List<int> B = new List<int>();
            int k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i; j++)
                {
                    k = i + j;
                    int max = 0;
                    for (int t = j; t <= k; t++)
                    {
                        if (arr[t] > max)
                        {
                            max = arr[t];
                        }
                    }
                    B.Add(max);
                }
            }
            return B;
        }      
        public static int SumElementList(int[] items)
        {
            int result = 0;
            foreach (int o in items)
            {
                result += o;
            }
            return result;
        }
    }
}
