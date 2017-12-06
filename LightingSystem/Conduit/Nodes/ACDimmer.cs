using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Nodes
{
    [Serializable]
    public class ACDimmer : Node
    {
        public ACDimmer(byte nodeId) : base(nodeId)
        {
        }
    }
}
