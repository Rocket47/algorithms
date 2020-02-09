using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {        
        public static bool Football(int[] F, int N)
        {
            bool ResultCheck1stMethod = false;
            bool Result2ndMethod = false;
            bool result = false;
            int[] SaveArr = new int[F.Length];
            F.CopyTo(SaveArr, 0);
            ResultCheck1stMethod = Check1stMethod(F);
            foreach (int n in SaveArr)
            {
                Console.WriteLine(n);
            }
            Result2ndMethod = Check2ndMethod(SaveArr);
            if (ResultCheck1stMethod == true || Result2ndMethod == true)
            {
                result = true;
            }
            return result;
        }

        public static bool Check1stMethod(int[] F)
        {
            bool result = false;
            int previous = 0;
            int count = 0;
            int k = 0;
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
                        k = j + 1 >= F.Length ? j - 1 : j;
                        if ((F[j] > F[j - 1] && F[j] < F[k + 1]) && ((F[previous] > F[previous - 1]) && (F[previous] < F[previous + 1])))
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
            bool result = true;
            int CountChainMinSide = 0;
            int SaveFirstPosition = 0;
            int previous = 0;                       

            if (CheckJustReverseOrder(F))
            {
                result = true;
            }
            else
            {
                for (int i = 1; i < F.Length; i++)
                {
                    int a = F[i];
                    int b = F[previous];
                    if (F[i] <= F[previous])
                    {
                        if (CountChainMinSide == 0)
                        {
                            SaveFirstPosition = previous;
                        }
                        CountChainMinSide++;                        
                    }                                                                             
                    previous = i;
                }
                int diapason = CountChainMinSide;
                if (CountChainMinSide == 1)
                {
                    diapason++;
                }
                for (int j = 0; j < diapason / 2; j++)
                {
                    int tmp = F[SaveFirstPosition];
                    F[SaveFirstPosition] = F[F.Length - CountChainMinSide];
                    F[F.Length - CountChainMinSide] = tmp;
                    CountChainMinSide++;
                }
                foreach (int n in F)
                {
                    Console.WriteLine(n);
                }
                for (int m = 0; m < F.Length - 1; m++)
                {
                    if (F[m] > F[m + 1])
                    {
                        result = false;
                        break;
                    }
                }
            }
            return result;
        }

        public static bool CheckJustReverseOrder(int[] F)
        {
            bool result = true;
            for (int i = F.Length - 1; i > 0; i--)
            {
                if (F[i] > F[i - 1])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
    }
}

