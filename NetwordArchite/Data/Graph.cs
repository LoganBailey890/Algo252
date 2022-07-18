using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetwordArchite.Data
{
    public class Graph
    {
        public List<Node> Nodes { get; set; }

        public Graph(string[] setUp)
        {
            Nodes = new List<Node>();
            //setupGraph

        }

        public Node FindNode(string id)
        {
            return Nodes.First(n => n.Id == id);
        }


    }
}
