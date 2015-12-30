namespace Client.Algs.Strings
{
    public class KmpKeySearch
    {
        public int Find(string str, string pattern)
        {
            var lpa = PrefixArrary(pattern);

            var i = 0;
            var j = 0;

            while (j < pattern.Length && i < str.Length)
            {

                if (pattern[j] == str[i])
                {
                    if (j + 1 == pattern.Length)
                        return i - j;

                    i++;
                    j++;
                }
                else
                {
                    if (j > 0)
                        j = lpa[j];

                    if (j == 0)
                        i++;
                }

            }


            return -1;
        }

        private int[] PrefixArrary(string pattern)
        {
            var l = pattern.Length;
            var lpa = new int[l];
            lpa[0] = 0;

            var i = 0;
            var j = 1;

            while (j < l)
            {
                if (pattern[i] != pattern[j])
                    i = 0;
                else
                    i++;

                lpa[j] = i;
                j++;
            }

            return lpa;
        }
    }
}