using LightTest.Kyle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightTest
{
    public delegate void ResponseReceivedDelegate(List<C4UFX.CANMessage> responses);


    class CANPing
    {
        public event ResponseReceivedDelegate ResponseReceived;

        Commands expectedResult;
        C4UFX.CANMessage lastMessage;
        Timer waitForResponse = new Timer();
        List<C4UFX.CANMessage> responses = new List<C4UFX.CANMessage>();

        Dictionary<Commands, Commands> responseCommands = new Dictionary<Commands, Commands>
        {
            { Commands.CmdSysPing, Commands.CmdSysPong },
            { Commands.CmdSysEName1, Commands.CmdSysRName1 },
            { Commands.CmdSysEName2, Commands.CmdSysRName2 },
            { Commands.CmdSysEName3, Commands.CmdSysRName3 },
            { Commands.CmdSysEPar, Commands.CmdSysRPar},
            { Commands.CmdSysEPar2, Commands.CmdSysRPar2 },
        };

        /// <summary>
        /// Polls the network with the given command, then fires the PollRecieved event with the results.
        /// </summary>
        /// <param name="sendCommand">The command to send.</param>
        /// <param name="nodes">The Nodes to poll.</param>
        /// <param name="devices">The Devices to poll on each Node.</param>
        public CANPing(Commands sendCommand, Dictionary<byte, List<byte>> nodeDevices)
        {
            if (nodeDevices.Count == 0)
                throw new Exception("Cannot ping 0 nodes.");

            expectedResult = responseCommands[sendCommand];

            foreach (byte node in nodeDevices.Keys)
            {
                lastMessage = CANInterface.SendMessage(node, 0, sendCommand);
                foreach (byte device in nodeDevices[node])
                    lastMessage = CANInterface.SendMessage(node, device, sendCommand);
            }

            CANInterface.MessageSent += CANInterface_MessageSent;
            CANInterface.MessageReceived += CANInterface_MessageReceived;
            waitForResponse.Interval = 100;
            waitForResponse.Tick += WaitForResponse_Tick;
        }

        /// <summary>
        /// Sends the given command to the given device, then fires the PollRecieved event with the result.
        /// </summary>
        /// <param name="sendCommand">The command to send.</param>
        /// <param name="nodeId">The Node to poll.</param>
        /// <param name="deviceId">The Device to poll on that Node.</param>
        public CANPing(Commands sendCommand, byte nodeId, byte deviceId)
        {
            expectedResult = responseCommands[sendCommand];

            lastMessage = CANInterface.SendMessage(nodeId, deviceId, sendCommand);

            CANInterface.MessageSent += CANInterface_MessageSent;
            CANInterface.MessageReceived += CANInterface_MessageReceived;
            waitForResponse.Interval = 100;
            waitForResponse.Tick += WaitForResponse_Tick;
        }

        private void CANInterface_MessageSent(C4UFX.CANMessage message)
        {
            if (message == lastMessage)
            {
                waitForResponse.Start();
                CANInterface.MessageSent -= CANInterface_MessageSent;
            }
        }

        private void CANInterface_MessageReceived(C4UFX.CANMessage message)
        {
            if (message.Data[0] == (byte)expectedResult)
                responses.Add(message);
        }

        private void WaitForResponse_Tick(object sender, EventArgs e)
        {
            ResponseReceived?.Invoke(responses);
            waitForResponse.Stop();
        }
    }
}
