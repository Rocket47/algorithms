using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {       
        public static int ConquestCampaign(int N, int M, int L, int[] battalion)
        {
            bool flag = true;
            int count = 1;
            int countFull = 0;
            int n = 0;
            int m = 0;
            int[,] array = new int[N, M];
            for (int i = 0; i < battalion.Length; i++)
            {
                if (i % 2 == 0)
                {
                    n = battalion[i] - 1;
                    continue;
                }
                if (i % 2 != 0)
                {
                    m = battalion[i] - 1;
                }
                array[n, m] = 1;
            }
            while (flag)
            {
                count++;
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < M; k++)
                    {
                        if ((array[j, k]) != 0)
                        {
                            array[j, k]++;
                        }
                    }
                }
                for (int j = 0; j < N; j++)
                {
                    for (int k = 0; k < M; k++)
                    {
                        int sosedN1 = j - 1;
                        int sosedN2 = j + 1;
                        int sosedM1 = k - 1;
                        int sosedM2 = k + 1;
                        if ((array[j, k]) >= 2 && sosedN1 >= 0)
                        {
                            array[sosedN1, k]++;
                        }
                        if ((array[j, k]) >= 2 && sosedN2 < N)
                        {
                            array[sosedN2, k]++;
                        }
                        if ((array[j, k]) >= 2 && sosedM1 >= 0)
                        {
                            array[j, sosedM1]++;
                        }
                        if ((array[j, k]) >= 2 && sosedM2 < M)
                        {
                            array[j, sosedM2]++;
                        }
                    }
                }
                flag = false;
                for (int j = 0; j < N; j++)
                {
                    for (int p = 0; p < M; p++)
                    {
                        if (array[j, p] == 0)
                        {
                            flag = true;
                            countFull++;
                        } 
                    }
                }
                if (countFull == 0)
                {
                    count = 1;
                }               
            }            
            return count;
        }     
    }  
}



