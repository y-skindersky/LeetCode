using System.Security.Cryptography;

namespace GraphTheory
{
    public static class SimilarStringGroups
    {
        public static int NumSimilarGroups(string[] strs)
        {
            var groups = new short[strs.Length][];

            for (short i = 0; i < strs.Length; i++)
            {
                if (groups[i] == null)
                    groups[i] = new short[0];
                var neighbors = new List<short>();
                for (short j = 0; j < i; j++)
                {
                    if (groups[j] == null)
                        groups[j] = new short[0];
                    var diff = Diff(strs[j], strs[i]);
                    if (diff <= 1)
                    {
                        neighbors.Add(j);
                        int length = groups[j].Length;
                        Array.Resize(ref groups[j], length + 1);
                        groups[j][length] = i;
                    }


                }
                groups[i] = neighbors.ToArray();
            }

            Queue<short> currentProvince = new Queue<short>();
            int provinceCount = 0;
            int[] province = new int[groups.Length];
            for (short i = 0; i < groups.Length; i++)
            {
                if (province[i] > 0)
                    continue;
                provinceCount++;
                province[i] = provinceCount;

                currentProvince.Enqueue(i);
                while (currentProvince.Count > 0)
                {
                    var currentCity = currentProvince.Dequeue();
                    foreach (var j in groups[currentCity])
                    {
                        if (province[j] == 0)
                        {
                            province[j] = provinceCount;
                            currentProvince.Enqueue(j);
                        }
                    }
                }
            }

            return provinceCount;
        }

        private static int Diff(string strA, string strB)
        {
            var i = 0;

            char letterA = ' ';
            char letterB = ' ';
            int lettersCount = 0;
            while (i < strA.Length)
            {
                if (strA[i] == strB[i])
                {

                }
                else if (lettersCount > 0 && letterA == strB[i] && letterB == strA[i])
                {

                }
                else
                {
                    letterA = strA[i];
                    letterB = strB[i];
                    lettersCount++;
                }

                i++;

                if (lettersCount > 1)
                    return lettersCount;
            }

            return lettersCount;
        }
    }
}