using NUnit.Framework;
using AlgorithmsDataStructures2;

namespace Task7.UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        #region MakeHeapTests
        [Test]
        public void MakeHeap_InputArrayIsNull_HeapNotChanged()
        {                     
            Heap heap = new Heap();           
            var prev = heap.HeapArray;
            heap.MakeHeap(null, 0);
            var current = heap.HeapArray;
            Assert.AreEqual(prev, current);
        }

        [Test]
        public void MakeHeap_DepthLessZero_HeapNotChanged()
        {
            var tmpArray = new int[] { 1, 3, 7, 9, 2 };    
            Heap heap = new Heap();

            var prev = heap.HeapArray;           
            heap.MakeHeap(tmpArray, -3);
            var current = heap.HeapArray;

            Assert.AreEqual(prev, current);
        }

        [Test]
        public void MakeHeap_DepthIsZero_HeapSizeOne()
        {
            var tmpArray = new int[] { 1, 3, 7, 9, 2 };
            Heap heap = new Heap();           
            heap.MakeHeap(tmpArray, 0);
            var length = heap.HeapArray.Length;

            Assert.AreEqual(length, 1);
        }

        [Test]
        public void MakeHeap_DepthIsOne_LenthIsThree()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[3], 1);
            var length = heap.HeapArray.Length;
            Assert.AreEqual(length, 3);
        }

        [Test]
        public void MakeHeap_DepthIs2_LenthIsSeven()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[3], 2);
            var length = heap.HeapArray.Length;
            Assert.AreEqual(length, 7);
        }

        [Test]
        public void MakeHeap_DepthIs3_LenthIs13()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[3], 3);
            var length = heap.HeapArray.Length;
            Assert.AreEqual(length, 15);
        }
        #endregion

        #region AddTests()
        [Test]
        public void Add_KeyLessZero_ReturnFalse()
        {
            Heap heap = new Heap();
            heap.HeapArray = new int[3];
            bool result = heap.Add(-3);
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Add_HeapArrayIsNull_ReturnFalse()
        {
            Heap heap = new Heap();            
            bool result = heap.Add(4);
            Assert.AreEqual(false, result);
        }

        #endregion
    }
}