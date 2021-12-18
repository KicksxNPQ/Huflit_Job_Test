using System;
using System.Collections.Generic;
using System.Text;

namespace Huflit_Test
{
    public class Node
    {
        public Object data { get; set; }
        public Node nextNode { get; set; }

        public Node(Object data = null)
        {
            this.data = data;
            this.nextNode = null;
        }
    }
}
