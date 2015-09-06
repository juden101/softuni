namespace StacksAndQueuesHomework.Tests
{
    using System;
    using System.Linq;
    using StacksAndQueuesHomework;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestLinkedQueue
    {
        private const string MESSAGE_COUNTNOTMATCHING = "LinkedQueue count is not correct.";
        private const string MESSAGE_NOTEQUALNUMBERS = "The two numbers are not equal.";
        private const string MESSAGE_POPFROMEMPTYARRAYATACK = "You cannot dequeue from empty linked queue.";
        private const string MESSAGE_THETWOARRAYSARENOTSAME = "The two arrays are not the same.";

        [TestMethod]
        public void TestEnqueueAndDequeueOneElement()
        {
            LinkedQueue<int> elements = new LinkedQueue<int>();

            // asserts Count == 0
            Assert.AreEqual(0, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int enqueuedNumber = 3;
            elements.Enqueue(enqueuedNumber);

            // asserts Count == 1
            Assert.AreEqual(1, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int dequeuedNumber = elements.Dequeue();

            // asserts the poped and the pushed elements are the same
            Assert.AreEqual(enqueuedNumber, dequeuedNumber, MESSAGE_NOTEQUALNUMBERS);

            // asserts Count == 0
            Assert.AreEqual(0, elements.Count, MESSAGE_COUNTNOTMATCHING);
        }
        
        [TestMethod]
        public void TestPushAndPopThousandElements()
        {
            LinkedQueue<string> elements = new LinkedQueue<string>();

            // asserts Count == 0
            Assert.AreEqual(0, elements.Count, MESSAGE_COUNTNOTMATCHING);

            for (int i = 0; i < 1000; i++)
            {
                elements.Enqueue("asdf" + i);

                // asserts correct count
                Assert.AreEqual(i + 1, elements.Count, MESSAGE_COUNTNOTMATCHING);
            }

            for (int i = 0, j = 999; i < 1000; i++, j--)
            {
                string dequeuedElement = elements.Dequeue();

                // asserts the poped and the pushed elements are the same
                Assert.AreEqual("asdf" + i, dequeuedElement, MESSAGE_NOTEQUALNUMBERS);

                // asserts correct count
                Assert.AreEqual(j, elements.Count, MESSAGE_COUNTNOTMATCHING);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), MESSAGE_POPFROMEMPTYARRAYATACK)]
        public void TestPopFromEmptyStack()
        {
            LinkedQueue<string> emptyElements = new LinkedQueue<string>();
            emptyElements.Dequeue();
        }

        [TestMethod]
        public void TestPushPopWithTwoElements()
        {
            LinkedQueue<int> elements = new LinkedQueue<int>();

            // asserts Count == 0
            Assert.AreEqual(0, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int firstEnqueuedNumber = 3;
            elements.Enqueue(firstEnqueuedNumber);

            // asserts Count == 1
            Assert.AreEqual(1, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int secondEnqueuedNumber = 17;
            elements.Enqueue(secondEnqueuedNumber);

            // asserts Count == 2
            Assert.AreEqual(2, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int firstDequeuedElement = elements.Dequeue();

            // asserts the poped and the pushed elements are the same
            Assert.AreEqual(firstEnqueuedNumber, firstDequeuedElement, MESSAGE_NOTEQUALNUMBERS);

            // asserts Count == 1
            Assert.AreEqual(1, elements.Count, MESSAGE_COUNTNOTMATCHING);

            int secondDequeuedElement = elements.Dequeue();

            // asserts the poped and the pushed elements are the same
            Assert.AreEqual(secondEnqueuedNumber, secondDequeuedElement, MESSAGE_NOTEQUALNUMBERS);

            // asserts Count == 0
            Assert.AreEqual(0, elements.Count, MESSAGE_COUNTNOTMATCHING);
        }
        
        [TestMethod]
        public void TestToArrayMethod()
        {
            int[] numbers = new int[] { 3, 5, -2, 7 };
            LinkedQueue<int> elements = new LinkedQueue<int>();

            foreach (int number in numbers)
            {
                elements.Enqueue(number);
            }

            int[] arrayStackNumbers = elements.ToArray();

            // asserts the two arrays are equal
            Assert.IsTrue(numbers.SequenceEqual(arrayStackNumbers), MESSAGE_THETWOARRAYSARENOTSAME);
        }
        
        [TestMethod]
        public void TestEmptyArrayStackToArray()
        {
            LinkedQueue<DateTime> elements = new LinkedQueue<DateTime>();

            DateTime[] outputArray = elements.ToArray();

            // asserts the array is empty
            Assert.AreEqual(0, outputArray.Length, MESSAGE_COUNTNOTMATCHING);
        }
    }
}