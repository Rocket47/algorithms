using System;

namespace AlgorithmsDataStructures2
{
	public static class BalancedBST
	{
		public static int[] GenerateBBSTArray(int[] a)
		{
			if (a != null)
			{
				var sourceArray = new int[a.Length];
				int depth = -1;
				Array.Copy(a, sourceArray, a.Length);
				Array.Sort(sourceArray);
				for (int size = sourceArray.Length; size != 0; depth++)
				{
					size /= 2;
				}

				double newSize = Math.Round(Math.Pow(2, (depth + 1)) - 1);
				var resultArray = new int[(int)newSize];

				if (resultArray.Length == sourceArray.Length)
				{
					RecursiveArrayCut(resultArray, sourceArray, 0);
					return resultArray;
				}
			}
			return null;
		}

		public static void RecursiveArrayCut(int[] resultArray, int[] sourceArray, int positionHead)
		{
			var srcLengthHalf = sourceArray.Length / 2;
			resultArray[positionHead] = sourceArray[srcLengthHalf];
			if (sourceArray.Length == 1) { return; }
			int[] sideArray = new int[srcLengthHalf];

			Array.Copy(sourceArray, 0, sideArray, 0, srcLengthHalf);
			RecursiveArrayCut(resultArray, sideArray, positionHead * 2 + 1);

			Array.Copy(sourceArray, srcLengthHalf + 1, sideArray, 0, srcLengthHalf);
			RecursiveArrayCut(resultArray, sideArray, positionHead * 2 + 2);
		}
	}
}