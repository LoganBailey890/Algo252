using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructers.LinkedList
{
    public class SingleLinkedList<T> where T: IComparable<T>
    {
        public Node<T> Head { get; set; }
        public int Count { get; set; } = 0;

        //creates the ToString for the list
        public override string ToString()
        {
            Node<T> node = Head;
            string nodeStr = "";
            if(node != null)
            {
                //loops through the nodes to creat a string of all nodes to return
                while(node.nextNode != null)
                {
                    nodeStr += node.ToString() + ", ";
                    node = node.nextNode;
                }
                nodeStr += node.ToString();
            }
            return nodeStr;
        }


        public void Add(T val)
        {
            Node<T> node = Head;
            Node<T> newNode = new Node<T>(val, null);
            //go thourgh the list
            if (node != null)
            {
                while(node.nextNode != null)
                {
                    node = node.nextNode;
                }
                node.nextNode = newNode;
            }
            else
            {
                Head = newNode;
            }
            Count++;

        }

        public void Insert(T val, int index)
        {
            if(index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("out of the range for this list");
            }
            Node<T> nodeInsert = Head;
            //checking to see if we have no nodes yet if so make our new node the head
            if(index ==0)
            {
                Node<T> newNode = new Node<T>(val, Head);

                Head = newNode;
            }
            else
            {
                for (int i = 0; i < index - 1 ; i++)
                {
                    nodeInsert = nodeInsert.nextNode;
                }
                Node<T> newNodeTwo = new Node<T>(val, nodeInsert.nextNode);
                nodeInsert.nextNode = newNodeTwo;
            }
            Count++;
        }

        public T Get(int num)
        {
            if(num < 0 || num >= Count)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }

            Node<T> NodeToGet = Head;
            for (int i = 0; i < num; i++)
            {
                NodeToGet = NodeToGet.nextNode;
            }
            return NodeToGet.Data;
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }

        public int Search(T val)
        {
            Node<T> searchForNode = Head;
            for(int i =0; i<Count;i++)
            {
                if(searchForNode.Data.Equals(val))
                {
                    return i;
                }
                searchForNode = searchForNode.nextNode;
            }
            return -1;
        }

        public T Remove()
        {
            T data = default(T);
            if(Head != null)
            {
                data = Head.Data;
                Head = Head.nextNode;
                Count--;
            }
            return data;
        }

        public T RemoveLast()
        {
            T data = default(T);
            Node<T> nodeToRemove = Head;

            for (int i = 0;  i < Count -2; i++)
            {
                nodeToRemove = nodeToRemove.nextNode;
            }
            data = nodeToRemove.nextNode.Data;
            nodeToRemove.nextNode = null;
            Count--;
            return data;
        }

        public T RemoveAt(int index)
        {
            if(index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Index out of bounds");
            }
            Node<T> nodeToRemove = Head;
            T value = default(T);
            if (index ==0 )
            {
                value = nodeToRemove.Data;
                Head = Head.nextNode;
            }
            else
            {
                for (int i = 0; i < index -1; i++)
                {
                    nodeToRemove = nodeToRemove.nextNode;
                }

                value = nodeToRemove.nextNode.Data;
                nodeToRemove.nextNode = nodeToRemove.nextNode.nextNode;
            }
            Count--;

            return value;
        }

      
    }
}
