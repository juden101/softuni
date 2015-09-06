﻿namespace StacksAndQueuesHomework.Tests
{
    using System;
    using System.Linq;
    using StacksAndQueuesHomework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestArrayStack
    {
        private const string MESSAGE_COUNTNOTMATCHING = "ArrayStack count is not correct.";
        private const string MESSAGE_NOTEQUALNUMBERS = "The two numbers are not equal.";
        private const string MESSAGE_POPFROMEMPTYARRAYATACK = "You cannot pop from empty array stack.";
        private const string MESSAGE_THETWOARRAYSARENOTSAME = "The two arrays are not the same.";

        [TestMethod]
        public void TestPushAndPopOneElement()
        {
            ArrayStack<int> elements = new ArrayStack<int>();

            // asserts Count == 0
            Assert.AreEqual(0, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int pushedNumber = 3;
            elements.Push(pushedNumber);

            // asserts Count == 1
            Assert.AreEqual(1, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int popedNumber = elements.Pop();

            // asserts the poped and the pushed elements are the same
            Assert.AreEqual(pushedNumber, popedNumber, MESSAGE_NOTEQUALNUMBERS);

            // asserts Count == 0
            Assert.AreEqual(0, elements.Count, MESSAGE_COUNTNOTMATCHING);
        }

        [TestMethod]
        public void TestPushAndPopThousandElements()
        {
            ArrayStack<string> elements = new ArrayStack<string>();

            // asserts Count == 0
            Assert.AreEqual(0, elements.Count, MESSAGE_COUNTNOTMATCHING);

            for (int i = 0; i < 1000; i++)
			{
                elements.Push("asdf" + i);

                // asserts correct count
                Assert.AreEqual(i + 1, elements.Count, MESSAGE_COUNTNOTMATCHING);
			}

            for (int i = 999; i >= 0; i--)
            {
                string popedElement = elements.Pop();

                // asserts the poped and the pushed elements are the same
                Assert.AreEqual("asdf" + i, popedElement, MESSAGE_NOTEQUALNUMBERS);

                // asserts correct count
                Assert.AreEqual(i, elements.Count, MESSAGE_COUNTNOTMATCHING);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), MESSAGE_POPFROMEMPTYARRAYATACK)]
        public void TestPopFromEmptyStack()
        {
            ArrayStack<string> emptyElements = new ArrayStack<string>();
            emptyElements.Pop();
        }

        [TestMethod]
        public void TestPushPopWithInitialCapacity1()
        {
            ArrayStack<int> elements = new ArrayStack<int>(1);

            // asserts Count == 0
            Assert.AreEqual(0, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int firstPushedNumber = 3;
            elements.Push(firstPushedNumber);

            // asserts Count == 1
            Assert.AreEqual(1, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int secondPushedNumber = 17;
            elements.Push(secondPushedNumber);

            // asserts Count == 2
            Assert.AreEqual(2, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int firstPopedElement = elements.Pop();

            // asserts the poped and the pushed elements are the same
            Assert.AreEqual(secondPushedNumber, firstPopedElement, MESSAGE_NOTEQUALNUMBERS);

            // asserts Count == 1
            Assert.AreEqual(1, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int secondPopedElement = elements.Pop();

            // asserts the poped and the pushed elements are the same
            Assert.AreEqual(firstPushedNumber, secondPopedElement, MESSAGE_NOTEQUALNUMBERS);

            // asserts Count == 0
            Assert.AreEqual(0, elements.Count, MESSAGE_COUNTNOTMATCHING);
        }

        [TestMethod]
        public void TestToArrayMethod()
        {
            int[] numbers = new int[] { 3, 5, -2, 7 };
            ArrayStack<int> elements = new ArrayStack<int>();

            foreach (int number in numbers)
            {
                elements.Push(number);
            }

            int[] arrayStackNumbers = elements.ToArray();

            // asserts the two arrays are equal
            Assert.IsTrue(numbers.Reverse().SequenceEqual(arrayStackNumbers), MESSAGE_THETWOARRAYSARENOTSAME);
        }

        [TestMethod]
        public void TestEmptyArrayStackToArray()
        {
            ArrayStack<DateTime> elements = new ArrayStack<DateTime>();

            DateTime[] outputArray = elements.ToArray();

            // asserts the array is empty
            Assert.AreEqual(0, outputArray.Length, MESSAGE_COUNTNOTMATCHING);
        }
    }
}