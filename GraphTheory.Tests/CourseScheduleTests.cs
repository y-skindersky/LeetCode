using NUnit.Framework;

namespace GraphTheory.Tests
{
    public class CourseScheduleTests
    {
        [Test]
        public void Test1()
        {
            var result = CourseSchedule.CanFinish(2, new[]
            {
                new[] { 0, 1 }
            });

            Assert.IsTrue(result);
        }

        [Test]
        public void Test2()
        {
            var result = CourseSchedule.CanFinish(2, new[]
            {
                new[] { 1, 0 },
                new[] { 0, 1 }
            });

            Assert.IsFalse(result);
        }

        [Test]
        public void Test3()
        {
            var result = CourseSchedule.CanFinish(1, new int[0][]);

            Assert.IsTrue(result);
        }

        [Test]
        public void Test4()
        {
            var result = CourseSchedule.CanFinish(3, new[]
            {
                new[] { 1, 0 },
                new[] { 1, 2 },
                new[] { 0, 1 }
            });

            Assert.IsFalse(result);
        }
    }
}