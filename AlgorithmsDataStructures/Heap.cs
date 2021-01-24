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

			return false; // если куча вся заполнена
		}

	}
}