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

        public static void Main(string[] args)
        {

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
                head = head.next;
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
            Node current = head;
            if (head == null)
            {
                return;
            }
            while (head.value == _value)
            {
                head = head.next;
                return;
            }
            while (current.next != null)
            {
                while (current.next.value == _value)
                {
                    current.next = current.next.next;
                }
                current = current.next;
            }
        }

        public void Clear()
        {

        }

        public int Count()
        {
            return 0;
        }

        public void InsertAfter(Node _nodeAfter, Node _nodeToInsert)
        {

        }
    }
}
