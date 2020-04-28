using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    class Deque<T>
    {
        public List<T> deque;
        int index;
        public Deque()
        {
            deque = new List<T>();
            index = 0;
        }

        //*///////////////////////////////////////
        public void AddFront(T item)
        {
            if (deque.Count == 0)
            {
                deque.Add(item);
                return;
            }

            if (deque.Count != 0)
            {
                List<T> demo = new List<T>();
                demo.Add(item);
                foreach (T tmp in deque)
                {
                    demo.Add(tmp);
                }
                deque.Clear();
                deque = demo;
            }
        }

        //*///////////////////////////////////////
        public void AddTail(T item)
        {
            deque.Add(item);// добавление в хвост
        }

        //*///////////////////////////////////////
        public T RemoveFront()
        {
            if (deque.Count > 0)
            {
                T item = deque[0];
                deque.Remove(item);
                return item;
            }
            return default(T);
        }

        //*///////////////////////////////////////
        public T RemoveTail()
        {
            index = Size() - 1;
            if (index >= 0)
            {
                T saveItem = deque[index];
                deque.RemoveAt(index);
                return saveItem;
            }
            return default(T); 
        }

        //*///////////////////////////////////////
        public int Size()
        {
            int count = 0;
            foreach (T item in deque)
            {
                count++;
            }
            if (count > 0)
            {
                return count;
            }
            return 0;
        }        
    }
}
