using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures2.Tests
{
    [TestClass()]
    public class BSTTests
    {
        #region FindNodeByKeyTests
        [TestMethod()]
        public void FindNodeByKeyTest1()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BST<int> treeInt = new BST<int>(rootInt);
            BSTFind<int> findNodeInt = treeInt.FindNodeByKey(8);
            Assert.AreEqual(findNodeInt.Node, rootInt);

            //string
            BSTNode<string> rootString = new BSTNode<string>(8, "88", null);
            BST<string> treeString = new BST<string>(rootString);
            BSTFind<string> findNodeString = treeString.FindNodeByKey(8);
            Assert.AreEqual(findNodeString.Node, rootString);
        }
        //@/////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod()]
        public void FindNodeByKeyTest2()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<int> nodeLeftChild = new BSTNode<int>(7, 88, rootInt);
            BST<int> treeInt = new BST<int>(rootInt);
            treeInt.AddKeyValue(nodeLeftChild.NodeKey, nodeLeftChild.NodeValue);
            BSTFind<int> findNodeRoot = treeInt.FindNodeByKey(8);
            BSTFind<int> findNodeInt = treeInt.FindNodeByKey(7);
            Assert.AreEqual(findNodeInt.Node.NodeKey, nodeLeftChild.NodeKey);
            Assert.AreEqual(findNodeInt.ToLeft, false);
            Assert.AreEqual(findNodeInt.NodeHasKey, true);

            //string
            BSTNode<string> rootString = new BSTNode<string>(8, "88", null);
            BSTNode<string> rootLeftChild = new BSTNode<string>(7, "88", null);
            BST<string> treeString = new BST<string>(rootString);
            treeString.AddKeyValue(rootLeftChild.NodeKey, rootLeftChild.NodeValue);
            BSTFind<string> findNodeString = treeString.FindNodeByKey(7);
            Assert.AreEqual(findNodeString.Node.NodeKey, nodeLeftChild.NodeKey);
            Assert.AreEqual(findNodeString.ToLeft, false);
            Assert.AreEqual(findNodeString.NodeHasKey, true);
        }
        //@/////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod()]
        public void FindNodeByKeyTest3()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<int> nodeRightChild = new BSTNode<int>(9, 88, rootInt);
            BST<int> treeInt = new BST<int>(rootInt);
            treeInt.AddKeyValue(nodeRightChild.NodeKey, nodeRightChild.NodeValue);
            BSTFind<int> findNodeInt = treeInt.FindNodeByKey(9);
            Assert.AreEqual(findNodeInt.Node.NodeKey, nodeRightChild.NodeKey);
            Assert.AreEqual(findNodeInt.ToLeft, false);
            Assert.AreEqual(findNodeInt.NodeHasKey, true);

            //string
            BSTNode<string> rootString = new BSTNode<string>(8, "88", null);
            BSTNode<string> rootRightChild = new BSTNode<string>(9, "88", null);
            BST<string> treeString = new BST<string>(rootString);
            treeString.AddKeyValue(nodeRightChild.NodeKey, rootRightChild.NodeValue);
            BSTFind<string> findNodeString = treeString.FindNodeByKey(9);
            Assert.AreEqual(findNodeString.Node.NodeKey, rootRightChild.NodeKey);
            Assert.AreEqual(findNodeString.ToLeft, false);
            Assert.AreEqual(findNodeString.NodeHasKey, true);
        }
        //@/////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod()]
        public void FindNodeByKeyTest4()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<int> nodeRightChild = new BSTNode<int>(9, 88, rootInt);
            BSTNode<int> nodeLeftChild = new BSTNode<int>(7, 88, rootInt);
            BST<int> treeInt = new BST<int>(rootInt);
            treeInt.AddKeyValue(nodeRightChild.NodeKey, nodeRightChild.NodeValue);
            treeInt.AddKeyValue(nodeLeftChild.NodeKey, nodeRightChild.NodeValue);
            BSTFind<int> findNodeRightInt = treeInt.FindNodeByKey(9);
            BSTFind<int> findNodeLeftInt = treeInt.FindNodeByKey(7);
            Assert.AreEqual(findNodeRightInt.Node.NodeKey, nodeRightChild.NodeKey);
            Assert.AreEqual(findNodeLeftInt.Node.NodeKey, nodeLeftChild.NodeKey);
            Assert.AreEqual(findNodeRightInt.ToLeft, false);
            Assert.AreEqual(findNodeLeftInt.ToLeft, false);
            Assert.AreEqual(findNodeRightInt.NodeHasKey, true);
            Assert.AreEqual(findNodeLeftInt.NodeHasKey, true);

            //string
            BSTNode<string> rootString = new BSTNode<string>(8, "88", null);
            BSTNode<string> nodeRightChildString = new BSTNode<string>(9, "88", rootString);
            BSTNode<string> nodeLeftChildString = new BSTNode<string>(7, "88", rootString);
            BST<string> treeString = new BST<string>(rootString);
            treeString.AddKeyValue(nodeRightChildString.NodeKey, nodeRightChildString.NodeValue);
            treeString.AddKeyValue(nodeLeftChildString.NodeKey, nodeLeftChildString.NodeValue);
            BSTFind<string> findNodeRightString = treeString.FindNodeByKey(9);
            BSTFind<string> findNodeLeftString = treeString.FindNodeByKey(7);
            Assert.AreEqual(findNodeRightString.Node.NodeKey, nodeRightChild.NodeKey);
            Assert.AreEqual(findNodeLeftString.Node.NodeKey, nodeLeftChild.NodeKey);
            Assert.AreEqual(findNodeRightString.ToLeft, false);
            Assert.AreEqual(findNodeLeftString.ToLeft, false);
            Assert.AreEqual(findNodeRightString.NodeHasKey, true);
            Assert.AreEqual(findNodeLeftString.NodeHasKey, true);
        }
        //@/////////////////////////////////////////////////////////////////////////////////////////
        [TestMethod()]
        public void FindNodeByKeyTest5()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<int> nodeRightChild = new BSTNode<int>(9, 88, rootInt);
            BSTNode<int> nodeLeftChild = new BSTNode<int>(7, 88, rootInt);
            BST<int> treeInt = new BST<int>(rootInt);
            treeInt.AddKeyValue(nodeRightChild.NodeKey, nodeRightChild.NodeValue);
            treeInt.AddKeyValue(nodeLeftChild.NodeKey, nodeRightChild.NodeValue);
            BSTFind<int> findNodeRightInt = treeInt.FindNodeByKey(10);
            Assert.AreEqual(findNodeRightInt.Node.NodeKey, nodeRightChild.NodeKey);
            Assert.AreEqual(findNodeRightInt.ToLeft, false);
            Assert.AreEqual(findNodeRightInt.NodeHasKey, false);
        }
        #endregion

        #region AddKeyValue() 
        [TestMethod()]
        public void AddKeyValueTest1()
        {
            //int
            BSTNode<int> rootInt = null;
            BST<int> treeInt = new BST<int>(rootInt);
            BSTNode<int> node1 = new BSTNode<int>(2, 88, rootInt);
            BSTNode<int> node2 = new BSTNode<int>(3, 88, rootInt);
            treeInt.AddKeyValue(2, 88);
            treeInt.AddKeyValue(3, 88);
            Assert.AreEqual(treeInt.FindNodeByKey(2).Node.NodeKey, 2);
            Assert.AreEqual(treeInt.FindNodeByKey(2).Node.RightChild.NodeKey, 3);
        }
        [TestMethod()]
        public void AddKeyValueTest2()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BST<int> treeInt = new BST<int>(rootInt);
            BSTNode<int> node1 = new BSTNode<int>(2, 88, rootInt);
            BSTNode<int> node2 = new BSTNode<int>(3, 88, rootInt);
            treeInt.AddKeyValue(node1.NodeKey, node1.NodeValue);
            treeInt.AddKeyValue(node2.NodeKey, node2.NodeValue);
            Assert.AreEqual(treeInt.FindNodeByKey(2).Node.NodeKey, 2);
            Assert.AreEqual(treeInt.FindNodeByKey(2).Node.RightChild.NodeKey, 3);
        }

        [TestMethod()]
        public void AddKeyValueTest3()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BST<int> treeInt = new BST<int>(rootInt);
            BSTNode<int> node1Left = new BSTNode<int>(2, 88, rootInt);
            BSTNode<int> node2Right = new BSTNode<int>(9, 88, rootInt);
            treeInt.AddKeyValue(node1Left.NodeKey, node1Left.NodeValue);
            treeInt.AddKeyValue(node2Right.NodeKey, node2Right.NodeValue);

            BSTFind<int> node1LeftFind = treeInt.FindNodeByKey(2);
            BSTFind<int> node2RitghtFind = treeInt.FindNodeByKey(9);
            BSTFind<int> node3NotFind = treeInt.FindNodeByKey(10);

            Assert.AreEqual(node1LeftFind.Node.NodeKey, 2);
            Assert.AreEqual(node1LeftFind.NodeHasKey, true);
            Assert.AreEqual(node1LeftFind.ToLeft, false);

            Assert.AreEqual(node2RitghtFind.Node.NodeKey, 9);
            Assert.AreEqual(node2RitghtFind.NodeHasKey, true);
            Assert.AreEqual(node2RitghtFind.ToLeft, false);

            Assert.AreEqual(node3NotFind.Node.NodeKey, 9);
            Assert.AreEqual(node3NotFind.NodeHasKey, false);
            Assert.AreEqual(node3NotFind.ToLeft, false);
        }

        [TestMethod()]
        public void AddKeyValueTestKeyExists()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BST<int> treeInt = new BST<int>(rootInt);
            BSTNode<int> node1Left = new BSTNode<int>(2, 88, rootInt);
            BSTNode<int> node2Right = new BSTNode<int>(9, 88, rootInt);
            BSTNode<int> node3Exist = new BSTNode<int>(9, 88, rootInt);
            treeInt.AddKeyValue(node1Left.NodeKey, node1Left.NodeValue);
            treeInt.AddKeyValue(node2Right.NodeKey, node2Right.NodeValue);
            treeInt.AddKeyValue(node3Exist.NodeKey, node3Exist.NodeValue);

            Assert.AreEqual(node2Right.LeftChild, null);
            Assert.AreEqual(node2Right.RightChild, null);
        }
        #endregion

        #region FinMinMaxTests()

        /*
        root == null
        */
        [TestMethod()]
        public void FinMinMaxTest1()
        {
            BSTNode<int> rootInt = null;
            BSTNode<string> rootString = null;
            BST<int> treeInt = new BST<int>(rootInt);
            BST<string> treeString = new BST<string>(rootString);
            BSTNode<int> node1TrueInt = treeInt.FinMinMax(rootInt, true);
            BSTNode<int> node2FalseInt = treeInt.FinMinMax(rootInt, false);
            BSTNode<string> node1TrueString = treeString.FinMinMax(rootString, true);
            BSTNode<string> node2FalseString = treeString.FinMinMax(rootString, false);
            Assert.AreEqual(node1TrueInt, null);
            Assert.AreEqual(node2FalseInt, null);
            Assert.AreEqual(node1TrueString, null);
            Assert.AreEqual(node2FalseString, null);
        }
        /*
       root != null
       */
        [TestMethod()]
        public void FinMinMaxTest2()
        {
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<string> rootString = new BSTNode<string>(8, "88", null);

            BST<int> treeInt = new BST<int>(rootInt);
            BST<string> treeString = new BST<string>(rootString);

            BSTNode<int> node1TrueInt = treeInt.FinMinMax(rootInt, true);
            BSTNode<int> node2FalseInt = treeInt.FinMinMax(rootInt, false);
            BSTNode<string> node1TrueString = treeString.FinMinMax(rootString, true);
            BSTNode<string> node2FalseString = treeString.FinMinMax(rootString, false);

            Assert.AreEqual(node1TrueInt, rootInt);
            Assert.AreEqual(node2FalseInt, rootInt);
            Assert.AreEqual(node1TrueString, rootString);
            Assert.AreEqual(node2FalseString, rootString);

            Assert.AreEqual(node1TrueInt.NodeKey, 8);
            Assert.AreEqual(node2FalseInt.NodeKey, 8);
            Assert.AreEqual(node1TrueString.NodeKey, 8);
            Assert.AreEqual(node2FalseString.NodeKey, 8);

            Assert.AreEqual(node1TrueInt.NodeValue, 88);
            Assert.AreEqual(node2FalseInt.NodeValue, 88);
            Assert.AreEqual(node1TrueString.NodeValue, "88");
            Assert.AreEqual(node2FalseString.NodeValue, "88");

            treeInt.DeleteNodeByKey(8);
            treeString.DeleteNodeByKey(8);

            node1TrueInt = treeInt.FinMinMax(null, true);
            node2FalseInt = treeInt.FinMinMax(null, false);
            node1TrueString = treeString.FinMinMax(null, true);
            node2FalseString = treeString.FinMinMax(null, false);

            Assert.AreEqual(node1TrueInt, null);
            Assert.AreEqual(node2FalseInt, null);
            Assert.AreEqual(node1TrueString, null);
            Assert.AreEqual(node2FalseString, null);
        }

        /*
         root != null + leftchild
        */
        [TestMethod()]
        public void FinMinMaxTest3()
        {
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<string> rootString = new BSTNode<string>(8, "88", null);

            BST<int> treeInt = new BST<int>(rootInt);
            BST<string> treeString = new BST<string>(rootString);

            treeInt.AddKeyValue(7, 77);
            treeString.AddKeyValue(7, "Test77");

            BSTNode<int> node1TrueInt = treeInt.FinMinMax(rootInt, true);
            BSTNode<int> node2FalseInt = treeInt.FinMinMax(rootInt, false);
            BSTNode<string> node1TrueString = treeString.FinMinMax(rootString, true);
            BSTNode<string> node2FalseString = treeString.FinMinMax(rootString, false);

            Assert.AreEqual(node1TrueInt, rootInt);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild);
            Assert.AreEqual(node1TrueString, rootString);
            Assert.AreEqual(node2FalseString, rootString.LeftChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 8);
            Assert.AreEqual(node2FalseInt.NodeKey, 7);
            Assert.AreEqual(node1TrueString.NodeKey, 8);
            Assert.AreEqual(node2FalseString.NodeKey, 7);

            Assert.AreEqual(node1TrueInt.NodeValue, 88);
            Assert.AreEqual(node2FalseInt.NodeValue, 77);
            Assert.AreEqual(node1TrueString.NodeValue, "88");
            Assert.AreEqual(node2FalseString.NodeValue, "Test77");

            node1TrueInt = treeInt.FinMinMax(rootInt.LeftChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.LeftChild, false);
            node1TrueString = treeString.FinMinMax(rootString.LeftChild, true);
            node2FalseString = treeString.FinMinMax(rootString.LeftChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.LeftChild);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.LeftChild);
            Assert.AreEqual(node2FalseString, rootString.LeftChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 7);
            Assert.AreEqual(node2FalseInt.NodeKey, 7);
            Assert.AreEqual(node1TrueString.NodeKey, 7);
            Assert.AreEqual(node2FalseString.NodeKey, 7);

            Assert.AreEqual(node1TrueInt.NodeValue, 77);
            Assert.AreEqual(node2FalseInt.NodeValue, 77);
            Assert.AreEqual(node1TrueString.NodeValue, "Test77");
            Assert.AreEqual(node2FalseString.NodeValue, "Test77");
        }
        /*
        root != null + rightChild
       */
        [TestMethod()]
        public void FinMinMaxTest4()
        {
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<string> rootString = new BSTNode<string>(8, "88", null);

            BST<int> treeInt = new BST<int>(rootInt);
            BST<string> treeString = new BST<string>(rootString);

            treeInt.AddKeyValue(10, 1010);
            treeString.AddKeyValue(10, "1010");

            BSTNode<int> node1TrueInt = treeInt.FinMinMax(rootInt, true);
            BSTNode<int> node2FalseInt = treeInt.FinMinMax(rootInt, false);
            BSTNode<string> node1TrueString = treeString.FinMinMax(rootString, true);
            BSTNode<string> node2FalseString = treeString.FinMinMax(rootString, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt);
            Assert.AreEqual(node1TrueString, rootString.RightChild);
            Assert.AreEqual(node2FalseString, rootString);

            Assert.AreEqual(node1TrueInt.NodeKey, 10);
            Assert.AreEqual(node2FalseInt.NodeKey, 8);
            Assert.AreEqual(node1TrueString.NodeKey, 10);
            Assert.AreEqual(node2FalseString.NodeKey, 8);

            Assert.AreEqual(node1TrueInt.NodeValue, 1010);
            Assert.AreEqual(node2FalseInt.NodeValue, 88);
            Assert.AreEqual(node1TrueString.NodeValue, "1010");
            Assert.AreEqual(node2FalseString.NodeValue, "88");

            node1TrueInt = treeInt.FinMinMax(rootInt.RightChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.RightChild, false);
            node1TrueString = treeString.FinMinMax(rootString.RightChild, true);
            node2FalseString = treeString.FinMinMax(rootString.RightChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.RightChild);
            Assert.AreEqual(node1TrueString, rootString.RightChild);
            Assert.AreEqual(node2FalseString, rootString.RightChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 10);
            Assert.AreEqual(node2FalseInt.NodeKey, 10);
            Assert.AreEqual(node1TrueString.NodeKey, 10);
            Assert.AreEqual(node2FalseString.NodeKey, 10);

            Assert.AreEqual(node1TrueInt.NodeValue, 1010);
            Assert.AreEqual(node2FalseInt.NodeValue, 1010);
            Assert.AreEqual(node1TrueString.NodeValue, "1010");
            Assert.AreEqual(node2FalseString.NodeValue, "1010");
        }
        /*
         root != null  + rightchild + leftchild
        */
        [TestMethod()]
        public void FinMinMaxTest5()
        {
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<string> rootString = new BSTNode<string>(8, "88", null);

            BST<int> treeInt = new BST<int>(rootInt);
            BST<string> treeString = new BST<string>(rootString);

            treeString.AddKeyValue(7, "77");
            treeString.AddKeyValue(7, "77");
            treeString.AddKeyValue(10, "1010");
            treeString.AddKeyValue(10, "1010");
            treeInt.AddKeyValue(10, 1010);
            treeString.AddKeyValue(10, "1010");
            treeInt.AddKeyValue(7, 77);
            treeString.AddKeyValue(7, "77");

            BSTNode<int> node1TrueInt = treeInt.FinMinMax(rootInt, true);
            BSTNode<int> node2FalseInt = treeInt.FinMinMax(rootInt, false);
            BSTNode<string> node1TrueString = treeString.FinMinMax(rootString, true);
            BSTNode<string> node2FalseString = treeString.FinMinMax(rootString, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.RightChild);
            Assert.AreEqual(node2FalseString, rootString.LeftChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 10);
            Assert.AreEqual(node2FalseInt.NodeKey, 7);
            Assert.AreEqual(node1TrueString.NodeKey, 10);
            Assert.AreEqual(node2FalseString.NodeKey, 7);

            Assert.AreEqual(node1TrueInt.NodeValue, 1010);
            Assert.AreEqual(node2FalseInt.NodeValue, 77);
            Assert.AreEqual(node1TrueString.NodeValue, "1010");
            Assert.AreEqual(node2FalseString.NodeValue, "77");

            node1TrueInt = treeInt.FinMinMax(rootInt.RightChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.RightChild, false);
            node1TrueString = treeString.FinMinMax(rootString.RightChild, true);
            node2FalseString = treeString.FinMinMax(rootString.RightChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.RightChild);
            Assert.AreEqual(node1TrueString, rootString.RightChild);
            Assert.AreEqual(node2FalseString, rootString.RightChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 10);
            Assert.AreEqual(node2FalseInt.NodeKey, 10);
            Assert.AreEqual(node1TrueString.NodeKey, 10);
            Assert.AreEqual(node2FalseString.NodeKey, 10);

            Assert.AreEqual(node1TrueInt.NodeValue, 1010);
            Assert.AreEqual(node2FalseInt.NodeValue, 1010);
            Assert.AreEqual(node1TrueString.NodeValue, "1010");
            Assert.AreEqual(node2FalseString.NodeValue, "1010");

            node1TrueInt = treeInt.FinMinMax(rootInt.LeftChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.LeftChild, false);
            node1TrueString = treeString.FinMinMax(rootString.LeftChild, true);
            node2FalseString = treeString.FinMinMax(rootString.LeftChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.LeftChild);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.LeftChild);
            Assert.AreEqual(node2FalseString, rootString.LeftChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 7);
            Assert.AreEqual(node2FalseInt.NodeKey, 7);
            Assert.AreEqual(node1TrueString.NodeKey, 7);
            Assert.AreEqual(node2FalseString.NodeKey, 7);

            Assert.AreEqual(node1TrueInt.NodeValue, 77);
            Assert.AreEqual(node2FalseInt.NodeValue, 77);
            Assert.AreEqual(node1TrueString.NodeValue, "77");
            Assert.AreEqual(node2FalseString.NodeValue, "77");
        }
        /*
        root = 8, 4,12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15
       */
        [TestMethod()]
        public void FinMinMaxTest6()
        {
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<string> rootString = new BSTNode<string>(8, "88", null);

            BST<int> treeInt = new BST<int>(rootInt);
            BST<string> treeString = new BST<string>(rootString);

            treeInt.AddKeyValue(8, 88);
            treeInt.AddKeyValue(4, 88);
            treeInt.AddKeyValue(12, 88);
            treeInt.AddKeyValue(2, 88);
            treeInt.AddKeyValue(6, 88);
            treeInt.AddKeyValue(10, 88);
            treeInt.AddKeyValue(14, 88);
            treeInt.AddKeyValue(1, 88);
            treeInt.AddKeyValue(3, 88);
            treeInt.AddKeyValue(5, 88);
            treeInt.AddKeyValue(7, 88);
            treeInt.AddKeyValue(9, 88);
            treeInt.AddKeyValue(11, 88);
            treeInt.AddKeyValue(13, 88);
            treeInt.AddKeyValue(15, 88);

            treeString.AddKeyValue(8, "88");
            treeString.AddKeyValue(4, "88");
            treeString.AddKeyValue(12, "88");
            treeString.AddKeyValue(2, "88");
            treeString.AddKeyValue(6, "88");
            treeString.AddKeyValue(10, "88");
            treeString.AddKeyValue(14, "88");
            treeString.AddKeyValue(1, "88");
            treeString.AddKeyValue(3, "88");
            treeString.AddKeyValue(5, "88");
            treeString.AddKeyValue(7, "88");
            treeString.AddKeyValue(9, "88");
            treeString.AddKeyValue(11, "88");
            treeString.AddKeyValue(13, "88");
            treeString.AddKeyValue(15, "88");

            BSTNode<int> node1TrueInt = treeInt.FinMinMax(rootInt, true);
            BSTNode<int> node2FalseInt = treeInt.FinMinMax(rootInt, false);
            BSTNode<string> node1TrueString = treeString.FinMinMax(rootString, true);
            BSTNode<string> node2FalseString = treeString.FinMinMax(rootString, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild.RightChild.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild.LeftChild.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.RightChild.RightChild.RightChild);
            Assert.AreEqual(node2FalseString, rootString.LeftChild.LeftChild.LeftChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 15);
            Assert.AreEqual(node2FalseInt.NodeKey, 1);
            Assert.AreEqual(node1TrueString.NodeKey, 15);
            Assert.AreEqual(node2FalseString.NodeKey, 1);

            node1TrueInt = treeInt.FinMinMax(rootInt.LeftChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.LeftChild, false);
            node1TrueString = treeString.FinMinMax(rootString.LeftChild, true);
            node2FalseString = treeString.FinMinMax(rootString.LeftChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.LeftChild.RightChild.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild.LeftChild.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.LeftChild.RightChild.RightChild);
            Assert.AreEqual(node2FalseString, rootString.LeftChild.LeftChild.LeftChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 7);
            Assert.AreEqual(node2FalseInt.NodeKey, 1);
            Assert.AreEqual(node1TrueString.NodeKey, 7);
            Assert.AreEqual(node2FalseString.NodeKey, 1);

            node1TrueInt = treeInt.FinMinMax(rootInt.RightChild.LeftChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.RightChild.LeftChild, false);
            node1TrueString = treeString.FinMinMax(rootString.RightChild.LeftChild, true);
            node2FalseString = treeString.FinMinMax(rootString.RightChild.LeftChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild.LeftChild.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.RightChild.LeftChild.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.RightChild.LeftChild.RightChild);
            Assert.AreEqual(node2FalseString, rootString.RightChild.LeftChild.LeftChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 11);
            Assert.AreEqual(node2FalseInt.NodeKey, 9);
            Assert.AreEqual(node1TrueString.NodeKey, 11);
            Assert.AreEqual(node2FalseString.NodeKey, 9);
        }
        /*
        root = 8, delete root, 8 4,12, 2, 6, 10, 14, 1, 3, 5, 7, 9, 11, 13, 15
       */
        [TestMethod()]
        public void FinMinMaxTest7()
        {
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<string> rootString = new BSTNode<string>(8, "88", null);

            BST<int> treeInt = new BST<int>(rootInt);
            BST<string> treeString = new BST<string>(rootString);

            treeInt.DeleteNodeByKey(8);

            treeInt.AddKeyValue(rootInt.NodeKey, rootInt.NodeValue);
            treeInt.AddKeyValue(4, 88);
            treeInt.AddKeyValue(12, 88);
            treeInt.AddKeyValue(2, 88);
            treeInt.AddKeyValue(6, 88);
            treeInt.AddKeyValue(10, 88);
            treeInt.AddKeyValue(14, 88);
            treeInt.AddKeyValue(1, 88);
            treeInt.AddKeyValue(3, 88);
            treeInt.AddKeyValue(5, 88);
            treeInt.AddKeyValue(7, 88);
            treeInt.AddKeyValue(9, 88);
            treeInt.AddKeyValue(11, 88);
            treeInt.AddKeyValue(13, 88);
            treeInt.AddKeyValue(15, 88);

            treeString.AddKeyValue(8, "88");
            treeString.AddKeyValue(4, "88");
            treeString.AddKeyValue(12, "88");
            treeString.AddKeyValue(2, "88");
            treeString.AddKeyValue(6, "88");
            treeString.AddKeyValue(10, "88");
            treeString.AddKeyValue(14, "88");
            treeString.AddKeyValue(1, "88");
            treeString.AddKeyValue(3, "88");
            treeString.AddKeyValue(5, "88");
            treeString.AddKeyValue(7, "88");
            treeString.AddKeyValue(9, "88");
            treeString.AddKeyValue(11, "88");
            treeString.AddKeyValue(13, "88");
            treeString.AddKeyValue(15, "88");

            BSTNode<int> node1TrueInt = treeInt.FinMinMax(treeInt.Root, true);
            BSTNode<int> node2FalseInt = treeInt.FinMinMax(treeInt.Root, false);
            BSTNode<string> node1TrueString = treeString.FinMinMax(treeString.Root, true);
            BSTNode<string> node2FalseString = treeString.FinMinMax(treeString.Root, false);

            Assert.AreEqual(treeInt.Root.Parent, null);
            Assert.AreEqual(node2FalseInt, treeInt.Root.LeftChild.LeftChild.LeftChild);

            Assert.AreEqual(node1TrueInt, treeInt.Root.RightChild.RightChild.RightChild);
            Assert.AreEqual(node2FalseInt, treeInt.Root.LeftChild.LeftChild.LeftChild);
            Assert.AreEqual(node1TrueString, treeString.Root.RightChild.RightChild.RightChild);
            Assert.AreEqual(node2FalseString, treeString.Root.LeftChild.LeftChild.LeftChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 15);
            Assert.AreEqual(node2FalseInt.NodeKey, 1);
            Assert.AreEqual(node1TrueString.NodeKey, 15);
            Assert.AreEqual(node2FalseString.NodeKey, 1);

            node1TrueInt = treeInt.FinMinMax(treeInt.Root.LeftChild, true);
            node2FalseInt = treeInt.FinMinMax(treeInt.Root.LeftChild, false);
            node1TrueString = treeString.FinMinMax(rootString.LeftChild, true);
            node2FalseString = treeString.FinMinMax(rootString.LeftChild, false);

            Assert.AreEqual(node1TrueInt, treeInt.Root.LeftChild.RightChild.RightChild);
            Assert.AreEqual(node2FalseInt, treeInt.Root.LeftChild.LeftChild.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.LeftChild.RightChild.RightChild);
            Assert.AreEqual(node2FalseString, rootString.LeftChild.LeftChild.LeftChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 7);
            Assert.AreEqual(node2FalseInt.NodeKey, 1);
            Assert.AreEqual(node1TrueString.NodeKey, 7);
            Assert.AreEqual(node2FalseString.NodeKey, 1);

            node1TrueInt = treeInt.FinMinMax(treeInt.Root.RightChild.LeftChild, true);
            node2FalseInt = treeInt.FinMinMax(treeInt.Root.RightChild.LeftChild, false);
            node1TrueString = treeString.FinMinMax(rootString.RightChild.LeftChild, true);
            node2FalseString = treeString.FinMinMax(rootString.RightChild.LeftChild, false);

            Assert.AreEqual(node1TrueInt, treeInt.Root.RightChild.LeftChild.RightChild);
            Assert.AreEqual(node2FalseInt, treeInt.Root.RightChild.LeftChild.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.RightChild.LeftChild.RightChild);
            Assert.AreEqual(node2FalseString, rootString.RightChild.LeftChild.LeftChild);

            Assert.AreEqual(node1TrueInt.NodeKey, 11);
            Assert.AreEqual(node2FalseInt.NodeKey, 9);
            Assert.AreEqual(node1TrueString.NodeKey, 11);
            Assert.AreEqual(node2FalseString.NodeKey, 9);
        }

        #endregion

        #region  DeleteNodeByKey(int key)

        [TestMethod()]
        public void DeleteNodeByKeyTest1()
        {
            //int
            BSTNode<int> rootInt = null;
            BST<int> treeInt = new BST<int>(rootInt);
            bool result = treeInt.DeleteNodeByKey(4);
            Assert.AreEqual(result, false);
            Assert.AreEqual(treeInt.Root, null);
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest2()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);           
            BST<int> treeInt = new BST<int>(rootInt);
            bool result = treeInt.DeleteNodeByKey(8);
            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root, null);
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest3()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<int> nodeRightChild = new BSTNode<int>(9, 88, rootInt);            
            BST<int> treeInt = new BST<int>(rootInt);

            treeInt.AddKeyValue(nodeRightChild.NodeKey, nodeRightChild.NodeValue);
            bool result = treeInt.DeleteNodeByKey(9);

            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 8);
            Assert.AreEqual(treeInt.Root.Parent, null);
            Assert.AreEqual(treeInt.Root.LeftChild, null);
            Assert.AreEqual(treeInt.Root.RightChild, null);                       
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest31()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);            
            BST<int> treeInt = new BST<int>(rootInt);

            treeInt.AddKeyValue(9, 88);
            bool result = treeInt.DeleteNodeByKey(8);

            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 9);
            Assert.AreEqual(treeInt.Root.Parent, null);
            Assert.AreEqual(treeInt.Root.LeftChild, null);
            Assert.AreEqual(treeInt.Root.RightChild, null);
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest4()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);
            BSTNode<int> nodeLeftChild = new BSTNode<int>(7, 88, rootInt);
            BST<int> treeInt = new BST<int>(rootInt);

            treeInt.AddKeyValue(nodeLeftChild.NodeKey, nodeLeftChild.NodeValue);
            bool result = treeInt.DeleteNodeByKey(7);

            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 8);
            Assert.AreEqual(treeInt.Root.Parent, null);
            Assert.AreEqual(treeInt.Root.RightChild, null);
            Assert.AreEqual(treeInt.Root.LeftChild, null);
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest41()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);            
            BST<int> treeInt = new BST<int>(rootInt);

            treeInt.AddKeyValue(7, 88);
            bool result = treeInt.DeleteNodeByKey(8);

            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 7);
            Assert.AreEqual(treeInt.Root.Parent, null);
            Assert.AreEqual(treeInt.Root.LeftChild, null);
            Assert.AreEqual(treeInt.Root.RightChild, null);
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest5()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);            
            BST<int> treeInt = new BST<int>(rootInt);
            treeInt.AddKeyValue(7, 88);
            treeInt.AddKeyValue(9, 88);
            bool result = treeInt.DeleteNodeByKey(7);
            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 8);
            Assert.AreEqual(treeInt.Root.LeftChild, null);
            Assert.AreEqual(treeInt.Root.RightChild.NodeKey, 9);
            Assert.AreEqual(treeInt.Root.RightChild.Parent.NodeKey, 8);
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest51()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);           
            BST<int> treeInt = new BST<int>(rootInt);
            treeInt.AddKeyValue(7, 88);
            treeInt.AddKeyValue(9, 88);
            bool result = treeInt.DeleteNodeByKey(9);
            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 8);
            Assert.AreEqual(treeInt.Root.LeftChild.NodeKey, 7);
            Assert.AreEqual(treeInt.Root.LeftChild.Parent.NodeKey, 8);
            Assert.AreEqual(treeInt.Root.RightChild, null);
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest52()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(8, 88, null);           
            BST<int> treeInt = new BST<int>(rootInt);
            treeInt.AddKeyValue(9, 88);
            treeInt.AddKeyValue(7, 88);
            bool result = treeInt.DeleteNodeByKey(8);
            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 9);
            Assert.AreEqual(treeInt.Root.LeftChild.NodeKey, 7);
            Assert.AreEqual(treeInt.Root.LeftChild.Parent.NodeKey, 9);
            Assert.AreEqual(treeInt.Root.RightChild, null);
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest6()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(16, 88, null);           
            BST<int> treeInt = new BST<int>(rootInt);
            treeInt.AddKeyValue(16, 88);
            treeInt.AddKeyValue(8, 88);
            treeInt.AddKeyValue(26, 88);
            treeInt.AddKeyValue(4, 88);
            treeInt.AddKeyValue(12, 88);
            treeInt.AddKeyValue(20, 88);
            treeInt.AddKeyValue(28, 88);
            treeInt.AddKeyValue(2, 88);
            treeInt.AddKeyValue(6, 88);
            treeInt.AddKeyValue(10, 88);
            treeInt.AddKeyValue(14, 88);            
            treeInt.AddKeyValue(18, 88);
            treeInt.AddKeyValue(22, 88);
            treeInt.AddKeyValue(26, 88);
            treeInt.AddKeyValue(30, 88);            
            bool result = treeInt.DeleteNodeByKey(16);
            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.LeftChild.NodeKey, 8);
            Assert.AreEqual(treeInt.Root.LeftChild.Parent.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.RightChild.Parent.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.RightChild.LeftChild.LeftChild, null);
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest7()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(16, 88, null);
            BST<int> treeInt = new BST<int>(rootInt);
            treeInt.AddKeyValue(16, 88);
            treeInt.AddKeyValue(8, 88);
            treeInt.AddKeyValue(26, 88);
            treeInt.AddKeyValue(4, 88);
            treeInt.AddKeyValue(12, 88);
            treeInt.AddKeyValue(20, 88);
            treeInt.AddKeyValue(28, 88);
            treeInt.AddKeyValue(2, 88);
            treeInt.AddKeyValue(6, 88);
            treeInt.AddKeyValue(10, 88);
            treeInt.AddKeyValue(14, 88);
            treeInt.AddKeyValue(18, 88);
            treeInt.AddKeyValue(22, 88);
            treeInt.AddKeyValue(26, 88);
            treeInt.AddKeyValue(30, 88);
            treeInt.AddKeyValue(19, 88);
            bool result = treeInt.DeleteNodeByKey(16);
            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.LeftChild.NodeKey, 8);
            Assert.AreEqual(treeInt.Root.LeftChild.Parent.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.RightChild.Parent.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.RightChild.LeftChild.LeftChild.NodeKey, 19);
            Assert.AreEqual(treeInt.Root.RightChild.LeftChild.LeftChild.Parent.NodeKey, 20);
        }

        [TestMethod()]
        public void DeleteNodeByKeyTest8()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(16, 88, null);
            BST<int> treeInt = new BST<int>(rootInt);
            Assert.AreEqual(treeInt.Root.NodeKey, 16);
            treeInt.DeleteNodeByKey(16);
            BSTNode<int> foundNull = treeInt.FinMinMax(treeInt.Root, false);
            Assert.AreEqual(foundNull, null);
            Assert.AreEqual(treeInt.Root, null);            
            treeInt.AddKeyValue(16, 88);
            BSTNode<int> foundNodeMin = treeInt.FinMinMax(treeInt.Root, false);
            BSTNode<int> foundNodeMax = treeInt.FinMinMax(treeInt.Root, false);
            Assert.AreEqual(foundNodeMin.NodeKey, 16);
            Assert.AreEqual(foundNodeMax.NodeKey, 16);
            Assert.AreEqual(treeInt.Root.NodeKey, 16);
            Assert.AreEqual(treeInt.Root.Parent, null);
            treeInt.AddKeyValue(8, 88);
            treeInt.AddKeyValue(26, 88);
            treeInt.AddKeyValue(4, 88);
            treeInt.AddKeyValue(12, 88);
            treeInt.AddKeyValue(20, 88);
            treeInt.AddKeyValue(28, 88);
            treeInt.AddKeyValue(2, 88);
            treeInt.AddKeyValue(6, 88);
            treeInt.AddKeyValue(10, 88);
            treeInt.AddKeyValue(14, 88);
            treeInt.AddKeyValue(18, 88);
            treeInt.AddKeyValue(22, 88);
            treeInt.AddKeyValue(26, 88);
            treeInt.AddKeyValue(30, 88);
            treeInt.AddKeyValue(19, 88);
            bool result = treeInt.DeleteNodeByKey(16);
            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.LeftChild.NodeKey, 8);
            Assert.AreEqual(treeInt.Root.LeftChild.Parent.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.RightChild.Parent.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.RightChild.LeftChild.LeftChild.NodeKey, 19);
            Assert.AreEqual(treeInt.Root.RightChild.LeftChild.LeftChild.Parent.NodeKey, 20);
        }


        [TestMethod()]
        public void DeleteNodeByKeyTest9()
        {
            //int
            BSTNode<int> rootInt = new BSTNode<int>(16, 88, null);
            BST<int> treeInt = new BST<int>(rootInt);
            Assert.AreEqual(treeInt.Root.NodeKey, 16);
            treeInt.DeleteNodeByKey(16);
            BSTNode<int> foundNull = treeInt.FinMinMax(treeInt.Root, false);
            Assert.AreEqual(foundNull, null);
            Assert.AreEqual(treeInt.Root, null);
            treeInt.AddKeyValue(16, 88);
            BSTNode<int> foundNodeMin = treeInt.FinMinMax(treeInt.Root, false);
            BSTNode<int> foundNodeMax = treeInt.FinMinMax(treeInt.Root, false);
            Assert.AreEqual(foundNodeMin.NodeKey, 16);
            Assert.AreEqual(foundNodeMax.NodeKey, 16);
            Assert.AreEqual(treeInt.Root.NodeKey, 16);
            Assert.AreEqual(treeInt.Root.Parent, null);
            treeInt.AddKeyValue(16, 88);
            treeInt.AddKeyValue(8, 88);
            treeInt.AddKeyValue(24, 88);
            treeInt.AddKeyValue(4, 88);
            treeInt.AddKeyValue(12, 88);
            treeInt.AddKeyValue(20, 88);
            treeInt.AddKeyValue(28, 88);
            treeInt.AddKeyValue(2, 88);
            treeInt.AddKeyValue(6, 88);
            treeInt.AddKeyValue(10, 88);
            treeInt.AddKeyValue(14, 88);
            treeInt.AddKeyValue(18, 88);
            treeInt.AddKeyValue(22, 88);
            treeInt.AddKeyValue(26, 88);
            treeInt.AddKeyValue(30, 88);

            bool result = treeInt.DeleteNodeByKey(24);
            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 16);
            Assert.AreEqual(treeInt.Root.LeftChild.NodeKey, 8);
            Assert.AreEqual(treeInt.Root.LeftChild.Parent.NodeKey, 16);
            Assert.AreEqual(treeInt.Root.RightChild.Parent.NodeKey, 16);
            Assert.AreEqual(treeInt.Root.RightChild.NodeKey, 26);
            Assert.AreEqual(treeInt.Root.RightChild.LeftChild.LeftChild.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.RightChild.LeftChild.LeftChild.Parent.NodeKey, 20);
            Assert.AreEqual(treeInt.Root.RightChild.RightChild.LeftChild, null);

            result = treeInt.DeleteNodeByKey(26);
            Assert.AreEqual(result, true);
            Assert.AreEqual(treeInt.Root.NodeKey, 16);
            Assert.AreEqual(treeInt.Root.LeftChild.NodeKey, 8);
            Assert.AreEqual(treeInt.Root.LeftChild.Parent.NodeKey, 16);
            Assert.AreEqual(treeInt.Root.RightChild.Parent.NodeKey, 16);
            Assert.AreEqual(treeInt.Root.RightChild.NodeKey, 28);
            Assert.AreEqual(treeInt.Root.RightChild.LeftChild.LeftChild.NodeKey, 18);
            Assert.AreEqual(treeInt.Root.RightChild.LeftChild.LeftChild.Parent.NodeKey, 20);
            Assert.AreEqual(treeInt.Root.RightChild.RightChild.NodeKey, 30);
        }

        #endregion
    }
}
