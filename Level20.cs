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
            Console.ReadKey();
        }

        public static void MatrixTurn(string[] Matrix, int M, int N, int T)
        {
            string oldUpSide = "";
            string oldDownSide = "";
            string leftSide = "";
            string rightSide = "";
            string strToSort = "";
            int countOfSquare = 0;         
            countOfSquare = M < N ? (M / 2) : (N / 2);

            for (int i = 0; i < countOfSquare; i++)
            {
                for (int m = 0; m < Matrix.Length; m++)
                {
                    leftSide += Matrix[m][i].ToString();
                    rightSide += Matrix[m][Matrix[m].Length - i - 1].ToString();
                }
                if (i > 0)
                {
                    oldUpSide = Matrix[i].Substring(1, Matrix[i].Length - 2);
                    oldDownSide = Matrix[(Matrix.Length - 1) - i].Substring(1, Matrix[i].Length - 2);
                    leftSide = leftSide.Substring(1, leftSide.Length - 2);
                    rightSide = rightSide.Substring(1, rightSide.Length - 2);
                }
                else
                {
                    oldUpSide = Matrix[i];
                    oldDownSide = Matrix[(Matrix.Length - 1) - i];                                        
                }
                if (leftSide.Length > 2 && rightSide.Length > 2)
                {
                    char[] reverseArr = oldDownSide.ToCharArray();
                    Array.Reverse(reverseArr);
                    oldDownSide = new string(reverseArr);
                    reverseArr = leftSide.ToCharArray();
                    Array.Reverse(reverseArr);
                    leftSide = new string(reverseArr);
                    strToSort = oldUpSide + rightSide.Substring(1, rightSide.Length - 2) + oldDownSide + leftSide.Substring(1, leftSide.Length - 2);
                }
                else
                {                   
                    char[] reverseArr = oldDownSide.ToCharArray();
                    Array.Reverse(reverseArr);
                    oldDownSide = new string(reverseArr);
                    strToSort = oldUpSide + oldDownSide;
                }
                Console.WriteLine(oldUpSide);
                Console.WriteLine(rightSide);
                Console.WriteLine(oldDownSide);
                Console.WriteLine(leftSide);
                Console.WriteLine("Получилась строка: " + strToSort);
                Console.WriteLine("********new cicle*********");
                oldDownSide = "";
                oldUpSide = "";
                leftSide = "";
                rightSide = "";
                strToSort = "";
            }                
        }
    }
}

