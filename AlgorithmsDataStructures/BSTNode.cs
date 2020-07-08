using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если в дереве вообще нету узлов
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind() { Node = null; }
    }

    public class BST<T>
    {
        public BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        //@/////////////////////////////////////////////////////////
        public BSTFind<T> FindNodeByKey(int key)
        {
            BSTNode<T> head = Root;
            BSTFind<T> findNode = new BSTFind<T>();

            if (head == null) { return null; }
           
            while (head != null)
            {
                if (key == head.NodeKey)
                {
                    findNode.Node = head;
                    findNode.NodeHasKey = true;
                    findNode.ToLeft = false;
                    return findNode;
                }

                BSTNode<T> prev;
                if (key < head.NodeKey)
                {
                    prev = head;
                    head = head.LeftChild;
                    if (head == null)
                    {
                        findNode.Node = prev;
                        findNode.NodeHasKey = false;
                        findNode.ToLeft = true;
                        return findNode;
                    }
                }
                else
                {
                    prev = head;
                    head = head.RightChild;
                    if (head == null)
                    {
                        findNode.Node = prev;
                        findNode.NodeHasKey = false;
                        findNode.ToLeft = false;
                        return findNode;
                    }
                }
            }            
            return null;
        }
        //@/////////////////////////////////////////////////////////
        public bool AddKeyValue(int key, T val)
        {            
            BSTNode<T> head = Root;
            BSTFind<T> foundNode = FindNodeByKey(key);
            if (head == null)
            {
                Root = new BSTNode<T>(key, val, null);
                return true;
            }
            if (foundNode.NodeHasKey) { return false; }

            if (!foundNode.NodeHasKey && foundNode.ToLeft)
            {
                foundNode.Node.LeftChild = new BSTNode<T>(key, val, foundNode.Node);
                return true;
            }

            if (!foundNode.NodeHasKey && !foundNode.ToLeft)
            {
                foundNode.Node.RightChild = new BSTNode<T>(key, val, foundNode.Node);
                return true;
            }
            return false; 
        }
        //@/////////////////////////////////////////////////////////
        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            BSTNode<T> head = Root;
            BSTNode<T> result = null;
            BSTFind<T> foundNode = FindNodeByKey(FromNode.NodeKey);
           
            if (head == null) { return null; }

            if (!foundNode.NodeHasKey) { return default; }

            if (FindMax)
            {
                result = findMax(FromNode);
            }
            if (!FindMax)
            {
                result = findMin(FromNode);                
            }
            return result;
        }
        //@/////////////////////////////////////////////////////////
        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            return false; // если узел не найден
        }
        //@/////////////////////////////////////////////////////////
        public int Count()
        {
            int count = 0;
            BSTNode<T> currentRoot = Root;

            if (currentRoot == null)
            {
                return 0;
            }

            count = getCountRecursive(Root);
            return count; // количество узлов в дереве
        }

        //@////////////////////////////////////////////////////////////////////////////
        public int getCountRecursive(BSTNode<T> node)
        {
            int count = 0;
            BSTNode<T> currentRoot = node;

            if (currentRoot == null)
            {
                return 0;
            }
            if (currentRoot.LeftChild == null && currentRoot.RightChild == null)
            {
                return 1;
            }

            if (currentRoot.LeftChild != null || currentRoot.RightChild != null)
            {
                count++;
            }

            count += getCountRecursive(currentRoot.LeftChild) + getCountRecursive(currentRoot.RightChild);
            return count; // количество узлов в дереве
        }
        //@////////////////////////////////////////////////////////////////////////////
        public BSTNode<T> findMin(BSTNode<T> minNode)
        {
            if (minNode == null)
            {
                return null;
            }
            else if (minNode.LeftChild == null)
            {
                return minNode;
            }
            else
            {
                return findMin(minNode.LeftChild);
            }
        }
        //@////////////////////////////////////////////////////////////////////////////
        public BSTNode<T> findMax(BSTNode<T> maxNode)
        {
            if (maxNode == null)
            {
                return null;
            }
            else if (maxNode.RightChild == null)
            {
                return maxNode;
            }
            else
            {
                return findMax(maxNode.RightChild);
            }
        }

    }
}

