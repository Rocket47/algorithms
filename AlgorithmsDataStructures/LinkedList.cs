using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int _value) { value = _value; }
    }

    public class LinkedList
    {
        public Node head;
        public Node tail;

        public LinkedList()
        {
            head = null;
            tail = null;
        }       

        public void AddInTail(Node _item)
        {
            if (head == null) head = _item;
            else tail.next = _item;
            tail = _item;
        }

        public Node Find(int _value)
        {
            Node node = head;
            while (node != null)
            {
                if (node.value == _value) return node;
                node = node.next;
            }
            return null;
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
                return result;
            }
            if (head.value == _value)
            {
                result = true;
                head = head.next;
                if (head == null)
                {
                    tail = null;
                }
                return result;
            }
            while (current.next != null)
            {
                if (current.next.value == _value)
                {
                    current.next = current.next.next;
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
                    }
                    else
                    {
                        prevNode.next = tmpNode.next;
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
            Node current = head;
            int count = 1;
            if (current == null)
            {
                count = 0;
            }
            while (current.next != null)
            {
                count++;
                current = current.next;
            }
            return count;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {
            Node current = head;
            if (_nodeAfter == null)
            {
                head = _nodeToInsert;
            }
            if (current == _nodeAfter)
            {
                current.next = _nodeToInsert;
            }
            while (current.next != null)
            {
                if (current.next == _nodeAfter)
                {
                    current.next.next = _nodeToInsert;
                }
                current = current.next;
            }
        }
    }
}
