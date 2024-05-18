using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Drawing;

namespace Laba12_3
{
    public class MyTree<T> where T : IInit, IComparable, new()
    {
        public Point<T>? root = null;

        int count = 0;

        public int Count => count;

        public MyTree(int length)
        {
            count = length;
            root = MakeTree(length, root);
        }

        public void ShowTree()
        {
            Show(root);
        }

        //ИСД
        Point<T>? MakeTree(int length, Point<T>? point)
        {
            T data = new T();
            data.RandomInit();
            Point<T> newItem = new Point<T>(data);
            if (length == 0) { return null; }
            int nl = length / 2;
            int nr = length - nl - 1;
            newItem.Left = MakeTree(nl, newItem.Left);
            newItem.Right = MakeTree(nr, newItem.Left);
            return newItem;
        }

        void Show(Point<T>? point, int spaces = 5)
        {
            if (point != null)
            {
                Show(point.Left, spaces + 5);
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.WriteLine(point.Data);
                Show(point.Right, spaces + 5);
            }
        }
        public void AddPoint(T data)
        {
            if (root == null)
            {
                root = new Point<T>(data);
                count++;
                return;
            }

            Point<T>? point = root;
            Point<T>? current = null;
            bool isExist = false;
            while (point != null && !isExist)
            {
                current = point;
                if (point.Data != null && point.Data.CompareTo(data) == 0)
                {
                    isExist = true;
                }
                else
                {
                    if (point.Data != null && point.Data.CompareTo(data) < 0)
                    {
                        point = point.Left;
                    }
                    else { point = point.Right; }
                }
            }
            if (isExist)
            {
                return;
            }
            Point<T> newPoint = new Point<T>(data);
            if (current != null && current.Data != null && current.Data.CompareTo(data) < 0)
                current.Left = newPoint;
            else
                current.Right = newPoint;
            count++;
        }

        

        public int CountLeaves()
        {
            return CountLeaves(root);
        }

        private int CountLeaves(Point<T>? point)
        {
            if (point == null)
                return 0;
            if (point.Left == null && point.Right == null)
                return 1;
            return CountLeaves(point.Left) + CountLeaves(point.Right);
        }

        public void ClearTree()
        {
            root = null;
            count = 0;
        }
    }
}
