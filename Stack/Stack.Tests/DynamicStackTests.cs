using System;
using System.Linq;
using NUnit.Framework;
using FluentAssertions;
using Stack.Logic;

namespace Stack.Tests
{
    /// <summary>
    /// Unit-tests for dynamic stack
    /// </summary>
    [TestFixture]
    public class DynamicStackTests
    {

        /// <summary>
        /// Tests for method Push() of class Stack<T>
        /// </summary>
        [Test]
        public void PushTest()
        {
            // Arrange
            var stack = new Stack<int>();
            int[] expected = { 2, 4, 6, 8 };

            // Act
            stack.Push(2);
            stack.Push(4);
            stack.Push(6);
            stack.Push(8);

            // Assert
            stack.ToArray().Should().Equals(expected);
            stack.Count.Should().Equals(4);
            stack.Peek.Should().Equals(8);
            stack.IsEmpty.Should().BeFalse();
        }

        /// <summary>
        /// Tests for method Pop() of class Stack<T>
        /// </summary>
        [Test]
        public void PopTest()
        {
            // Arrange
            var stack = new Stack<char>();
            stack.Push('}');
            stack.Push('2');
            stack.Push('#');
            stack.Push('s');
            stack.Push('A');
            char[] expected = { '}', '2', '#' };

            // Act
            stack.Pop();
            stack.Pop();

            // Assert
            stack.ToArray().Should().Equals(expected);
            stack.Count.Should().Equals(3);
            stack.Peek.Should().Equals('#');
            stack.IsEmpty.Should().BeFalse();
        }

        /// <summary>
        /// Test for exception of method Pop()
        /// </summary>
        [Test]
        public void PopExceptionTest()
        {
            // Arrange
            var stack = new Stack<char>();

            // Act
            Action act = () => stack.Pop();

            // Assert
            act.Should().Throw<InvalidOperationException>();
        }
    }
}