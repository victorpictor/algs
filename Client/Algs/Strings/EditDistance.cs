using System;

namespace Client.Algs.Strings
{
    public class EditDistance
    {
        public int Find(string str1, string str2)
        {
            var s1l = str1.Length;
            var s2l = str2.Length;

            var d = new int[s1l, s2l];

            for (int j = 0; j < s2l; j++)
                d[0, j] = j;

            for (int i = 0; i < s1l; i++)
                d[i, 0] = i;

            for (int i = 1; i < s1l; i++)
            {
                for (int j = 1; j < s2l; j++)
                {
                    if (str1[i] == str2[j])
                    {
                        d[i, j] = d[i - 1, j - 1];
                    }
                    else
                    {
                        d[i, j] = Math.Min(Math.Min(d[i - 1, j - 1], d[i, j - 1]), d[i - 1, j]) + 1;
                    }
                }
            }

            return d[s1l - 1, s2l - 1];
        } 
    }
}