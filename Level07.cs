using System;
using System.Collections.Generic;

namespace Level1Space
{
  public static class Level1
    {
        public static int SumOfThe(int N, int[] data)
        {
            int resultValue = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[0] != getSumNumbersOfArray(data))
                {
                    int saveValFirstElement = data[0];
                    for (int k = 1; k < data.Length; k++)
                    {
                        data[k - 1] = data[k];
                    }
                    data[data.Length - 1] = saveValFirstElement;
                }
                else
                {
                    resultValue = data[0];
                    break;
                }
            }
            return resultValue;
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