using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1Space
{
    class Level1
    {
        static void Main(string[] args)
        {
            Console.WriteLine(getDay(4, 3, 2, new int[] { 4, 3, 1, 1 }));
        }

        public static int getDay(int N, int M, int L, int[] battalion)
        {
            bool flag = false;
            int count = 0;
            int[,] array = new int[N, M];

            for (int i = 0; i < battalion.Length;)
            {
                i = i + 2;
                array[battalion[i], battalion[i + 1]] = 1;
            }
            while (!flag)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    for (int k = 0; k < array.Length; k++)
                    {
                        if ((array[j, k]) != 0)
                        {
                            array[j, k]++;
                        }
                    }
                }

                for (int m = 0; m < array.Length; m++)
                {
                    for (int n = 0; n < array.Length; n++)
                    {
                        if (array[m, n] == 0 && array[m, n - 1] >= 2)
                        {
                            array[m, n]++;
                        }
                        if (array[m, n] == 0 && array[m, n + 1] >= 2)
                        {
                            array[m, n]++;
                        }
                        if (array[m, n] == 0 && array[m - 1, n] >= 2)
                        {
                            array[m, n]++;
                        }
                        if (array[m, n] == 0 && array[m + 1, n] >= 2)
                        {
                            array[m, n]++;
                        }
                    }
                }

                for (int s = 0; s < array.Length; s++)
                {
                    for (int d = 0; d < array.Length; d++)
                    {
                        if (array[s, d] == 0)
                        {
                            flag = false;
                            count++;
                            break;
                        }
                    }
                }               
            }
            return count;
        }
    }
}
