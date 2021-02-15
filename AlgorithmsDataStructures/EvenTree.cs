using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue;
        public SimpleTreeNode<T> Parent;
        public List<SimpleTreeNode<T>> Children;
        public int Weight;


        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
            Weight = 0;
        }
    }

    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root;
        public List<SimpleTreeNode<T>> resultList;

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
            resultList = new List<SimpleTreeNode<T>>();
        }

        //*////////////////////////////////////////////////////////////////////////////
        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            if (NewChild == null)
            {
                return;
            }
            if (Root == null && Root == ParentNode)
            {
                Root = NewChild;
                return;
            }
            if (Root.Children == null)
            {
                Root.Children = new List<SimpleTreeNode<T>>();
                Root.Children.Add(NewChild);
                NewChild.Parent = Root;
                return;
            }
            if (ParentNode.Children == null)
            {
                ParentNode.Children = new List<SimpleTreeNode<T>>();
                ParentNode.Children.Add(NewChild);
                NewChild.Parent = ParentNode;
                return;
            }
            else
            {
                ParentNode.Children.Add(NewChild);
                NewChild.Parent = ParentNode;
            }
        }

        //*////////////////////////////////////////////////////////////////////////////
        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            SimpleTreeNode<T> node = NodeToDelete;
            if (node != Root)
            {
                node.Parent.Children.Remove(node);
                node.Parent = null;
            }
        }

        //*////////////////////////////////////////////////////////////////////////////
        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            List<SimpleTreeNode<T>> resultList = new List<SimpleTreeNode<T>>();
            Stack<SimpleTreeNode<T>> stack = new Stack<SimpleTreeNode<T>>();

            if (Root == null)
            {
                resultList.Add(Root);
                return resultList;
            }

            stack.Push(Root);

            while (stack.Count != 0)
            {
                SimpleTreeNode<T> node = stack.Pop();
                if (node == null) { continue; }
                resultList.Add(node);

                if (node.Children != null)
                {
                    for (int i = node.Children.Count - 1; i >= 0; i--)
                    {
                        stack.Push(node.Children[i]);
                    }
                }
            }
            return resultList;
        }

        //*////////////////////////////////////////////////////////////////////////////
        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            if (Root == null) { return null; }
            List<SimpleTreeNode<T>> resultList = new List<SimpleTreeNode<T>>();
            List<SimpleTreeNode<T>> listToFindNode = GetAllNodes();
            foreach (SimpleTreeNode<T> tmp in listToFindNode)
            {
                if (typeof(T) == typeof(string))
                {
                    if (string.Compare(tmp.NodeValue.ToString(), val.ToString()) == 0)
                    {
                        resultList.Add(tmp);
                    }
                }
                else
                {
                    if ((int)(object)tmp.NodeValue == (int)(object)val)
                    {
                        resultList.Add(tmp);
                    }
                }
            }
            return resultList;
        }

        //*////////////////////////////////////////////////////////////////////////////
        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            if (OriginalNode != Root)
            {
                DeleteNode(OriginalNode);
                AddChild(NewParent, OriginalNode);
            }
        }

        //*////////////////////////////////////////////////////////////////////////////
        public int Count()
        {
            return GetAllNodes().Count;
        }

        //*////////////////////////////////////////////////////////////////////////////
        public int LeafCount()
        {
            int LeafCount = 0;
            List<SimpleTreeNode<T>> listSaveNodes = GetAllNodes();
            foreach (SimpleTreeNode<T> tmp in listSaveNodes)
            {
                if (tmp == null || tmp.Children == null || tmp.Children.Count == 0)
                {
                    LeafCount++;
                }
            }
            return LeafCount;
        }

        //*////////////////////////////////////////////////////////////////////////////
        public List<T> EvenTrees()
        {

            List<T> verticesList = new List<T>();
            Stack<SimpleTreeNode<T>> nodes = BFSTraverse();
            if (nodes != null)
            {
                while (nodes.Count != 1)
                {
                    SimpleTreeNode<T> tempNode = nodes.Pop();
                    if (tempNode.Weight % 2 == 0)
                    {
                        tempNode.Parent.Weight++;
                    }
                    else
                    {
                        verticesList.Add(tempNode.Parent.NodeValue);
                        verticesList.Add(tempNode.NodeValue);
                    }
                }
                return verticesList;
            }
            return null;
        }

        //*////////////////////////////////////////////////////////////////////////////
        public Stack<SimpleTreeNode<T>> BFSTraverse()
        {            
            Stack<SimpleTreeNode<T>> nodes = new Stack<SimpleTreeNode<T>>();
            Queue<SimpleTreeNode<T>> numbers = new Queue<SimpleTreeNode<T>>();
            if (Root != null)
            {
                numbers.Enqueue(Root);
                while (numbers.Count != 0)
                {
                    SimpleTreeNode<T> tempNode = numbers.Dequeue();

                    nodes.Push(tempNode);

                    if (tempNode.Children != null && tempNode.Children.Count > 0)
                    {
                        for (int i = 0; i < tempNode.Children.Count; i++)
                        {
                            numbers.Enqueue(tempNode.Children[i]);
                        }
                    }
                }
            }
            return nodes;
        }
    }
}
