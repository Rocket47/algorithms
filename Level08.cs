using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {

        static void Main(string[] args)
        {
            TheRabbitsFoot("отдай мою кроличью лапку", true);
            Console.ReadKey();
        }

        public static string TheRabbitsFoot(string s, bool encode)
        {
            int lengthString = 0;
            double squareRoot = 0;
            int countStringMatrix = 0;
            int countNumbersLine = 0;
            int multiplier = 100;
            string[] afterSplitting = s.Split(' ');
            foreach (string i in afterSplitting)
            {
                lengthString += i.Length;
            }
            squareRoot = Math.Round(Math.Sqrt(lengthString), 2);
            Console.WriteLine("Length of this line: " + lengthString);
            Console.WriteLine("после вычисления квадратного корня: " + squareRoot);

            int afterPoint = (int)(((squareRoot - (int)squareRoot) * multiplier) / 10);
            Console.WriteLine("Number after point. Count of lines: " + afterPoint);
            int beforePoint = (int)squareRoot;
            Console.WriteLine("NUmber before point. Count of Columne: " + beforePoint);

            while (afterPoint * beforePoint < lengthString)
            {
                beforePoint++;
            }

            char[,] matrixArr = new char[beforePoint, afterPoint];

            s = s.Replace(" ", String.Empty);
            char[] charArr = s.ToCharArray();
            int a = 0;
            for (int i = 0; i < afterPoint; i++)
            {
                for (int j = 0; j < beforePoint && a < lengthString; j++)
                {
                    matrixArr[i, j] = charArr[a];
                    a++;
                }
            }

            //output 2d array

            int rowLength = matrixArr.GetLength(0);
            int colLength = matrixArr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrixArr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            //---------------------------------//

            // create a finally string
            string result = null;
            for (int j = 0; j < afterPoint; j++)
            {
                for (int i = 0; i < beforePoint; i++)
                {
                    result = result + matrixArr[i, j];
                }
                result = result + " ";
            }
            Console.WriteLine(result);


            return result;
        }
    }
}
