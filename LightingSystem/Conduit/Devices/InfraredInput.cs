using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conduit.Devices
{
    [Serializable]
    class InfraredInput : Device
    {
        public InfraredInput(byte nodeId, byte deviceId) : base(nodeId, deviceId)
        {
        }

        //public void UpdateParameters()
        //{
        //    CANInterface.SendMessage(this, Commands.CmdSysPLock);
        //    CANInterface.MessageReceived += CANInterface_RLockReceived;
        //}

        //private void CANInterface_RLockReceived(C4UFX.CANMessage message)
        //{
        //    FndTnd address = CANInterface.IdToFndTnd(message.ID);
        //    if(address.FromNode == NodeId && address.FromDevice == DeviceId && message.Data[0] == (byte)Commands.CmdSysRLock)
        //    {


        //        CANInterface.MessageReceived -= CANInterface_RLockReceived;
        //    }
        //}
    }
}
