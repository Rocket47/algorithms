using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void Main(string[] args)
        {
            int[] F = new int[] { 1, 3, 2 };
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
            int count = 0;
            for (int i = 0; i < F.Length; i++)
            {
                if (count == 2)
                {
                    break;
                }
                if (F[i] < previous && count < 2)
                {
                    count++;
                    for (int j = i; j < F.Length; j++)
                    {
                        if ((F[i] > F[j - 1] && F[i] < F[j + 1]) && (F[j] > F[i - 1] && F[j] < F[i + 1]))
                        {
                            result = true;
                        }
                    }
                }
                previous = F[i];

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

