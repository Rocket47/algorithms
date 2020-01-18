using System;
using System.Collections.Generic;


namespace Level1Space
{
    public static class Level1
    {
        // static string[] Matrix = new string[] { "123456", "234567", "345678", "456789" };
        //static string[] Matrix = new string[] { "123", "456", "789" };
        // static string[] Matrix = new string[] { "412", "753", "896", "956" };
        static string[] Matrix = new string[] { "1234", "5678", "4567", "2343" };
       // static string[] Matrix = new string[] { "12", "34"};
        static void Main(string[] args)
        {                     
           // MatrixTurn(Matrix, 4, 6, 3);           
            //MatrixTurn(Matrix, 4, 3, 3);           
            MatrixTurn(Matrix, 4, 4, 3);           
            //MatrixTurn(Matrix, 2, 2, 3);           
            Console.ReadKey();
        }

        public static void MatrixTurn(string[] Matrix, int M, int N, int T)
        {
            int countOfSquare = 0;
            countOfSquare = M < N ? (M / 2) : (N / 2);
            string[,] newMatrix = new string[M, N];
            for (int i = 0; i < countOfSquare; i++)
            {
                string oldUpSide = "";
                string oldDownSide = "";
                string leftSide = "";
                string rightSide = "";
                string strToSort = "";

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
                Console.WriteLine("Делаем реверс стандартным методом ");
                strToSort = reverseString(strToSort);
                Console.WriteLine("Строка после реверса: " + strToSort);
                Console.WriteLine("********new cicle*********");


                int position = 0;
                int mainIndex = i;
                int rowLength = N;
                int columnLength = M - ((i + 1) * 2);
                int index = i + 1;
                //******here I fill a new matrix**********

                if (i == 1)
                {
                    Console.WriteLine();
                }
                for (int count = 0; count < strToSort.Length; count++)
                {

                    string test;
                    if (position == 0)
                    {
                        if (mainIndex < rowLength - i)
                        {
                            test = strToSort[count].ToString();
                            //string test2 = newMatrix[1, 0];
                            newMatrix[i, mainIndex] = strToSort[count].ToString();
                            mainIndex++;
                            showMatrix(newMatrix);
                        }
                        else
                        {
                            position++;
                            mainIndex = i;
                        }
                    }
                    if (position == 1)
                    {
                        if (mainIndex < columnLength - i)
                        {
                            test = strToSort[count].ToString();
                            newMatrix[index, rowLength - (i + 1)] = strToSort[count].ToString();
                            index++;
                            mainIndex++;
                            showMatrix(newMatrix);
                        }
                        else
                        {
                            index = i + 1;
                            position++;
                            mainIndex = i;
                        }
                    }
                    if (position == 2)
                    {
                        if (mainIndex < (rowLength - i))
                        {
                            if (columnLength == 0) { columnLength++; }   
                            test = strToSort[count].ToString();
                            newMatrix[columnLength + 1, rowLength - index] = strToSort[count].ToString();
                            index++;
                            mainIndex++;
                            showMatrix(newMatrix);
                        }
                        else
                        {
                            position++;
                            mainIndex = i;
                            index = i + 1;
                        }
                    }
                    if (position == 3)
                    {
                        if (mainIndex < (rowLength - i))
                        {
                            test = strToSort[count].ToString();
                            newMatrix[columnLength - mainIndex, i] = strToSort[count].ToString();
                            showMatrix(newMatrix);
                            mainIndex++;
                        }
                        else
                        {
                            position++;
                            mainIndex = i;
                        }
                    }
                }
                
            }
            changeMainMatrix(ref Matrix, newMatrix, N);
        }
        public static void showMatrix(string[,] newMatrix)
        {
            //***********show new matrix*********//
            Console.WriteLine("*********РИСУЮ**************");
            int rowLeng = newMatrix.GetLength(0);
            int colLeng = newMatrix.GetLength(1);

            for (int r = 0; r < rowLeng; r++)
            {
                for (int t = 0; t < colLeng; t++)
                {
                    Console.Write(string.Format("{0}", newMatrix[r, t]));
                }
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine("*********КОНЕЦ**************");

            //************END SHOW NEW MATRIX************
        }       

        public static string reverseString(string newString)
        {
            string result = newString[newString.Length - 1].ToString();
            for (int i = 0; i < newString.Length - 1; i++)
            {
                result += newString[i].ToString();
            }
            return result;
        }

        public static void changeMainMatrix(ref string[] Matrix, string[,] newMatrix, int lengthRow)
        {
            string result = "";
            for (int i = 0; i < newMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < lengthRow; j++)
                {
                    result += newMatrix[i,j];
                }
                Matrix[i] = result;
                result = "";
            }
        }
    }
}

