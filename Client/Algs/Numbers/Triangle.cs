using System;
using System.Collections.Generic;

namespace Client.Algs.Numbers
{
    public class Triangle
    {
        public List<List<int>> Find(int[] a)
        {
            if (a == null)
                throw new ArgumentNullException();

            if (a.Length < 3)
                return new List<List<int>>();

            var aL = a.Length;

            var result = new List<List<int>>();
            for (int l = 3; l < aL; l++)
            {
                for (int i = 0; i <= l - 3; i++)
                {
                    var j = l - 1;

                    for (int k = i + 1; k < l - 1; k++)
                    {
                        if (a[i] + a[k] > a[j] &&
                            a[i] + a[j] > a[k] &&
                            a[j] + a[k] > a[i])
                            result.Add(new List<int>() { a[i], a[k], a[j] });
                    }
                }
            }

            return result;
        }
    }
}