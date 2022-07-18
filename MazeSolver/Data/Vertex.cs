﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Data
{
   public class Vertex
    {
        public char Data { get; set; }
        public List<Edge> Connections { get; set; }
        public int Index { get; set; }


        public Vertex(int index, char data)
        {
            Connections = new List<Edge>();
            Data = data;
            Index = index;
        }
        public void AddConnection(Edge e)
        {
            Connections.Add(e);
        }
    }
}
