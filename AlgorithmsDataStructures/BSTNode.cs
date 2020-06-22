using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices.WindowsRuntime;

namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	
        public string result = null;

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
        BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }



        //@////////////////////////////////////////////////////////////////////////////
        public BSTFind<T> FindNodeByKey(int key) // ищем в дереве узел и сопутствующую информацию по ключу
        {
            BSTFind<T> bSTFind = new BSTFind<T>();
            BSTNode<T> nodeSearch = Root;
            BSTNode<T> parentNode = Root.Parent;

            //if (Count() == 0) { bSTFind.Node = null; }            
            while (nodeSearch != null)
            {
                if (key == nodeSearch.NodeKey)
                {
                    bSTFind.Node = nodeSearch;
                    bSTFind.NodeHasKey = true;
                    return bSTFind;
                }

                if (key < nodeSearch.NodeKey)
                {
                    parentNode = nodeSearch;
                    nodeSearch = nodeSearch.LeftChild;
                    bSTFind.Node = parentNode;
                    bSTFind.NodeHasKey = false;
                    bSTFind.ToLeft = true;
                }
                else
                {
                    parentNode = nodeSearch;
                    nodeSearch = nodeSearch.RightChild;
                    bSTFind.Node = parentNode;
                    bSTFind.NodeHasKey = false;
                    bSTFind.ToLeft = false;
                }
            }
            return bSTFind;
        }

        //@////////////////////////////////////////////////////////////////////////////
        public bool AddKeyValue(int key, T val)
        {
            if (Root == null)
            {
                Root = new BSTNode<T>(key, val, null);
                return true;
            }
            if (Root.LeftChild == null && key < Root.NodeKey)
            {
                Root.LeftChild = new BSTNode<T>(key, val, Root);
                return true;
            }
            if (Root.RightChild == null && key > Root.NodeKey)
            {
                Root.RightChild = new BSTNode<T>(key, val, Root);
                return true;
            }
            BSTFind<T> bSTFind = FindNodeByKey(key);
            if (!bSTFind.NodeHasKey)
            {
                if (bSTFind.ToLeft)
                {
                    bSTFind.Node.LeftChild = new BSTNode<T>(key, val, bSTFind.Node);
                }
                else
                {
                    bSTFind.Node.RightChild = new BSTNode<T>(key, val, bSTFind.Node);
                }
                return true;
            }
            return false; // если ключ уже есть
        }

        //@////////////////////////////////////////////////////////////////////////////
        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            if (!FindNodeByKey(FromNode.NodeKey).NodeHasKey) { return null; }
            BSTNode<T> current = FromNode;          
            if (FromNode == null) { return null; }
            if (!FindMax)
            {
                while (current.LeftChild != null)
                {
                    current = current.LeftChild;
                }
                return current;
            }
            else
            {
                while (current.RightChild != null)
                {
                    current = current.RightChild;
                }
                return current;
            }
        }

        //@////////////////////////////////////////////////////////////////////////////
        public bool DeleteNodeByKey(int key)
        {
            if (Root == null) { return false; }
            bool left = true;
            BSTNode<T> node = FindNodeByKey(key).Node;
            BSTNode<T> parent = node.Parent;            
            if (node == null)
            {
                return false;
            }          
                
            if (parent != null)
            {
                if (parent.LeftChild == null || parent.LeftChild.NodeKey != key)
                {
                    left = false;
                }
            }
                 
            if (node.LeftChild == null && node.RightChild == null)
            {                
                if (parent == null)
                {
                    Root = null;
                    return true;
                }
                if (left)
                {
                    parent.LeftChild = null;
                }
                else
                {
                    parent.RightChild = null;
                }
                return true;
            }
            if (node.LeftChild != null && node.RightChild == null)
            {                
                if (parent == null)
                {
                    Root = null;
                    return true;
                }
                if (left)
                {
                    parent.LeftChild = null;
                }
                else
                {
                    parent.RightChild = null;
                }

                return true;
            }

            if (node.RightChild != null && node.LeftChild == null)
            {
                if (parent == null)
                {
                    Root = null;
                    return true;
                }
                if (left)
                {
                    parent.LeftChild = null;
                }
                else
                {
                    parent.RightChild = null;
                }

                return true;
            }
            if (node.RightChild != null && node.LeftChild != null)
            {
                BSTNode<T> currentNode = node.RightChild;
                while (currentNode != null)
                {
                    if (currentNode.LeftChild == null && currentNode.RightChild == null)
                    {
                        node = currentNode;
                        node.Parent = parent;
                        if (parent != null)
                        {
                            if (left)
                            {
                                parent.LeftChild = node;
                            }
                            else
                            {
                                parent.RightChild = node;
                            }
                            break;
                        }   
                        else
                        {
                            Root = node;
                        }
                    }
                    if (currentNode.LeftChild == null && currentNode.RightChild != null)
                    {
                        node = currentNode.RightChild;
                        node.Parent = parent;
                        if (left)
                        {
                            parent.LeftChild = node;
                        }
                        else
                        {
                            parent.RightChild = node;
                        }
                        break;
                    }
                    currentNode = currentNode.LeftChild;                    
                }
                return true;
            }
            return false;
        }

        //@////////////////////////////////////////////////////////////////////////////
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

            if (currentRoot.LeftChild != null && currentRoot.RightChild != null)
            {
                count++;
            }

            count += getCountRecursive(currentRoot.LeftChild) + getCountRecursive(currentRoot.RightChild);
            return count; // количество узлов в дереве
        }
    }
}

