using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;

namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int globalIndex;
        public int positionFoundKey;

        public NativeDictionary(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
        }

        public int HashFun(string key)
        {
            int hashCode2 = 0;
            char[] converterArray = key.ToCharArray();
            for (int i = 0; i < converterArray.Length; i++)
            {
                byte[] bytesArray = BitConverter.GetBytes(converterArray[i]);
                for (int j = 0; j < bytesArray.Length; j++)
                {
                    hashCode2 += bytesArray[j];
                }
            }
            hashCode2 = hashCode2 % size;
            globalIndex = hashCode2;
            return hashCode2;
        }

        public bool IsKey(string key)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == null)
                {
                    continue;
                }
                if (slots[i].Equals(key))
                {
                    positionFoundKey = i;
                    return true;
                }
            }            
            return false;
        }

        public void Put(string key, T value)
        {
            if (!IsKey(key))
            {
                int indexEmptySlot = SeekSlot();
                if (indexEmptySlot != -1)
                {
                    slots[indexEmptySlot] = key;
                    values[indexEmptySlot] = value;
                }
            }
        }

        public T Get(string key)
        {
            
            if (IsKey(key))
            {
                return values[positionFoundKey];
            }            
            return default(T);
        }

        public int SeekSlot()
        {            
            int stepCopy = 2;

            if (globalIndex >= size)
            {
                return -1;
            }
            while (stepCopy != 0)
            {
                for (int i = globalIndex; i < size; i++)
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
                globalIndex = 0;
                stepCopy--;
            }
            return -1;
        }
    }
}
