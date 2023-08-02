namespace GraphTheory
{
    public static class NumberOfIslands
    {
        public static int NumIslands(char[][] grid)
        {
            var a = new int[grid[0].Length];
            var b = new int[grid[0].Length];
            var c = new int[grid[0].Length];
            int max = 0;
            int joined = 0;

            int cprev = 0;
            int ccurr = 0;
            for (int i = 0; i < grid[0].Length; i++)
            {
                ccurr = (byte)grid[0][i] - (byte)'0';
                if (ccurr == 1)
                {
                    a[i] = cprev == 0 ? ++max : a[i-1];
                }
                else
                {
                    a[i] = 0;
                }
                cprev = ccurr;
            }

            for (int i = 1; i < grid.Length; i++)
            {
                Console.WriteLine($"{i - 1}:" + string.Join(',', a));
                cprev = (byte)grid[i][0] - (byte)'0';
                ccurr = cprev;
                if (ccurr == 1 && a[0] > 0)
                    b[0] = a[0];
                else if (ccurr == 1)
                    b[0] = ++max;
                else
                    b[0] = 0;
                
                for (int j = 1; j < a.Length; j++)
                {
                    ccurr = (byte)grid[i][j] - (byte)'0';
                    if (ccurr == 1 && a[j] > 0)
                    {
                        if (cprev == 0)
                        {
                            b[j] = a[j];
                        }
                        else if (a[j] < b[j-1])
                        {
                            //Console.WriteLine($"{b[j-1]} joined to {a[j]}");

                            for (int k = 0; k <= j-1; k++)
                            {
                                if (b[k] == b[j-1])
                                    b[k] = a[j];
                            }
                            b[j] = a[j];

                            joined++;
                        }
                        else
                        {
                            b[j] = b[j-1];

                            if (a[j] > b[j-1])
                            {
                                //Console.WriteLine($"{a[j]} joined to {b[j-1]}");
                                for (int k = j+1; k < a.Length; k++)
                                {
                                    if (a[k] == a[j])
                                        a[k] = b[j];
                                }
                                a[j] = b[j];

                                joined++;
                            }
                        }
                    }
                    else if (ccurr == 1)
                    {
                        if (cprev > 0)
                            b[j] = b[j-1];
                        else
                            b[j] = ++max;
                    }
                    else
                        b[j] = 0;
                    cprev = ccurr;
                }

                //Console.WriteLine($"{i-1}:" + string.Join(',', a));
                //Console.WriteLine($"{i}:" + string.Join(',', b));
                //Console.WriteLine();

                c = a;
                a = b;
                b = c;
            }

            //Console.WriteLine("max:" + max);
            //Console.WriteLine("joined:" + joined);

            return max - joined;
        }
    }
}