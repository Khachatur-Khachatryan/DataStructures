using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using Queue.Logic;

namespace Queue.Tests
{
    [TestFixture]
    class StaticQueueTests
    {
        [Test]
        public void EnqueueTest()
        {
            // Arrange
            int[] expected = { 23, 543, 12, 674, 32 }; 
            var queue = new Queue<int>(5);

            // Act
            queue.Enqueue(23);
            queue.Enqueue(543);
            queue.Enqueue(12);
            queue.Enqueue(674);
            queue.Enqueue(32);

            // Assert
            queue.ToArray().Should().Equals(expected);
            queue.Capacity.Should().Equals(5);
            queue.Count.Should().Equals(5);
            queue.Peek.Should().Equals(23);
            queue.IsFull.Should().BeTrue();
            queue.IsEmpty.Should().BeFalse();
        }

        [Test]
        public void EnqueueExceptionTest()
        {
            // Arrange
            var queue = new Queue<char>(3);
            queue.Enqueue('}');
            queue.Enqueue('2');
            queue.Enqueue('v');

            // Act
            Action act = () => queue.Enqueue('}');

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Test for method Pop() of class Stack<T>
        /// </summary> 
        [Test]
        public void DequeueTest()
        {
            // Arrange
            int[] expected = { 3, 4, 5 };
            var queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            // Act
            queue.Dequeue();
            queue.Dequeue();

            // Assert
            queue.ToArray().Should().Equals(expected);
            queue.Count.Should().Equals(3);
            queue.Peek.Should().Equals(3);
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
