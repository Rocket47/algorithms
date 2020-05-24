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
    public class GetAllNodesTests
    {
        /*
        root == null
        */
        [TestMethod()]
        public void GetAllNodesTests1()
        {
            SimpleTreeNode<int> root = null;
            SimpleTree<int> simpleTree = new SimpleTree<int>(root);
            List<SimpleTreeNode<int>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0], null);
        }
        //*///////////////////////////////////////////////////////////////

        /*
        root == null, add child = null
        */
        [TestMethod()]
        public void GetAllNodesTests2()
        {
            SimpleTreeNode<int> root = null;
            SimpleTree<int> simpleTree = new SimpleTree<int>(root);
            SimpleTreeNode<int> child = null;
            List<SimpleTreeNode<int>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0], child);
        }
        //*///////////////////////////////////////////////////////////////

        /*
       root == null, add child != null
       */
        [TestMethod()]
        public void GetAllNodesTests3()
        {
            SimpleTreeNode<int> root = null;
            SimpleTree<int> simpleTree = new SimpleTree<int>(root);
            SimpleTreeNode<int> child = new SimpleTreeNode<int>(1, root);
            simpleTree.AddChild(root, child);
            List<SimpleTreeNode<int>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0], child);
        }
        //*///////////////////////////////////////////////////////////////
        /*
        общий случай для нескольких узлов
       */
        [TestMethod()]
        public void GetAllNodesTests4()
        {
            SimpleTreeNode<int> root = null;
            SimpleTree<int> simpleTree = new SimpleTree<int>(root);
            SimpleTreeNode<int> child1 = new SimpleTreeNode<int>(1, root);
            SimpleTreeNode<int> child2 = new SimpleTreeNode<int>(2, child1);
            SimpleTreeNode<int> child3 = new SimpleTreeNode<int>(3, child1);
            SimpleTreeNode<int> child4 = new SimpleTreeNode<int>(4, child2);
            SimpleTreeNode<int> child5 = new SimpleTreeNode<int>(5, child2);
            SimpleTreeNode<int> child6 = new SimpleTreeNode<int>(6, child2);
            SimpleTreeNode<int> child7 = new SimpleTreeNode<int>(7, child3);
            SimpleTreeNode<int> child8 = new SimpleTreeNode<int>(8, child3);
            SimpleTreeNode<int> child9 = new SimpleTreeNode<int>(9, child3);
            SimpleTreeNode<int> child10 = new SimpleTreeNode<int>(10, child4);
            simpleTree.AddChild(root, child1);
            simpleTree.AddChild(child1, child2);
            simpleTree.AddChild(child1, child3);
            simpleTree.AddChild(child2, child4);
            simpleTree.AddChild(child2, child5);
            simpleTree.AddChild(child2, child6);
            simpleTree.AddChild(child4, child10);
            simpleTree.AddChild(child3, child7);
            simpleTree.AddChild(child3, child8);
            simpleTree.AddChild(child3, child9);
            List<SimpleTreeNode<int>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0].NodeValue, 1);
            Assert.AreEqual(allElementsTree[1].NodeValue, 2);
            Assert.AreEqual(allElementsTree[2].NodeValue, 4);
            Assert.AreEqual(allElementsTree[3].NodeValue, 10);
            Assert.AreEqual(allElementsTree[4].NodeValue, 5);
            Assert.AreEqual(allElementsTree[5].NodeValue, 6);
            Assert.AreEqual(allElementsTree[6].NodeValue, 3);
            Assert.AreEqual(allElementsTree[7].NodeValue, 7);
            Assert.AreEqual(allElementsTree[8].NodeValue, 8);
            Assert.AreEqual(allElementsTree[9].NodeValue, 9);
        }
        //*///////////////////////////////////////////////////////////////

        /*
        root != null
        */
        [TestMethod()]
        public void GetAllNodesTests5()
        {
            SimpleTreeNode<int> root = new SimpleTreeNode<int>(1, null);
            SimpleTree<int> simpleTree = new SimpleTree<int>(root);
            List<SimpleTreeNode<int>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0].NodeValue, 1);
        }
        //*///////////////////////////////////////////////////////////////

        /*
       root != null && add child == null
       */
        [TestMethod()]
        public void GetAllNodesTests6()
        {
            SimpleTreeNode<int> root = new SimpleTreeNode<int>(1, null);
            SimpleTree<int> simpleTree = new SimpleTree<int>(root);
            SimpleTreeNode<int> child = null;
            simpleTree.AddChild(root, child);
            List<SimpleTreeNode<int>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree.Count, 1);
            Assert.AreEqual(allElementsTree[0].NodeValue, 1);
        }
        //*///////////////////////////////////////////////////////////////

        /*
      root != null && add child != null
      */
        [TestMethod()]
        public void GetAllNodesTests7()
        {
            SimpleTreeNode<int> root = new SimpleTreeNode<int>(1, null);
            SimpleTree<int> simpleTree = new SimpleTree<int>(root);
            SimpleTreeNode<int> child = new SimpleTreeNode<int>(2, root);
            simpleTree.AddChild(root, child);
            List<SimpleTreeNode<int>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree.Count, 2);
            Assert.AreEqual(allElementsTree[0].NodeValue, 1);
            Assert.AreEqual(allElementsTree[1].NodeValue, 2);
        }
        //*///////////////////////////////////////////////////////////////
        /*
        общий случай для нескольких узлов
       */
        [TestMethod()]
        public void GetAllNodesTests8()
        {
            SimpleTreeNode<int> root = new SimpleTreeNode<int>(0, null);
            SimpleTree<int> simpleTree = new SimpleTree<int>(root);
            SimpleTreeNode<int> child1 = new SimpleTreeNode<int>(1, root);
            SimpleTreeNode<int> child2 = new SimpleTreeNode<int>(2, child1);
            SimpleTreeNode<int> child3 = new SimpleTreeNode<int>(3, child1);
            SimpleTreeNode<int> child4 = new SimpleTreeNode<int>(4, child2);
            SimpleTreeNode<int> child5 = new SimpleTreeNode<int>(5, child2);
            SimpleTreeNode<int> child6 = new SimpleTreeNode<int>(6, child2);
            SimpleTreeNode<int> child7 = new SimpleTreeNode<int>(7, child3);
            SimpleTreeNode<int> child8 = new SimpleTreeNode<int>(8, child3);
            SimpleTreeNode<int> child9 = new SimpleTreeNode<int>(9, child3);
            SimpleTreeNode<int> child10 = new SimpleTreeNode<int>(10, child4);
            simpleTree.AddChild(root, child1);
            simpleTree.AddChild(child1, child2);
            simpleTree.AddChild(child1, child3);
            simpleTree.AddChild(child2, child4);
            simpleTree.AddChild(child2, child5);
            simpleTree.AddChild(child2, child6);
            simpleTree.AddChild(child4, child10);
            simpleTree.AddChild(child3, child7);
            simpleTree.AddChild(child3, child8);
            simpleTree.AddChild(child3, child9);
            List<SimpleTreeNode<int>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0].NodeValue, 0);
            Assert.AreEqual(allElementsTree[1].NodeValue, 1);
            Assert.AreEqual(allElementsTree[2].NodeValue, 2);
            Assert.AreEqual(allElementsTree[3].NodeValue, 4);
            Assert.AreEqual(allElementsTree[4].NodeValue, 10);
            Assert.AreEqual(allElementsTree[5].NodeValue, 5);
            Assert.AreEqual(allElementsTree[6].NodeValue, 6);
            Assert.AreEqual(allElementsTree[7].NodeValue, 3);
            Assert.AreEqual(allElementsTree[8].NodeValue, 7);
            Assert.AreEqual(allElementsTree[9].NodeValue, 8);
            Assert.AreEqual(allElementsTree[10].NodeValue, 9);
        }
        //*///////////////////////////////////////////////////////////////


        //////******string case******//////

        /*
        root == null
        */
        [TestMethod()]
        public void GetAllNodesTests9()
        {
            SimpleTreeNode<string> root = null;
            SimpleTree<string> simpleTree = new SimpleTree<string>(root);
            List<SimpleTreeNode<string>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0], null);
        }
        //*///////////////////////////////////////////////////////////////

        /*
        root == null, add child = null
        */
        [TestMethod()]
        public void GetAllNodesTests10()
        {
            SimpleTreeNode<string> root = null;
            SimpleTree<string> simpleTree = new SimpleTree<string>(root);
            SimpleTreeNode<string> child = null;
            List<SimpleTreeNode<string>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0], child);
        }
        //*///////////////////////////////////////////////////////////////

        /*
       root == null, add child != null
       */
        [TestMethod()]
        public void GetAllNodesTests11()
        {
            SimpleTreeNode<string> root = null;
            SimpleTree<string> simpleTree = new SimpleTree<string>(root);
            SimpleTreeNode<string> child = new SimpleTreeNode<string>("1", root);
            simpleTree.AddChild(root, child);
            List<SimpleTreeNode<string>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0], child);
        }
        //*///////////////////////////////////////////////////////////////    

        /*
           root == null, add child == ""
           */
        [TestMethod()]
        public void GetAllNodesTests12()
        {
            SimpleTreeNode<string> root = null;
            SimpleTree<string> simpleTree = new SimpleTree<string>(root);
            SimpleTreeNode<string> child = new SimpleTreeNode<string>("", root);
            simpleTree.AddChild(root, child);
            List<SimpleTreeNode<string>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0].NodeValue, child.NodeValue);
        }
        //*//////////////////////////////////////////////////////////////               

        /*
        общий случай для нескольких узлов
       */
        [TestMethod()]
        public void GetAllNodesTests13()
        {
            SimpleTreeNode<string> root = null;
            SimpleTree<string> simpleTree = new SimpleTree<string>(root);
            SimpleTreeNode<string> child1 = new SimpleTreeNode<string>("1", root);
            SimpleTreeNode<string> child2 = new SimpleTreeNode<string>("2", child1);
            SimpleTreeNode<string> child3 = new SimpleTreeNode<string>("3", child1);
            SimpleTreeNode<string> child4 = new SimpleTreeNode<string>("4", child2);
            SimpleTreeNode<string> child5 = new SimpleTreeNode<string>("5", child2);
            SimpleTreeNode<string> child6 = new SimpleTreeNode<string>("6", child2);
            SimpleTreeNode<string> child7 = new SimpleTreeNode<string>("7", child3);
            SimpleTreeNode<string> child8 = new SimpleTreeNode<string>("8", child3);
            SimpleTreeNode<string> child9 = new SimpleTreeNode<string>("9", child3);
            SimpleTreeNode<string> child10 = new SimpleTreeNode<string>("10", child4);
            simpleTree.AddChild(root, child1);
            simpleTree.AddChild(child1, child2);
            simpleTree.AddChild(child1, child3);
            simpleTree.AddChild(child2, child4);
            simpleTree.AddChild(child2, child5);
            simpleTree.AddChild(child2, child6);
            simpleTree.AddChild(child4, child10);
            simpleTree.AddChild(child3, child7);
            simpleTree.AddChild(child3, child8);
            simpleTree.AddChild(child3, child9);
            List<SimpleTreeNode<string>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0].NodeValue, "1");
            Assert.AreEqual(allElementsTree[1].NodeValue, "2");
            Assert.AreEqual(allElementsTree[2].NodeValue, "4");
            Assert.AreEqual(allElementsTree[3].NodeValue, "10");
            Assert.AreEqual(allElementsTree[4].NodeValue, "5");
            Assert.AreEqual(allElementsTree[5].NodeValue, "6");
            Assert.AreEqual(allElementsTree[6].NodeValue, "3");
            Assert.AreEqual(allElementsTree[7].NodeValue, "7");
            Assert.AreEqual(allElementsTree[8].NodeValue, "8");
            Assert.AreEqual(allElementsTree[9].NodeValue, "9");
        }
        //*///////////////////////////////////////////////////////////////

        /*
       root != null
       */
        [TestMethod()]
        public void GetAllNodesTests14()
        {
            SimpleTreeNode<string> root = new SimpleTreeNode<string>("1", null);
            SimpleTree<string> simpleTree = new SimpleTree<string>(root);
            List<SimpleTreeNode<string>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0].NodeValue, "1");
        }
        //*///////////////////////////////////////////////////////////////

        /*
        root != null, add child = null
        */
        [TestMethod()]
        public void GetAllNodesTests15()
        {
            SimpleTreeNode<string> root = new SimpleTreeNode<string>("1", null);
            SimpleTree<string> simpleTree = new SimpleTree<string>(root);
            SimpleTreeNode<string> child = null;
            simpleTree.AddChild(root, child);
            List<SimpleTreeNode<string>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree.Count, 1);
            Assert.AreEqual(allElementsTree[0].NodeValue, "1");
        }
        //*///////////////////////////////////////////////////////////////

        /*
       root != null, add child != null
       */
        [TestMethod()]
        public void GetAllNodesTests16()
        {
            SimpleTreeNode<string> root = new SimpleTreeNode<string>("1", null);
            SimpleTree<string> simpleTree = new SimpleTree<string>(root);
            SimpleTreeNode<string> child = new SimpleTreeNode<string>("2", root);
            simpleTree.AddChild(root, child);
            List<SimpleTreeNode<string>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree.Count, 2);
            Assert.AreEqual(allElementsTree[0].NodeValue, "1");
            Assert.AreEqual(allElementsTree[1].NodeValue, "2");
        }
        //*///////////////////////////////////////////////////////////////    

        /*
           root != null, add child == ""
           */
        [TestMethod()]
        public void GetAllNodesTests17()
        {
            SimpleTreeNode<string> root = new SimpleTreeNode<string>("1", null);
            SimpleTree<string> simpleTree = new SimpleTree<string>(root);
            SimpleTreeNode<string> child = new SimpleTreeNode<string>("", root);
            simpleTree.AddChild(root, child);
            List<SimpleTreeNode<string>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0].NodeValue, "1");
            Assert.AreEqual(allElementsTree[1].NodeValue, "");
        }
        //*//////////////////////////////////////////////////////////////               

        /*
        общий случай для нескольких узлов
       */
        [TestMethod()]
        public void GetAllNodesTests18()
        {
            SimpleTreeNode<string> root = new SimpleTreeNode<string>("0", null);
            SimpleTree<string> simpleTree = new SimpleTree<string>(root);
            SimpleTreeNode<string> child1 = new SimpleTreeNode<string>("1", root);
            SimpleTreeNode<string> child2 = new SimpleTreeNode<string>("2", child1);
            SimpleTreeNode<string> child3 = new SimpleTreeNode<string>("3", child1);
            SimpleTreeNode<string> child4 = new SimpleTreeNode<string>("4", child2);
            SimpleTreeNode<string> child5 = new SimpleTreeNode<string>("5", child2);
            SimpleTreeNode<string> child6 = new SimpleTreeNode<string>("6", child2);
            SimpleTreeNode<string> child7 = new SimpleTreeNode<string>("7", child3);
            SimpleTreeNode<string> child8 = new SimpleTreeNode<string>("8", child3);
            SimpleTreeNode<string> child9 = new SimpleTreeNode<string>("9", child3);
            SimpleTreeNode<string> child10 = new SimpleTreeNode<string>("10", child4);
            simpleTree.AddChild(root, child1);
            simpleTree.AddChild(child1, child2);
            simpleTree.AddChild(child1, child3);
            simpleTree.AddChild(child2, child4);
            simpleTree.AddChild(child2, child5);
            simpleTree.AddChild(child2, child6);
            simpleTree.AddChild(child4, child10);
            simpleTree.AddChild(child3, child7);
            simpleTree.AddChild(child3, child8);
            simpleTree.AddChild(child3, child9);
            List<SimpleTreeNode<string>> allElementsTree = simpleTree.GetAllNodes();
            Assert.AreEqual(allElementsTree[0].NodeValue, "0");
            Assert.AreEqual(allElementsTree[1].NodeValue, "1");
            Assert.AreEqual(allElementsTree[2].NodeValue, "2");
            Assert.AreEqual(allElementsTree[3].NodeValue, "4");
            Assert.AreEqual(allElementsTree[4].NodeValue, "10");
            Assert.AreEqual(allElementsTree[5].NodeValue, "5");
            Assert.AreEqual(allElementsTree[6].NodeValue, "6");
            Assert.AreEqual(allElementsTree[7].NodeValue, "3");
            Assert.AreEqual(allElementsTree[8].NodeValue, "7");
            Assert.AreEqual(allElementsTree[9].NodeValue, "8");
            Assert.AreEqual(allElementsTree[10].NodeValue, "9");
        }
        //*///////////////////////////////////////////////////////////////
    }
}
