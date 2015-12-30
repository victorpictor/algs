namespace Client.Algs
{
    public class MergeSort
    {
        public int[] Sort(int[] arr, int s, int e)
        {
            if (s == e)
                return new[] {arr[s]};

            var mid = s + (e - s)/2;

            var l = Sort(arr, s, mid);
            var r = Sort(arr, mid + 1, e);

            return Merge(l, r);
        }


        public int[] Merge(int[] l, int[] r)
        {
            var ll = l.Length;
            var lr = r.Length;
            var i = 0;
            var j = 0;
            var k = 0;

            var result = new int[ll + lr];

            while (j < ll && k < lr)
            {
                if (l[j] < r[k])
                {
                    result[i] = l[j];
                    j++;
                }
                else
                {
                    result[i] = r[k];
                    k++;
                }
                i++;
            }

            if (j < ll)
            {
                while (j < ll)
                {
                    result[i] = l[j];
                    j++;
                    i++;
                }

            }

            if (k < lr)
            {
                while (k < ll)
                {
                    result[i] = r[k];
                    k++;
                    i++;
                }

            }

            return result;
        }
    }
}