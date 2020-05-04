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
                // -1 если v1 < v2
                // 0 если v1 == v2
                // +1 если v1 > v2
            }
            return result;
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

            if (_ascending)
            {
                int result1 = (Compare(value, head.value));
                if (head != null && head.next == null && (result1 == 1 || result1 == 0))
                {
                    head.next = tmp;                    
                    return;
                }

                if (head != null && (result1 == -1))
                {
                    Node<T> saveFirstHead = head;
                    head = tmp;
                    tmp.next = saveFirstHead;
                }

                if (head != null && head.next != null)
                {
                    Node<T> headNode = head;
                    Node<T> headPosition = null;
                    while (headNode != null)
                    {
                        int result2 = Compare(value, headNode.value);

                        if (result2 == 1 || result2 == 0)
                        {
                            headPosition = headNode;
                        }
                        headNode = headNode.next;
                    }
                    headNode = headPosition;
                    Node<T> saveNode = headNode.next;
                    headNode.next = tmp;
                    tmp.next = saveNode;
                }
            }
            else
            {
                if (head != null && head.next == null)
                {
                    int resultFalse = Compare(head.value, value);
                    if (resultFalse == -1)
                    {
                        Node<T> saveHead = head;
                        head = tmp;
                        head.next = saveHead;
                        return;
                    }

                    if (resultFalse == 0 || resultFalse == 1)
                    {
                        head.next = tmp;
                        return;
                    }
                }

                if (head != null && head.next != null)
                {
                    Node<T> headNode = head;
                    Node<T> headPosition = null;
                    while (headNode != null)
                    {
                        int result2 = Compare(headNode.value, value);

                        if (result2 == 1 || result2 == 0)
                        {
                            headPosition = headNode;
                        }
                        else
                        {
                            if (headPosition == null)
                            {
                                head = tmp;
                                tmp.next = headNode;
                                return;
                            }
                        }
                        headNode = headNode.next;
                    }
                    headNode = headPosition;

                    Node<T> saveNode = headNode.next;
                    headNode.next = tmp;
                    tmp.next = saveNode;

                }
            }
        }

        //*////////////////////////////////////////
        public Node<T> Find(T val)
        {
            Node<T> HeadNode = head;
            while (HeadNode != null)
            {
                int result = Compare(HeadNode.value, val);
                if (result == 0)
                {
                    return HeadNode;
                }
                else
                {
                    HeadNode = HeadNode.next;
                }
            }
            return null; // здесь будет ваш код
        }

        //*////////////////////////////////////////
        public void Delete(T val)
        {
            Node<T> currentHead = head;           

            while (currentHead != null)
            {
                int result = Compare(currentHead.value, val);
                if (result == 0 && currentHead.prev == null)
                {                    
                    currentHead = currentHead.next;                    
                    head = currentHead;
                    return;
                }
                if (result == 0)
                {                    
                    if (currentHead.next != null && currentHead.prev != null)
                    {
                        
                        return;
                    }                    
                    else
                    {
                        currentHead = null;
                        return;
                    }
                }
                currentHead.prev = currentHead;
                currentHead = currentHead.next;
            }
        }

        //*////////////////////////////////////////
        public void Clear(bool asc)
        {
            _ascending = asc;
            if (_ascending)
            {
                head = null;
                tail = null;
            }// здесь будет ваш код
        }

        //*////////////////////////////////////////
        public int Count()
        {
            Node<T> currentHead = head;
            int count = 0;
            while (currentHead != null)
            {
                count++;
                currentHead = currentHead.next;
            }
            return count; // здесь будет ваш код подсчёта количества элементов в списке
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
