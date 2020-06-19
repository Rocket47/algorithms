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

        public void PrintPretty(string indent, bool last)
        {
            string result = null;
            result += indent;
            if (last)
            {
                result += "└─";
                indent += "  ";
            }
            else
            {
                result += "├─";
                indent += "| ";
            }
            result += NodeKey.ToString() + '\n';

            var children = new List<BSTNode<T>>();
            if (LeftChild != null)
                children.Add(LeftChild);
            if (RightChild != null)
                children.Add(RightChild);

            for (int i = 0; i < children.Count; i++)
            {
                children[i].PrintPretty(indent, i == children.Count - 1);
            }
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
            BSTNode<T> nodeSearch = new BSTNode<T>(0, default(T), null);
            
            if (Count() == 0) { bSTFind.Node = null; }
            
            while (nodeSearch.Parent != null)
            {
                if (key == nodeSearch.NodeKey )
                {
                    bSTFind.Node = nodeSearch;
                    bSTFind.NodeHasKey = true;
                    bSTFind.ToLeft = true;
                }
               
                if (key < nodeSearch.NodeKey)
                {
                    nodeSearch = nodeSearch.LeftChild;
                    bSTFind.Node = nodeSearch;
                    bSTFind.NodeHasKey = false;
                    bSTFind.ToLeft = true;
                }
                else
                {
                    nodeSearch = nodeSearch.RightChild;
                    bSTFind.Node = nodeSearch;
                    bSTFind.NodeHasKey = false;
                    bSTFind.ToLeft = false;
                }
            }                
            return bSTFind;
        }

        //@////////////////////////////////////////////////////////////////////////////
        public bool AddKeyValue(int key, T val)
        {
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
            // ищем максимальное/минимальное в поддереве
            return null;
        }

        //@////////////////////////////////////////////////////////////////////////////
        public bool DeleteNodeByKey(int key)
        {
            // удаляем узел по ключу
            return false; // если узел не найден
        }

        //@////////////////////////////////////////////////////////////////////////////
        public int Count()
        {
            return 0; // количество узлов в дереве
        }

    }
}
