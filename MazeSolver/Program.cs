using System;
using System.Collections.Generic;
using System.IO;
using MazeSolver.Data;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter File path");

            //string path = "C:/Users/lbailey/source/repos/Algo252/MazeSolver/TestMazes.txt";
            string path = Console.ReadLine();
            List<string> lines = new List<string>(File.ReadAllLines(path));

            GraphList graphList = new GraphList(lines);

            int mazeCount = 1;
            foreach(Graph graph in graphList.Graphs)
            {
                List<string> solution = SolverMaze.UsingDijkstra(graph);
                Console.WriteLine($"Maze # {mazeCount}:");
                if(solution.Count > 0)
                {
                    Console.WriteLine(solution[0]);
                }
                else
                {
                    Console.WriteLine("no soulution");
                }
                mazeCount++;
            }
        }
    }
}
