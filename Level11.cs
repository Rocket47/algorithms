using System;
using System.Collections.Generic;

namespace Task11
{
    public static class Level1
    {
        public static string MassVote(int N, int[] Votes)
        {
            int saveMuxNumber = 0;
            string result = null;
            double percent = 0.0;
            int sumCounter = 0;
            int position = 0;
            bool flag = true;
            for (int i = 0; i < Votes.Length; i++)
            {
                if (Votes[i] > saveMuxNumber)
                {
                    saveMuxNumber = Votes[i];
                    position = i + 1;
                    flag = true;
                    for (int k = i + 1; k < Votes.Length; k++)
                    {
                        if ((k) < Votes.Length && Votes[k] == saveMuxNumber)
                        {
                            result = "no winner";
                            flag = false;
                        }
                    }

                }

            }
            if (flag)
            {
                for (int j = 0; j < Votes.Length; j++)
                {
                    sumCounter = sumCounter + Votes[j];
                    if (j == (Votes.Length - 1))
                    {
                        percent = 100 / sumCounter * saveMuxNumber;
                    }
                }
                if (percent > 50.0)
                {
                    result = "majority winner " + position;
                }
                else
                {
                    result = "minority winner " + position;
                }
            }
            return result;
        }
    }
}

