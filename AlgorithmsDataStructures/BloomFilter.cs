using System.Collections.Generic;
using System;
using System.IO;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public byte[] filterArray;

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            filterArray = new byte[filter_len];
        }
       
        //*//////////////////////////////////////////////////
        public int Hash1(string str1)
        {
            int result = 0;            
            
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                result = (result * (17 + code)) % filter_len;
            }
            
            return result;
        }

        //*//////////////////////////////////////////////////
        public int Hash2(string str1)
        {
            int result = 0;            
            for (int i = 0; i < str1.Length; i++) 
            {
                int code = (int)str1[i];
                result = (result * (223 + code)) % filter_len;
            }
            return result;
        }

        //*//////////////////////////////////////////////////
        public void Add(string str1)
        {
            int position1 = Hash1(str1);
            int position2 = Hash2(str1);
            filterArray[position1] = 1;
            filterArray[position2] = 1;                       
        }

        //*//////////////////////////////////////////////////
        public bool IsValue(string str1)
        {
            int position1 = Hash1(str1);
            int position2 = Hash2(str1);
            if (filterArray[position1] == 0 && filterArray[position2] == 0)
            {
                return false;
            }
            else if (filterArray[position1] == 0 && filterArray[position2] == 1)
            {
                return false;
            }
            else if (filterArray[position1] == 1 && filterArray[position2] == 0)
            {
                return false;
            } 
            else
            {
                return true;
            }          
        }
    }
}
