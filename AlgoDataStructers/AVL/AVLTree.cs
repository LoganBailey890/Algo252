using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructers.AVL
{
   public class AVLTree<T> where T : IComparable<T>
    {

        public AVLNode<T> Root { get; set; }

        public int Count { get; set; } = 0;
        
        public void Add(T val)
        {
            if(Root == null)
            {
                Root = new AVLNode<T>(val); 
            }
            else
            {
                Root = Root.Add(val);
            }
            Count++;
        }

        public bool Contains(T val)
        {
            if(Root != null)
            {
                return Root.Contains(val);
            }
            return false;
        }

        public void Clear()
        {
            Root = null;
            Count = 0;
        }
        public void Remove(T val)
        {
            if (Root != null && Contains(val))
            {
               Root = Root.Remove(val);
               Count--;
            }
        }


        public T[] ToArray()
        {
            List<T> toarray = new List<T>();

            for (int i = 0; i < Root.Height(); i++)
            {
                Root.ToArray(toarray, i);
            }
            return toarray.ToArray();
        }

        public string InOrder()
        {
            string tempString = "";
            if (Root != null)
            {
               tempString = Root.InOrder();
            }
            if(tempString == "")
            {
                return tempString;
            }
            else
            {
                return tempString.Substring(0, tempString.Length - 2);
            }
        }   

        public string PreOrder()
        {
            string tempString = "";
            if (Root != null)
            {
                tempString = Root.PreOrder();
            }
            if (tempString == "")
            {
                return tempString;
            }
            else
            {
                return tempString.Substring(0, tempString.Length - 2);
            }
        }

        public string PostOrder()
        {
            string tempString = "";
            if (Root != null)
            {
                tempString = Root.PostOrder();
            }
            if (tempString == "")
            {
                return tempString;
            }
            else
            {
                return tempString.Substring(0, tempString.Length - 2);
            }
        }

        public int Height()
        {
            return Root != null ? Root.Height() : 0; 
        }
    }
}
