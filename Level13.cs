using System;
using System.Collections.Generic;

namespace Level1Space
{
    class Task12
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Level1.Unmanned(10, 2, new int[][] { new int[] { 3, 5, 5 }, new int[] { 5, 2, 2 } }));
            Console.ReadKey();
        }
    }
    public static class Level1
    {
        public static int Unmanned(int L, int N, int[][] track)
        {
            double resultTime = 0;
            resultTime = track[0][0];
            for (int i = 0; i < track.Length; i++)
            {
                double percent = (resultTime / (track[i][1] + track[i][2]) * 100);
                if (percent >= 0 && percent <= (track[i][1] * 100 / (track[i][1] + track[i][2]))) 
                {
                    resultTime = resultTime + (track[i][1] - (track[i][1] * percent / (track[i][1] * 100 / (track[i][1] + track[i][2]))));
                }
                if ((i + 1) < track.Length)
                {
                    resultTime = resultTime + (track[i+1][0] - track[i][0]);
                }
                else
                {
                    resultTime = resultTime + (L - track[i][0]);
                }

            }
            return (int)resultTime;
        }
    }
}

