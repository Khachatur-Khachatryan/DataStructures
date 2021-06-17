using System;
using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AddHeadTest()
        {
            // Arrange
            var linkedList = new LinkedList<int>();

            // Act 
            linkedList.AddHead(41);
            linkedList.AddHead(37);
            linkedList.AddHead(24);

            // Assert
            linkedList.Head.Should().Equals(41);
            linkedList.Tail.Should().Equals(24);
            linkedList.Count.Should().Equals(3);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains(37).Should().BeTrue();
        }
        
        [Test]
        public void AddTailTest()
        {
            // Arrange
            var linkedList = new LinkedList<char>();
            linkedList.AddHead('♂');

            // Act
            linkedList.AddTail('3');
            linkedList.AddTail('}');

            // Assert
            linkedList.Head.Should().Equals('♂');
            linkedList.Tail.Should().Equals('}');
            linkedList.Count.Should().Equals(3);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains('3').Should().BeFalse();
        }

        [Test]
        public void AddAfterTest()
        {
            // Arrange 
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(251);
            linkedList.AddHead(634);
            linkedList.AddTail(498);
            var node1 = (Node<int>) linkedList.Find(634);
            var node2 = (Node<int>) linkedList.Tail;
            var node3 = new Node<int>(362) { Next = node2 };
            var node4 = new Node<int>(63) { Previous = node3 };
            var node5 = new Node<int>(58) { Next = node4, Previous = node3 };

            // Act
            linkedList.AddAfter(node1, 236);
            linkedList.AddAfter(node2, 748);
            Action act = () => linkedList.AddAfter(new Node<int>(478), 34);
            Action act2 = () => linkedList.AddAfter(node3, 236);
            Action act3 = () => linkedList.AddAfter(node4, 285);
            Action act4 = () => linkedList.AddAfter(node5, 845);

            // Assert
            linkedList.Head.Should().Equals(634);
            linkedList.Tail.Should().Equals(748);
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains(634).Should().BeTrue();
            act.Should().Throw<EmptyNodeException>();
            act2.Should().Throw<NullPreviousException>();
            act3.Should().Throw<NullNextException>();
            act4.Should().Throw<NotBelongToThisListException>();
        }

        [Test]
        public void RemoveAfterTest()
        {
            // Arrange 
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(4689);
            linkedList.AddHead(786);
            linkedList.AddTail(91);
            linkedList.AddTail(23);
            var node1 = linkedList.Find(786);
            var node2 = linkedList.Tail;
            var node3 = new Node<int>(362) { Next = node2 };
            var node4 = new Node<int>(63) { Previous = node3 };
            var node5 = new Node<int>(58) { Next = node4, Previous = node3 };

            // Act
            linkedList.RemoveAfter(node1);
            linkedList.RemoveAfter(node2);
            Action act = () => linkedList.RemoveAfter(new Node<int>(478));
            Action act2 = () => linkedList.RemoveAfter(node3);
            Action act3 = () => linkedList.RemoveAfter(node4);
            Action act4 = () => linkedList.RemoveAfter(node5);

            // Assert
            linkedList.Head.Should().Equals(4689);
            linkedList.Tail.Should().Equals(786);
            linkedList.Count.Should().Equals(2);
            linkedList.IsEmpty.Should().BeFalse(); 
            act.Should().Throw<EmptyNodeException>();
            act2.Should().Throw<NullPreviousException>();
            act3.Should().Throw<NullNextException>();
            act4.Should().Throw<NotBelongToThisListException>();
        }

        [Test]
        public void RemoveHeadTest()
        {
            // Arrange
            var linkedList = new LinkedList<decimal>();
            linkedList.AddHead(13M);
            linkedList.AddHead(25.2632M);
            linkedList.AddHead(3.14M);
            linkedList.AddHead(6437.734734732M);
            linkedList.AddTail(15.00001M);

            // Act
            linkedList.RemoveHead();
            linkedList.RemoveHead();

            // Assert
            linkedList.Head.Should().Equals(13M);
            linkedList.Tail.Should().Equals(15.00001M);
            linkedList.Count.Should().Equals(3);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains(62.32M).Should().BeFalse();
        }

        [Test]
        public void RemoveTailTest()
        {
            // Arrange
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(13);
            linkedList.AddHead(45);
            linkedList.AddTail(98);
            linkedList.AddTail(532);
            linkedList.AddTail(35);

            // Act
            linkedList.RemoveTail();
            linkedList.RemoveTail();

            // Assert
            linkedList.Head.Should().Equals(13);
            linkedList.Tail.Should().Equals(98);
            linkedList.Count.Should().Equals(3);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains(13).Should().BeTrue();
        }

        [Test]
        public void ClearTest()
        {
            // Arrange
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(98);
            linkedList.AddHead(75);
            linkedList.AddHead(14);
            linkedList.AddHead(52);
            linkedList.AddTail(21);

            // Act
            linkedList.Clear();

            // Assert
            linkedList.Head.Should().Equals(24);
            linkedList.Tail.Should().Equals(958);
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeTrue();
            linkedList.Contains(64).Should().BeFalse();
        }

        [Test]
        public void ReverseTest()
        {
            // Arrange
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(98);
            linkedList.AddHead(75);
            linkedList.AddHead(14);
            linkedList.AddHead(52);
            linkedList.AddTail(21);

            var expected = new LinkedList<int>();
            linkedList.AddHead(21);
            linkedList.AddHead(52);
            linkedList.AddHead(14);
            linkedList.AddHead(75);
            linkedList.AddTail(98);

            // Act
            linkedList.Reverse();

            // Assert
            linkedList.Equals(expected);
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains(52).Should().BeTrue();
        }

        [Test]
        public void FindTest()
        {
            // Arrange
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(6);
            linkedList.AddHead(52);
            linkedList.AddHead(754);
            linkedList.AddHead(176);
            linkedList.AddTail(96);

            // Act
            var node1 = (Node<int>)linkedList.Find(6);
            var node2 = (Node<int>)linkedList.Find(96);

            // Assert
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains(42).Should().BeFalse();
            node1.Should().Equals(linkedList.Head);
            node2.Should().Equals(linkedList.Tail);
        }

        [Test]
        public void ContainsTest()
        {
            // Arrange
            var linkedList = new LinkedList<char>();
            linkedList.AddHead('d');
            linkedList.AddHead('}');
            linkedList.AddHead('2');
            linkedList.AddHead('ы');
            linkedList.AddTail('/');

            var node1 = linkedList.Find('}');
            var node2 = linkedList.Find('ы');
            // Act
            var contains1 = linkedList.Contains(node1);
            var contains2 = linkedList.Contains(node2);
            var contains3 = linkedList.Contains(new Node<char>('.'));

            // Assert
            linkedList.Head.Should().Equals('ы');
            linkedList.Tail.Should().Equals('/');
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains('5').Should().BeFalse();
            contains1.Should().BeTrue();
            contains2.Should().BeTrue();
            contains3.Should().BeFalse();
        }
    }
}