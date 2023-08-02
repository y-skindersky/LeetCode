using NUnit.Framework;

namespace GraphTheory.Tests
{
    public class ReverseWordsInAStringTests
    {
        [Test]
        [TestCase("the sky is blue", "blue is sky the")]
        [TestCase("  hello world  ", "world hello")]
        public void Test1(string input, string expected)
        {
            var output = ReverseWordsInAString.ReverseWords(input);

            Assert.AreEqual(expected, output);
        }
    }
}