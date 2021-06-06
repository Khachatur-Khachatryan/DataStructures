using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using Queue.Logic;

namespace Queue.Tests
{
    public class DynamicQueueTests
    {
        /// <summary>
        /// Test for method Enqueue() of class Queue<T>
        /// </summary>
        [Test]
        public void EnqueueTest()
        {
            // Arrange
            int[] expected = { 32, 45, 12, 754, 55 };
            var queue = new Queue<int>();

            // Act
            queue.Enqueue(32);
            queue.Enqueue(45);
            queue.Enqueue(12);
            queue.Enqueue(754);
            queue.Enqueue(55);

            // Assert
            queue.ToArray().Should().Equals(expected);
            queue.Count.Should().Equals(5);
            queue.Peek.Should().Equals(32);
            queue.IsEmpty.Should().BeFalse();
        }

        /// <summary>
        /// Test for method Pop() of class Stack<T>
        /// </summary> 
        [Test]
        public void DequeueTest()
        {
            // Arrange
            char[] expected = { 'c', 'd', 'e'};
            var queue = new Queue<char>();
            queue.Enqueue('a');
            queue.Enqueue('b');
            queue.Enqueue('c');
            queue.Enqueue('d');
            queue.Enqueue('e');

            // Act
            queue.Dequeue();
            queue.Dequeue();

            // Assert
            queue.ToArray().Should().Equals(expected);
            queue.Count.Should().Equals(3);
            queue.Peek.Should().Equals('c');
            queue.IsEmpty.Should().BeFalse();
        }

        /// <summary>
        /// Test for exception of method Pop()
        /// </summary>
        [Test]
        public void DequeueException()
        {
            // Arrange
            var queue = new Queue<int>();

            // Act
            Action act = () => queue.Dequeue();

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}