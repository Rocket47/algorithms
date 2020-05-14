using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class NativeCache<T>
    {
        public int size;
        public string[] slots;
        public T[] values;
        public int positionFoundKey;
        public int positionMinumumHits;
        public int[] hits;

        public NativeCache(int sz)
        {
            size = sz;
            slots = new string[size];
            values = new T[size];
            hits = new int[size];
        }

        //*//////////////////////////////////////////////////////////////////////////////
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
            return hashCode2;
        }

        //*//////////////////////////////////////////////////////////////////////////////
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
                    hits[i] += 1;
                    positionFoundKey = i;
                    return true;
                }
            }
            return false;
        }

        //*//////////////////////////////////////////////////////////////////////////////
        public void Put(string key, T value)
        {
            bool status = IsKey(key);           
            if (isArrayFull())
            {
                if (!status)
                {
                    SearchMinimumHits();
                    slots[positionMinumumHits] = null;
                    values[positionMinumumHits] = default(T);
                    hits[positionMinumumHits] = 0;
                }                
            }            
            int indexEmptySlot = SeekSlot(key);
            if (status)
            {
                for (int searchIndex = 0; searchIndex < slots.Length; searchIndex++)
                {
                    if (slots[searchIndex] == null) { continue; }
                    if (slots[searchIndex].Equals(key))
                    {
                        values[searchIndex] = value;
                        return;
                    }
                }
            }
            if (indexEmptySlot != -1)
            {
                slots[indexEmptySlot] = key;
                values[indexEmptySlot] = value;
                return;
            }
        }

        //*//////////////////////////////////////////////////////////////////////////////
        public T Get(string key)
        {
            if (IsKey(key))
            {
                return values[positionFoundKey];
            }
            return default(T);
        }

        //*//////////////////////////////////////////////////////////////////////////////
        public int SeekSlot(string key)
        {
            int stepCopy = 2;
            int slotIndex = HashFun(key);

            if (slotIndex >= size)
            {
                return -1;
            }
            while (stepCopy != 0)
            {
                for (int i = slotIndex; i < size; i++)
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
                slotIndex = 0;
                stepCopy--;
            }
            return -1;
        }

        //*//////////////////////////////////////////////////////////////////////////////
        public void SearchMinimumHits()
        {
            int min = hits[0];
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i] < min)
                {
                    min = hits[i];
                    positionMinumumHits = i;
                }
            }           
        }

        //*//////////////////////////////////////////////////////////////////////////////
        public bool isArrayFull()
        {
            foreach (string item in slots)
            {
                if (item == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
