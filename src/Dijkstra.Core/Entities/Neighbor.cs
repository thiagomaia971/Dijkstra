namespace Dijkstra.Core.Entities
{
    public class Neighbor
    {
        public Node Node { get; set; }
        public int Width { get; set; }

        private Neighbor(Node node, int width)
        {
            Node = node;
            Width = width;
        }

        public static Neighbor Create(Node node, int width)
            => new Neighbor(node, width);

        public void UpdateNeighborWidth(Node currentNode)
        {
            Node.UpdateWidth(currentNode, Node, Width);
        }
    }
}