using System.Collections.Generic;
using System.Linq;
using Dijkstra.Core.Entities;
using Dijkstra.Core.Interfaces;

namespace Dijkstra.Core
{
    public class DijkstraService : IDijkstraService
    {
        public (List<Node>, List<Node>) LowestPath(Node initialNode, Node finalNode, List<Node> nodes)
        {
            initialNode = nodes.FirstOrDefault(x => x.Title == initialNode.Title);
            initialNode.MarkAsInitialNode();
            var lowestPath = new List<Node>();

            var currentNode = initialNode;
            var queue = new Queue<Node>();
            queue.Enqueue(currentNode);
            while (queue.Any())
            {
                currentNode = queue.Dequeue();
                foreach (var neighbor in currentNode.Neighbors)
                {
                    if (!neighbor.Node.Visited)
                    {
                        neighbor.UpdateNeighborWidth(currentNode);
                        queue.Enqueue(neighbor.Node);
                    }
                }

                currentNode.SetVisited();
            }

            var ancestral = finalNode;
            while (ancestral != null)
            {
                lowestPath.Add(ancestral);
                ancestral = ancestral.AncestralNode;
            }

            lowestPath.Reverse();
            return (nodes, lowestPath);
        }
    }
}
