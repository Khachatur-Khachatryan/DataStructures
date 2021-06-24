using System;
using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    class ClearTest
    {
        [Test]
        public void Clear_Test()
        {
            // Arrange
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(98);
            linkedList.AddHead(75);
            linkedList.AddHead(14);
            linkedList.AddHead(52);
            linkedList.AddTail(21);
            linkedList.AddTail(63);

            // Act
            linkedList.Clear();
            Action act = () => linkedList.Clear();

            // Assert
            linkedList.Head.Should().BeNull();
            linkedList.Tail.Should().BeNull();
            linkedList.Count.Should().Equals(0);
            act.Should().Throw<EmptyListException>();
        }

    }
}
