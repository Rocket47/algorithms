using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
                string V1 = v1.ToString();
                string V2 = v2.ToString();
                V1 = V1.TrimStart(' ').TrimEnd(' ');
                V2 = V2.TrimStart(' ').TrimEnd(' ');
                char[] charArrV1 = V1.ToCharArray();
                char[] charArrV2 = V2.ToCharArray();
                int lengthArr;
                if (charArrV1.Length < charArrV2.Length)
                {
                    lengthArr = charArrV1.Length;
                }
                else
                {
                    lengthArr = charArrV2.Length;
                }                
                for (int i = 0; i < lengthArr; i++)
                {
                    if (charArrV1[i] < charArrV2[i])
                    {
                        return -1;
                    }
                    if (charArrV1[i] > charArrV2[i])
                    {
                        return 1;
                    }                    
                }
                if (result == 0 && charArrV1.Length == charArrV2.Length)
                {
                    result = 0;
                }
                if (result == 0 && charArrV1.Length < charArrV2.Length)
                {
                    result = -1;
                }
                if (result == 0 && charArrV1.Length > charArrV2.Length)
                {
                    result = 1;
                }
                return result;
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
                tail = tmp;
                head.next = null;
                tail.prev = null;
                return;
            }

            if (_ascending)
            {
                int result1 = (Compare(value, head.value));
                if (head != null && head.next == null && (result1 == 1 || result1 == 0))
                {
                    head.next = tmp;
                    tail = tmp;
                    tmp.prev = head;
                    return;
                }

                if (head != null && (result1 == -1))
                {
                    Node<T> saveFirstHead = head;
                    head = tmp;
                    saveFirstHead.prev = tmp;
                    tmp.next = saveFirstHead;
                    return;
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
                    tmp.prev = headNode;
                    tmp.next = saveNode;
                    if (saveNode != null)
                    {
                        saveNode.prev = tmp;
                        if (tmp.next.next == null)
                        {
                            tail = tmp.next;
                        }
                    }
                    else
                    {
                        tail = tmp;

                    }
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
                        tmp.next = saveHead;
                        tmp.next.prev = tmp;
                        tail = saveHead;
                        tail.prev = head;
                        return;
                    }

                    if (resultFalse == 0 || resultFalse == 1)
                    {
                        head.next = tmp;
                        tail = tmp;
                        tmp.prev = head;
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
                                tmp.next.prev = tmp;                                                                                             
                                return;
                            }
                        }
                        headNode = headNode.next;
                    }
                    headNode = headPosition;

                    Node<T> saveNode = headNode.next;
                    headNode.next = tmp;
                    tmp.prev = headNode;
                    tmp.next = saveNode;
                    if (saveNode != null)
                    {
                        saveNode.prev = tmp;
                        if (tmp.next.next == null)
                        {
                            tail = tmp.next;
                        }
                    }
                    else
                    {
                        tail = tmp;

                    }
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
            Node<T> current = head;
            int resultDelete = -2;

            if (GetAll().Count != 0)
            {
              resultDelete = Compare(current.value, val);
            }
            else
            {
                return;
            }

            if (current.next == null && resultDelete == 0)
            {
                head = null;
                tail = null;
                return;
            }

            if (head.prev == null && resultDelete == 0)
            {
                head = head.next;
                head.prev = null;
                if (head.next == null)
                {
                    tail = head;
                    tail.prev = null;
                }
                return;
            }
           
            while (current != null)
            {
                resultDelete = Compare(current.value, val);
                if (resultDelete == 0)
                {
                    current.prev.next = current.next;                        
                    if (current.next == null)
                    {
                        tail = current.prev;
                        return;
                    }
                    current.next.prev = current.prev;
                    return;
                }
                
                current = current.next;
            }
            
        }

        //*////////////////////////////////////////
        public void Clear(bool asc)
        {
            _ascending = asc;
            head = null;
            tail = null;
            // здесь будет ваш код
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
