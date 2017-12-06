using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Enums
{
    public enum DimmerMode
    {
        Disabled = 0x00,
        Dimming = 0x01,
        DimmingInverted = 0x02,
        NonDimming = 0x03,
        NonDimmingInverted = 0x04
    }
}
