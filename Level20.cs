using System;
using System.Collections.Generic;


namespace Level1Space
{
    public static class Level1
    {
        static void Main(string[] args)
        {
            string[] Matrix = new string[] { "123456", "234567", "345678", "456789" };
            MatrixTurn(Matrix, 4, 6, 3);
            Console.WriteLine(Matrix[0]);
            Console.ReadKey();
        }

        public static void MatrixTurn(string[] Matrix, int M, int N, int T)
        {
            int countOfSquare = 0;
            countOfSquare = M < N ? (M / 2) : (N / 2);
            for (int i = 0; i < Matrix.Length; i++)
            {
                char[] arrayOfNumber = Matrix[i].ToCharArray();
                for (int j = 0; j < countOfSquare; j++) 
                {

                }
            }
        }       
    }
}

