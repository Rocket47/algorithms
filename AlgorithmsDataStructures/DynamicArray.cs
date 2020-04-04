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
            if (capacity == 0)
            {
                capacity = 16;
            }
            array = new T[capacity];
            T[] newArray = new T[capacity];
            int currentCapacity = capacity;
            if (new_capacity > currentCapacity)
            {
                while (currentCapacity < new_capacity)
                {
                    currentCapacity *= 2;
                }
                newArray = new T[currentCapacity];
                Array.Copy(array, newArray, array.Length);
            }
            else if (new_capacity < currentCapacity)
            {
                while (currentCapacity > new_capacity)
                {
                    var newSize = currentCapacity / 1.5;
                    if (newSize < 16)
                    {
                        currentCapacity = 16;
                        break;
                    }
                    currentCapacity = Convert.ToInt32(newSize);
                }
                newArray = new T[currentCapacity];
                Array.Copy(this.array, newArray, currentCapacity);
            }
            capacity = newArray.Length;
            count = GetCountElementsArr(newArray);
        }

        public int GetCountElementsArr(T[] array)
        {
            int count = 0;
            foreach (T i in array)
            {
                bool resultConvert = int.TryParse(i.ToString(), out int result);
                if (resultConvert && Convert.ToInt32(i) != 0)
                {
                    count++;
                }
            }
            return count;
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

