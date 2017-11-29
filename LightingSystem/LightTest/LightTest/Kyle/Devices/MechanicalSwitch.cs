﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightTest.Kyle.Devices
{
    [Serializable]
    class MechanicalSwitch : Device
    {
        public MechanicalSwitch(byte nodeId, byte deviceId) : base(nodeId, deviceId)
        {
        }
    }
}
