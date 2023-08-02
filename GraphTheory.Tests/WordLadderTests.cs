using NUnit.Framework;

namespace GraphTheory.Tests
{
    public class WordLadderTests
    {
        [Test]
        public void Test1()
        {
            var result = WordLadder.LadderLength("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" });

            Assert.AreEqual(5, result);
        }

        [Test]
        public void Test2()
        {
            var result = WordLadder.LadderLength("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log" });

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Test3()
        {
            var result = WordLadder.LadderLength("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log" });

            Assert.AreEqual(0, result);
        }
    }
}