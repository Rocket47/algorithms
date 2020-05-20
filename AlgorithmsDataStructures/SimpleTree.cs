using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue;
        public SimpleTreeNode<T> Parent;
        public List<SimpleTreeNode<T>> Children; 
        

        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;            
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
            if (NodeToDelete == null || Root == null) { return; }
            List<SimpleTreeNode<T>> listToDelete = GetAllNodes();

            foreach (SimpleTreeNode<T> tmp in listToDelete)
            {
                if (tmp == Root) { continue; }
                if (typeof(T) == typeof(string))
                {
                    if (string.Compare(tmp.NodeValue.ToString(), NodeToDelete.ToString()) == 0)
                    {
                        if (tmp.Parent.Children != null)
                        {
                            tmp.Parent.Children.Remove(tmp);
                        }
                    }
                }
                else
                {
                    if ((int)(object)tmp.NodeValue == (int)(object)NodeToDelete.NodeValue)
                    {                       
                        if (tmp.Parent.Children != null)
                        {
                            tmp.Parent.Children.Remove(tmp);
                        }
                    }
                }
            }
        }

        //*////////////////////////////////////////////////////////////////////////////
        public List<SimpleTreeNode<T>> GetAllNodes()
        {           
            if (Root == null) { return null; }
            List<SimpleTreeNode<T>> resultList = new List<SimpleTreeNode<T>>();
            Stack<SimpleTreeNode<T>> stack = new Stack<SimpleTreeNode<T>>();                      
            stack.Push(Root);            
            while (stack.Count != 0)
            {
                SimpleTreeNode<T> node = stack.Pop();
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
            foreach (SimpleTreeNode<T> tmp in GetAllNodes())
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
            if (OriginalNode == null || OriginalNode == Root || NewParent == null) { return; }
            if (OriginalNode == NewParent) { return; }
            DeleteNode(OriginalNode);
            AddChild(NewParent, OriginalNode);
        }

        //*////////////////////////////////////////////////////////////////////////////
        public int Count()
        {
            if (Root == null) { return 0; }
            return GetAllNodes().Count;
        }

        //*////////////////////////////////////////////////////////////////////////////
        public int LeafCount()
        {
            if (Root == null) { return 0; }
            int LeafCount = 0;            
            Stack<SimpleTreeNode<T>> stack = new Stack<SimpleTreeNode<T>>();
            stack.Push(Root);           
            while (stack.Count != 0)
            {
                SimpleTreeNode<T> node = stack.Pop();                
                if (node.Children == null)
                {
                    LeafCount++;
                }
                if (node.Children != null)
                {
                    for (int i = 0; i < node.Children.Count; i++)
                    {
                        stack.Push(node.Children[i]);
                    }
                }
            }
            return LeafCount;
        }
    }
}
