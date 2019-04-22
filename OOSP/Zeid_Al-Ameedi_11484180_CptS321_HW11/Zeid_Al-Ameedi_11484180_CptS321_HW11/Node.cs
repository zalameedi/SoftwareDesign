using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeid_Al_Ameedi_11484180_CptS321_HW11
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

        /// <summary>
        /// Next constructor for Node object that sets data if it's passed in
        /// </summary>
        /// <param name="mdata"></param>
        public Node(int mdata)
        {
            this.Data = mdata;
            this.PLeft = null;
            this.PRight = null;
        }
    }
}
