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
            string result = null;
            if (encode)
            {
                result = Encrypt(s);
            } else
            {

            }
            return result;
        }

        public static string Encrypt(string str)
        {
            int lengthString = 0;
            double squareRoot = 0;
            int multiplier = 100;
            string[] afterSplitting = str.Split(' ');
            foreach (string i in afterSplitting)
            {
                lengthString += i.Length;
            }
            squareRoot = Math.Round(Math.Sqrt(lengthString), 2);
            Console.WriteLine("____________Process of ecryption was started___________");
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

            str = str.Replace(" ", String.Empty);
            char[] charArr = str.ToCharArray();
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

                Console.WriteLine();
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
            result = result.Replace("\0", "");
            Console.WriteLine("Result of encryption: " + result);
            Console.WriteLine("____________Process of encryption was finished____________");
            return result;
        }

        public static string Decrypt(string str)
        {
            return null;
        }
    }
}
