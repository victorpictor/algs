using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.Algs.Graph
{
    public class DjikstraShortestPath
    {
        public class Edge
        {
            public int S;
            public int D;
            public int C;
        }

        private int infinity = 999;

        public void FindAll(List<Edge> edges)
        {
            var costs = InitCosts(edges);
            var alist = AdjacencyListFrom(edges);

            var q = new Queue<Edge>();
            q.Enqueue(edges[0]);

            while (q.Any())
            {
                var e = q.Dequeue();

                foreach (var edge in alist[e.S])
                {
                    costs[edge.D] = Math.Min(costs[edge.D], costs[e.S] + e.C);
                    alist[e.D].ForEach(q.Enqueue);
                }
            }

        }

        private Dictionary<int, List<Edge>> AdjacencyListFrom(List<Edge> edges)
        {
            return new Dictionary<int, List<Edge>>();
        }

        private Dictionary<int, int> InitCosts(List<Edge> edges)
        {
            var result = new Dictionary<int, int>();

            result.Add(edges[0].S, 0);

            for (int i = 1; i < edges.Count; i++)
            {
                if (!result.ContainsKey(edges[i].S))
                {
                    result.Add(edges[i].S, infinity);
                }
            }

            return result;
        }
    }
}
