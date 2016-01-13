using System.Collections.Generic;

namespace Client.Algs.Search
{
    public class LongestIncreasingSeq
    {
        public int Find(int[] a)
        {
            var sol = new List<int>();
            var len = 1;
            sol.Add(a[0]);

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i - 1] < a[i])
                {
                    len++;
                    sol.Add(a[i]);
                }
                else
                    sol[FindIndex(sol, a[i], len)] = a[i];

            }

            return len;
        }


        public int FindIndex(List<int> sol, int key, int n)
        {
            var s = 0;
            var e = n - 1;
            var m = (s + e) / 2;
            while (s <= e)
            {
                m = (s + e) / 2;

                if (sol[m] == key)
                    return m;

                if (sol[m] < key)
                    s = m + 1;
                else
                    e = m - 1;
            }

            return m;
        }
    }
}