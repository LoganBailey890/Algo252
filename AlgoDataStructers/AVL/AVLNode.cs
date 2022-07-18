using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDataStructers.AVL
{
    public class AVLNode<T> where T : IComparable<T>
    {

        public AVLNode(T val)
        {
            Data = val;
        }
        public int Count { get; set; } = 1;
        public AVLNode<T> left { get; set; }
        public AVLNode<T> right { get; set; }
        public T Data { get; set; }


        public int CheckBalance()
        {
            int leftHight = 0;
            int rightHight =0;

            if (right != null)
            {
                 rightHight = right.Height();
            }
            if (left != null)
            {
                 leftHight = left.Height();
            }


             return leftHight - rightHight;
        }

        public AVLNode<T> BalanceTree()
        {
            if (CheckBalance() == 2)
            {
                if (left.CheckBalance() == 1)
                {
                    return RightRotation();
                }
                else if (left.CheckBalance() == -1)
                {
                    return LeftRightRotation();
                }
            }
            else if (CheckBalance() == -2)
            {
                if (right.CheckBalance() == -1)
                {
                    return LeftRotation();
                }
                else if (right.CheckBalance() == 1)
                {
                    return RightLeftRotation();
                }
            }
            return this;
        }

        public AVLNode<T> LeftRotation()
        {
            var pivot = this.right;
            this.right = pivot.left;
            pivot.left = this;
            return pivot;
        }

        public AVLNode<T> RightRotation()
        {
            var pivot = this.left;
            this.left = pivot.right;
            pivot.right = this;
            return pivot;
        }

        public AVLNode<T> LeftRightRotation()
        {
            left = left.LeftRotation();
            return RightRotation();
        }

        public AVLNode<T> RightLeftRotation()
        {
            right = right.RightRotation();
            return LeftRotation();
        }


        public AVLNode<T> Add(T val)
        {
            if(Data.CompareTo(val) < 0)
            {
                if(right != null)
                {
                     right = right.Add(val);
                }
                else
                {
                    right = new AVLNode<T>(val);
                }
            }
            else if (Data.CompareTo(val) > 0)
            {
                if(left != null)
                {
                    left = left.Add(val);
                }
                else
                {
                    left = new AVLNode<T>(val);
                }
            }
            else
            {
                Count++;
            }

            return BalanceTree();
           
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

        public T FindSmall(AVLNode<T> node)
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

        public void ToArray(List<T> toarray, int count)
        { 
            if(count ==0)
            {
                toarray.Add(Data);
            }
            if(left != null)
            {
                left.ToArray(toarray, count - 1);
            }
            if(right !=null)
            {
                right.ToArray(toarray, count - 1);
            }
            
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


        public AVLNode<T> Remove(T val)
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
