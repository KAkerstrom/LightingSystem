using LightTest;
using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Conduit
{
        /// <summary>
        /// Occurs when the brightness is changed.
        /// </summary>
        /// <param name="brightness">The brightness.</param>
        public delegate void BrightnessChangedDelegate(byte brightness);

    [Serializable]
    public abstract class Light : Device, IDeserialize
    {

        /// <summary>
        /// Occurs when [brightness changed].
        /// </summary>
        public event BrightnessChangedDelegate BrightnessChanged;

        private byte brightness;

        /// <summary>
        /// Gets or sets the brightness of the light. <BR>
        /// Setting this property will send a command to the actual light.
        /// </summary>
        public byte Brightness
        {
            get { return brightness; }
            set { SetBrightness(value); }
        }

        //public byte Mode { get { return parameters[1]; } }
        //public byte SoftOnOff { get { return parameters[2]; } }
        //public byte MinimumBrightness { get { return parameters[3]; } }
        //public byte MaximumBrightness { get { return parameters[4]; } }
        //public byte PresetOn { get { return parameters[5]; } }
        //public byte DimStep { get { return parameters[6]; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="Light"/> class.
        /// </summary>
        /// <param name="nodeId">The id of the Node holding the Light.</param>
        /// <param name="deviceId">The device identifier.</param>
        public Light(byte nodeId, byte deviceId) : base(nodeId, deviceId)
        {
            CANInterface.MessageReceived += CANInterface_MessageReceived;
        }

        private void CANInterface_MessageReceived(C4UFX.CANMessage message)
        {
            if (message.Data[0] == (byte)Commands.CmdStatLightValue && CANInterface.IdToFndTnd(message.ID).FromDevice == deviceId)
            {
                if (brightness != message.Data[1])
                    BrightnessChanged?.Invoke(message.Data[1]);

                brightness = message.Data[1];
            }
        }

        /// <summary>
        /// Toggles the light on and off.
        /// </summary>
        public void ToggleOnOff()
        {
            CANInterface.SendMessage(this, Commands.CmdConOnOff);
        }

        /// <summary>
        /// Sets whether the light is on (at a preset brightness), or off.
        /// </summary>
        /// <param name="on">if set to <c>true</c>, the light is [on].</param>
        public void SetOnOff(bool on)
        {
            CANInterface.SendMessage(this, on ? Commands.CmdConOn : Commands.CmdConOff);
        }

        public void FullOn()
        {
            CANInterface.SendMessage(this, Commands.CmdConDClk);
        }

        /// <summary>
        /// Sets the last “On” value to the current value. Used when a switch is
        /// dimming the output and is then released.
        /// </summary>
        public void Release()
        {
            CANInterface.SendMessage(this, Commands.CmdConRelease);
        }

        /// <summary>
        /// Set brightness value over time.
        /// </summary>
        /// <param name="brightness">The brightness, as a value from 0-100.</param>
        /// <param name="time">The time in seconds to reach the brightness value, as a value between 0 - 65535.</param>
        public void SetFade(byte brightness, int time)
        {
            if (time < 0 || time > 65535)
                throw new Exception("Time value for SetFade must be a value between 0 - 65535.");

            byte time1 = BitConverter.GetBytes(time)[1];
            byte time2 = BitConverter.GetBytes(time)[0];
            CANInterface.SendMessage(this, Commands.CmdConSetFade, new byte[] { brightness, time1, time2 });
        }

        /// <summary>
        /// Fade up one step and stop when 100% is reached.
        /// </summary>
        public void FadeUp()
        {
            CANInterface.SendMessage(this, Commands.CmdConFadeUp);
        }

        /// <summary>
        /// Fade down one step and stop when 0% is reached.
        /// </summary>
        public void FadeDown()
        {
            CANInterface.SendMessage(this, Commands.CmdConFadeDwn);
        }

        /// <summary>
        /// Fade one step up or down and reverse direction when 0 or 100% is reached.
        /// </summary>
        public void FadeContinuous()
        {
            CANInterface.SendMessage(this, Commands.CmdConFadeCont);
        }

        /// <summary>
        /// Sets the brightness of the light as a percent.
        /// </summary>
        /// <param name="brightness">The brightness, as a value from 0-100.</param>
        private void SetBrightness(byte brightness)
        {
            if (brightness > 100)
                throw new Exception("Cannot set light brightness higher than 100%.");

            CANInterface.SendMessage(this, Commands.CmdConValue, new byte[] { brightness });
        }

        public void OnDeserializingMethod()
        {
            CANInterface.MessageReceived += CANInterface_MessageReceived;
            CANInterface.SendMessage(this, Commands.CmdSysEStateZZ);
        }
    }
}
