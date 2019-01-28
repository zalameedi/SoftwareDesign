using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW1
{
    /// <summary>
    /// Node class which represents data entries and the links for the branches in our tree.
    /// </summary>
    public class Node
    {
        //Node's attributes (Data for the value, and L/R pts for the Tree)
        public int Data { get; set; }
        public Node PLeft { get; set; }
        public Node PRight { get; set; }

        //Constructors Default/1 Argument
        public Node()
        {
            this.PLeft = null;
            this.PRight = null;
            this.Data = 0;
        }

        public Node(int mdata)
        {
            this.Data = mdata;
            this.PLeft = null;
            this.PRight = null;
        }

    }
}
