namespace CustomLinkedList.Tests
{
    ﻿using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using CustomLinkedList;

    [TestClass]
    public class DynamicListTests
    {
        private DynamicList<int> numList;

        [TestInitialize]
        public void MethodInitialize()
        {
            numList = new DynamicList<int>();
        }

        [TestMethod]
        public void CreateEmptyListShouldBeWithZeroElements()
        {
            Assert.AreEqual(0, numList.Count, "The number of the elements is not equal to zero.");
        }

        [TestMethod]
        public void AddingOneElementShouldIncreaseTheElemetsCountWithOne()
        {
            numList.Add(8);
            Assert.AreEqual(1, numList.Count, "List count is not equal to 1.");
            Assert.AreEqual(8, numList[0], "The added element is not equal to list's element.");
        }

        [TestMethod]
        public void AddingMoreElementsShouldIncreaseTheElemetsCount()
        {
            var numList = new DynamicList<int>();
            numList.Add(2);
            numList.Add(-10);
            numList.Add(5);
            Assert.AreEqual(3, numList.Count, "The list count is not equal to the number of added elements.");
        }

        [TestMethod]
        public void ChangeValueOfGivenPositionShoudChangeTheValueAtThisPosition()
        {
            var numList = new DynamicList<int>();
            numList.Add(2);
            numList.Add(-10);
            numList[0] = 9;
            Assert.AreEqual(numList[0], 9, "The value is not equal to the expected change.");
        }

        [TestMethod]
        public void FoundingElementInListShouldReturnIndexOfElement()
        {
            var numList = new DynamicList<int>();
            numList.Add(13);
            numList.Add(-6);
            int index = numList.IndexOf(-6);
            Assert.AreEqual(1, index, "Invalid index.");
        }

        [TestMethod]
        public void RemovingElementAtIndexShouldRemoveElementFromListAndReorderList()
        {
            var numList = new DynamicList<int>();
            numList.Add(13);
            numList.Add(-6);
            numList.Add(5);
            int number = numList.RemoveAt(0);

            Assert.AreEqual(-6, numList[0], "Does not reorder the elements.");
        }

        [TestMethod]
        public void RemovingElementAtIndexShouldReturnElement()
        {
            var numList = new DynamicList<int>();
            numList.Add(7);
            int number = numList.RemoveAt(0);

            Assert.AreEqual(7, number, "The elements is found and it's equal to what is expected.");
        }

        [TestMethod]
        public void RemovingElementAtIndexShouldDecreaseCount()
        {
            var numList = new DynamicList<int>();
            numList.Add(7);
            numList.Add(10);
            int number = numList.RemoveAt(0);

            Assert.AreEqual(1, numList.Count, "The count does not decrease when removin an element.");
        }

        [TestMethod]
        [ExpectedException(
            typeof(ArgumentOutOfRangeException),
            "Indexer didn't throw correct exception, when invalid index was requested",
            AllowDerivedTypes = true)]
        public void IndexerShouldThrowExceptionWhenInvalidIndexRequested()
        {
            var numList = new DynamicList<int>();
            numList.Add(12);
            int number = numList[1];
        }

        [TestMethod]
        [ExpectedException(
            typeof(ArgumentOutOfRangeException),
            "Indexer didn't throw correct exception, when negative index was requested",
            AllowDerivedTypes = true)]
        public void IndexerShouldThrowExceptionWhenNegativeIndexRequested()
        {
            var numList = new DynamicList<int>();
            Console.WriteLine(numList[-1]);
        }

        [TestMethod]
        [ExpectedException(
            typeof(ArgumentOutOfRangeException),
            "Indexer didn't throw correct exception, when invalid index was setted",
            AllowDerivedTypes = true)]
        public void IndexerShouldThrowExceptionWhenSettingElementOnInvalidPosition()
        {
            var numList = new DynamicList<int>();
            numList[1] = 5;
        }

        [TestMethod]
        public void FoundingElementInListShouldNotFoundIt()
        {
            var numbers = new DynamicList<int>();
            numbers.Add(-5);
            numbers.Add(13);
            numbers.Add(21);
            var initialCount = numbers.Count;
            var index = numbers.Remove(13);

            Assert.IsFalse(numbers.Contains(13), "The element is not removed.");
            Assert.IsTrue(numbers.Count < initialCount, "The count does not decrease.");
            Assert.AreEqual(1, index, "Return invalid index.");
        }
    }
}