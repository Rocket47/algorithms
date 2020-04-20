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

            if (new_capacity == 16 && count != 0 && new_capacity > count)
            {               
                array = CopyArrayToNewSize(array, count, new_capacity);
                capacity = 16;
                return;
            }
            if (new_capacity == 16 && new_capacity > count)
            {
                capacity = 16;
                array = new T[new_capacity];
            }
            if (new_capacity > capacity && count == 0)
            {
                while (capacity < new_capacity)
                {
                    capacity = capacity * 2;
                }              
                array = new T[capacity];
                return;
            }     
            
            if (new_capacity > capacity && count != 0)
            {
                array = CopyArrayToNewSize(array, count, capacity * 2);
                capacity = capacity * 2;
                return;
            }
            
            if (new_capacity < capacity && count == 0)
            {        
                if (new_capacity < 16)
                {
                    capacity = 16;
                }
                while (Convert.ToInt32(capacity / 1.5) > new_capacity && Convert.ToInt32(capacity / 1.5) >= 16)
                {
                    capacity = Convert.ToInt32(capacity / 1.5);
                }
                array = new T[capacity];
                return;
            }

            if (new_capacity < capacity &&  count != 0)
            {               
                    if (new_capacity < 16)
                    {
                        capacity = 16;
                    }
                    if (new_capacity > count)
                    {
                        while (Convert.ToInt32(capacity / 1.5) > new_capacity && Convert.ToInt32(capacity / 1.5) > count && Convert.ToInt32(capacity / 1.5) >= 16)
                        {
                            capacity = Convert.ToInt32(capacity / 1.5);
                            if (capacity < 16)
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

            if (index < 0 || index > count || index > capacity)
            {
                throw new ArgumentOutOfRangeException();
            }
            return default(T);
        }

        public void Append(T itm)
        {
            if (count == 0)
            {
                array[0] = itm;
                count++;
                return;
            }

            count = count + 1;            
            if (count > capacity)
            {
                MakeArray(capacity * 2);
               
            }
            array[count - 1] = itm;
        }

        public void Insert(T itm, int index)
        {
            if (count == 0 && index == 0)
            {
                Append(itm);
                return;
            }

            if (count == 0 && index != 0)
            {
                throw new ArgumentOutOfRangeException();
            }

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
                    array = ShiftArrayToRightSide(array, index, capacity, itm);
                }
                if (count < capacity)
                {
                    array = ShiftArrayToRightSide(array, index, capacity, itm);
                }
                if (count == capacity)
                {
                    array = ShiftArrayToRightSide(array, index, capacity, itm);
                }
                return;
            }

            if (index >= 0 && count == 0)
            {
                array[0] = itm;
                return;
            }

            if (index == count)
            {                
                return;
            }
        }

        public void Remove(int index)
        {
            if (index >= count || index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }            
            count = count - 1;
            if ((count * 100 / capacity) < 50)
            {
                while (Convert.ToInt32(capacity / 1.5) >= count)
                {
                    if (Convert.ToInt32(capacity / 1.5) <= 16)
                    {
                        capacity = 16;
                        break;
                    }
                    capacity = Convert.ToInt32(capacity / 1.5);
                }
            }
            T[] ArrayForCopy = array;
            array = new T[capacity];
            array = ShiftArrayToLeftSide(ArrayForCopy, index, capacity);
        }

        public T[] CopyArrayToNewSize(T[] oldArray, int count, int new_capacity)
        {
            T[] newArray = new T[new_capacity];
            if (new_capacity > capacity)
            {
                Array.Copy(oldArray, newArray, oldArray.Length);
            }
            if (new_capacity <= capacity)
            {
                Array.Copy(oldArray, newArray, new_capacity);
            }
            
            return newArray;
        }

        public T[] ShiftArrayToRightSide(T[] oldArray, int index, int capacity, T item)
        {
            T[] newArray = new T[capacity];
            int NewArrayCount = 0;
            for (int i = 0; i < capacity; i++)
            {
                if (i == index)
                {                    
                        newArray[NewArrayCount] = item;
                        NewArrayCount++;
                    if (NewArrayCount < capacity)
                    {
                        newArray[NewArrayCount] = oldArray[i];
                        NewArrayCount++;
                    }
                    continue;
                }
                if (i != index)
                {                  
                    if (NewArrayCount < capacity)
                    {
                        newArray[NewArrayCount] = oldArray[i];
                    }                   
                }
                NewArrayCount++;
            }
            return newArray;
        }

        public T[] ShiftArrayToLeftSide(T[] oldArray, int index, int capacity)
        {
            int NewArrayCount = 0;
            T[] newArray = new T[capacity];
            for (int i = 0; i < count; i++)
            {                
                if (i == index)
                {
                    NewArrayCount++;
                    newArray[i] = oldArray[NewArrayCount];                    
                }
                if (i != index)
                {
                    newArray[i] = oldArray[NewArrayCount];
                }
                NewArrayCount++;
            }           
            return newArray;
        }
    }
}
