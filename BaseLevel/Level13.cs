using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {        
         public static int Unmanned(int L, int N, int[][] track)
        {
            double resultTime = 0;
            if (track[0][0] < L)
            {
                resultTime = track[0][0];
                for (int i = 0; i < track.Length; i++)
                {

                    double percent = (resultTime / (track[i][1] + track[i][2]));
                    if (percent < 0.99)
                    {
                        percent = percent * 100;
                    }
                    else
                    {
                        percent = (percent - Math.Truncate(percent)) * 100;
                    }
                    if (percent >= 0 && percent <= (track[i][1] * 100 / (track[i][1] + track[i][2])))
                    {
                        resultTime = resultTime + (track[i][1] - (track[i][1] * percent / (track[i][1] * 100 / (track[i][1] + track[i][2]))));
                    }
                    if ((i + 1) < track.Length && track[i + 1][0] < L)
                    {
                        resultTime = resultTime + (track[i + 1][0] - track[i][0]);
                    }
                    else
                    {
                        if (track[i][0] > L)
                        {
                            break;
                        }
                        resultTime = resultTime + (L - track[i][0]);
                    }

                }
            }
            else
            {
                resultTime = L;
            }

            resultTime = Math.Round(resultTime);
            return (int)resultTime;
        }
    }
}

