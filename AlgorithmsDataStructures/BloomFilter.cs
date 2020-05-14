using System.Collections.Generic;
using System;
using System.IO;
using System.Collections;

namespace AlgorithmsDataStructures
{
    public class BloomFilter
    {
        public int filter_len;
        public byte[] bytesFilter;       
        

        public BloomFilter(int f_len)
        {
            filter_len = f_len;
            bytesFilter = new byte[filter_len / 8];            
        }
       
        //*//////////////////////////////////////////////////
        public int Hash1(string str1)
        {
            int result = 0;            
            
            for (int i = 0; i < str1.Length; i++)
            {
                int code = (int)str1[i];
                result = ((result + code) * 17 ) % filter_len;
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
                result = ((result + code) * 223) % filter_len;
            }
            return result;
        }

        //*//////////////////////////////////////////////////
        public void Add(string str1)
        {
            int position1 = Hash1(str1);
            int position2 = Hash2(str1);
            int hash1 = position1 & 0x7FFFFFFF; 
            int hash2 = position2 & 0x7FFFFFFF;
            byte bit1 = (byte)(1 << (hash1 & 7)); 
            byte bit2 = (byte)(1 << (hash2 & 7)); 
            bytesFilter[hash1 % bytesFilter.Length] |= bit1;
            bytesFilter[hash2 % bytesFilter.Length] |= bit2;
        }

        //*//////////////////////////////////////////////////
        public bool IsValue(string str1)
        {
            int hash1 = Hash1(str1) & 0x7FFFFFFF;
            int hash2 = Hash2(str1) & 0x7FFFFFFF;
            byte bit1 = (byte)(1 << (hash1 & 7)); 
            byte bit2 = (byte)(1 << (hash2 & 7)); 
            return (bytesFilter[hash1 % bytesFilter.Length] & bit1) != 0 && (bytesFilter[hash2 % bytesFilter.Length] & bit2) != 0;
        }
    }
}
