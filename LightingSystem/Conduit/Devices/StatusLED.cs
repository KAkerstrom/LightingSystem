﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Devices
{
    [Serializable]
    class StatusLED : Device
    {
        public StatusLED(byte nodeId, byte deviceId) : base(nodeId, deviceId)
        {
        }
    }
}
