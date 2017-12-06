using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Enums
{
    public enum Signatures
    {
        //Nodes
        SmartSwitch = 0x05,
        ACDimmer = 0x03,
        TimerRTC = 0x12,
        SceneController = 0x0B,

        //Devices
        MechanicalSwitch = 0xFC,
        StatusLED = 0xFD,
        InfraredInput = 0xFE,
        DimmerOut = 0xED,
        LatLong = 0x11,
        TimerEvent = 0x14,
        Scene = 0x06,
        RealTimeClock = 0x10,
    }
}
