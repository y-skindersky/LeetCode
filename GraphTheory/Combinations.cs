using System.Collections;

namespace GraphTheory
{
    public static class Combinations
    {
        public static IList<IList<int>> Combine(int n, int k)
        {
            return Permutate(1, n, k).Select(x => (IList<int>)x).ToList();
        }

        private static IList<LinkedListNode> Permutate(int from, int to, int k)
        {
            IList<LinkedListNode> result = new List<LinkedListNode>();
            if (k == 0)
                return result;

            var tails = Permutate(from + 1, to, k - 1);
            for (int i = from; i <= to - k + 1; i++)
            {
                if (k == 1)
                {
                    var tail = new LinkedListNode
                    {
                        Value = i
                    };
                    result.Add(tail);
                    continue;
                }

                foreach (LinkedListNode tail in tails)
                {
                    if (i < tail.Value)
                    {
                        var perm = new LinkedListNode
                        {
                            Value = i,
                            Next = tail
                        };
                        result.Add(perm);
                    }
                }
            }

            return result;
        }

        public class LinkedListNode : IEnumerable<int>, IEnumerator<int>, IList<int>
        {
            public LinkedListNode()
            {
                Count = 1;
            }

            public int Value { get; set; }

            public LinkedListNode? Next
            {
                get => _next;
                set
                {
                    _next = value;
                    Count = _next.Count + 1;
                }
            }

            private LinkedListNode? currentItem = null;
            private LinkedListNode? _next;

            public IEnumerator<int> GetEnumerator()
            {
                return this;
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public bool MoveNext()
            {
                if (currentItem == null)
                {
                    currentItem = this;
                    return currentItem != null;
                }

                if (currentItem.Next != null)
                {
                    currentItem = currentItem.Next;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                currentItem = null;
            }

            public int Current
            {
                get
                {
                    if (currentItem == null)
                        return -1;
                    return currentItem.Value;
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                Reset();
            }

            public void Add(int item)
            {
                throw new NotImplementedException();
            }

            public void Clear()
            {
                throw new NotImplementedException();
            }

            public bool Contains(int item)
            {
                throw new NotImplementedException();
            }

            public void CopyTo(int[] array, int arrayIndex)
            {
                throw new NotImplementedException();
            }

            public bool Remove(int item)
            {
                throw new NotImplementedException();
            }

            public int Count { get; set; }
            public bool IsReadOnly { get; }
            public int IndexOf(int item)
            {
                throw new NotImplementedException();
            }

            public void Insert(int index, int item)
            {
                throw new NotImplementedException();
            }

            public void RemoveAt(int index)
            {
                throw new NotImplementedException();
            }

            public int this[int index]
            {
                get => throw new NotImplementedException();
                set => throw new NotImplementedException();
            }
        }
    }
}