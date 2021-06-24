using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    public class ReverseTest
    {
        [Test]
        public void Reverse_Test()
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
            linkedList.Contains(52).Should().BeTrue();
        }


    }
}
