namespace Client.Algs
{
    public class StringReversalAlg
    {
        private void ReverseString(char[] str, int i, int j)
        {
            if (i == j)
                return;
            else
            {
                var t = str[i];
                str[i] = str[j];
                str[j] = t;

                ReverseString(str, i + 1, j - 1);
            }
        }
    }
}
