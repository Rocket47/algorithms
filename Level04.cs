using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {        
        public static int[] SynchronizingTables(int N, int[] ids, int[] salary)
        {
            int[] additionalArr = new int[N];
            for (int k = 0; k < ids.Length; k++)
            {
                additionalArr[k] = ids[k];
            }
            sortArr(additionalArr);
            sortArr(salary);
            Dictionary<int, int> pairs = new Dictionary<int, int>();
            for (int m = 0; m < N; m++)
            {
                pairs.Add(additionalArr[m], salary[m]);
            }
            for (int n = 0; n < N; n++)
            {
                
                salary[n] = pairs[ids[n]];
            }
            return salary;
        }
        public static void sortArr(int[] arrForSorting)
        {
            for (int i = 0; i < arrForSorting.Length; i++)
            {
                for (int j = i + 1; j < arrForSorting.Length; j++)
                {
                    if (arrForSorting[j] < arrForSorting[i])
                    {
                        int saveValue = arrForSorting[i];
                        arrForSorting[i] = arrForSorting[j];
                        arrForSorting[j] = saveValue;
                    }
                }
            }
        }
    }
}
