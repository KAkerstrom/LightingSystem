using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit
{
    [Serializable]
    public class Device : Entity
    {
        public Device(byte nodeId, byte deviceId)
        {
            this.nodeId = nodeId;
            this.deviceId = deviceId;
        }
    }
}
