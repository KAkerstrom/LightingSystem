using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightTest.Kyle
{
    [Serializable]
    public abstract class Node : Entity
    {
        public List<Device> Devices = new List<Device>();

        public override byte DeviceId
        {
            get { return deviceId; }
        }

        public Node(byte nodeId)
        {
            this.NodeId = nodeId;
            DeviceId = 0;
        }
    }
}
