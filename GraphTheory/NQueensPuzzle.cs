using System.Collections;
using System.Text;

namespace GraphTheory
{
    public static class NQueensPuzzle
    {
        public static IList<IList<string>> SolveNQueens(int n)
        {
            Board.Size = n;
            Board.s.Clear();

            var ongoing = new Board();
            for (int j = 0; j < n; j++)
            {
                ongoing.PlaceNextQueenTo(j);
                ongoing.Rollback();
            }

            var boards = new List<IList<string>>();
            foreach (Board board in Board.s)
            {
                boards.Add(board.ToStrings());
            }

            return boards;
        }

        public class Board
        {
            public static readonly List<Board> s = new List<Board>();
            public static int Size;

            private readonly int[] _queens;
            private readonly BusyFlag[] _mask;
            private int _row;
            private int _minMask;
            private int _maxMask;

            public Board()
            {
                _queens = new int[Size];
                _mask = new BusyFlag[3 * Size];
                _row = 0;
                _minMask = Size;
                _maxMask = 2 * Size - 1;
            }

            public void PlaceNextQueenTo(int column, bool placeNext = true)
            {
                _queens[_row++] = column;
                _mask[Size + column] = BusyFlag.Busy | BusyFlag.Up | BusyFlag.Down;

                _minMask = Math.Min(_minMask, Size + column);
                _maxMask = Math.Max(_maxMask, Size + column);

                MoveForward();

                if (_row == Size)
                {
                    s.Add(DeepClone());
                    return;
                }

                if (!placeNext)
                    return;

                foreach (var possibleColumn in AvailableColumns)
                {
                    PlaceNextQueenTo(possibleColumn);
                    Rollback();
                }
            }

            private Board DeepClone()
            {
                var clone = new Board();
                clone._row = _row;
                Array.Copy(_queens, clone._queens, _queens.Length);
                Array.Copy(_mask, clone._mask, _mask.Length);
                return clone;
            }

            private void MoveForward()
            {
                for (int i = _minMask; i <= _maxMask; i++)
                {
                    if (_mask[i].HasFlag(BusyFlag.Down))
                    {
                        _mask[i] &= ~BusyFlag.Down;
                        _mask[i - 1] |= BusyFlag.Down;
                        _minMask = Math.Min(_minMask, i - 1);
                    }
                }

                for (int i = _maxMask; i >= _minMask; i--)
                {
                    if (_mask[i].HasFlag(BusyFlag.Up))
                    {
                        _mask[i] &= ~BusyFlag.Up;
                        _mask[i + 1] |= BusyFlag.Up;
                        _maxMask = Math.Max(_maxMask, i + 1);
                    }
                }
            }

            private void MoveBackward()
            {
                for (int i = _minMask; i <= _maxMask; i++)
                {
                    if (_mask[i].HasFlag(BusyFlag.Up))
                    {
                        _mask[i] &= ~BusyFlag.Up;
                        _mask[i - 1] |= BusyFlag.Up;
                        if (_maxMask == i)
                            _maxMask--;
                    }
                }
                for (int i = _maxMask; i >= _minMask; i--)
                {
                    if (_mask[i].HasFlag(BusyFlag.Down))
                    {
                        _mask[i] &= ~BusyFlag.Down;
                        _mask[i + 1] |= BusyFlag.Down;
                        if (_minMask == i)
                            _minMask++;
                    }
                }
            }

            public List<string> ToStrings()
            {
                List<string> result = new List<string>();
                foreach (var q in Queens.OrderBy(q => q.x))
                {
                    result.Add(new string('.', q.y) + "Q" + new string('.', Size - q.y - 1));
                }
                return result;
            }

            public IEnumerable<(int x, int y)> Queens
            {
                get
                {
                    for (int i = 0; i < Size; i++)
                    {
                        if (i >= _row)
                            yield break;

                        yield return new(i, _queens[i]);
                    }
                }
            }

            public IEnumerable<int> AvailableColumns
            {
                get
                {
                    for (int i = Size; i < 2 * Size; i++)
                    {
                        if (_mask[i] == BusyFlag.Empty)
                            yield return i - Size;
                    }
                }
            }

            public void Rollback()
            {
                MoveBackward();

                _mask[Size + _queens[_row - 1]] = BusyFlag.Empty;
                _queens[_row - 1] = -1;

                _row--;
                _minMask = Math.Min(_minMask, Size + _row);
            }
        }

        [Flags]
        internal enum BusyFlag
        {
            Empty = 0,
            Busy = 1,
            Up = 2,
            Down = 4
        }
    }
}