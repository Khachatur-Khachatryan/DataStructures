using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    public class RemoveHeadTest
    {
        [Test]
        public void RemoveHead_Test()
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
            linkedList.Head.Should().Equals(3.14M);
            linkedList.Head.Previous.Should().BeNull();
            linkedList.Tail.Should().Equals(15.00001M);
            linkedList.Count.Should().Equals(3);
            linkedList.Contains(62.32M).Should().BeFalse();
        }

    }
}
