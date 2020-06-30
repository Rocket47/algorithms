using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Windows.Forms;

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

        public BSTFind(BSTNode<T> node, bool nodeHasKey, bool toLeft)
        {
            Node = node;
            NodeHasKey = nodeHasKey;
            ToLeft = toLeft;
        }
    }

    public class BST<T>
    {
       public BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }
       
        //@////////////////////////////////////////////////////////////////////////////
        public BSTFind<T> FindNodeByKey(int key) 
        {
            BSTNode<T> node = Root;

            if (node == null) return new BSTFind<T>(null, false, false); 

            while (node != null)
            {
                int result = key.CompareTo(node.NodeKey);
                if (result < 0) 
                {
                    if (node.LeftChild != null)
                    {
                        node = node.LeftChild;
                        continue;
                    }
                    return new BSTFind<T>(node, false, true); 
                }
                else if (result > 0) 
                {
                    if (node.RightChild != null)
                    {
                        node = node.RightChild;
                        continue;
                    }
                    return new BSTFind<T>(node, false, false); 
                }
                return new BSTFind<T>(node, true, false);
            }
            return null;
        }

        //@////////////////////////////////////////////////////////////////////////////
        public bool AddKeyValue(int key, T val)
        {
            BSTFind<T> find = this.FindNodeByKey(key);
            if (find.Node == null)
            {
                Root = new BSTNode<T>(key, val, null);
                return true;
            }
            var node = find.Node;
            if (Root == null)
            {
                Root = node;                
                return true;
            }
            if (node.NodeKey == key) return false;
            else
            {
                if (node.NodeKey > key)
                {
                    node.LeftChild = new BSTNode<T>(key, val, node);
                }
                else
                {
                    node.RightChild = new BSTNode<T>(key, val, node);
                }
            }            
            return true;
        }

        //@////////////////////////////////////////////////////////////////////////////
        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            BSTNode<T> current = FromNode;

            if (FromNode == null) return null;

            if (FindMax)
            {
                while (current.RightChild != null) current = current.RightChild;
                return current;
            }
            else
            {
                while (current.LeftChild != null) current = current.LeftChild;
                return current;
            }
        }

        //@////////////////////////////////////////////////////////////////////////////
        public bool DeleteNodeByKey(int key)
        {
            // no child

            BSTNode<T> found = FindNodeByKey(key).Node;
            if (found == null) { return false; }
            BSTNode<T> parent = found.Parent;

            if (found.LeftChild == null && found.RightChild == null)
            {
                if (found.NodeKey == Root.NodeKey)
                {
                    Root = null;                    
                    return true;
                }                
                if (parent.LeftChild == found)
                {
                    parent.LeftChild = null;
                }
                else
                {
                    parent.RightChild = null;
                }
                return true;
            }

            //one child
            if (found.LeftChild == null)
            {
                if (found == Root)
                {
                    Root = Root.RightChild;
                    Root.Parent = null;
                    return true;
                }                

                if (parent.LeftChild == found)
                {
                    parent.LeftChild = found.RightChild;
                }
                else
                {
                    parent.RightChild = found.RightChild;
                }
                return true;
            }
            if (found.RightChild == null)
            {
                if (found == Root)
                {
                    Root = Root.LeftChild;
                    Root.Parent = null;
                    return true;
                }
                if (parent.LeftChild == found)
                {
                    parent.LeftChild = found.LeftChild;
                }
                else
                {
                    parent.RightChild = found.LeftChild;
                }
                return true;
            }
            //two child;
            if (found.LeftChild != null && found.RightChild != null)
            {
                BSTNode<T> succ = found.RightChild;
                BSTNode<T> succParent = found;
                if (succ.LeftChild == null)
                {
                    found.NodeKey = succ.NodeKey;
                    found.RightChild = succ.RightChild;
                    return true;
                }
                while (succ.LeftChild != null)
                {
                    succParent = succ;
                    succ = succ.LeftChild;
                }
                if (succ.RightChild == null)
                {
                    succ.Parent.LeftChild = null;
                }
                else
                {
                    succ.Parent.LeftChild = succ.RightChild;
                    succ.RightChild.Parent = succ.Parent;
                }
                found.NodeKey = succ.NodeKey;
                succ.Parent = found.Parent;
                found.LeftChild.Parent = succ;
                found.RightChild.Parent = succ;
                succParent.LeftChild = succ.RightChild;
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

            if (currentRoot.LeftChild != null || currentRoot.RightChild != null)
            {
                count++;
            }

            count += getCountRecursive(currentRoot.LeftChild) + getCountRecursive(currentRoot.RightChild);
            return count; // количество узлов в дереве
        }
    }
}

