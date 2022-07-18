using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeSolver.Data
{
    public class GraphList
    {
        public List<Graph> Graphs { get; set; }

        public GraphList(List<string> setup)
        {
            Graphs = new List<Graph>();
            SetUpGraphs(setup);
        }

        private void SetUpGraphs(List<string> setup)
        {
            Graph graph = new Graph();
            //variable made to help track if we are making a new graph
            int mazeIndex = 0;

            for (int line = 0; line < setup.Count; line++)
            {
                
                if(mazeIndex ==0)
                {
                    string verticies = setup[line];
                    string[] data = verticies.Split(",");
                    for (int i = 0; i < data.Length; i++)
                    {
                        Vertex v = new Vertex(i, Char.Parse(data[i]));
                        graph.AddVertex(v);
                    }
                }
                else if(mazeIndex ==1)
                {
                    string startAndEnd = setup[line];
                    string[] startEndList = startAndEnd.Split(',');

                    //set the start vertex for the graph
                    graph.Start = graph.GetVertex(Char.Parse(startEndList[0]));
                    //sets the end vertex for the graph
                    graph.End = graph.GetVertex(Char.Parse(startEndList[1]));
                }
                else if (setup[line].Equals(""))
                {
                    //New Graph
                    Graphs.Add(graph);
                    graph = new Graph();
                    mazeIndex = -1;

                }
                else if(setup[line].StartsWith("//"))
                {
                    //Ignore Comment
                }
                else
                {
                    //Edges
                    //B,A,C,D,F
                    string[] adjancenyList = setup[line].Split(",");
                    Vertex vert = graph.GetVertex(Char.Parse(adjancenyList[0]));

                    //looping trought the adjanceny List to creat the Edges
                    for (int i = 1; i < adjancenyList.Length; i++)
                    {
                        Edge e = new Edge(vert, graph.GetVertex(Char.Parse(adjancenyList[i])));
                        vert.AddConnection(e);
                    }


                }

                mazeIndex++;
            }
            Graphs.Add(graph);
            
        }
    }

}
