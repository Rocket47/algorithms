using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{

    public class Node
    {
        public int value;
        public Node next, prev;

        public Node(int _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class LinkedList2
    {
        public Node head;
        public Node tail;

        public LinkedList2()
        {
            head = null;
            tail = null;
        }       

        public void AddInTail(Node _item)
        {
            if (head == null)
            {
                head = _item;
                head.next = null;
                head.prev = null;
            }
            else
            {
                tail.next = _item;
                _item.prev = tail;
            }
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node ResultNode = null;
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    ResultNode = node;
                    return node;
                }
                node = node.next;
            }
            return ResultNode;
        }

        public List<Node> FindAll(int _value)
        {
            List<Node> nodes = new List<Node>();
            Node node = head;
            while (node != null)
            {
                if (node.value == _value)
                {
                    nodes.Add(node);
                }
                node = node.next;
            }
            return nodes;
        }

        public bool Remove(int _value)
        {
            bool result = false;
            Node current = head;
            if (head == null)
            {
                result = true;
                return result;
            }
            if (head.value == _value)
            {
                result = true;
                head = head.next;
                tail.prev = null;
                tail = head;
                if (head != null)
                {
                    Node tmp = head;
                    while (tmp.next != null)
                    {
                        Node prv = tmp;                        
                        tmp = tmp.next;
                        tail = tmp;
                        tail.prev = prv;                        
                    }
                }
                return result;
            }
            while (current.next != null)
            {
                if (current.next.value == _value)
                {
                    current.next = current.next.next;
                    current.next.prev = current;
                    result = true;
                    return result;
                }
                current = current.next;
            }
            return result;
        }

        public void RemoveAll(int _value)
        {
            Node tmpNode = head;
            Node prevNode = null;
            while (tmpNode != null)
            {
                if (tmpNode.value == _value)
                {
                    if (tmpNode == head)
                    {
                        head = head.next;
                        tail = head;
                        if (head != null)
                        {
                            tail.prev = null;
                        }
                    }
                    else
                    {
                        prevNode.next = tmpNode.next;
                        if (tmpNode.next != null)
                        {
                            tmpNode.next.prev = prevNode;
                        }
                    }
                }
                else
                {
                    prevNode = tmpNode;
                }
                tmpNode = tmpNode.next;
                tail = prevNode;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }

        public int Count()
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            if (head == null && tail == null)
            {
                head = _nodeToInsert;
                tail = _nodeToInsert;
            }
            if (_nodeAfter == null)
            {
                head = _nodeToInsert;
                head.prev = null;
            }
            Node current = head;
            if (current == _nodeAfter)
            {
                current.next = _nodeToInsert;
                current.next.prev = current;
            }
            while (current.next != null)
            {
                if (current.next == _nodeAfter)
                {
                    current.next.next = _nodeToInsert;
                    current.next.next.prev = current.next;
                }
                current = current.next;
                tail = current;
            }

        }
    }
}
