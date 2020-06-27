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

            treeInt.AddKeyValue(7, 88);
            treeString.AddKeyValue(7, "88");

            BSTNode<int> node1TrueInt = treeInt.FinMinMax(rootInt, true);
            BSTNode<int> node2FalseInt = treeInt.FinMinMax(rootInt, false);
            BSTNode<string> node1TrueString = treeString.FinMinMax(rootString, true);
            BSTNode<string> node2FalseString = treeString.FinMinMax(rootString, false);           

            Assert.AreEqual(node1TrueInt, rootInt);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild);
            Assert.AreEqual(node1TrueString, rootString);
            Assert.AreEqual(node2FalseString, rootString.LeftChild);

            node1TrueInt = treeInt.FinMinMax(rootInt.LeftChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.LeftChild, false);
            node1TrueString = treeString.FinMinMax(rootString.LeftChild, true);
            node2FalseString = treeString.FinMinMax(rootString.LeftChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.LeftChild);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.LeftChild);
            Assert.AreEqual(node2FalseString, rootString.LeftChild);
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

            treeInt.AddKeyValue(10, 88);
            treeString.AddKeyValue(10, "88");

            BSTNode<int> node1TrueInt = treeInt.FinMinMax(rootInt, true);
            BSTNode<int> node2FalseInt = treeInt.FinMinMax(rootInt, false);
            BSTNode<string> node1TrueString = treeString.FinMinMax(rootString, true);
            BSTNode<string> node2FalseString = treeString.FinMinMax(rootString, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt);
            Assert.AreEqual(node1TrueString, rootString.RightChild);
            Assert.AreEqual(node2FalseString, rootString);

            node1TrueInt = treeInt.FinMinMax(rootInt.RightChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.RightChild, false);
            node1TrueString = treeString.FinMinMax(rootString.RightChild, true);
            node2FalseString = treeString.FinMinMax(rootString.RightChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.RightChild);
            Assert.AreEqual(node1TrueString, rootString.RightChild);
            Assert.AreEqual(node2FalseString, rootString.RightChild);
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

            treeString.AddKeyValue(7, "88");
            treeString.AddKeyValue(7, "88");
            treeString.AddKeyValue(10, "88");
            treeString.AddKeyValue(10, "88");
            treeInt.AddKeyValue(10, 88);
            treeString.AddKeyValue(10, "88");
            treeInt.AddKeyValue(7, 88);
            treeString.AddKeyValue(7, "88");

            BSTNode<int> node1TrueInt = treeInt.FinMinMax(rootInt, true);
            BSTNode<int> node2FalseInt = treeInt.FinMinMax(rootInt, false);
            BSTNode<string> node1TrueString = treeString.FinMinMax(rootString, true);
            BSTNode<string> node2FalseString = treeString.FinMinMax(rootString, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.RightChild);
            Assert.AreEqual(node2FalseString, rootString.LeftChild);

            node1TrueInt = treeInt.FinMinMax(rootInt.RightChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.RightChild, false);
            node1TrueString = treeString.FinMinMax(rootString.RightChild, true);
            node2FalseString = treeString.FinMinMax(rootString.RightChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.RightChild);
            Assert.AreEqual(node1TrueString, rootString.RightChild);
            Assert.AreEqual(node2FalseString, rootString.RightChild);

            node1TrueInt = treeInt.FinMinMax(rootInt.LeftChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.LeftChild, false);
            node1TrueString = treeString.FinMinMax(rootString.LeftChild, true);
            node2FalseString = treeString.FinMinMax(rootString.LeftChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.LeftChild);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.LeftChild);
            Assert.AreEqual(node2FalseString, rootString.LeftChild);
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

            node1TrueInt = treeInt.FinMinMax(rootInt.LeftChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.LeftChild, false);
            node1TrueString = treeString.FinMinMax(rootString.LeftChild, true);
            node2FalseString = treeString.FinMinMax(rootString.LeftChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.LeftChild.RightChild.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.LeftChild.LeftChild.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.LeftChild.RightChild.RightChild);
            Assert.AreEqual(node2FalseString, rootString.LeftChild.LeftChild.LeftChild);

            node1TrueInt = treeInt.FinMinMax(rootInt.RightChild.LeftChild, true);
            node2FalseInt = treeInt.FinMinMax(rootInt.RightChild.LeftChild, false);
            node1TrueString = treeString.FinMinMax(rootString.RightChild.LeftChild, true);
            node2FalseString = treeString.FinMinMax(rootString.RightChild.LeftChild, false);

            Assert.AreEqual(node1TrueInt, rootInt.RightChild.LeftChild.RightChild);
            Assert.AreEqual(node2FalseInt, rootInt.RightChild.LeftChild.LeftChild);
            Assert.AreEqual(node1TrueString, rootString.RightChild.LeftChild.RightChild);
            Assert.AreEqual(node2FalseString, rootString.RightChild.LeftChild.LeftChild);
        }               
        #endregion
