﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Nodes
{
    [Serializable]
    public class UnknownNode : Node
    {
        public UnknownNode(byte nodeId) : base(nodeId)
        {
        }
    }
}
