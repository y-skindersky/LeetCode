using NUnit.Framework;

namespace GraphTheory.Tests
{
    public class IsGraphBipartiteTests
    {
        [Test]
        public void Test1()
        {
            var graph = new int[][]
            {
                new int[] { 1, 2, 3 },
                new int[] { 0, 2 },
                new int[] { 0, 1, 3 },
                new int[] { 0, 2 }
            };

            var result = IsGraphBipartite.IsBipartite(graph);

            Assert.IsFalse(result);
        }

        [Test]
        public void Test2()
        {
            var graph = new int[][]
            {
                new int[] { 1, 3 },
                new int[] { 0, 2 },
                new int[] { 1, 3 },
                new int[] { 0, 2 }
            };

            var result = IsGraphBipartite.IsBipartite(graph);

            Assert.IsTrue(result);
        }

        [Test]
        public void Test3()
        {
            var graph = new int[][]
            {
                new int[] { 4 },
                new int[] { },
                new int[] { 4 },
                new int[] { 4 },
                new int[] { 0, 2, 3 },
            };

            var result = IsGraphBipartite.IsBipartite(graph);

            Assert.IsTrue(result);
        }
    }
}