using System;
using NUnit.Framework;
using FluentAssertions;
using LinkedList.Logic;

namespace LinkedList.Tests
{
    [TestFixture]
    public class Tests
    {
        /// <summary>
        /// Test for method AddHead(T data)
        /// </summary>
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
            linkedList.Contains(37).Should().BeTrue();
        }

        /// <summary>
        /// Test for method AddTail(T data)
        /// </summary>
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
            linkedList.Contains('3').Should().BeFalse();
        }

        /// <summary>
        /// Test for method AddAfter(IElement<T> elem, T data);
        /// </summary>
        [Test]
        public void AddAfterTest()
        {
            // Arrange 
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(251);
            linkedList.AddHead(634);
            linkedList.AddTail(498);
            var elem1 = (Element<int>) linkedList.Find(634);
            var elem2 = (Element<int>) linkedList.Tail;

            // Act
            linkedList.AddAfter(elem1, 236);
            linkedList.AddAfter(elem2, 748);
            Action act = () => linkedList.AddAfter(new Element<int>(478), 34);

            // Assert
            linkedList.Head.Should().Equals(634);
            linkedList.Tail.Should().Equals(748);
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains(634).Should().BeTrue();
            act.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Test for method RemoveAfter(IElement<T> elem, T data)
        /// </summary>
        [Test]
        public void RemoveAfterTest()
        {
            // Arrange 
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(4689);
            linkedList.AddHead(786);
            linkedList.AddTail(91);
            linkedList.AddTail(23);
            var elem1 = linkedList.Find(786);
            var elem2 = linkedList.Tail;

            // Act
            linkedList.RemoveAfter(elem1);
            linkedList.RemoveAfter(elem2);
            Action act = () => linkedList.RemoveAfter(new Element<int>(25));

            // Assert
            linkedList.Head.Should().Equals(4689);
            linkedList.Tail.Should().Equals(786);
            linkedList.Count.Should().Equals(2);
            linkedList.IsEmpty.Should().BeFalse();
            act.Should().Throw<InvalidOperationException>();
        }

        /// <summary>
        /// Test for method RemoveHead()
        /// </summary>
        [Test]
        public void RemoveHeadTest()
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
            linkedList.Head.Should().Equals(13M);
            linkedList.Tail.Should().Equals(15.00001M);
            linkedList.Count.Should().Equals(3);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains(62.32M).Should().BeFalse();
        }

        /// <summary>
        /// Test for method RemoveTail()
        /// </summary>
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
            linkedList.Contains(13).Should().BeTrue();
        }

        /// <summary>
        /// Test for method Clear()
        /// </summary>
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
            linkedList.Head.Should().Equals(24);
            linkedList.Tail.Should().Equals(958);
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeTrue();
            linkedList.Contains(64).Should().BeFalse();
        }

        /// <summary>
        /// Test for method Reverse()
        /// </summary>
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
            linkedList.Equals(expected);
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains(52).Should().BeTrue();
        }

        /// <summary>
        /// Test for method Find(T data)
        /// </summary>
        [Test]
        public void FindTest()
        {
            // Arrange
            var linkedList = new LinkedList<int>();
            linkedList.AddHead(6);
            linkedList.AddHead(52);
            linkedList.AddHead(754);
            linkedList.AddHead(176);
            linkedList.AddTail(96);

            // Act
            var i = (Element<int>)linkedList.Find(6);
            var j = (Element<int>)linkedList.Find(96);

            // Assert
            linkedList.Count.Should().Equals(5);
            linkedList.IsEmpty.Should().BeFalse();
            linkedList.Contains(42).Should().BeFalse();
            i.Should().Equals(linkedList.Head);
            i.Next.Should().Equals(754);
            j.Should().Equals(linkedList.Tail);

        }
    }
}