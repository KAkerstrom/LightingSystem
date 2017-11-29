using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightTest.Kyle.Nodes
{
    [Serializable]
    class SmartSwitch : Node
    {
        public SmartSwitch(byte nodeId) : base (nodeId)
        {
        }
    }
}
