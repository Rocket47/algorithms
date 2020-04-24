using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Stack<T>
    {
        public List<T> stack;
        int index;
        public Stack()
        {
            stack = new List<T>();
            index = 0;// инициализация внутреннего хранилища стека
        }
        //*////////////////////////////////////////////////////
        public int Size()
        {
            int count = 0;
            foreach (var tmp in stack)
            {
                count++;
            }
            if (count > 0)
            {
                return count;
            }		  
            return 0;
        }
        //*////////////////////////////////////////////////////
        public T Pop()
        {
            index = Size() - 1;
            if (index >= 0)
            {
                T val = stack[index];
                stack.Remove(val);
                return val;
            }
            return default(T); // null, если стек пустой
        }
        //*////////////////////////////////////////////////////
        public void Push(T val)
        {           
            stack.Add(val);                   
        }
        //*////////////////////////////////////////////////////
        public T Peek()
        {
            index = Size() - 1;
            if (index >= 0)
            {
                return stack[index];
            }
            return default(T); // null, если стек пустой
        }       
    }

}
