using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Data
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; }
        public Vertex Start { get; set; }
        public Vertex End { get; set; }

        public Graph()
        {
            Vertices = new List<Vertex>();
        }
        public void AddVertex(Vertex v)
        {
            Vertices.Add(v);
        }

        public Vertex GetVertex(char data)
        {
            return Vertices.FirstOrDefault(v=> v.Data == data);
        }
    }

}
