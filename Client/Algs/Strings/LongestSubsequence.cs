using System;

namespace Client.Algs.Strings
{
    public class LongestSubsequence
    {
        public int Find(string s1, string s2)
        {
            var s1l = s1.Length;
            var s2l = s2.Length;

            var ls = new int[s1l + 1, s2l + 1];
            for (int i = 0; i <= s1l; i++)
            {
                for (int j = 0; j <= s2l; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        ls[i, j] = 0;
                    }
                    else
                    {
                        if (s1[i] == s2[j])
                        {
                            ls[i, j] = ls[i - 1, j - 1] + 1;
                        }
                        else
                        {
                            ls[i, j] = Math.Max(ls[i - 1, j], ls[i, j - 1]);
                        }
                    }
                }
            }

            return ls[s1l, s2l];
        }

    }
}