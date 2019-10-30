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
            int resultTime = 0;
            Console.WriteLine(track.Length);
            for(int i = 0; i < track.Length; i++)
            {
                resultTime = track[0][0] + (resultTime / (track[0][1] + track[]));
            }
            return 0;
        }
    }
}
