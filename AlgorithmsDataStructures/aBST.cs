using System;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей

        public aBST(int depth)
        {
            // правильно рассчитайте размер массива для дерева глубины depth:
            int tree_size = (int)Math.Pow(2, depth + 1) - 1;
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++) Tree[i] = null;
        }

        public int? FindKeyIndex(int key)
        {
            if (Tree[0] == null) return null;
            // ищем в массиве индекс ключа
            int indexSearch = 0;
            while (indexSearch < Tree.Length)
            {
                if (Tree[indexSearch] == null)
                {
                    return -indexSearch;
                }
                if (key > Tree[indexSearch])
                {
                    //go to right child
                    indexSearch = 2 * indexSearch + 2;
                }
                else if (key < Tree[indexSearch]) 
                {
                    //go to left child
                    indexSearch = 2 * indexSearch + 1;
                }
                else
                {
                    return indexSearch;
                }
            }
            return null; // не найден
        }

        public int AddKey(int key)        
        {
            if (Tree[0] == null)
            {
                Tree[0] = key;
                return 0;
            }
            int? foundIndex = FindKeyIndex(key);
            int mainIndexNotNull = foundIndex ?? -1;
            

            if (foundIndex == null)
            {
                return -1;
            }

            if (mainIndexNotNull <= 0)
            {
                if (Tree[0] == null)
                {
                    Tree[0] = key;
                    return 0;
                }
                Tree[0 - (mainIndexNotNull)] = key;
                return mainIndexNotNull;
            }
            return mainIndexNotNull;
            // индекс добавленного/существующего ключа или -1 если не удалось
        }       
    }
}