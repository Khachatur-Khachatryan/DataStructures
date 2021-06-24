using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;
namespace LinkedList.Tests
{
    [TestFixture]
    public class AddHeadTest
    {
        [Test]
        public void AddHead_Test()
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
            linkedList.Contains(37).Should().BeTrue();
        }
    }
}
