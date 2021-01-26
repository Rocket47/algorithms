using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public class Heap
	{

		public int[] HeapArray; // хранит неотрицательные числа-ключи
		int countInsert = 0;

		public Heap() { HeapArray = null; }

		public void MakeHeap(int[] a, int depth)
		{
            if (a == null) { return; }

            if (depth < 0) { return; }

            int heapArraySize;
            if (depth == 0)
            {
                heapArraySize = 1;
            }
            else
            {
                var power = depth + 1;
                heapArraySize = (int)Math.Pow(2, power) - 1;
            }
            HeapArray = new int[heapArraySize];
			for (int i = 0; i < a.Length; i++)
			{
				Add(a[i]);
			}
		}

		public int GetMax()
		{			
			if (HeapArray[0] == 0)
			{
				return -1; // если куча пуста
			}
			else
			{
				int max = HeapArray[0];
				HeapArray[0] = HeapArray[GetIndexNotNull(HeapArray)];
				HeapArray[GetIndexNotNull(HeapArray)] = 0;
				SiftDown(0);
				return max;
			}
		}

		public void SiftDown(int index)
		{
			int temp;
			while (2 * index + 1 < GetIndexLastElement(HeapArray))
			{
				int left = 2 * index + 1;
				int right = 2 * index + 2;
				int j = left;
				if (HeapArray[right] > HeapArray[left])
				{
					j = right;
				}
				if (HeapArray[index] >= HeapArray[j])
				{
					break;
				}
				else
				{
					temp = HeapArray[index];
					HeapArray[index] = HeapArray[j];
					HeapArray[j] = temp;
				}
				index = j;
			}
		}

		public int GetIndexNotNull(int[] a)
		{
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] == 0) return i - 1;

			}
			return a.Length - 1;
		}

		public bool Add(int key)
		{
			if (key < 0 || HeapArray == null) { return false; }

			var count = HeapArray.Length - 1;

			if (count == 0)
            {
				HeapArray[0] = key;
				return true;
            }

			if (count >= 1)
			{
				if (countInsert < count)
				{
					HeapArray[countInsert] = key;
					countInsert++;
					HeapArray = ShuffleAdd(HeapArray);
					return true;
				}				
			}
			return false; // если куча вся заполнена
		}

		public int[] ShuffleAdd(int[] array)
        {			
			if (array != null)
			{
				var lastPosition = GetIndexLastElement(array);
				while (true)
				{					
					var parent = (int)Math.Floor((double)(lastPosition - 1) / 2);
					if (parent < 0) { break; }
					if (array[lastPosition] > array[parent])
					{
						int tmp = array[parent];
						array[parent] = array[lastPosition];
						array[lastPosition] = tmp;
						lastPosition = parent;
					}
					else
                    {
						break;
                    }
				}
			}
			return array;
        }

		public int GetIndexLastElement(int[] array)
        {
			int index = 0;
			foreach (int tmp in array)
            {
				if (tmp == 0)
                {
					return --index;
                }
				index++;
            }
			return --index;
        }

	}
}