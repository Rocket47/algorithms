using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static string MassVote(int N, int [] Votes)
        {
            int saveMuxNumber = 0;
            string result = null;
            double percent = 0.0;
            int sumCounter = 0;
            bool flag = true;
            for (int i = 0; i < Votes.Length; i++)
            {
                if (Votes[i] > saveMuxNumber)
                {
                    saveMuxNumber = Votes[i];
                }
                if ((i+1) < Votes.Length && Votes[i + 1] == saveMuxNumber )
                {
                    result = "no winner";
                    flag = false;
                    break;
                }
                i++;
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
                    result = "majority winner 1";
                }
                else
                {
                    result = "minority winner 2";
                }
            }
            return result;
        }
    }
}

