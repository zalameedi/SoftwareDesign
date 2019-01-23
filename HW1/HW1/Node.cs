using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    class Node
    {
        //Node's attributes (Data for the value, and L/R pts for the Tree)
        public int data;
        public Node pLeft;
        public Node pRight;

        //Constructors Default/1 Argument
        public Node()
        {
            this.pLeft = null;
            this.pRight = null;
            this.data = 0;
        }

        public Node(int mdata)
        {
            this.data = mdata;
            this.pLeft = null;
            this.pRight = null;
        }

    }
}
