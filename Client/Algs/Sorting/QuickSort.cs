using System;

namespace Client.Algs.Sorting
{
    public class QSort
    {
        private int[] a;

        public QSort(int[] array)
        {
            this.a = array;
        }

        private int Partition(int l, int h)
        {
            var pivot = l - 1;
            var element = a[h];

            for (var i = l; i <= h - 1; i++)
            {
                if (a[i] <= element)
                {
                    pivot++;
                    Swap(i, pivot);
                }
            }

            Swap(h, pivot + 1);
            return pivot + 1;
        }

        public void Sort(int l, int h)
        {
            if (a == null)
                throw new NullReferenceException();

            if (l < h)
            {
                var pivot = Partition(l, h);

                Sort(l, pivot - 1);
                Sort(pivot + 1, h);
            }
        }

        private void Swap(int i, int j)
        {
            var t = a[j];
            a[j] = a[i];
            a[i] = t;
        }
    }
}