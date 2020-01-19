using System;
using System.Collections;
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
            int sum = SumElementList(B);			
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
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    k = i + j;
                    int max = 0;
                    for (int t = j; t <= k; t++)
                    {
                        if (arr[j] > max)
                        {
                            max = arr[j];
                        }
                    }
                    B.Add(max);
                }
            }
            return B;
        }       
        public static int SumElementList(IEnumerable items)
        {
            int result = 0;
            foreach (object o in items)
            {
                result += Convert.ToInt32(o);
            }
            return result;
        }
    }
}
