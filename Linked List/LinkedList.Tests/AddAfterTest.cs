using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    public class AddAfterTest
    {
        [Test]
        public void AddAfter_Test()
        {
            // Arrange 
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(251);
            linkedList.AddHead(634);
            linkedList.AddTail(498);
            var node1 = (Node<int>)linkedList.Find(634);
            var node2 = (Node<int>)linkedList.Tail;

            // Act
            linkedList.AddAfter(node1, 236);
            linkedList.AddAfter(node2, 748);

            // Assert
            linkedList.Head.Should().Equals(634);
            linkedList.Tail.Should().Equals(748);
            linkedList.Count.Should().Equals(5);
            linkedList.Contains(634).Should().BeTrue();
            node1.List.Should().Equals(linkedList);
        }

    }
}
