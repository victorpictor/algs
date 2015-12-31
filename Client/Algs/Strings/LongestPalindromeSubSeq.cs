using System;

namespace Client.Algs.Strings
{
    public class LongestPalindromeSubSeq
    {
        public int Find(string str)
        {
            var len = str.Length;
            var lseq = new int[len, len];

            for (int i = 0; i < len; i++)
            {
                lseq[i, i] = 1;
            }

            for (int l = 2; l <= len; l++)
            {
                for (int i = 0; i < len - l + 1; i++)
                {
                    var j = i + l - 1;

                    if (str[i] == str[j])
                    {
                        lseq[i, j] = 2 + lseq[i + 1, j - 1];
                        continue;
                    }

                    for (int k = i; k < j; k++)
                    {
                        lseq[i, j] = Math.Max(lseq[i, j], Math.Max(lseq[i, k], lseq[k + 1, j]));
                    }

                }
            }

            return lseq[0, len - 1];

        }
    }
}