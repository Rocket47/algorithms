using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
        BSTNode<T> Root; // корень дерева, или null

        public BST(BSTNode<T> node)
        {
            Root = node;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            BSTFind<T> bstFindResult = new BSTFind<T>();
            BSTNode<T> bstNode = Root;
            if (bstNode == null) { return bstFindResult; }

            while (key != bstNode.NodeKey)
            {
                if (key < bstNode.NodeKey)
                {
                    if (bstNode.LeftChild != null)
                    {
                        bstNode = bstNode.LeftChild;
                    }
                    else
                    {
                        bstFindResult.ToLeft = true;
                        break;
                    }
                }
                else
                {
                    if (bstNode.RightChild != null)
                    {
                        bstNode = bstNode.RightChild;
                    }
                    else
                    {
                        bstFindResult.ToLeft = false;
                        break;
                    }
                }
            }
            bstFindResult.Node = bstNode;
            bstFindResult.NodeHasKey = bstNode.NodeKey == key;

            return bstFindResult;
        }

        public bool AddKeyValue(int key, T val)
        {
            // добавляем ключ-значение в дерево
            BSTFind<T> bstFind = FindNodeByKey(key);
            if (bstFind.NodeHasKey) return false;
            BSTNode<T> bstNode = new BSTNode<T>(key, val, bstFind.Node);
            if (Root == null)
            {
                Root = bstNode;
                return true;
            }
            if (bstFind.ToLeft)
            {
                bstFind.Node.LeftChild = bstNode;
            }
            else
            {
                bstFind.Node.RightChild = bstNode;
            }
            return true; 
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            BSTNode<T> nodeResult = FromNode;
            if (FromNode == null)
            {
                return null;
            }
            if (FindMax)
            {
                while (nodeResult.RightChild != null)
                {
                    nodeResult = nodeResult.RightChild;
                }
            }
            else
            {
                while (nodeResult.LeftChild != null)
                {
                    nodeResult = nodeResult.LeftChild;
                }
            }
            return nodeResult; 
        }

        public bool DeleteNodeByKey(int key)
        {
            bool isLeftChild = true;
            BSTFind<T> findNode = FindNodeByKey(key);
            if (!findNode.NodeHasKey) { return false; }

            BSTNode<T> nodeToDelete = findNode.Node;
            BSTNode<T> parentNodeToDelete = findNode.Node.Parent;

            if (parentNodeToDelete != null)
            {
                isLeftChild = parentNodeToDelete.LeftChild == nodeToDelete;
            }

            BSTNode<T> nodeForReplace = nodeToDelete;
            if (nodeForReplace.RightChild != null)
            {
                nodeForReplace = nodeForReplace.RightChild;
            }
            while (nodeForReplace.LeftChild != null)
            {
                nodeForReplace = nodeForReplace.LeftChild;
            }

            if (nodeToDelete == nodeForReplace)
            {
                if (parentNodeToDelete != null)
                {
                    if (!isLeftChild)
                    {
                        parentNodeToDelete.RightChild = null;
                    }
                    else
                    {
                        parentNodeToDelete.LeftChild = null;
                    }
                }
                else
                {
                    Root = null;
                }
                return true;
            }

            BSTNode<T> parentNodeForReplace = nodeForReplace.Parent;
            if (parentNodeForReplace != null)
            {
                if (parentNodeForReplace.LeftChild == nodeForReplace)
                {
                    parentNodeForReplace.LeftChild = null;
                }
                else
                {
                    parentNodeForReplace.RightChild = null;
                }
            }
            nodeForReplace.Parent = parentNodeToDelete;

            if (parentNodeToDelete != null)
            {
                if (!isLeftChild)
                {
                    parentNodeToDelete.RightChild = nodeForReplace;
                }
                else
                {
                    parentNodeToDelete.LeftChild = nodeForReplace;
                }
            }
            else
            {
                Root = nodeForReplace;
            }

            BSTNode<T> deleteNodeLeftChild = nodeToDelete.LeftChild;
            BSTNode<T> deleteNodeRightChild = nodeToDelete.RightChild;

            nodeForReplace.LeftChild = deleteNodeLeftChild;
            nodeForReplace.RightChild = deleteNodeRightChild;

            if (deleteNodeLeftChild != null)
            {
                deleteNodeLeftChild.Parent = nodeForReplace;
            }
            if (deleteNodeRightChild != null)
            {
                deleteNodeRightChild.Parent = nodeForReplace;
            }

            return true; // если узел не найден
        }

        public int Count()
        {
            if (Root != null)
                return CountNodes(Root.RightChild) + CountNodes(Root.LeftChild) + 1;
            return 0;          
        }

        private int CountNodes(BSTNode<T> node)
        {
            if (node != null)
                return CountNodes(node.LeftChild) + CountNodes(node.RightChild) + 1;
            return 0;
        }

    }
}
