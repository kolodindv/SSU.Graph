using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SSU.Kolodin_graphClass
{
    [TypeConverter(typeof(NodeTypeClass))]
    class NodeTypeClass
    {
        public string Name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public NodeTypeClass()
        {
            Name = "none";
        }

        public NodeTypeClass(string in_)
        {
            Name = in_;
        }

        public void takeName(string in_)
        {
            Name = in_;
        }

        public NodeTypeClass ConvertFrom(string in_)
        {
            return new NodeTypeClass(in_);
        }

        readonly private string inside = "pass";

        public string get()
        {
            return inside;
        }
       
    }
}
