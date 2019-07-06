using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static string PatternUnlock(int N, int[] hits)
        {
            double counter = 0.0;
            double hypotenuse = 1.41421;
            Dictionary<int, double> sequenceDictionary = createScheme();
            if (N > 1)
            {
                for (int i = 0; i < N - 1; i++)
                {
                    double moduleResult = Math.Abs(sequenceDictionary[hits[i]] - sequenceDictionary[hits[i + 1]]);

                    if ((moduleResult > 1.00001) || (moduleResult > 0.89) && (moduleResult < 0.91) || (moduleResult > 1.09) && (moduleResult < 1.2))
                    {
                        counter = counter + hypotenuse;
                    }
                    else
                    {
                        counter++;
                    }
                }
            }
            else
            {
                counter++;
            }
            counter = counter * 100000;
            return counter.ToString().Replace("0", "");
        }
        public static Dictionary<int, double> createScheme()
        {
            Dictionary<int, double> coordinates = new Dictionary<int, double>();
            coordinates.Add(6, 0.0);
            coordinates.Add(1, 0.1);
            coordinates.Add(9, 0.2);
            coordinates.Add(5, 1.0);
            coordinates.Add(2, 1.1);
            coordinates.Add(8, 1.2);
            coordinates.Add(4, 2.0);
            coordinates.Add(3, 2.1);
            coordinates.Add(7, 2.2);
            return coordinates;
        }
    }
}