using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgorithmsDataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmsDataStructures.Tests
{
    [TestClass()]
    public class DynArrayTests
    {
        #region MakeArrayTests
        [TestMethod()]
        public void MakeArrayTest()
        {
            DynArray<string> dynArray = new DynArray<string>();
            int ExpectedCapacity = 16;
            int ResultLength = dynArray.array.Length;
            Assert.AreEqual(ExpectedCapacity, ResultLength);            
        }
        #endregion

        #region GetItemTests
        [TestMethod()]
        public void GetItemTest()
        {
            Assert.Fail();
        }
        #endregion

        #region AppendTests
        [TestMethod()]
        public void AppendTest()
        {
            Assert.Fail();
        }
        #endregion

        #region InsertTests
        [TestMethod()]
        public void InsertTest()
        {
            Assert.Fail();
        }
        #endregion

        #region RemoveTests
        [TestMethod()]
        public void RemoveTest()
        {
            Assert.Fail();
        }
    }
        #endregion
}
