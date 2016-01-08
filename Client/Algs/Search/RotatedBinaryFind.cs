namespace Client.Algs.Search
{
    public class RotatedBinaryFind
    {
        private int[] a;
        private int NotFound = -1;

        public RotatedBinaryFind(int[] a)
        {
            this.a = a;
        }

        public int FindKey(int key)
        {
            return FindKey(key, 0, a.Length - 1);
        }

        private int FindKey(int key, int s, int e)
        {
            if (s == e && a[e] != key)
                return NotFound;

            var m = (s + e) / 2;

            if (a[m] == key)
                return m;

            if (a[m] < a[e] && key >= a[m] && key <= a[e])
            {
                return FindKey(key, m, e);
            }

            return FindKey(key, s, m - 1);
        }

        public void AlgTest()
        {
            var i = new Client.RotatedBinaryFind(new[] { 6, 9, 1, 2, 3, 4, 5, }).FindKey(8);
        }

    }
}