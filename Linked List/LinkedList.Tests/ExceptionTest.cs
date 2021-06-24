using System;
using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    public class ExceptionTests
    {
        [Test]
        public void Exception_Tests()
        {
            // Arrange
            var linkedList = new LinkedList<string>();
            linkedList.AddHead("hello world");
            linkedList.AddHead("lorem ipsum");
            linkedList.AddHead("abcde");
            linkedList.AddTail("12345");

            var node1 = new Node<string>("banan", linkedList) { Next = null, Previous = null };
            var node2 = new Node<string>("notebook") { Next = new Node<string>("fdsg"), Previous = node1 };
            var node3 = new Node<string>("прiвiт свiт") { Previous = node2 };
            var node4 = new Node<string>("<>/\\|:''{}[]") { Next = node3 };

            // Act
            Action act1 = () => linkedList.AddAfter(node1, "apple");
            Action act2 = () => linkedList.AddAfter(node2, "book");
            Action act3 = () => linkedList.AddAfter(node3, "абвгд");
            Action act4 = () => linkedList.AddAfter(node4, "/*-+.");

            // Assert
            linkedList.Head.Should().Equals(9845);
            linkedList.Tail.Should().Equals(12);
            linkedList.Count.Should().Equals(5);
            act1.Should().Throw<EmptyNodeException>();
            act2.Should().Throw<NotBelongToThisListException>();
            act3.Should().Throw<NullNextException>();
            act4.Should().Throw<NullPreviousException>();
        }
    }
}
