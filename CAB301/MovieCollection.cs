using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAB301
{
    class MovieCollection
    {
        public Movie root;

        public MovieCollection()
        {
            root = null;
        }

        public void Insert(string title, string actList, string directorList, string genre, string classification, string duration, string released, int available)
        {
            Movie newNode = new Movie(title, actList, directorList, genre, classification, duration, released, available);
            

            if (root == null)
            {
                root = newNode;
            }
            else
            {
                Movie current = root;
                Movie parent;
                while (true)
                {
                    parent = current;
                    if (string.Compare(current.getTitle(), title) > -1)
                    {
                        current = current.Lchild;

                        if (current == null)
                        {
                            parent.Lchild = newNode;
                            break;
                        }
                    }
                    else
                    {
                        current = current.Rchild;
                        if (current == null)
                        {
                            parent.Rchild = newNode;
                            break;
                        }
                    }
                }
            }

        }

        public Movie Find(string title)
        {
            Movie current = root;
            while (current.getTitle() != title)
            {
                if (string.Compare(current.getTitle(), title) > -1)
                    current = current.Lchild;
                else
                current = current.Rchild;
                if (current == null)
                    return current;
            }
            return current;
        }

        public void InOrder(Movie theRoot)
        {
            if (theRoot != null)
            {
                InOrder(theRoot.Lchild);
                theRoot.DisplayMovie();
                InOrder(theRoot.Rchild);
            }
        }

        public void PostOrder(Movie theRoot)
        {
            if (theRoot != null)
            {
                PostOrder(theRoot.Lchild);
                PostOrder(theRoot.Rchild);
                theRoot.DisplayMovie();
            }
        }

    }



}

