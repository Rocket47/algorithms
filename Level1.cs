using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1Space
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(getDay(3, 4, 2, new int[] { 2, 2, 1, 3 }));
            Console.ReadKey();
        }

        public static int getDay(int N, int M, int L, int[] battalion)
        {
            bool flag = true;
            int count = 0;
            int n = 0;
            int m = 0;
            int[,] array = new int[N, M];

            //Заполнение 1 высадившихся десантников
            //**************************************
            for (int i = 0; i < battalion.Length; i++)
            {
                if (i % 2 == 0)
                {
                    n = battalion[i];
                    continue;
                }
                if (i % 2 != 0)
                {
                    m = battalion[i];
                }
                array[n, m] = 1;
            }
            //**************************************
            //while (flag)
            //{
            //    count++;
            //    //Заполнение массива +1 к высадившимся
            //    for (int j = 0; j < N; j++)
            //    {
            //        for (int k = 0; k < M; k++)
            //        {
            //            if ((array[j, k]) != 0)
            //            {
            //                array[j, k]++;
            //            }
            //        }
            //    }
            //    //*************************************************

            //    //Заполнение соседних клеток
            //    for (int j = 0; j < N; j++)
            //    {
            //        for (int k = 0; k < M; k++)
            //        {
            //            int sosedN1 = j - 1;
            //            int sosedN2 = j + 1;
            //            int sosedM1 = k - 1;
            //            int sosedM2 = k + 1;
            //            if ((array[j, k]) >= 2 && sosedN1 >= 0)
            //            {
            //                array[sosedN1, k]++;
            //            }
            //            if ((array[j, k]) >= 2 && sosedN2 < N)
            //            {
            //                array[sosedN2, k]++;
            //            }
            //            if ((array[j, k]) >= 2 && sosedM1 >= 0)
            //            {
            //                array[j, sosedM1]++;
            //            }
            //            if ((array[j, k]) >= 2 && sosedM2 < M)
            //            {
            //                array[j, sosedM2]++;
            //            }
            //        }
            //    }

            //    //Вывод массива
            //    //*********************************
            //    for (int j = 0; j < N; j++)
            //    {
            //        for (int p = 0; p < M; p++)
            //        {
            //            Console.Write(array[j, p]);
            //        }
            //        Console.WriteLine();
            //    }
            //    //**********************************  
            //    flag = false;

            //    for (int j = 0; j < N; j++)
            //    {
            //        for (int p = 0; p < M; p++)
            //        {
            //            if (array[j, p] == 0)
            //            {
            //                flag = true;
                            
            //            }
            //        }
            //    }
            //    Console.WriteLine();                
            //}
            return count;
        }
    }
}
    
