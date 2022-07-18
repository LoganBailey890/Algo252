using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetwordArchite.Data;

namespace NetwordArchite
{
    public static class Extansions
    {
        public static void PrintResults(this Results results)
        {
            Console.WriteLine("Socket Set: " + String.Join(", " , results.SocketSet));
            Console.WriteLine("Cable Length Needed: " + results.CableLength + "ft");
        }
    }
}
