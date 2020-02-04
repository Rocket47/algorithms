using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void Main(string[] args)
        {
            int[] F = new int[] { 9, 5, 3, 7, 1 };
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
            int previous = 0;
            int count = 0;
            for (int i = 0; i < F.Length; i++)
            {
                if (count == 2)
                {
                    break;
                }
                if (F[i] < F[previous] && count < 2)
                {
                    count++;
                    int j = i;
                    if (i + 1 == F.Length)
                    {
                        if (F[i] > F[i - 2])
                        {
                            result = true;
                            break;
                        }
                    }
                    while (j < F.Length)
                    {
                        int tmp = F[j];
                        F[j] = F[previous];
                        F[previous] = tmp;         
                        if (previous == 0)
                        {
                            previous = 1;
                        }
                        if ((F[j] > F[j - 1] && F[j] < F[j + 1]) && ((F[previous] > F[previous - 1]) && (F[previous] < F[previous + 1])))
                        {
                            result = true;
                        }
                        else
                        {
                            F[previous] = F[j];
                            F[j] = tmp;
                        }
                        j++;
                    }
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

