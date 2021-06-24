using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    public class RemoveTailTest
    {
        [Test]
        public void RemoveTail_Test()
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
            linkedList.Contains(13).Should().BeTrue();
        }
    }
}
