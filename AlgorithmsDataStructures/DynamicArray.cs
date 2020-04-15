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
            capacity = 16;
            if (new_capacity > capacity && count == 0)
            {
                capacity = capacity * 2;
                array = new T[new_capacity];
            }     
            
            if (new_capacity > capacity && count != 0)
            {
                array = CopyArrayToNewSize(array, count, capacity * 2);
                capacity = capacity * 2;
            }
            
            if (new_capacity < capacity && count == 0)
            {        
                if (new_capacity < 16)
                {
                    capacity = 16;
                }
                while (Convert.ToInt32(capacity / 1.5) > count && Convert.ToInt32(capacity / 1.5) >= 16)
                {
                    capacity = Convert.ToInt32(capacity / 1.5);
                }
                array = new T[capacity];
            }

            if (new_capacity < capacity &&  count != 0)
            {
                if (new_capacity < 16)
                {
                    capacity = 16;
                }
                if (new_capacity > count)
                {
                    while (Convert.ToInt32(capacity / 1.5) > count && count >= 16)
                    {
                        capacity = Convert.ToInt32(capacity / 1.5);
                        if (Convert.ToInt32(capacity / 1.5) < 16)
                        {
                            capacity = 16;
                            break;
                        }
                    }
                    array = CopyArrayToNewSize(array, count, capacity);
                }
                else if (new_capacity < count)
                {
                    throw new ArgumentOutOfRangeException();
                }                
                else { }
            }          
        }

        public T GetItem(int index)
        {
            if (index >= 0 && index < count)
            {
                return array[index];
            }

            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException();
            }
            return default(T);
        }

        public void Append(T itm)
        {
            count = count + 1;
            if (count > capacity)
            {
                MakeArray(capacity * 2);
               
            }
            array[count - 1] = itm;
        }

        public void Insert(T itm, int index)
        {
            if (index > count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (0 <= index && index <= count)
            {
                count = count + 1;
                if (count > capacity)
                {
                    MakeArray(capacity * 2);
                    ShiftArrayToRightSide(array, index, capacity / 2, itm);
                }
                if (count < capacity)
                {
                    ShiftArrayToRightSide(array, index, capacity / 2, itm);
                }               
            }

            if (index >= 0 && count == 0)
            {
                array[0] = itm;
            }

            if (index == count)
            {
                array[count - 1] = itm;
            }
        }

        public void Remove(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }            
            count = count - 1;
           while (count < capacity && capacity >= 16)
            {
                if (count < Convert.ToInt32(capacity * 0.5))
                {
                    capacity = Convert.ToInt32(capacity / 1.5);
                }
            }
            MakeArray(capacity);
            ShiftArrayToLeftSide(array, index, capacity);
        }

        public T[] CopyArrayToNewSize(T[] oldArray, int count, int new_capacity)
        {
            T[] newArray = new T[new_capacity];
            Array.Copy(oldArray, newArray, count);
            return newArray;
        }

        public T[] ShiftArrayToRightSide(T[] oldArray, int index, int capacity, T item)
        {
            T[] newArray = new T[capacity];
            for (int i = 0; i < capacity + 1; i++)
            {
                if (i == index)
                {
                    newArray[i] = item;
                    continue; 
                }
                newArray[i] = oldArray[i];               
            }
            return newArray;
        }

        public T[] ShiftArrayToLeftSide(T[] oldArray, int index, int capacity)
        {
            T[] newArray = new T[capacity];
            for (int i = 0; i < capacity; i++)
            {                
                if (i == index)
                {                    
                    i++;
                    newArray[i] = array[i];
                    continue;
                }
                newArray[i] = oldArray[i];
            }
            return newArray;
        }
    }
}