using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {        
        public static string TheRabbitsFoot(string s, bool encode)
        {
            string result = null;
            if (encode)
            {
                result = Encrypt(s);
            }
            else
            {
                result = Decrypt(s);
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
                if (beforePoint < afterPoint || beforePoint == afterPoint)
                {
                    beforePoint++;
                }
                else
                {
                    afterPoint++;
                }

            }
            char[,] matrixArr = new char[beforePoint, afterPoint];
            str = str.Replace(" ", String.Empty);
            char[] charArr = str.ToCharArray();
            int a = 0;
            for (int i = 0; i < beforePoint; i++)
            {
                for (int j = 0; j < afterPoint && a < lengthString; j++)
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
            Console.WriteLine("************Next operation************");
            return result;
        }

        public static string Decrypt(string str)
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
            Console.WriteLine("____________Process of decryption was started___________");
            Console.WriteLine("Length of this line: " + lengthString);
            Console.WriteLine("после вычисления квадратного корня: " + squareRoot);
            int afterPoint = (int)(((squareRoot - (int)squareRoot) * multiplier) / 10);
            Console.WriteLine("Number after point. Count of lines: " + afterPoint);
            int beforePoint = (int)squareRoot;
            Console.WriteLine("NUmber before point. Count of Columne: " + beforePoint);
            while (afterPoint * beforePoint < lengthString)
            {
                if (beforePoint < afterPoint || beforePoint == afterPoint)
                {
                    beforePoint++;
                }
                else
                {
                    afterPoint++;
                }

            }
            char[,] matrixArr = new char[beforePoint, afterPoint];
            //--------------create matrix------------
            int counter = 0;
            for (int k = 0; k < afterPoint; k++)
            {
                char[] createArr = afterSplitting[counter].ToCharArray();
                int index = 0;
                for (int m = 0; m < beforePoint; m++)
                {
                    if (index < createArr.Length)
                    {
                        matrixArr[m, k] = createArr[index];
                        char test = createArr[index];
                        index++;
                    }
                }
                counter++;
                //-------------matrix was created-----------
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

            //Create final string

            string result = null;
            foreach (char parse in matrixArr)
            {
                result = result + parse.ToString();
            }
            Console.WriteLine("Result of decryption: " + result);
            if (!result.Equals(null))
            {
                result = result.Replace("\0", "");
            }
            return result;
        }
    }
}

