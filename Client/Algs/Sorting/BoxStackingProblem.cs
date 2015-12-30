using System.Collections.Generic;
using System.Linq;

namespace Client.Algs.Sorting
{
    public class BoxStackingProblem
    {
        private class Box
        {
            public float h;
            public float w;
            public float d;

            public Box(float w, float d, float h)
            {
                this.h = h;
                this.w = w;
                this.d = d;
            }

            public List<Box> GetPermutations()
            {
                var boxes = new List<Box>();

                boxes.Add(new Box(h, d, w));
                boxes.Add(new Box(d, w, h));
                boxes.Add(new Box(w, h, d));

                return boxes;
            }

            public float BaseArea
            {
                get { return w * d; }
            }
        }


        public void BoxStacking()
        {
            var boxes = new List<Box>();

            boxes.AddRange(new Box(4, 6, 7).GetPermutations());
            boxes.AddRange(new Box(1, 2, 3).GetPermutations());
            boxes.AddRange(new Box(4, 5, 6).GetPermutations());
            boxes.AddRange(new Box(10, 12, 32).GetPermutations());

            var sorted = boxes.OrderBy(b => b.BaseArea);

            Lis(sorted.ToList());

        }

        private void Lis(List<Box> boxes)
        {
            var sol = new Box[boxes.Count];
            var bcount = boxes.Count;
            sol[0] = boxes[0];

            var len = 1;

            for (var i = 1; i < bcount; i++)
            {
                if (boxes[i - 1].w < boxes[i].w && boxes[i - 1].d < boxes[i].d)
                {
                    sol[len] = boxes[i];
                    len++;
                }
                else
                {
                    sol[FindEndex(sol, boxes[i], len)] = boxes[i];
                }
            }


        }

        private int FindEndex(Box[] sol, Box box, int len)
        {
            var left = 0;
            var right = len;

            var mid = right / 2;

            while (left + 1 < right)
            {
                if (sol[mid].w > box.w && sol[mid].d > box.d)
                    right = mid;
                else
                    left = mid;

                mid = left + (right - left) / 2;
            }

            return mid;
        }
    }
}