using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit
{

    /// <summary>
    /// The CAN ID is broken down into four 7-bit groups.
    /// The From Node is the most significant group and it works down from there.
    /// This uses up 28 bits of the 29 bit ID.  MSb is always zero.
    /// </summary>
    public struct FndTnd        // From Node/Device To Node/Device
    {
        public byte FromNode;     // From Node
        public byte FromDevice;     // From Device
        public byte ToNode;     // To Node
        public byte ToDevice;     // To Device
    };
}
