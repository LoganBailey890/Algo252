using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetwordArchite.Data
{
    public class Node
    {
        public string Id { get; set; }
        public List<Edge> Connections { get; set; }
        public bool IsPartOfTree { get; set; }


        public Node(string Id)
        {
            this.Id = Id;
            Connections = new List<Edge>();
        }

        public Edge FindEdgeByStartId(string startId)
        {
            return Connections.First(s => s.StartId.Equals(startId));
        }
        public Edge FindEdgeByEndId(string endId)
        {
            return Connections.First(s => s.EndId.Equals(endId));
        }
    }
}
