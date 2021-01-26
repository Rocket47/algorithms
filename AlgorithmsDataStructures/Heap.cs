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
		}

		public int GetMax()
		{
			// вернуть значение корня и перестроить кучу
			return -1; // если куча пуста
		}

		public bool Add(int key)
		{
			if (key < 0 || HeapArray == null) { return false; }

			var count = HeapArray.Length - 1;

			if (count >= 1)
			{
				if (countInsert < count)
				{
					HeapArray[count] = key;
					countInsert++;
					Shuffle(HeapArray);
					return true;
				}				
			}
			return false; // если куча вся заполнена
		}

		public int[] Shuffle(int[] array)
        {			
			if (array != null)
			{
				var lastPosition = array.Length - 1;
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

	}
}