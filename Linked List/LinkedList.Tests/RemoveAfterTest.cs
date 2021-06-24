using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    public class RemoveAfterTest
    {
        [Test]
        public void RemoveAfter_Test()
        {
            // Arrange 
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(4689);
            linkedList.AddHead(786);
            linkedList.AddTail(91);
            linkedList.AddTail(23);
            var node1 = linkedList.Find(786);
            var node2 = linkedList.Find(4689);

            // Act
            linkedList.RemoveAfter(node1);
            linkedList.RemoveAfter(node2);

            // Assert
            linkedList.Head.Should().Equals(4689);
            linkedList.Tail.Should().Equals(786);
            linkedList.Count.Should().Equals(2);
        }

    }
}
