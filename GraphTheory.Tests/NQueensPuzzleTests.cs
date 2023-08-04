using NUnit.Framework;

namespace GraphTheory.Tests
{
    public class NQueensPuzzleTests
    {
        [Test]
        //public void Test([Range(1, 9)] int n)
        public void Test4()
        {
            var result = NQueensPuzzle.SolveNQueens(4);

            foreach (var b in result)
            {
                foreach (var r in b)
                    Console.WriteLine(r);
                Console.WriteLine();
            }

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void Test7()
        {
            NQueensPuzzle.Board.Size = 7;
            NQueensPuzzle.Board.s.Clear();

            var ongoing = new NQueensPuzzle.Board();

            ongoing.PlaceNextQueenTo(6, false);
            ongoing.PlaceNextQueenTo(2);
            ongoing.Rollback();

            Assert.That(ongoing.AvailableColumns.Contains(3));
            ongoing.PlaceNextQueenTo(3);

            foreach (var r in ongoing.ToStrings())
                Console.WriteLine(r);

            Assert.That(ongoing.Queens.Any(q => q.x == 1 && q.y == 3));
            Assert.AreEqual(2, NQueensPuzzle.Board.s.Count);
        }

        [Test]
        public void Test7_Ex()
        {
            NQueensPuzzle.Board.Size = 7;
            NQueensPuzzle.Board.s.Clear();

            var ongoing = new NQueensPuzzle.Board();

            ongoing.PlaceNextQueenTo(6, false);
            ongoing.PlaceNextQueenTo(3, false);
            ongoing.PlaceNextQueenTo(0, false);
            ongoing.PlaceNextQueenTo(4, false);

            Assert.That(ongoing.AvailableColumns.Contains(1));
            ongoing.PlaceNextQueenTo(1);

            foreach (var r in ongoing.ToStrings())
                Console.WriteLine(r);
            Console.WriteLine();

            foreach (var b in NQueensPuzzle.Board.s)
            {
                foreach (var r in b.ToStrings())
                    Console.WriteLine(r);
                Console.WriteLine();
            }

            Assert.That(ongoing.Queens.Any(q => q.x == 4 && q.y == 1));
            Assert.AreEqual(1, NQueensPuzzle.Board.s.Count);
        }
    }
}