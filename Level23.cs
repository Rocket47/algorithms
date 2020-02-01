using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {      
        public static bool Footbal(int[] F, int N)
        {
            bool result = false;
            return result;
        }

        public static bool Check1stMethod(int[] F)
        {
            bool result = true;
            int previous = 1;
            int saveErrorIndex = 0;
            int saveNextAfterSmallerValue = 0;
            int saveLast = 0;
            int count = 0;
            for (int i = 0; i < F.Length; i++)
            {
                if (F[i] < previous && count < 2)
                {
                    count = 1;
                    saveNextAfterSmallerValue = i + 1;
                    saveErrorIndex = i;
                }
                else if (count == 1 && F[i] > previous)
                {
                    saveLast = F[i + 1];
                    if (F[i] > saveNextAfterSmallerValue)


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

