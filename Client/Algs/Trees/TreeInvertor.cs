namespace Client.Algs.Trees
{
    public class TreeInvertor
    {
        public class Node
        {
            public int Key;
            public Node Left;
            public Node Right;
        }

        public Node Invert(Node node)
        {
            if (node.Left == null)
                return node;

            var root = Invert(node);
            node.Left = null;
            root.Left = node.Right;
            root.Right = node;

            return node.Right;
        }

    }
}