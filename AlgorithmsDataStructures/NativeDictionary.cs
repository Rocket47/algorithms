using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeDictionary<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int globalIndex;

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
            foreach (string searchKey in slots)
            {
                if (searchKey == null)
                {
                    continue;
                }
                if (searchKey.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public void Put(string key, T value)
        {
            int indexEmptySlot = SeekSlot(value);
            if (indexEmptySlot != -1)
            {
                slots[indexEmptySlot] = key;
                values[indexEmptySlot] = value;                
            }
        }

        public T Get(string key)
        {
            // возвращает value для key, 
            // или null если ключ не найден
            return default(T);
        }

        public int SeekSlot(T value)
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
