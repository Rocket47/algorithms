using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class DynArray<T>
    {
        public T[] array;
        public int count;
        public int capacity;

        public DynArray()
        {
            count = 0;
            MakeArray(16);
        }

        public void MakeArray(int new_capacity)
        {
            T[] newArray;
            int currentCapacity = capacity;
            if (new_capacity >= capacity)
            {
                while (currentCapacity < new_capacity)
                {
                    currentCapacity += 16;
                }
                newArray = new T[currentCapacity];
                Array.Copy(array, newArray, capacity);
            }
            else if (new_capacity < currentCapacity)
            {
                while (currentCapacity > new_capacity)
                {
                    var newSize = currentCapacity / 1.5;
                    if (newSize < 16)
                    {
                        break;
                    }
                    currentCapacity = Convert.ToInt32(currentCapacity / 1.5);
                }
                newArray = new T[currentCapacity];
                Array.Copy(array, newArray, capacity);
            }
        }

        public T GetItem(int index)
        {
            // ваш код
            return default(T);
        }

        public void Append(T itm)
        {
            // ваш код
        }

        public void Insert(T itm, int index)
        {
            // ваш код
        }

        public void Remove(int index)
        {
            // ваш код
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

