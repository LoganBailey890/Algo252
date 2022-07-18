using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeSolver.Data;

namespace MazeSolver
{
    public class SolverMaze
    {
        public static List<string> UsingDijkstra(Graph graph)
        {
            List<DNode> dijkstraNodes = SetUpDijkstrasChart(graph);
            FillInChart(dijkstraNodes);


            return new List<string> { FindSoultion(dijkstraNodes,graph) };

        }

        private static string FindSoultion(List<DNode> dijkstraNodes, Graph graph)
        {

            DNode end = dijkstraNodes.First(d => d.Node == graph.End);
            StringBuilder builder = new StringBuilder();
            while (end.Previous != null)
            {
                builder.Insert(0, " " + end.Node.Data);
                end = dijkstraNodes.First(d => d.Node == end.Previous);
            }
            builder.Insert(0, end.Node.Data);

            return builder.ToString().Contains(graph.Start.Data) ? builder.ToString() : "No soutions"; 
        }

        private static List<DNode> SetUpDijkstrasChart(Graph graph)
        {
            //List nodes and create a chart
            List<DNode> DijkstraNodes = new List<DNode>();
            for (int i = 0; i < graph.Vertices.Count; i++)
            {
                Vertex thisOne = graph.Vertices[i];
                int distance = thisOne == graph.Start ? 0 : Int32.MaxValue;
                DNode dNode = new DNode(thisOne, distance);
                DijkstraNodes.Add(dNode);
            }
            return DijkstraNodes;
        }

        private static void FillInChart(List<DNode> dijkstraNodes)
        {
            while (dijkstraNodes.Any(d => !d.IsVisited))
            {
                DNode lowestDistance = dijkstraNodes.Where(n => !n.IsVisited).OrderBy(n => n.Distance).First();
                lowestDistance.IsVisited = true;
                foreach (Edge e in lowestDistance.Node.Connections)
                {

                    DNode found = dijkstraNodes.First(d => d.Node == e.End);
                    if (!found.IsVisited)
                    {
                        int distance = lowestDistance.Distance + e.Weight;
                        if (found.Distance > distance)
                        {
                            found.Distance = distance;
                            found.Previous = lowestDistance.Node;
                        }
                    }
                }
            }
        }
    }
}
