using System.Collections.Generic;
using Dijkstra.Core.Entities;

namespace Dijkstra.Core.Interfaces
{
    public interface IDijkstraService
    {
        (List<Node> nodes, List<Node> lowestPath) LowestPath(Node initialNode, Node finalNode, List<Node> nodes);
    }
}
