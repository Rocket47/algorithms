using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {      
        public static void Main(string[] args)
        {
            int[] F = new int[] { 1,3,2 };
            Console.WriteLine(Footbal(F, 3));
            Console.ReadKey();
        }
        public static bool Footbal(int[] F, int N)
        {
            bool result = false;
            result = Check1stMethod(F);
            return result;
        }

        public static bool Check1stMethod(int[] F)
        {
            bool result = false;
            int previous = 1;
            int saveErrorIndex = 0;
            int saveNextAfterSmallerValue = 0;
            int saveLast = 0;
            int count = 0;
            for (int i = 0; i < F.Length; i++)
            {
                if (count == 2)
                {
                    break;
                }
                if (F[i] < previous && count < 2)
                {
                    count = 1;
                    saveNextAfterSmallerValue = i + 1;
                    saveErrorIndex = i;                   
                }
                else if (count == 1 && F[i] > previous)
                {
                    saveLast = F[i + 1];
                    if (F[saveErrorIndex] >= saveNextAfterSmallerValue && F[i] <= saveLast)
                    {
                        result = true;
                    }
                    count = 0;
                }
                previous = i;
            }
            return result;
        }

        public static bool Check2ndMethod(int[] F)
        {
            bool result = false;
            return result;
        }
    }
}

