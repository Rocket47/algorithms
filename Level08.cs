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
            Console.WriteLine("Number after point. Count of lines: " +  afterPoint);
            int beforePoint = (int)squareRoot;
            Console.WriteLine("NUmber before point. Count of Columne: " + beforePoint);

            return null;
        }
    }
}
