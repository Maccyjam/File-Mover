using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace File_Mover
{
    struct XmlGroup
    {
        public string Comment { get; set; }
        public string Id { get; set; }

        public XmlGroup(string comment, string id) : this()
        {
            Comment = comment;
            Id = id;
        }
    }
}
