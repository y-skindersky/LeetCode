using System.Security.Cryptography.X509Certificates;

namespace GraphTheory
{
    public static class WordLadder
    {
        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            using (WordProcessor p = new WordProcessor(wordList.Count + 2))
            {
                p.AddWord(beginWord);
                foreach (var word in wordList)
                {
                    p.AddWord(word);
                }
                //p.AddWord(endWord);

                return p.FindPath(beginWord, endWord);
            }
        }

        private class WordProcessor : IDisposable
        {
            private readonly string[] words;
            private int wordIndex;
            private readonly Dictionary<int, List<int>> paths;

            public WordProcessor(int n)
            {
                words = new string[n];
                wordIndex = 0;
                paths = new Dictionary<int, List<int>>();
            }

            public void Dispose()
            {

            }

            public void AddWord(string newWord)
            {
                List<int> neighbours = new List<int>();

                foreach (var index in paths.Keys)
                {
                    bool accepted = Diff(words[index], newWord);
                    if (accepted)
                    {
                        neighbours.Add(index);
                        paths[index].Add(wordIndex);
                    }
                }

                words[wordIndex] = newWord;
                paths.Add(wordIndex++, neighbours);
            }

            public int FindPath(int begin, int end)
            {
                if (end == -1)
                    return 0;
                Queue<(int x, int path)> queue = new Queue<(int x, int path)>();
                queue.Enqueue((begin, 1));
                while (queue.Count > 0)
                {
                    var currentPath = queue.Dequeue();
                    foreach (var neighbour in paths[currentPath.x])
                    {
                        if (neighbour == end)
                            return currentPath.path + 1;

                        queue.Enqueue((neighbour, currentPath.path + 1));
                    }
                    paths[currentPath.x].Clear();
                }
                return 0;
            }

            public int FindPath(string beginWord, string endWord)
            {
                return FindPath(Array.IndexOf(words, beginWord), Array.IndexOf(words, endWord));
            }
        }

        public static bool Diff(string a, string b)
        {
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i] && ++diff > 1)
                    return false;
            }
            return true;
        }
    }
}