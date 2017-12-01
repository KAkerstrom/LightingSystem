using LightTest.Kyle.Devices;
using LightTest.Kyle.Enums;
using LightTest.Kyle.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightTest.Kyle
{
    public delegate void PongsRecievedDelegate(List<Node> pongs);
    public delegate void StatusUpdateDelegate(string status);

    /// <summary>
    /// Provides an interface for polling the network.
    /// </summary>
    public static class Poll
    {
        public static event PongsRecievedDelegate PongsReceived;
        public static event StatusUpdateDelegate StatusUpdate;

        private static List<Node> allResponses = new List<Node>();

        public static void PollNetwork()
        {
            StatusUpdate?.Invoke("Pinging nodes...");

            Dictionary<byte, List<byte>> sendList = new Dictionary<byte, List<byte>>();
            for (byte i = 1; i < 127; i++)
                sendList.Add(i, new List<byte>());

            CANPing nodePoll = new CANPing(Commands.CmdSysPing, sendList);
            nodePoll.ResponseReceived += NodePoll_PollReceived;
        }

        private static void NodePoll_PollReceived(List<C4UFX.CANMessage> responses)
        {
            if (responses.Count == 0)
            {
                StatusUpdate?.Invoke("No Nodes found - Check your connection.");
                return;
            }

            StatusUpdate?.Invoke("Pinging devices...");

            foreach (C4UFX.CANMessage response in responses)
            {
                byte fromNode = CANInterface.IdToFndTnd(response.ID).FromNode;
                Node newNode;
                switch ((Signatures)response.Data[2])
                {
                    case Signatures.SmartSwitch: newNode = new SmartSwitch(fromNode); break;
                    case Signatures.ACDimmer: newNode = new ACDimmer(fromNode); break;
                    case Signatures.TimerRTC: newNode = new TimerRTC(fromNode); break;
                    case Signatures.SceneController: newNode = new SceneController(fromNode); break;
                    default: newNode = new UnknownNode(fromNode); break;
                }

                allResponses.Add(newNode);
            }

            Dictionary<byte, List<byte>> sendList = new Dictionary<byte, List<byte>>();
            foreach (Node node in allResponses)
            {
                if (sendList.Keys.Contains(node.NodeId))
                    break;
                sendList.Add(node.NodeId, new List<byte>());
                for (byte i = 1; i < 127; i++)
                    sendList[node.NodeId].Add(i);
            }

            CANPing poll = new CANPing(Commands.CmdSysPing, sendList);
            poll.ResponseReceived += DevicePoll_Received;
        }

        private static void DevicePoll_Received(List<C4UFX.CANMessage> responses)
        {
            StatusUpdate?.Invoke("Querying names (1/3)...");


            foreach (C4UFX.CANMessage response in responses)
            {
                FndTnd address = CANInterface.IdToFndTnd(response.ID);
                if (address.FromDevice > 0)
                {
                    Node currentNode = allResponses.First(x => x.NodeId == address.FromNode);
                    byte fromNode = CANInterface.IdToFndTnd(response.ID).FromNode;
                    byte fromDevice = CANInterface.IdToFndTnd(response.ID).FromDevice;
                    Device newDevice;
                    switch ((Signatures)response.Data[2])
                    {
                        case Signatures.MechanicalSwitch: newDevice = new MechanicalSwitch(fromNode, fromDevice); break;
                        case Signatures.StatusLED: newDevice = new StatusLED(fromNode, fromDevice); break;
                        case Signatures.InfraredInput: newDevice = new InfraredInput(fromNode, fromDevice); break;
                        case Signatures.DimmerOut: newDevice = new DimmerOut(fromNode, fromDevice); break;
                        case Signatures.LatLong: newDevice = new LatLong(fromNode, fromDevice); break;
                        case Signatures.TimerEvent: newDevice = new TimerEvent(fromNode, fromDevice); break;
                        case Signatures.Scene: newDevice = new Scene(fromNode, fromDevice); break;
                        case Signatures.RealTimeClock: newDevice = new RealTimeClock(fromNode, fromDevice); break;
                        default: newDevice = new UnknownDevice(fromNode, fromDevice); break;
                    }

                    currentNode.Devices.Add(newDevice);
                }
            }

            Dictionary<byte, List<byte>> sendList = new Dictionary<byte, List<byte>>();
            foreach (Node node in allResponses)
            {
                if (sendList.Keys.Contains(node.NodeId))
                    break;
                sendList.Add(node.NodeId, new List<byte>());
                for (byte i = 1; i < 127; i++)
                    sendList[node.NodeId].Add(i);
            }

            CANPing poll = new CANPing(Commands.CmdSysEName1, sendList);
            poll.ResponseReceived += Name1Poll_Received;
        }

        private static void Name1Poll_Received(List<C4UFX.CANMessage> responses)
        {
            StatusUpdate?.Invoke("Querying names (2/3)...");

            foreach (C4UFX.CANMessage response in responses)
            {
                FndTnd address = CANInterface.IdToFndTnd(response.ID);
                string namePart = string.Empty;
                for (int i = 1; i < response.Data.Length; i++)
                    namePart += (char)response.Data[i];

                Node thisNode = allResponses.Find(x => x.NodeId == address.FromNode);
                //if (thisNode == null)
                //    allResponses.Add(new UnknownNode(address.FromNode));

                if (address.FromDevice == 0)
                    allResponses.Find(x => x.NodeId == address.FromNode).SetNamePart(namePart, 1);
                else
                    allResponses.Find(x => x.NodeId == address.FromNode).Devices.Find(x => x.DeviceId == address.FromDevice).SetNamePart(namePart, 1);
                //If the node/device isn't found, add it to the list
            }

            Dictionary<byte, List<byte>> sendList = new Dictionary<byte, List<byte>>();
            foreach (Node node in allResponses)
            {
                if (sendList.Keys.Contains(node.NodeId))
                    break;
                sendList.Add(node.NodeId, new List<byte>());
                foreach (Device device in node.Devices)
                    sendList[node.NodeId].Add(device.DeviceId);
            }

            CANPing poll = new CANPing(Commands.CmdSysEName2, sendList);
            poll.ResponseReceived += Name2Poll_Received;
        }

        private static void Name2Poll_Received(List<C4UFX.CANMessage> responses)
        {
            StatusUpdate?.Invoke("Querying names (3/3)...");

            foreach (C4UFX.CANMessage response in responses)
            {
                FndTnd address = CANInterface.IdToFndTnd(response.ID);
                string namePart = string.Empty;
                for (int i = 1; i < response.Data.Length; i++)
                    namePart += (char)response.Data[i];

                if (address.FromDevice == 0)
                    allResponses.First(x => x.NodeId == address.FromNode).SetNamePart(namePart, 2);
                else
                    allResponses.First(x => x.NodeId == address.FromNode).Devices.First(x => x.DeviceId == address.FromDevice).SetNamePart(namePart, 2);
            }

            Dictionary<byte, List<byte>> sendList = new Dictionary<byte, List<byte>>();
            foreach (Node node in allResponses)
            {
                if (sendList.Keys.Contains(node.NodeId))
                    break;
                sendList.Add(node.NodeId, new List<byte>());
                foreach (Device device in node.Devices)
                    sendList[node.NodeId].Add(device.DeviceId);
            }

            CANPing poll = new CANPing(Commands.CmdSysEName3, sendList);
            poll.ResponseReceived += Name3Poll_Received;
        }

        private static void Name3Poll_Received(List<C4UFX.CANMessage> responses)
        {
            StatusUpdate?.Invoke("Poll complete!");

            foreach (C4UFX.CANMessage response in responses)
            {
                FndTnd address = CANInterface.IdToFndTnd(response.ID);
                string namePart = string.Empty;
                for (int i = 1; i < response.Data.Length; i++)
                    namePart += (char)response.Data[i];

                if (address.FromDevice == 0)
                    allResponses.First(x => x.NodeId == address.FromNode).SetNamePart(namePart, 3);
                else
                    allResponses.First(x => x.NodeId == address.FromNode).Devices.First(x => x.DeviceId == address.FromDevice).SetNamePart(namePart, 3);
            }

            Dictionary<byte, List<byte>> sendList = new Dictionary<byte, List<byte>>();
            foreach (Node node in allResponses)
            {
                if (sendList.Keys.Contains(node.NodeId))
                    break;
                sendList.Add(node.NodeId, new List<byte>());
                foreach (Device device in node.Devices)
                    sendList[node.NodeId].Add(device.DeviceId);
            }

            CANPing poll = new CANPing(Commands.CmdSysEPar, sendList);
            poll.ResponseReceived += Parameters_Received;
        }

        private static void Parameters_Received(List<C4UFX.CANMessage> responses)
        {
            StatusUpdate?.Invoke("Querying parameters (1/2)...");

            foreach (C4UFX.CANMessage response in responses)
            {
                FndTnd address = CANInterface.IdToFndTnd(response.ID);
                if (address.FromDevice == 0)
                    for (int i = 0; i < response.DLC - 1; i++)
                        allResponses.First(x => x.NodeId == address.FromNode).Parameters[i] = response.Data[i + 1];
                //else
                //    allResponses.First(x => x.NodeId == address.FromNode).Devices.First(x => x.DeviceId == address.FromDevice).SetNamePart(namePart, 2);
            }

            Dictionary<byte, List<byte>> sendList = new Dictionary<byte, List<byte>>();
            foreach (Node node in allResponses)
            {
                if (sendList.Keys.Contains(node.NodeId))
                    break;
                sendList.Add(node.NodeId, new List<byte>());
                foreach (Device device in node.Devices)
                    sendList[node.NodeId].Add(device.DeviceId);
            }

            CANPing poll = new CANPing(Commands.CmdSysEName3, sendList);
            poll.ResponseReceived += Name3Poll_Received;
        }
    }
}
