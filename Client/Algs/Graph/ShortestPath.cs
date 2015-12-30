namespace Client.Algs
{
    public class ShortestPath
    {
        public class Edge
        {
            public int S;
            public int D;
            public int C;
        }

        private int[,] am;

        public void FindAll(List<Edge> edges)
        {
            am = new int[edges.Count,edges.Count];

            for (int i = 0; i < edges.Count; i++)
            {
                for (int j = i + 1; j < edges.Count; j++)
                {
                    for (int k = i; k < j; k++)
                    {
                        am[i, j] = Math.Min(am[i, j], am[i, k] + am[k, j]);
                    }
                }
            }
        }
    }
}