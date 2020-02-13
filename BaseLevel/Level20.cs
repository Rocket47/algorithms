using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void MatrixTurn(string[] Matrix, int M, int N, int T)
        {
            int globalCount = 0;
            while (globalCount < T)
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
                    strToSort = reverseString(strToSort);
                    int position = 0;
                    int mainIndex = i;
                    int rowLength = N;
                    int columnLength = M - ((i + 1) * 2);
                    int index = i + 1;
                    if (i == 1)
                    {
                        Console.WriteLine();
                    }
                    for (int count = 0; count < strToSort.Length; count++)
                    {
                        if (position == 0)
                        {
                            if (mainIndex < rowLength - i)
                            {
                                newMatrix[i, mainIndex] = strToSort[count].ToString();
                                mainIndex++;
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
                                newMatrix[index, rowLength - (i + 1)] = strToSort[count].ToString();
                                index++;
                                mainIndex++;
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
                            bool check = true;
                            if (mainIndex < (rowLength - i))
                            {
                                if (columnLength == 0) { columnLength++; }
                                if (M == 2 && check)
                                {
                                    columnLength = 0;
                                    check = false;
                                }
                                newMatrix[columnLength + 1, rowLength - index] = strToSort[count].ToString();
                                index++;
                                mainIndex++;
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
                                newMatrix[columnLength - mainIndex, i] = strToSort[count].ToString();
                                mainIndex++;
                            }
                            else
                            {
                                position++;
                                mainIndex = i;
                            }
                        }
                    }
                    if (N == 3)
                    {
                        for (int num = 1; num < M - 1; num++)
                        {
                            newMatrix[num, 1] = Matrix[num][1].ToString();
                        }
                    }
                }
                changeMainMatrix(ref Matrix, newMatrix, N);
                globalCount++;
            }
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
                    result += newMatrix[i, j];
                }
                Matrix[i] = result;
                result = "";
            }
        }
    }
}

