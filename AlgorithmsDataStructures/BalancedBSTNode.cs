using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
	public class BSTNode
	{
		public int NodeKey; // ключ узла
		public BSTNode Parent; // родитель или null для корня
		public BSTNode LeftChild; // левый потомок
		public BSTNode RightChild; // правый потомок	
		public int Level; // глубина узла

		public BSTNode(int key, BSTNode parent)
		{
			NodeKey = key;
			Parent = parent;
			LeftChild = null;
			RightChild = null;
		}
	}


	public class BalancedBST
	{
		public BSTNode Root; // корень дерева

		public BalancedBST()
		{
			Root = null;
		}

		public void GenerateTree(int[] a)
		{
			int length = a.Length;
			Root = new BSTNode(length / 2, null);
			Root.Level = 0;
			Array.Sort(a);
			GenerateTree(a, 0, length - 1, Root);
			Root.Parent = null;
		}

		public BSTNode GenerateTree(int[] array, int start, int end, BSTNode parent)
		{
			if (array == null || array.Length == 0 || start > end) { return null; }

			int mid = (start + end) / 2;
			BSTNode bSTNode = new BSTNode(array[mid], Root);
			bSTNode.Level = parent.Level + 1;
			bSTNode.LeftChild = GenerateTree(array, start, mid - 1, parent);
			bSTNode.RightChild = GenerateTree(array, mid + 1, end, parent);

			return bSTNode;
		}

		public bool IsBalanced(BSTNode root_node)
		{
			if (root_node == null) { return true; }

			int left = Deep(root_node.LeftChild);
			int right = Deep(root_node.RightChild);
			if (Math.Abs(left - right) <= 1 && IsBalanced(root_node.LeftChild) && IsBalanced(root_node.RightChild))
			{
				return true;
			}
			return false; // сбалансировано ли дерево с корнем root_node
		}

		public int Deep(BSTNode root_node)
		{
			if (root_node == null) { return 0; }

			return 1 + Math.Max(Deep(root_node.LeftChild), Deep(root_node.RightChild));
		}
	}
}