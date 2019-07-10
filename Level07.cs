using System;
using System.Collections.Generic;

namespace Level1Space
{
   public static class Level1
    {
        public static int SumOfThe(int N, int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != getSumNumbersOfArray(data))
                {
                   for (int k = 0; k < data.Length; k++)
                    {

                    }
                }
            }
            return 0;
        }

        public static int getSumNumbersOfArray(int[] arrayWithoutFirstElement)
        {            
            int sum = 0;
            for (int i = 1; i < arrayWithoutFirstElement.Length; i++)
            {
                sum = sum + arrayWithoutFirstElement[i];
            }               
            return sum;
        }
    }
}