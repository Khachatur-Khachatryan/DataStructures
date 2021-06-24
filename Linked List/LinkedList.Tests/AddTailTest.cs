using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    public class AddTailTest
    {
        [Test]
        public void AddTail_Test()
        {
            // Arrange
            var linkedList = new LinkedList<char>();
            linkedList.AddHead('Є');

            // Act
            linkedList.AddTail('3');
            linkedList.AddTail('}');

            // Assert
            linkedList.Head.Should().Equals('Є');
            linkedList.Tail.Should().Equals('}');
            linkedList.Count.Should().Equals(3);
            linkedList.Contains('3').Should().BeFalse();
        }

    }
}
