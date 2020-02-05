using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void Main(string[] args)
        {
            int[] F = new int[] { 3, 2, 1 };
            Console.WriteLine(Footbal(F, 5));
            Console.ReadKey();
        }
        public static bool Footbal(int[] F, int N)
        {
            int[] SaveArr = F;
            bool ResultCheck1stMethod = false;
            bool Result2ndMethod = false;
            bool result = false;
            ResultCheck1stMethod = Check1stMethod(F);
            F = SaveArr;
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
            bool ChainExist = false;
            bool result = false;
            int CountChainMaxSide = 0;
            int CountChainMinSide = 0;
            int ResultChainValue = 0;
            int SaveFirstPosition = 0;
            int previous = 0;
            int k, j = 1;
            for (int i = 0; i < F.Length; i++)
            {
                int a = F[i];
                int b = F[previous];
                if (F[i] >= F[previous] && CountChainMinSide == 0)
                {
                    if (CountChainMaxSide == 0)
                    {
                        SaveFirstPosition = i;
                    }
                    ChainExist = true;
                    CountChainMaxSide++;
                    previous = i;                   
                }         
                else
                {
                    ChainExist = false;
                    CountChainMinSide = 0;
                }
                if (F[i] <= F[previous] && CountChainMaxSide == 0)
                {
                    if (CountChainMinSide == 0)
                    {
                        SaveFirstPosition = i;
                    }
                    ChainExist = true;
                    CountChainMinSide++;
                    previous = i;
                }
                else
                {
                    ChainExist = false;
                    CountChainMaxSide++;
                }
            }
            if (ChainExist)
            {
            ResultChainValue = CountChainMaxSide > 0 ? CountChainMaxSide : CountChainMinSide;            
            SaveFirstPosition = SaveFirstPosition == 0 ? k = 0 : k = 1;
            ResultChainValue = ResultChainValue == 0 ? j = 0 : j = 1;
            if (F[SaveFirstPosition] >= F[SaveFirstPosition - k] && F[ResultChainValue - j] >= F[ResultChainValue])
            {
                result = true;
            }
            }
            return result;
        }
    }
}

