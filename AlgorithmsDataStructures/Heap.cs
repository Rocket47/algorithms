using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public class Heap
	{
		public int[] HeapArray; // хранит неотрицательные числа-ключи		

		public Heap() { HeapArray = null; }

		public void MakeHeap(int[] a, int depth)
		{			
			int heapArraySize;

			int power = 0;
			if (depth >= 0)
			{
				power = depth + 1;
			}
		    heapArraySize = (int)Math.Pow(2, power) - 1;		
			HeapArray = new int[heapArraySize];
			if (a != null)
			{
				for (int i = 0; i < a.Length; i++)
				{
					Add(a[i]);
				}
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
			if (HeapArray[0] == 0)
			{
				HeapArray[0] = key;
				return true;
			}

			int index = GetIndexNull(HeapArray);
			if (index != -1)
			{
				HeapArray[index] = key;
				ShuffleAdd(index);
				return true;
			}
			else
			{
				return false;
			}
		}

		public void ShuffleAdd(int index)
		{
			int temp;
			while (HeapArray[index] > HeapArray[(index - 1) / 2])
			{
				temp = HeapArray[(index - 1) / 2];
				HeapArray[(index - 1) / 2] = HeapArray[index];
				HeapArray[index] = temp;
				index = (index - 1) / 2;
			}
		}

		public int GetIndexNull(int[] a)
		{
			for (int i = 0; i < a.Length; i++)
			{
				if (a[i] == 0) return i;

			}
			return -1;
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