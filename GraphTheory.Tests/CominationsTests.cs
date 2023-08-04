using NUnit.Framework;

namespace GraphTheory.Tests
{
    public class CominationsTests
    {
        [Test]
        public void Test()
        {
            var result = Combinations.Combine(4, 2);

            foreach (var list in result)
            {
                Console.WriteLine(string.Join(",", list));
            }

            Assert.AreEqual(6, result.Count);
        }

        /// <summary>
        /// <seealso cref="Combinations.LinkedListNode.this[int]"/>
        /// </summary>
        [Ignore("LinkedListNode indexer is not implemented")]
        [Test]
        public void Test1()
        {
            var result = Combinations.Combine(1, 1);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.Single().Single());
        }        

        [Test]
        public void Test13()
        {
            var result = Combinations.Combine(13, 13);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(13, result.Single().Count);
        }

        [Test]
        public void Test20()
        {
            var result = Combinations.Combine(20, 16);

            Assert.AreEqual(4845, result.Count);
            Assert.AreEqual(16, result.First().Count);
            Assert.AreEqual(16, result.Last().Count);
        }
    }
}