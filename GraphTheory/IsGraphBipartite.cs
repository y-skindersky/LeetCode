namespace GraphTheory
{
    public static class IsGraphBipartite
    {
        public static bool IsBipartite(int[][] graph)
        {
            int[] parts = Enumerable.Repeat(-1, graph.Length).ToArray();

            for (int i = 0; i < graph.Length; i++)
            {
                if (parts[i] != -1)
                    continue;
                if (graph[i].Length == 0)
                    continue;

                Stack<int> order = new Stack<int>();
                order.Push(i);

                var part = 1;
                parts[i] = part;
                while (order.Count > 0)
                {
                    var j = order.Pop();
                    part = parts[j];
                    var neighborPart = 3 - part;
                    foreach (var neighbor in graph[j])
                    {
                        if (parts[neighbor] == part)
                            return false;
                        if (parts[neighbor] == -1)
                        {
                            parts[neighbor] = neighborPart;
                            order.Push(neighbor);
                        }
                    }
                }
            }

            return true;
        }
    }
}