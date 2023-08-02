namespace GraphTheory
{
    public static class NumberOfProvinces
    {
        public static int FindCircleNum(int[][] isConnected)
        {
            Stack<byte> currentProvince = new Stack<byte>();
            int provinceCount = 0;

            for (byte i = 0; i < isConnected.Length; i++)
            {
                if (isConnected[i][i] == 0)
                    continue;
                isConnected[i][i] = 0;
                provinceCount++;

                currentProvince.Push(i);
                while (currentProvince.Count > 0)
                {
                    var currentCity = currentProvince.Pop();
                    for (byte j = 0; j < isConnected.Length; j++)
                    {
                        if (j == currentCity)
                            continue;
                        if (isConnected[currentCity][j] == 1)
                        {
                            currentProvince.Push(j);

                            isConnected[currentCity][j] = 0;
                            isConnected[j][currentCity] = 0;
                            isConnected[j][j] = 0;
                        }
                    }
                }
            }

            return provinceCount;
        }
    }
}