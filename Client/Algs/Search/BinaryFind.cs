namespace Client.Algs.Search
{
    public class BinaryFind
    {
        private int[] a;

        public BinaryFind(int[] a)
        {
            this.a = a;
        }

        public int FindKey(int key)
        {
            var index = Find(key, 0, a.Length - 1);

            if (index == -1)
                return index;

            var first = Find(key, 0, index);
            var checkfirst = true;

            while (checkfirst)
            {
                var f = Find(key, 0, first);
                if (f == first)
                    checkfirst = false;
                else
                    first = f;
            }


            var second = Find(key, index, a.Length - 1);
            var checkSecond = true;
            
            while (checkSecond)
            {
                var s = Find(key, second, a.Length - 1);
                if (s == second)
                    checkSecond = false;
                else
                    second = s;
            }

            return second - first + 1;
        }

        
        public int Find(int key, int s, int e)
        {
            if (s+1 == e)
            {
                if (a[e] == key)
                    return e;

                if (a[s] == key)
                    return s;
            }

            while (s <= e)
            {
                var m = (e + s) / 2;

                if (a[m] == key)
                    return m;

                if (a[m] < key)
                    s = m + 1;
                else
                    e = m - 1;
            }

            return -1;
        }

    }
}