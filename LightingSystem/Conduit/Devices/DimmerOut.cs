using Conduit.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Devices
{
    [Serializable]
    public class DimmerOut : Light
    {
        public DimmerOut(byte nodeId, byte deviceId) : base(nodeId, deviceId)
        {
        }

        public DimmerMode Mode
        {
            get { return (DimmerMode)parameters1[0]; }
        }

        /// <summary>
        /// A value between 0x00 and 0xFA.
        /// This features controls how fast the dimming output will turn on and off 
        /// and change between two settings.Instead of the output turning on to full power instantly, 
        /// the power will ramp up or down depending on the amount of time set here.The range is from 0 (disabled) 
        /// to a maximum of 2 seconds in 8ms increments.
        /// </summary>
        public byte SoftOnOff
        {
            get { return parameters1[1]; }
            set { }
        }

        /// <summary>
        /// A value between 0x00 and 0x64.
        /// 
        /// </summary>
        public byte MinimumBrightness
        {
            get { return parameters1[2]; }
            set { }
        }

        public byte MaximumBrightness
        {
            get { return parameters1[3]; }
            set { }
        }

        public byte PresetOn
        {
            get { return parameters1[4]; }
            set { }
        }

        public byte DimStep
        {
            get { return parameters1[5]; }
            set { }
        }
    }
}
