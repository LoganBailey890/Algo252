using System;
using NetwordArchite.Data;
using System.IO;

namespace NetwordArchite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to File");
            var path = Console.ReadLine();

            Graph mst = new Graph(File.ReadAllLines(path));

            Results primsResults = Solving.Solve(mst);

            primsResults.PrintResults();
        }
    }
}
