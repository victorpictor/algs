using System.Collections.Generic;

namespace Client.Algs.Trees
{
    public class Node
    {
        public int Key;

        public Node Left;
        public Node Right;
    }

    public class Relation
    {
        public int child;
        public int parent;
        public bool isLeft;

        public Relation()
        {
        }

        public Relation(int child, int parent, bool isLeft)
        {
            this.child = child;
            this.parent = parent;
            this.isLeft = isLeft;
        }
    }

    public class TreeBuilder
    {

        public void Build()
        {
            var relations = new List<Relation>()
                {
                    new Relation(15, 20, true),
                    new Relation(19, 80, true),
                    new Relation(17, 20, false),
                    new Relation(16, 80, false),
                    new Relation(80, 50, false),
                    new Relation(50, -1, false),
                    new Relation(20, 50, true)
                };
            var nodes = new Dictionary<int, Node>();

            foreach (var r in relations)
            {
                var node = new Node() {Key = r.child};

                if (nodes.ContainsKey(r.child))
                    node = nodes[r.child];

                if (r.parent == -1 && !nodes.ContainsKey(r.child))
                {
                    nodes.Add(r.child, new Node() {Key = r.child});
                    continue;
                }
                else
                {
                    if (!nodes.ContainsKey(r.parent))
                    {
                        var parent = new Node() {Key = r.parent};
                        nodes.Add(parent.Key, parent);
                    }

                    if (r.isLeft)
                        nodes[r.parent].Left = node;
                    else
                        nodes[r.parent].Right = node;
                }

            }
        }
    }
}