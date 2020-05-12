using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class HashTable
    {
        public int size;
        public int step;
        public string[] slots;

        public HashTable(int sz, int stp)
        {
            size = sz;
            step = stp;
            slots = new string[size];
            for (int i = 0; i < size; i++) slots[i] = null;
        }

        public int HashFun(string value)
        {
            int hashCode2 = 0;
            char[] converterArray = value.ToCharArray();
            for (int i = 0; i < converterArray.Length; i++)
            {
                byte[] bytesArray = BitConverter.GetBytes(converterArray[i]);
                for (int j = 0; j < bytesArray.Length; j++)
                {
                    hashCode2 += bytesArray[j];
                }
            }
            hashCode2 = hashCode2 % size;            
            return hashCode2;
        }

        public int SeekSlot(string value)
        {
            int index = HashFun(value);
            int stepCopy = step;

            if (index >= size)
            {
                return -1;
            }
            while (stepCopy != 0)
            {
                for (int i = index; i < size; i++)
                {
                    if (slots[i] == null)
                    {
                        return i;
                    }
                    else
                    {
                        continue;
                    }
                }
                index = 0;
                stepCopy--;
            }           
            return -1;
        }

        public int Put(string value)
        {
            int indexEmptySlot = SeekSlot(value);
            if (indexEmptySlot != -1)
            {
                slots[indexEmptySlot] = value;
                return indexEmptySlot;
            }            
            return -1;
        }

        public int Find(string value)
        {
            int count = 2;
            int slotIndex = HashFun(value);
            while (count != 0)
            {
                for (int i = slotIndex; i < slots.Length; i++)
                {
                    if (slots[i] == null) { continue; }
                    if (slots[i].Equals(value))
                    {
                        return i;
                    }
                }
                slotIndex = 0;
                count--;
            }                       
            return -1;
        }
    }
}

