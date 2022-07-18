using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetwordArchite.Data
{
    public class Edge
    {

        public int Weight { get; set; }
        public string StartId { get; set; }
        public string EndId { get; set; }

        public Edge(int weight, string startId, string endId)
        {
            Weight = weight;
            StartId = startId;
            EndId = endId;
        }


    }
}
