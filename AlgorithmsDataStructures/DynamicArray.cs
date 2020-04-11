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

            if (new_capacity < 16)
            {
                capacity = 16;
                return;
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
                    if (Convert.ToInt32(currentCapacity / 1.5) < new_capacity)
                    {
                        break;
                    }
                    var newSize = currentCapacity / 1.5;
                    if (newSize < 16)
                    {
                        currentCapacity = 16;
                        break;
                    }
                    currentCapacity = Convert.ToInt32(newSize);
                    if (Convert.ToInt32(currentCapacity / 1.5) < 16 || Convert.ToInt32(currentCapacity / 1.5) < new_capacity)
                    {
                        break;
                    }
                }
                newArray = new T[currentCapacity];
                Array.Copy(this.array, newArray, currentCapacity);
            }
            capacity = newArray.Length;
            count = Counter<T>.GetCountElementsArr(newArray);
            array = newArray;
        }

        public T GetItem(int index)
        {
            if (index > capacity || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (array[index] != null)
            {
                return array[index];
            }
            return default(T);
        }

        public void Append(T itm)
        {
            if (count == capacity)
            {
                MakeArray(capacity * 2);
            }
            array[count] = itm;
            count++;
        }

        public void Insert(T itm, int index)
        {
            if (index > capacity || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            T[] newArray = new T[capacity];
            if (count + 1 == capacity)
            {
                Array.Copy(array, newArray, capacity);
                capacity *= 2;
                array = new T[capacity];
                Array.Copy(newArray, array, capacity / 2);
                newArray = new T[capacity];
                Array.Copy(array, newArray, capacity);
            }
            int tmp = 0;
            for (int i = 0; i < capacity - 1; i++)
            {
                if (i != index)
                {
                    newArray[tmp] = array[i];
                    tmp++;
                }
                if (i == index && index < count)
                {
                    newArray[tmp] = itm;
                    tmp++;
                    newArray[tmp] = array[i];
                    tmp++;
                }
            }
            if (index >= Counter<T>.GetCountElementsArr(array))
            {
                newArray[Counter<T>.GetCountElementsArr(array)] = itm;
            }
            for (int i = 0; i < newArray.Length; i++)
            {
                array[i] = newArray[i];
            }
            count = Counter<T>.GetCountElementsArr(array);
            Array.Copy(array, newArray, capacity);
        }

        public void Remove(int index)
        {
            if (index > capacity || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (count <= capacity * 0.5 && capacity / 1.5 >= 16)
            {
                capacity = Convert.ToInt32(capacity / 1.5);
            }

            if (count <= capacity * 0.5 && capacity / 1.5 < 16)
            {
                capacity = 16;
            }
            T[] newArray = new T[capacity];
            for (int i = 0; i < capacity; i++)
            {
                if (i == index)
                {
                    for (int j = i; j < capacity - 1; j++)
                    {
                        newArray[j] = array[j + 1];
                    }
                    break;
                }
                newArray[i] = array[i];
            }
            for (int i = 0; i < newArray.Length; i++)
            {
                array[i] = newArray[i];
            }
            count--;
        }
    }

    static class Counter<T>
    {
        public static int GetCountElementsArr(T[] array)
        {
            int count = 0;
            foreach (T i in array)
            {
                if (Convert.ToInt32(i) != 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}


