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

            if (node == null) return null;

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
            if (find == null)
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
           BSTFind<T> found = FindNodeByKey(key);
            if (found == null)
            {
                return false;
            }
            if (found.NodeHasKey)
            {
                if (found.Node.Parent == null)
                {
                    if (found.Node.LeftChild == null && found.Node.RightChild == null)
                    {
                        Root = null;
                        return true;
                    }

                    if (found.Node.LeftChild != null && found.Node.RightChild == null)
                    {
                        found.Node.LeftChild.Parent = null;
                        Root = found.Node.LeftChild;
                        return true;
                    }

                    if (found.Node.LeftChild == null && found.Node.RightChild != null)
                    {
                        BSTNode<T> minRightNode = FinMinMax(found.Node.RightChild, false);
                        if (minRightNode.RightChild == null)
                        {
                            minRightNode.Parent.LeftChild = null;
                            minRightNode.RightChild = Root.RightChild;
                            Root.RightChild.Parent = minRightNode;
                            minRightNode.LeftChild = Root.LeftChild;
                            minRightNode.Parent = null;
                            Root = minRightNode;
                            return true;
                        }
                        if (minRightNode.RightChild != null)
                        {
                            if (minRightNode.Parent != Root)
                            {
                                minRightNode.Parent.LeftChild = minRightNode.RightChild;
                            }                            
                            minRightNode.RightChild.Parent = minRightNode.Parent;
                            minRightNode.RightChild = Root.RightChild;
                            Root.RightChild.Parent = minRightNode;
                            minRightNode.LeftChild = Root.LeftChild;
                            minRightNode.Parent = null;
                            Root = minRightNode;
                            return true;
                        }
                    }

                    if (found.Node.LeftChild != null && found.Node.RightChild != null)
                    {
                        BSTNode<T> minRightNode = FinMinMax(found.Node.RightChild, false);
                        if (minRightNode.RightChild == null)
                        {
                            if (minRightNode.Parent != Root)
                            {
                                minRightNode.Parent.LeftChild = null;
                            }                           
                            minRightNode.RightChild = Root.RightChild;
                            Root.RightChild.Parent = minRightNode;
                            minRightNode.LeftChild = Root.LeftChild;
                            Root.LeftChild.Parent = minRightNode;
                            minRightNode.Parent = null;
                            Root = minRightNode;
                            return true;
                        }
                        else
                        {
                            if (minRightNode.Parent != null)
                            {
                                minRightNode.Parent.LeftChild = minRightNode.RightChild;
                            }                            
                            minRightNode.RightChild.Parent = minRightNode.Parent;
                            minRightNode.RightChild = Root.RightChild;
                            Root.RightChild.Parent = minRightNode;
                            minRightNode.LeftChild = Root.LeftChild;
                            Root.LeftChild.Parent = minRightNode;
                            minRightNode.Parent = null;
                            Root = minRightNode;
                            return true;
                        }
                    }
                }            
                if (found.Node.LeftChild == null && found.Node.RightChild == null)
                {
                    if (found.Node.Parent.LeftChild != null && found.Node.Parent.LeftChild.Equals(found.Node))
                        found.Node.Parent.LeftChild = null;
                    else if (found.Node.Parent.RightChild != null && found.Node.Parent.RightChild.Equals(found.Node))
                        found.Node.Parent.RightChild = null;
                }              
                else if (found.Node.LeftChild == null ^ found.Node.RightChild == null)
                {
                    if (found.Node.LeftChild != null)
                    {
                        if (found.Node.Parent.LeftChild != null && found.Node.Parent.LeftChild.Equals(found.Node))
                            found.Node.Parent.LeftChild = found.Node.LeftChild;
                        else
                            found.Node.Parent.RightChild = found.Node.LeftChild;

                        found.Node.LeftChild.Parent = found.Node.Parent;
                    }
                    else 
                    {
                        if (found.Node.Parent.LeftChild != null && found.Node.Parent.LeftChild.Equals(found.Node))
                            found.Node.Parent.LeftChild = found.Node.RightChild;
                        else
                            found.Node.Parent.RightChild = found.Node.RightChild;

                        found.Node.RightChild.Parent = found.Node.Parent;
                    }
                }               
                else
                {
                    BSTNode<T> successorNode = FinMinMax(found.Node.RightChild, false); 

                    if (successorNode.RightChild != null) 
                    {
                        successorNode.Parent.LeftChild = successorNode.RightChild; 
                        successorNode.RightChild.Parent = successorNode.Parent; 
                    }
                    else
                    {
                        if (successorNode.Parent.LeftChild == successorNode)
                            successorNode.Parent.LeftChild = null; 
                        else
                            successorNode.Parent.RightChild = null;
                    }
                    
                    if (found.Node.Parent.RightChild == found.Node)
                        found.Node.Parent.RightChild = successorNode;
                    else
                        found.Node.Parent.LeftChild = successorNode;

                    successorNode.Parent = found.Node.Parent; 

                    successorNode.LeftChild = found.Node.LeftChild; 
                    successorNode.RightChild = found.Node.RightChild; 

                    
                    if (found.Node.RightChild != null)
                        found.Node.RightChild.Parent = successorNode;
                    if (found.Node.LeftChild != null)
                        found.Node.LeftChild.Parent = successorNode;
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

            if (currentRoot.LeftChild != null || currentRoot.RightChild != null)
            {
                count++;
            }

            count += getCountRecursive(currentRoot.LeftChild) + getCountRecursive(currentRoot.RightChild);
            return count; // количество узлов в дереве
        }
    }
}

