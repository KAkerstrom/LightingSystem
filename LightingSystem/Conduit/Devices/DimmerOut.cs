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
        /// A value between 0x00 and 0xFA. <BR>
        /// This features controls how fast the dimming output will turn on and off <BR>
        /// and change between two settings.Instead of the output turning on to full power instantly, <BR>
        /// the power will ramp up or down depending on the amount of time set here.The range is from 0 (disabled) <BR>
        /// to a maximum of 2 seconds in 8ms increments.
        /// </summary>
        public byte SoftOnOff
        {
            get { return parameters1[1]; }
            set { }
        }

        /// <summary>
        /// A value between 0x01 and 0x64. <BR>
        /// The minimum brightness of the light.
        /// </summary>
        public byte MinimumBrightness
        {
            get { return parameters1[2]; }
            set { }
        }

        /// <summary>
        /// A value between 0x01 and 0x64. <BR>
        /// The maximum brightness of the light.
        /// </summary>
        public byte MaximumBrightness
        {
            get { return parameters1[3]; }
            set { }
        }

        /// <summary>
        /// A value from 0x00 to 0x64. 0x00 represents "Last Value", 0x01 to 0x64 represent a percentage. <BR>
        /// This feature allows you to set the output to go to a preset level of 1-100% when the output <BR>
        /// is sent the On command or, if set to 0, the output will return to the last value that it was <BR>
        /// set to when it was last dimmed.
        /// </summary>
        public byte PresetOn
        {
            get { return parameters1[4]; }
            set { }
        }

        /// <summary>
        /// A value between 0x01 to 0x05. <BR>
        /// This setting will determine how fast the output will dim up and down when a switch <BR>
        /// is held that is sending dimming commands to this output.Because the holding switch will send <BR>
        /// commands at a constant rate(50ms) the Dim Step can be adjusted from 1-5% per command <BR>
        /// received.This would change the time taken to go from full off to full on from 5 seconds (1% setting) to 1 second (5% setting)
        /// </summary>
        public byte DimStep
        {
            get { return parameters1[5]; }
            set { }
        }
    }
}
