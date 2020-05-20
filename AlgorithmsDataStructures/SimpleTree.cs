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
                return;
            }
            if (ParentNode.Children == null)
            {
                ParentNode.Children = new List<SimpleTreeNode<T>>();
                ParentNode.Children.Add(NewChild);
                return;
            }           
            else
            {
                ParentNode.Children.Add(NewChild);
            }
        }

        //*////////////////////////////////////////////////////////////////////////////
        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            List<SimpleTreeNode<T>> listToDelete = GetAllNodes();            

            foreach (SimpleTreeNode<T> tmp in listToDelete)
            {
                if (typeof(T) == typeof(string))
                {
                    if (string.Compare(tmp.NodeValue.ToString(), NodeToDelete.ToString()) == 0)
                    {
                        tmp.Parent.Children.Remove(tmp);
                    }
                }
                else
                {
                    if ((int)(object)tmp.NodeValue == (int)(object)NodeToDelete.NodeValue)
                    {
                        tmp.Parent.Children.Remove(tmp);
                    }
                }               
            }
        }

        //*////////////////////////////////////////////////////////////////////////////
        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            List<SimpleTreeNode<T>> resultList = new List<SimpleTreeNode<T>>();
            Stack<SimpleTreeNode<T>> stack = new Stack<SimpleTreeNode<T>>();
            stack.Push(Root);            
            while (stack.Count != 0)
            {
                SimpleTreeNode<T> node = stack.Pop();
                resultList.Add(node);
                
                if (node.Children != null)
                {
                    for (int i = 0; i < node.Children.Count; i++)
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
            if (OriginalNode == null || NewParent == null) { return; }
            DeleteNode(OriginalNode);
            AddChild(NewParent, OriginalNode);
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
