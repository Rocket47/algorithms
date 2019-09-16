using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static string BigMinus(string s1, string s2)
        {
            string result = null;
            List<int> number1 = new BigInteger().bigInteger(s1);
            List<int> number2 = new BigInteger().bigInteger(s2);
            BigInteger res = new BigInteger(number1).Substract(new BigInteger(number2));
            List<int> resultList = res.arr;
            for (int i = resultList.Count - 1; i >= 0; i--)
            {
                result = result + resultList[i];
            }
            return result;
        }
    }

    public class BigInteger
    {
        public List<int> arr { get; set; } = new List<int>();
        int order = 8;

        public BigInteger()
        {

        }

        public BigInteger(List<int> arr)
        {
            this.arr = arr;
        }

        public List<int> bigInteger(string s)
        {
            int tempValue = 0;
            int tempOrder = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (tempOrder == order)
                {
                    arr.Add(tempValue);
                    tempValue = int.Parse(s[i].ToString());
                    tempOrder = 1;
                }
                else
                {
                    tempValue = tempValue + (int)Math.Pow(10, tempOrder) * int.Parse(s[i].ToString());
                    tempOrder++;
                }
            }
            if (tempOrder != 0)
            {
                arr.Add(tempValue);
            }
            return arr;
        }

        public BigInteger Substract(BigInteger value)
        {
            int myBase = 8;
            int k = 0;
            int n = Math.Max(arr.Count, value.arr.Count);
            List<int> resultList = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int tempA = (arr.Count > i) ? arr[i] : 0;
                int tempB = (value.arr.Count > i) ? value.arr[i] : 0;
                resultList.Add(Math.Abs(tempA - tempB - k));
                if (resultList[i] < 0)
                {
                    resultList[i] += myBase;
                    k = 1;
                }
                else
                {
                    k = 0;
                }
            }
            while (resultList.Count > 0 && resultList[resultList.Count - 1] == 0)
            {
                resultList.RemoveAt(resultList.Count - 1);
            }
            return new BigInteger(resultList);
        }
    }
}
