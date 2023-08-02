namespace GraphTheory
{
    public static class NearestExitFromEntranceInMaze
    {
        public static int NearestExit(char[][] maze, int[] entrance)
        {
            var positions = new Queue<(byte x, byte y, short d)>();
            positions.Enqueue(((byte)entrance[0], (byte)entrance[1], 0));
            maze[entrance[0]][entrance[1]] = ' ';

            while (positions.Count > 0)
            {
                var currentPosition = positions.Dequeue();

                var x = currentPosition.x;
                var y = currentPosition.y;
                short steps = (short)(currentPosition.d + 1);

                if (Check(ref maze, x - 1, y))
                {
                    positions.Enqueue(((byte)(x - 1), y, steps));
                    maze[x - 1][y] = ' ';
                }
                if (Check(ref maze, x + 1, y))
                {
                    positions.Enqueue(((byte)(x + 1), y, steps));
                    maze[x + 1][y] = ' ';
                }
                if (Check(ref maze, x, y - 1))
                {
                    positions.Enqueue((x, (byte)(y - 1), steps));
                    maze[x][y - 1] = ' ';
                }
                if (Check(ref maze, x, y + 1))
                {
                    positions.Enqueue((x, (byte)(y + 1), steps));
                    maze[x][y + 1] = ' ';
                }

                if ((x != entrance[0] || y != entrance[1]) &&
                    (x == 0 || x + 1 == maze.Length ||
                     y == 0 || y + 1 == maze[0].Length))
                {
                    return steps - 1;
                }
            }

            return -1;
        }

        private static bool Check(ref char[][] maze, int m, int n)
        {
            if (m >= maze.Length)
                return false;
            if (n >= maze[0].Length)
                return false;
            if (m < 0)
                return false;
            if (n < 0)
                return false;
            return maze[m][n] == '.';
        }
    }
}