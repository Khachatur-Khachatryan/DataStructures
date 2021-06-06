using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using Stack.Logic;

namespace Stack.Tests
{
    /// <summary>
    /// Unit-tests for static stack
    /// </summary>
    [TestFixture]
    class StaticStackTests
    {
        /// <summary>
        /// Test for method Push() of class Stack<T>
        /// </summary>
        [Test]
        public void PushTest()
        {
            // Arrange
            var stack = new Stack<int>(5);
            int[] expected = { 42, 54, 78, 2, 398 };

            // Act
            stack.Push(42);
            stack.Push(54);
            stack.Push(78);
            stack.Push(2);
            stack.Push(398);

            // Assert
            stack.ToArray().Should().Equals(expected);
            stack.Capacity.Should().Equals(5);
            stack.Count.Should().Equals(5);
            stack.Peek.Should().Equals(398);
            stack.IsFull.Should().BeTrue();
            stack.IsEmpty.Should().BeFalse();
        }

        /// <summary>
        /// Test for exception of method Push()
        /// </summary>
        [Test]
        public void PushExceptionTest()
        {
            // Arrange
            var stack = new Stack<char>(3);
            stack.Push('a');
            stack.Push(')');
            stack.Push('$');

            // Act
            Action act = () => stack.Push('û');

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Test for method Pop() of class Stack<T>
        /// </summary>
        [Test]
        public void PopTest()
        {
            // Arrange 
            int[] expected = { 21, 34, 2853 };
            var stack = new Stack<int>(5);
            stack.Push(21);
            stack.Push(34);
            stack.Push(2853);
            stack.Push(987);
            stack.Push(124);

            // Act
            stack.Pop();
            stack.Pop();

            // Assert
            stack.ToArray().Should().Equals(expected);
            stack.Capacity.Should().Equals(5);
            stack.Count.Should().Equals(5);
            stack.Peek.Should().Equals(124);
            stack.IsFull.Should().BeFalse();
            stack.IsEmpty.Should().BeFalse();
        }

        /// <summary>
        /// Test for exception of method Pop()
        /// </summary>
        [Test]
        public void PopExceptionTest()
        {
            // Arrange
            var stack = new Stack<char>(3);

            // Act
            Action act = () => stack.Pop();

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}
