using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null
        

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
        public List<SimpleTreeNode<T>> resultList; // корень, может быть null

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
            foreach (SimpleTreeNode<T> tmp in GetAllNodes())
            {
                if (typeof(T) == typeof(string))
                {
                    if (string.Compare(tmp.NodeValue.ToString(), NodeToDelete.ToString()) == 0)
                    {
                        listToDelete.Remove(tmp);
                    }
                }
                else
                {
                    if ((int)(object)tmp.NodeValue == (int)(object)NodeToDelete.NodeValue)
                    {
                        listToDelete.Remove(tmp);
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
            while (stack.Any())
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
            DeleteNode(OriginalNode);
            AddChild(NewParent, OriginalNode);
        }

        //*////////////////////////////////////////////////////////////////////////////
        public int Count()
        {
            // количество всех узлов в дереве
            return GetAllNodes().Count;
        }

        //*////////////////////////////////////////////////////////////////////////////
        public int LeafCount()
        {
            int LeafCount = 0;            
            Stack<SimpleTreeNode<T>> stack = new Stack<SimpleTreeNode<T>>();
            stack.Push(Root);
            while (stack.Any())
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
