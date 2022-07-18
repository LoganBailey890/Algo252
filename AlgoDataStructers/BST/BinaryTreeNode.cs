/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructers.BST
{
    public class BinaryTreeNode<T> where T : IComparable<T>
    {

        public BinaryTreeNode(T val)
        {
            Data = val;
        }
        public int Count { get; set; } = 1;
        public BinaryTreeNode<T> left { get; set; }
        public BinaryTreeNode<T> right { get; set; }
        public T Data { get; set; }
        
        public void Add(T val)
        {
            if(Data.CompareTo(val) < 0)
            {
                if(right != null)
                {
                    right.Add(val);
                }
                else
                {
                    right = new BinaryTreeNode<T>(val);
                }
            }
            else if (Data.CompareTo(val) > 0)
            {
                if(left != null)
                {
                    left.Add(val);
                }
                else
                {
                    left = new BinaryTreeNode<T>(val);
                }
            }
            else
            {
                Count++;
            }
           
             
           
        }

        public int Height()
        {
            if( right!= null || left != null)
            {
                int leftCount = 0;
                int rightCount = 0;

                if (left != null)
                {
                    leftCount = (left.Height() + 1);
                }
                if (right != null)
                {
                    rightCount = (right.Height() + 1);
                }

                return (leftCount > rightCount) ? leftCount : rightCount;
            }
            else
            {
               return Count;
            }

        }

        public bool Contains(T val)
        {
            if(Data.Equals(val))
            {
                return true;
            }
            if(left != null && Data.CompareTo(val) > 0)
            {
                return left.Contains(val);
            }
            if(right != null && Data.CompareTo(val)<0)
            {
                return right.Contains(val);
            }

            return false;
        }

        public T FindSmall(BinaryTreeNode<T> node)
        {
            if(node.left != null)
            {
               return FindSmall(node.left);
            }
            else
            {
                return node.Data;
            }
        }

        public List<T> ToArray(List<T> toarray)
        { 
                      
            if (left != null)
            {
                left.ToArray(toarray);
            }
            for (int i = 0; i < Count; i++)
            {
                toarray.Add(Data);
            }
            if (right != null)
            {
                right.ToArray(toarray);
            }
            return toarray;
        }

        public string InOrder()
        {
            string tempString = "";
           
            if (left != null)
            {
               tempString += left.InOrder();
            }
            for (int i = 0; i < Count; i++)
            {
                tempString += Data + ", ";
            }
            if(right != null)
            {
               tempString += right.InOrder();
            }
               
            return tempString;
        }

        public string PreOrder()
        {
            string tempString = "";

            for (int i = 0; i < Count; i++)
            {
                tempString += Data + ", ";
            }
            if (left != null)
            {
                tempString += left.PreOrder();
            }
            if (right != null)
            {
                tempString += right.PreOrder();
            }

            return tempString;
        }

        public string PostOrder()
        {
            string tempString = "";
            if (left != null)
            {
                tempString += left.PostOrder();
            }
            if (right != null)
            {
                tempString += right.PostOrder();
            }
            for (int i = 0; i < Count; i++)
            {
                tempString += Data + ", ";
            }
            return tempString;
        }


        public BinaryTreeNode<T> Remove(T val)
        {   
            if(val.CompareTo(Data) < 0)
            {
                left = left.Remove(val);

            }
            else if(val.CompareTo(Data) >0)
            {
                right = right.Remove(val);
            }
            else if(Count > 1)
            {
                Count--;
            }
            else
            {
                if(left == null)
                {
                    return right;
                }
                else if(right == null)
                {
                    return left;
                }
                else
                {
                    if(Count > 1)
                    {
                        Count--;
                    }
                    else
                    {
                        Data = FindSmall(right);
                        right = right.Remove(this.Data);

                    }
                }
               

            }
            return this;
        }
    }
}
*/