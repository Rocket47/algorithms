using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

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
            BSTNode<T> parentNode = null;
            
            //if (Count() == 0) { bSTFind.Node = null; }            
            while (nodeSearch != null)
            {
                if (key == nodeSearch.NodeKey )
                {                    
                    bSTFind.Node = nodeSearch;
                    bSTFind.NodeHasKey = true;
                    bSTFind.ToLeft = true;
                    break;
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
            if (Root.LeftChild == null && key < Root.NodeKey)
            {
                Root.LeftChild = new BSTNode<T>(key, val, Root);
            }
            if (Root.RightChild == null && key > Root.NodeKey)
            { 
                Root.RightChild = new BSTNode<T>(key, val, Root);            
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
            BSTNode<T> result = null;
            if (!FindMax)
            {
                while (FromNode.LeftChild != null)
                {
                    result = FromNode.LeftChild;
                    FromNode.LeftChild = FromNode.LeftChild.LeftChild;
                }
            }
           
            if (FindMax) {               
                while (FromNode.RightChild != null)
                {
                    result = FromNode.RightChild;
                    FromNode.RightChild = FromNode.RightChild.RightChild;
                }              
            }
            return result;
        }

        //@////////////////////////////////////////////////////////////////////////////
        public bool DeleteNodeByKey(int key)
        {
            bool left = true;
            BSTNode<T> node = FindNodeByKey(key).Node;            
            BSTNode<T> parent = node.Parent;
            if (parent.LeftChild.NodeKey != key)
            {
                left = false;
            }
            if (node == null) { return false; }
            if (node.LeftChild == null && node.RightChild == null)
            {
                node = null;
                return true;
            }
            if (node.LeftChild != null && node.RightChild == null)
            {
                node = node.LeftChild;
                return true;
            }
            if (node.RightChild != null)
            {
                BSTNode<T> currentNode = node.RightChild;
                while (currentNode != null)
                {
                    if (currentNode.LeftChild == null && currentNode.RightChild == null)
                    {
                        node = currentNode;
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
            return 0; // количество узлов в дереве
        }

    }
}
