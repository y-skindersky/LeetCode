using NUnit.Framework;

namespace GraphTheory.Tests
{
    public class NumberOfProvincesTests
    {
        [Test]
        public void Test1()
        {
            var isConnected = new[]
            {
                new[] { 1, 1, 0 }, 
                new[] { 1, 1, 0 }, 
                new[] { 0, 0, 1 }
            };

            var result = NumberOfProvinces.FindCircleNum(isConnected);

            Assert.AreEqual(2, result);
        }
        
        [Test]
        public void Test2()
        {
            var isConnected = new[]
            {
                new[] { 1, 0, 0 }, 
                new[] { 0, 1, 0 }, 
                new[] { 0, 0, 1 }
            };

            var result = NumberOfProvinces.FindCircleNum(isConnected);

            Assert.AreEqual(3, result);
        }
        
        [Test]
        public void Test3()
        {
            var isConnected = new[]
            {
                new[] { 1, 0, 0, 1 }, 
                new[] { 0, 1, 1, 0 }, 
                new[] { 0, 1, 1, 1 },
                new[] { 1, 0, 1, 1 }
            };

            var result = NumberOfProvinces.FindCircleNum(isConnected);

            Assert.AreEqual(1, result);
        }
    }
}