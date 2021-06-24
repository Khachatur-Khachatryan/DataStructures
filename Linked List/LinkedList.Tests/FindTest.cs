using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    public class FindTest
    {
        [Test]
        public void Find_Test()
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
            linkedList.Contains(42).Should().BeFalse();
            node1.Should().Equals(linkedList.Head);
            node2.Should().Equals(linkedList.Tail);
        }


    }
}
