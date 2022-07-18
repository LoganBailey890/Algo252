using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructers.LinkedList
{
    public class Node<T> 
    {
        public T Data { get; set; }

        public Node<T> nextNode { get; set; }
        public Node<T> prevNode { get; set; }

        public override string ToString()
        {
            return Data.ToString();
        }

        public Node(T data, Node<T> nextNode)
        {
            Data = data;
            this.nextNode = nextNode;
        }


    }
}
