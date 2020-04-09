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
            array = newArray;
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
            if (index > capacity || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return array[index];
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
            T[] newArray = new T[capacity];
           
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
            if (index >= GetCountElementsArr(array))
            {
                newArray[GetCountElementsArr(array)] = itm;
            }
            for (int i = 0; i < newArray.Length; i++)
            {
                array[i] = newArray[i];
            }
            count = GetCountElementsArr(array);

            foreach (T a in array)
            {
                Console.Write(a + " ");
            }

            if (count == capacity)
            {
                MakeArray(capacity * 2);
            }
           

            Console.WriteLine();
            foreach (T a in array)
            {
                Console.Write(a + " ");
            }
            Console.WriteLine();
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
            DynArray<int> da = new DynArray<int>();
            da.Append(1);                       
            da.Append(2);                       
            da.Append(3);
            da.Insert(4, 0);
            da.Insert(5, 0);
            da.Insert(6, 0);
            da.Insert(7, 0);
            da.Insert(8, 0);
            da.Insert(9, 0);
            da.Insert(3, 0);
            da.Insert(4, 0);
            da.Insert(5, 0);
            da.Insert(6, 0);
            da.Insert(7, 0);
            da.Insert(8, 0);
            da.Insert(9, 0);
            da.Insert(10, 0);
            Console.ReadKey();
        }
    }
}

