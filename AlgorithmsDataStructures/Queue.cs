using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Queue<T>
    {
        public List<T> queue;        
        public Queue()
        {
            queue = new List<T>();            
        }

        public void Enqueue(T item)
        {
            queue.Add(item);
        }

        public T Dequeue()
        {
            if (queue.Count > 0)
            {
                T item = queue[0];
                queue.Remove(item);
                return item;
            }           
            return default(T); 
        }

        public int Size()
        {
            int count = 0;
            foreach (T item in queue)
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