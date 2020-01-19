using System;
using System.Collections;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {      
        static void Main(string[] args)
        {
            int[] A = new int[] { 2, 3, 4, 2, 1, 3, 4 };
            TransformTransform(A, 7);
            Console.ReadKey();
        }

        public static bool TransformTransform(int[] A, int N)
        {
            bool result = false;           
            List<int> B = new List<int>();
            int k = 0;
            for (int i = 0; i < A.Length; i++)
            {               
                for (int j = 0; j < A.Length - i - 1; j++)
                {
                    k = i + j;
                    int max = 0;
                    for (int t = j; t <= k; t++)
                    {
                        if (A[j] > max)
                        {
                            max = A[j];
                        }
                    }
                    B.Add(max);                      
                }                       
            }
            int[] newArray = B.ToArray();
            WriteToConsole(B);
            TransformTransform(newArray, newArray.Length);           
            return result;
        }

        static public void WriteToConsole(IEnumerable items)
        {
            Console.WriteLine("***********new circle************");
            foreach (object o in items)
            {
                Console.WriteLine(o);
            }
        }
    }
}
