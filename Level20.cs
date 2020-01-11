using System;
using System.Collections.Generic;


namespace Level1Space
{
    public static class Level1
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            MatrixTurn(matrix, 4, 6, 3);
            Console.ReadKey();

        }

        public static int[,] MatrixTurn(int[,] Matrix, int M, int N, int T)
        {           
            {
                int[,] newMatrix = new int[Matrix.GetLength(1), Matrix.GetLength(0)];
                int newColumn, newRow = 0;
                for (int oldColumn = Matrix.GetLength(1) - 1; oldColumn >= 0; oldColumn--)
                {
                    newColumn = 0;
                    for (int oldRow = 0; oldRow < Matrix.GetLength(0); oldRow++)
                    {
                        newMatrix[newRow, newColumn] = Matrix[oldRow, oldColumn];
                        newColumn++;
                    }
                    newRow++;                    
                }
                
                for (int row = 0; row < newMatrix.GetLength(0); row++)
                {
                    for (int col = 0; col < newMatrix.GetLength(1); col++)
                    {
                        Console.Write(newMatrix[row, col] + " ");
                    }

                    Console.WriteLine();
                }
                return newMatrix;
            }
        }
    }
}

