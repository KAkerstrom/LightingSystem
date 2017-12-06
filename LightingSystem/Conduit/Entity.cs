using LightTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit
{
    [Serializable]
    public abstract class Entity
    {
        public delegate void ParametersChangedDelegate();
        public event ParametersChangedDelegate ParametersChanged;

        protected string name = string.Empty.PadRight(7 * 3);
        protected byte nodeId;
        protected byte deviceId;
        protected byte[] parameters1 = new byte[7] { 0, 0, 0, 0, 0, 0, 0};
        protected byte[] parameters2 = new byte[7] { 0, 0, 0, 0, 0, 0, 0};

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public byte NodeId
        {
            get { return nodeId; }
            protected set { nodeId = value; }
        }

        public virtual byte DeviceId
        {
            get { return deviceId; }
            protected set
            {
                if (deviceId == 0 && this is Device)
                    throw new Exception("Device ID cannot be 0.");
                deviceId = value;
            }
        }

        /// <summary>
        /// A raw byte array of 7 parameters, unique to each device.
        /// </summary>
        public byte[] Parameters1
        {
            get { return parameters1; }
            set
            {
                if (parameters1 != value)
                    ParametersChanged?.Invoke();

                parameters1 = value;
            }
        }

        /// <summary>
        /// A raw byte array of 7 parameters, unique to each device.
        /// </summary>
        public byte[] Parameters2
        {
            get { return parameters2; }
            set
            {
                if (parameters2 != value)
                    ParametersChanged?.Invoke();

                parameters2 = value;
            }
        }

        //public void GetParameters()
        //{
        //    ping = new CANPing(Commands.CmdSysEPar, nodeId, DeviceId);
        //    ping.ResponseReceived += Ping_ParameterReceived;
        //}

        //private void Ping_ParameterReceived(List<C4UFX.CANMessage> responses)
        //{
        //    if (responses.Count == 1)
        //        for (int i = 0; i < 7; i++)
        //            Parameters[i] = responses[0].Data[i + 1];

        //    ping.ResponseReceived -= Ping_ParameterReceived;
        //}

        public bool SetNamePart(string name, int section)
        {
            const int CHARS_PER_MESSAGE = 7;
            if (name.Length > CHARS_PER_MESSAGE)
                return false;

            name = name.PadRight(CHARS_PER_MESSAGE);

            switch (section)
            {
                case 1:
                    Name = name + Name.Substring(CHARS_PER_MESSAGE);
                    return true;
                case 2:
                    Name = Name.Substring(0, CHARS_PER_MESSAGE) + name + Name.Substring(CHARS_PER_MESSAGE * 2);
                    return true;
                case 3:
                    Name = Name.Substring(0, CHARS_PER_MESSAGE * 2) + name;
                    return true;
                default:
                    return false;
            }
        }

        //Untested
        public void SetDeviceName(string newName)
        {
            name = newName;

            byte[] namePart = GetNamePart(newName, 1);
            if (namePart == null)
                return;
            CANInterface.SendMessage(this, Commands.CmdSysPName1, namePart);

            namePart = GetNamePart(newName, 2);
            if (namePart == null)
                return;
            CANInterface.SendMessage(this, Commands.CmdSysPName2, namePart);

            namePart = GetNamePart(newName, 3);
            if (namePart == null)
                return;
            CANInterface.SendMessage(this, Commands.CmdSysPName3, namePart);
        }

        //Untested
        private byte[] GetNamePart(string fullName, int section)
        {
            const int CHARS_PER_MESSAGE = 7;

            if (fullName.Length <= CHARS_PER_MESSAGE * (section - 1))
                return null;

            fullName = fullName.Substring(CHARS_PER_MESSAGE * (section - 1));

            byte[] nameArray = new byte[fullName.Length];
            for (int i = 0; i < fullName.Length; i++)
                nameArray[i] = (byte)fullName[i];

            byte[] namePart = new byte[(fullName.Length >= CHARS_PER_MESSAGE) ? CHARS_PER_MESSAGE : fullName.Length - CHARS_PER_MESSAGE];
            for (int i = 0; i < namePart.Length; i++)
                namePart[i] = nameArray[i];
            return namePart;
        }
    }
}
