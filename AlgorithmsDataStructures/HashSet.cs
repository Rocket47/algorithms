using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T>
    {
        public int size = 20;
        public T[] slots;
        public PowerSet()
        {
            size = 20;
            slots = new T[size];
            for (int i = 0; i < 20; i++) slots[i] = default(T);
        }

        //*////////////////////////////////////////////////////////
        public int Size()
        {
            int count = 0;
            foreach (T item in slots)
            {
                count++;
            }
            return count;
        }

        //*////////////////////////////////////////////////////////
        public void Put(T value)
        {
            if (!Get(value))
            {
                int indexEmptySlot = SeekSlot(value);
                if (indexEmptySlot != -1) { slots[indexEmptySlot] = value; }
            }
        }

        //*////////////////////////////////////////////////////////
        public bool Get(T value)
        {
            foreach (T searchValue in slots)
            {
                if (searchValue == null) { continue; }
                if (searchValue.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        //*////////////////////////////////////////////////////////
        public bool Remove(T value)
        {
            if (typeof(T) == typeof(string)) // возвращает true если value удалено
            {
                for (int i = 0; i < slots.Length; i++)
                {
                    if (slots[i].Equals(value))
                    {
                        for (int j = i; j < slots.Length - 1; j++)
                        {
                            slots[j] = slots[j + 1];
                        }
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < slots.Length; i++)
                {
                    if ((int)(object)slots[i] == (int)(object)(value))
                    {
                        for (int j = i; j < slots.Length - 1; j++)
                        {
                            slots[j] = slots[j + 1];
                        }
                        return true;
                    }
                }
            }
            // иначе false
            return false;
        }

        //*////////////////////////////////////////////////////////
        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            // пересечение текущего множества и set2
            return null;
        }

        //*////////////////////////////////////////////////////////
        public PowerSet<T> Union(PowerSet<T> set2)
        {
            // объединение текущего множества и set2
            return null;
        }

        //*////////////////////////////////////////////////////////
        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            // разница текущего множества и set2
            return null;
        }

        //*////////////////////////////////////////////////////////
        public bool IsSubset(PowerSet<T> set2)
        {
            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
            return false;
        }

        //*////////////////////////////////////////////////////////
        public int HashFun(T value)
        {
            int hashCode2 = 0;
            string convertToStringValue = value.ToString();
            char[] converterArray = convertToStringValue.ToCharArray();
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

        //*////////////////////////////////////////////////////////
        public int SeekSlot(T value)
        {
            int index = HashFun(value);
            int stepSize = 2;

            if (index >= size)
            {
                return -1;
            }
            while (stepSize != 0)
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
                stepSize--;
            }
            return -1;
        }
    }
}
