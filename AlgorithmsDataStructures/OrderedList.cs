using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;

        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;

        public OrderedList(bool asc)
        {
            head = null;
            tail = null;
            _ascending = asc;
        }
        //*////////////////////////////////////////
        public int Compare(T v1, T v2)
        {
            int result = 0;
            if (typeof(T) == typeof(String))
            {
                // версия для лексикографического сравнения строк
            }
            else
            {
                int number1 = (int)(object)v1;
                int number2 = (int)(object)v2;
                if (number1 < number2)
                {
                    result = -1;
                }
                else if (number1 > number2)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
            // -1 если v1 < v2
            // 0 если v1 == v2
            // +1 если v1 > v2
        }

        //*////////////////////////////////////////
        public void Add(T value)
        {
            Node<T> tmp = new Node<T>(value);
            if (head == null)
            {
                head = tmp;
                return;
            }

            if (head != null && head.next == null)
            {
                head.next = tmp;
                return;
            }

            if (head != null && head.next != null)
            {
                Node<T> headNode = head;
                Node<T> headPosition = null;                     
                while (headNode != null)
                {
                    int result = Compare(value, headNode.value);

                    if (result == 1 || result == 0)
                    {
                        headPosition = headNode;                                          
                    }
                    headNode = headNode.next;
                }
                headNode = headPosition;
                Node<T> saveNode = headNode.next;
                headNode.next = tmp;
                tmp.next = saveNode;
                Console.WriteLine("head value " + head.value);
            }
        }

        //*////////////////////////////////////////
        public Node<T> Find(T val)
        {
            return null; // здесь будет ваш код
        }

        //*////////////////////////////////////////
        public void Delete(T val)
        {
            // здесь будет ваш код
        }

        //*////////////////////////////////////////
        public void Clear(bool asc)
        {
            _ascending = asc;
            // здесь будет ваш код
        }

        //*////////////////////////////////////////
        public int Count()
        {
            return 0; // здесь будет ваш код подсчёта количества элементов в списке
        }

        List<Node<T>> GetAll() // выдать все элементы упорядоченного 
                               // списка в виде стандартного списка
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
    }
}
