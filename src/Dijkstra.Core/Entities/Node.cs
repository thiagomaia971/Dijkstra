using System.Collections.Generic;
using System.Linq;

namespace Dijkstra.Core.Entities
{
    public class Node
    {
        public string Title { get; private set; }
        public int Width { get; private set; }
        public bool Visited { get; private set; }
        public List<Neighbor> Neighbors { get; private set; }

        private Node(string title, int width, params Neighbor[] neighbors)
        {
            Title = title;
            Width = width;
            Neighbors = neighbors.ToList();
        }

        public static Node Create(string title, int width, params Neighbor[] neighbors)
            => new Node(title, width, neighbors);

        public Node AddNeighbor(Neighbor neighbor)
        {
            Neighbors.Add(neighbor);
            return this;
        }

        public Node MarkAsInitialNode()
        {
            Width = 0;
            return this;
        }

        public void UpdateWidth(Node currentNode, Node neighborNode, int edgeWidth)
        {
            var currentNodeWidth = currentNode.Width + edgeWidth;
            var updateWidth = currentNodeWidth < neighborNode.Width;
            Width = updateWidth ? currentNodeWidth : neighborNode.Width;
            AncestralNode = updateWidth ? currentNode : AncestralNode;
        }

        public Node AncestralNode { get; set; }

        public void SetVisited() 
            => Visited = true;
    }
}