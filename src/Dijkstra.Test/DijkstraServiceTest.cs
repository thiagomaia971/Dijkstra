using System;
using System.Collections.Generic;
using System.Linq;
using Dijkstra.Core;
using Dijkstra.Core.Entities;
using Dijkstra.Core.Interfaces;
using NUnit.Framework;

namespace Dijkstra.Test
{
    public class DijkstraServiceTest
    {
        private IDijkstraService _dijkstraService;
        private List<Node> nodes;
        private Node nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG;

        [SetUp]
        public void Setup()
        {
            _dijkstraService = new DijkstraService();

            nodeA = Node.Create("A", int.MaxValue);
            nodeB = Node.Create("B", int.MaxValue);
            nodeC = Node.Create("C", int.MaxValue);
            nodeD = Node.Create("D", int.MaxValue);
            nodeE = Node.Create("E", int.MaxValue);
            nodeF = Node.Create("F", int.MaxValue);
            nodeG = Node.Create("G", int.MaxValue);

            nodes = new List<Node>
            {
                nodeA.AddNeighbor(Neighbor.Create(nodeB, 4))
                    .AddNeighbor(Neighbor.Create(nodeC, 3))
                    .AddNeighbor(Neighbor.Create(nodeE, 7)),
                nodeB.AddNeighbor(Neighbor.Create(nodeD, 5))
                    .AddNeighbor(Neighbor.Create(nodeC, 6)),
                nodeC.AddNeighbor(Neighbor.Create(nodeB, 6))
                    .AddNeighbor(Neighbor.Create(nodeD, 11))
                    .AddNeighbor(Neighbor.Create(nodeE, 8)),
                nodeE.AddNeighbor(Neighbor.Create(nodeC, 8))
                    .AddNeighbor(Neighbor.Create(nodeD, 2))
                    .AddNeighbor(Neighbor.Create(nodeG, 5)),
                nodeD.AddNeighbor(Neighbor.Create(nodeE, 2))
                    .AddNeighbor(Neighbor.Create(nodeG, 10))
                    .AddNeighbor(Neighbor.Create(nodeF, 2)),
                nodeG.AddNeighbor(Neighbor.Create(nodeE, 5))
                    .AddNeighbor(Neighbor.Create(nodeD, 10))
                    .AddNeighbor(Neighbor.Create(nodeF, 3)),
                nodeF
            };
        }

        [Test]
        public void InitialNodeStartWithZero()
        {
            var nodeA = nodes.First(x => x.Title == "A");
            var nodeF = nodes.First(x => x.Title == "F");
            var result = _dijkstraService.LowestPath(nodeA, nodeF, nodes);

            Assert.AreEqual(nodeA.Width, result.nodes.First(x => x.Title == "A").Width);
        }

        [Test]
        public void AllNodesWithInity_LessInitialNode()
        {
            var nodeA = nodes.First(x => x.Title == "A");
            var nodeF = nodes.First(x => x.Title == "F");
            var result = _dijkstraService.LowestPath(nodeA, nodeF, nodes);

            var lowestPath = new List<Node> { nodeA, nodeB, nodeD, nodeF};
            var resultPath = string.Join(',' ,result.lowestPath.Select(x => x.Title));
            var expetedPath = string.Join(',' ,lowestPath.Select(x => x.Title));
            
            Assert.AreEqual(resultPath, expetedPath);
        }
    }
}