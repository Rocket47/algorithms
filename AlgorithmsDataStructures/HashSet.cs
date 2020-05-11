using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    // наследуйте этот класс от HashTable
    // или расширьте его методами из HashTable
    public class PowerSet<T>
    {
        public int size = 0;
        public T[] slots;
        public PowerSet()
        {
            size = 20000;
            slots = new T[20000];
            for (int i = 0; i < 20000; i++) slots[i] = default(T);
        }

        public int Size()
        {
            int count = 0;
            foreach (T item in slots)
            {
                count++;
            }
            return count;
        }

        public void Put(T value)
        {
            // всегда срабатывает
        }

        public bool Get(T value)
        {
            // возвращает true если value имеется в множестве,
            // иначе false
            return false;
        }

        public bool Remove(T value)
        {
            // возвращает true если value удалено
            // иначе false
            return false;
        }

        public PowerSet<T> Intersection(PowerSet<T> set2)
        {
            // пересечение текущего множества и set2
            return null;
        }

        public PowerSet<T> Union(PowerSet<T> set2)
        {
            // объединение текущего множества и set2
            return null;
        }

        public PowerSet<T> Difference(PowerSet<T> set2)
        {
            // разница текущего множества и set2
            return null;
        }

        public bool IsSubset(PowerSet<T> set2)
        {
            // возвращает true, если set2 есть
            // подмножество текущего множества,
            // иначе false
            return false;
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
    }
}
