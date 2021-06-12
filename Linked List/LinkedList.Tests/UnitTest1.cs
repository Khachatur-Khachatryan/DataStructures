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
            linkedList.Head.Should().Equals(24);
            linkedList.Tail.Should().Equals(41);
            linkedList.Count.Should().Equals(3);
            linkedList.IsEmpty.Should().BeFalse();
        }

        [Test]
        public void AddTailTest()
        {
            // Arrange
            var linkedList = new LinkedList<char>();

            // Act
            linkedList.AddTail('♂');
            linkedList.AddTail('3');
            linkedList.AddTail('}');

            // Assert
            linkedList.Head.Should().Equals('♂');
            linkedList.Tail.Should().Equals('}');
            linkedList.Count.Should().Equals(3);
            linkedList.IsEmpty.Should().BeFalse();
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
        }

        [Test]
        public void RemoveTailTest()
        {
            // Arrange
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(13);
            linkedList.AddTail(45);
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
            linkedList.Head.Should().Equals(null);
            linkedList.Tail.Should().Equals(null);
            linkedList.Count.Should().Equals(0);
            linkedList.IsEmpty.Should().BeTrue();
        }
    }
}