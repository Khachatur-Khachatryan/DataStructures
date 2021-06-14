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
            linkedList.Find(1).Should().Equals(41);
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
            linkedList.Find(1).Should().Equals('♂');
        }

        [Test]
        public void AddAfterTest()
        {
            // Arrange
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(24);
            linkedList.AddHead(25);
            linkedList.AddTail(958);

            var expected = new LinkedList<int>();
            expected.AddHead(24);
            expected.AddHead(25);
            expected.AddHead(63);
            expected.AddHead(87);
            expected.AddTail(958);


            // Act
            linkedList.AddAfter(2, 63);
            linkedList.AddAfter(3, 87);

            // Assert
            linkedList.Head.Should().Equals(24);
            linkedList.Tail.Should().Equals(958);
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Find(3).Should().Equals(63);
        }

        [Test]
        public void RemoveHeadTest()
        {
            // Arrange
            var linkedList = new LinkedList<dynamic>();
            linkedList.AddHead(13);
            linkedList.AddHead('$');
            linkedList.AddHead("stalker top");
            linkedList.AddHead(true);
            linkedList.AddTail(0.24F);

            // Act
            linkedList.RemoveHead();
            linkedList.RemoveHead();

            // Assert
            linkedList.Head.Should().Equals("stalker top");
            linkedList.Tail.Should().Equals(0.24F);
            linkedList.Count.Should().Equals(3);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Find(3).Should().Equals(0.24F);
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
            linkedList.Find(2).Should().Equals(45);
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

            Action act = () => linkedList.Find(3);

            // Assert
            linkedList.Head.Should().Equals(24);
            linkedList.Tail.Should().Equals(958);
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeTrue();
            act.Should().Throw<IndexOutOfRangeException>();
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
            linkedList.Head.Should().Equals(21);
            linkedList.Tail.Should().Equals(98);
            linkedList.Count.Should().Equals(5);
            linkedList.Find(1).Should().Equals(21);
            linkedList.IsEmpty.Should().BeFalse();
        }
    }
}