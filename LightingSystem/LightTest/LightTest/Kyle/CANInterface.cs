using LightTest.Kyle.Enums;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LightTest.Kyle
{
    public delegate void MessageReceivedDelegate(C4UFX.CANMessage message);
    public delegate void MessageSentDelegate(C4UFX.CANMessage message);

    public delegate void CANStatusDelegate(CANSTAT status);
    public delegate void InterfaceWarningDelegate(Warning status, bool setWarning);

    static class CANInterface
    {
        #region Events

        /// <summary>
        /// Occurs when a message is received from the CAN.
        /// </summary>
        public static event MessageReceivedDelegate MessageReceived;

        /// <summary>
        /// Occurs when a message is sent to the CAN.
        /// </summary>
        public static event MessageSentDelegate MessageSent;

        /// <summary>
        /// Occurs when there is a change in the CAN status.
        /// </summary>
        public static event CANStatusDelegate CANStatus;

        /// <summary>
        /// Occurs when there is an update in the interface warnings.
        /// </summary>
        public static event InterfaceWarningDelegate InterfaceWarning;

        #endregion Events

        #region Constants

        private const byte MAX_ID = 127;
        private const byte MAX_DATA_BYTES = 8;
        private const C4UFX.CANBaud CANBAUD = C4UFX.CANBaud.Kbps500;

        #endregion Constants

        #region Fields

        private static Queue<C4UFX.CANMessage> messageQueue = new Queue<C4UFX.CANMessage>();
        private static Timer updateTmr = new Timer();
        private static Timer errorResetTmr = new Timer();
        private static Timer sendQueueTmr = new Timer();
        private static int checkStatusInterval = 10;
        private static CANSTAT CANInterfaceStatus = 0;

        #endregion Fields

        #region Constructors

        /// <summary>
        /// Initializes the <see cref="CANInterface"/> class.
        /// </summary>
        static CANInterface()
        {
            updateTmr.Interval = 10;
            updateTmr.Tick += UpdateTmr_Tick;
            updateTmr.Start();

            errorResetTmr.Interval = 500;
            errorResetTmr.Tick += ErrorResetTmr_Tick;

            sendQueueTmr.Interval = 20;
            sendQueueTmr.Tick += SendQueueTmr_Tick;
            sendQueueTmr.Start();

            CANInit();
        }

        #endregion Constructors

        #region Public Methods

        #region Overload Methods

        /// <summary>
        /// Sends a message to the given device from an arbitrary FndTnd (0x7, 0x00).
        /// </summary>
        /// <param name="toNode">The ID of the Node to send to.</param>
        /// <param name="toDevice">The ID of the Device on that Node to send to.</param>
        /// <param name="command">The Command to send.</param>
        /// <param name="data">The optional parameters for the command.</param>
        public static C4UFX.CANMessage SendMessage(byte toNode, byte toDevice, Commands command, byte[] data = null)
        {
            return SendMessage(MAX_ID, 0, toNode, toDevice, command, data);
        }

        /// <summary>
        /// Sends a message to the given device from an arbitrary FndTnd (0x7F, 0x00).
        /// </summary>
        /// <param name="toEntity">The device to send the command to.</param>
        /// <param name="command">The Command to send.</param>
        /// <param name="data">The optional parameters for the command.</param>
        public static C4UFX.CANMessage SendMessage(Entity toEntity, Commands command, byte[] data = null)
        {
            return SendMessage(MAX_ID, 0, toEntity.NodeId, toEntity.DeviceId, command, data);
        }

        /// <summary>
        /// Sends a message to the given device from an arbitrary FndTnd (0x7F, 0x00).
        /// </summary>
        /// <param name="fromEntity">The device sending the command.</param>
        /// <param name="toEntity">The device to send the command to.</param>
        /// <param name="command">The Command to send.</param>
        /// <param name="data">The optional parameters for the command.</param>
        public static C4UFX.CANMessage SendMessage(Entity fromEntity, Entity toEntity, Commands command, byte[] data = null)
        {
            return SendMessage(fromEntity.NodeId, fromEntity.DeviceId, toEntity.NodeId, toEntity.DeviceId, command, data);
        }

        /// <summary>
        /// Broadcasts a message from an arbitrary device (0x7F, 0x00) by sending it to (0, 0).
        /// </summary>
        /// <param name="command">The Command to send.</param>
        /// <param name="data">The optional parameters for the command.</param>
        public static C4UFX.CANMessage BroadcastMessage(Commands command, byte[] data = null)
        {
            return SendMessage(MAX_ID, 0, 0, 0, command, data);
        }

        /// <summary>
        /// Broadcasts a message from a given device by sending it to (0, 0).
        /// </summary>
        /// <param name="fromNode">The ID of the Node sending the message.</param>
        /// <param name="fromDevice">The ID of the device sending the message.</param>
        /// <param name="command">The Command to send.</param>
        /// <param name="data">The optional parameters for the command.</param>
        public static C4UFX.CANMessage BroadcastMessage(byte fromNode, byte fromDevice, Commands command, byte[] data = null)
        {
            return SendMessage(fromNode, fromDevice, 0, 0, command, data);
        }

        #endregion Overload Methods

        /// <summary>
        /// Sends a message from / to the given devices.
        /// </summary>
        /// <param name="fromNode">The ID of the Node sending the message.</param>
        /// <param name="fromDevice">The ID of the device sending the message.</param>
        /// <param name="toNode">The ID of the Node to send to.</param>
        /// <param name="toDevice">The ID of the Device on that Node to send to.</param>
        /// <param name="command">The Command to send.</param>
        /// <param name="data">The optional parameters for the command.</param>
        public static C4UFX.CANMessage SendMessage(byte fromNode, byte fromDevice, byte toNode, byte toDevice, Commands command, byte[] data = null)
        {
            if (fromNode > MAX_ID || fromDevice > MAX_ID || toNode > MAX_ID || toDevice > MAX_ID)
                throw new Exception("Node / Device IDs cannot be higher than 127.");

            if (data?.Length > MAX_DATA_BYTES - 1)
                throw new Exception("Messages cannot carry more than 8 bytes of data, including the Command byte.");

            C4UFX.CANMessage message = new C4UFX.CANMessage();
            FndTnd fndtnd = GetFndTnd(fromNode, fromDevice, toNode, toDevice);
            message.DLC = (data != null) ? (byte)(data.Length + 1) : (byte)1;
            message.ID = FndTndToId(fndtnd);
            message.Data[0] = (byte)command;

            if (data != null)
                for (int i = 0; i < data.Length; i++)
                    message.Data[i + 1] = data[i];

            messageQueue.Enqueue(message);
            return message;
        }

        /// <summary>
        /// Convert from an ID to a FndTnd.
        /// </summary>
        /// <param name="ID">The ID.</param>
        /// <returns>The FndTnd.</returns>
        public static FndTnd IdToFndTnd(long ID)
        {
            FndTnd fndtnd = new FndTnd();
            // 01111111000000000000000000000    7 bits for From Node
            fndtnd.FromNode = (byte)((ID >> 21) & 0x7F);
            // 00000000111111100000000000000    7 bits for From Device
            fndtnd.FromDevice = (byte)((ID >> 14) & 0x7F);
            // 00000000000000011111110000000    7 bits for To Node
            fndtnd.ToNode = (byte)((ID >> 7) & 0x7F);
            // 00000000000000000000001111111    7 bits for To Device
            fndtnd.ToDevice = (byte)(ID & 0x7F);
            return fndtnd;
        }

        /// <summary>
        /// Convert from FndTnd to an ID.
        /// </summary>
        /// <param name="fndtnd">The FndTnd.</param>
        /// <returns>The ID.</returns>
        public static long FndTndToId(FndTnd fndtnd)
        {
            long id;
            id = (long)fndtnd.FromNode << 21;
            id += (long)fndtnd.FromDevice << 14;
            id += (long)fndtnd.ToNode << 7;
            id += (long)fndtnd.ToDevice;

            return id;
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Creates a FndTnd instance with the given ID values.
        /// </summary>
        /// <param name="fromNode">The ID of the From Node.</param>
        /// <param name="fromDevice">The ID of the From Device</param>
        /// <param name="toNode">The ID of the To Node.</param>
        /// <param name="toDevice">The ID of the To Device.</param>
        /// <returns>A FndTnd with the given values.</returns>
        private static FndTnd GetFndTnd(byte fromNode, byte fromDevice, byte toNode, byte toDevice)
        {
            FndTnd FndTnd = new FndTnd();

            FndTnd.FromNode = fromNode;
            FndTnd.FromDevice = fromDevice;
            FndTnd.ToNode = toNode;
            FndTnd.ToDevice = toDevice;
            return FndTnd;
        }

        /// <summary>
        /// Sends the oldest message in the queue to the CAN.
        /// </summary>
        private static void SendNextInQueue()
        {
            if (messageQueue.Count > 0)
            {
                int error = 0;
                C4UFX.CANMessage mess = messageQueue.Dequeue();
                C4UFX.SendCANMess(0, 0, mess, out error);
                MessageSent?.Invoke(mess);
            }
        }

        /// <summary>
        /// Checks the CAN for incoming messages.
        /// </summary>
        private static void GetIncomingMessages()
        {
            try
            {
                int Result = C4UFX.Resp_Ack;
                C4UFX.CANMessage CANMess = new C4UFX.CANMessage();

                while (Result == C4UFX.Resp_Ack)
                {
                    Result = C4UFX.GetCANMess(0, 0, ref CANMess);
                    if (Result == C4UFX.Resp_Ack)
                        MessageReceived?.Invoke(CANMess);
                }
            }
            catch
            {
                CANStatus?.Invoke(CANSTAT.NOINTERFACE); //Error found by not connecting interface, unsure if that's the only possible reason
            }
        }

        /// <summary>
        /// Checks the status of the CAN.
        /// </summary>
        /// <param name="ForceErr">If true, force an error even if there is none.</param>
        private static void CANCheckStatus(bool ForceErr)
        {
            int Result;

            if (CANInterfaceStatus == CANSTAT.OK && !ForceErr)
            {
                byte[] DataBuffer = new byte[10];

                Result = C4UFX.ReadReg(0, 0, 0x2D, 1, ref DataBuffer); // EFLG
                if (Result == C4UFX.Resp_Ack)
                {
                    InterfaceWarning?.Invoke(Warning.OK, DataBuffer[0] == 0);
                    InterfaceWarning?.Invoke(Warning.RxWarning, (DataBuffer[0] & 0x02) > 0);
                    InterfaceWarning?.Invoke(Warning.TxWarning, (DataBuffer[0] & 0x04) > 0);
                    InterfaceWarning?.Invoke(Warning.Buffer0Warning, (DataBuffer[0] & 0x08) > 0);
                    InterfaceWarning?.Invoke(Warning.Buffer1Warning, (DataBuffer[0] & 0x10) > 0);
                    InterfaceWarning?.Invoke(Warning.RxPassive, (DataBuffer[0] & 0x20) > 0);
                    InterfaceWarning?.Invoke(Warning.TxPassive, (DataBuffer[0] & 0x40) > 0);
                    InterfaceWarning?.Invoke(Warning.BussOff, (DataBuffer[0] & 0x80) > 0);

                    if ((DataBuffer[0] & 0x40) > 0 || (DataBuffer[0] & 0x80) > 0)
                        errorResetTmr.Start();
                }
            }
            else
            {
                C4UFX.CANMessage errorMessage = new C4UFX.CANMessage();
                int errorCode;

                errorMessage.ID = 0;
                errorMessage.DLC = 0;
                for (int i = 0; i < 8; i++)
                    errorMessage.Data[i] = 0;
                errorMessage.EID = true;
                errorMessage.RTR = false;
                errorMessage.MO = 0;
                errorMessage.SendOption = 7;

                Result = C4UFX.SendCANMess(0, 0, errorMessage, out errorCode);

                switch (Result)
                {
                    case C4UFX.Resp_Ack:
                        CANStatus?.Invoke(CANSTAT.OK);
                        break;

                    case C4UFX.Resp_NAck:
                        // message was transmitted but there was an error, so reset
                        CANInit();
                        CANStatus?.Invoke(CANSTAT.SENDERROR);
                        break;

                    case C4UFX.Resp_ErrImproperResponse:
                        CANStatus?.Invoke(CANSTAT.NOINTERFACE);
                        break;

                    default:
                        CANStatus?.Invoke(CANSTAT.ERROR);
                        break;
                }
            }
        }

        /// <summary>
        /// Initializes the CAN.
        /// </summary>
        /// <returns>If successful, return [true].</returns>
        private static bool CANInit()
        {
            int Result;
            Result = C4UFX.EnableTS(0, 0);
            Result = C4UFX.ResetInterface(0, 0);          // clear out any misc messages

            if (Result != C4UFX.Resp_Ack)
            {
                CANCheckStatus(true);
                return false;
            }
            Result = C4UFX.ClearCANMess(0, 0);            // clear out any misc messages

            if (Result != C4UFX.Resp_Ack)
            {
                CANCheckStatus(true);
                return false;
            }
            Result = C4UFX.SetCANBaud(0, 0, CANBAUD);

            if (Result != C4UFX.Resp_Ack)
            {
                CANCheckStatus(true);
                return false;
            }
            Result = C4UFX.ClearCANMess(0, 0);

            if (Result != C4UFX.Resp_Ack)
            {
                CANCheckStatus(true);
                return false;
            }
            Result = C4UFX.RecCANMess(0, 0, (long)Filters.MESS0, 0x0C + 1); //'//MO0 + enable rollover bit

            if (Result != C4UFX.Resp_Ack)
            {
                CANCheckStatus(true);
                return false;
            }

            Result = C4UFX.RecCANMess(0, 0, (long)Filters.MESS1, 0x1C);
            if (Result != C4UFX.Resp_Ack)
            {
                CANCheckStatus(true);
                return false;
            }

            for (int i = 0; i < 6; i++)
            {
                Result = C4UFX.SetFilters(0, 0, (byte)i, (long)Filters.FILTER0, true);
                if (Result != C4UFX.Resp_Ack)
                {
                    CANCheckStatus(true);
                    return false;
                }
            }

            return true;
        }

        #endregion Private Methods

        #region Events

        /// <summary>
        /// Handles the Tick event of the ErrorResetTmr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void ErrorResetTmr_Tick(object sender, EventArgs e)
        {
            int Result;
            byte[] Buf = new Byte[4];
            Buf[0] = 0;
            Result = C4UFX.WriteReg(0, 0, 0x2D, 1, Buf);
            errorResetTmr.Stop();
        }

        /// <summary>
        /// Handles the Tick event of the UpdateTmr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void UpdateTmr_Tick(object sender, EventArgs e)
        {
            GetIncomingMessages();
        }

        /// <summary>
        /// Handles the Tick event of the SendQueueTmr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private static void SendQueueTmr_Tick(object sender, EventArgs e)
        {
            if (--checkStatusInterval <= 0)
            {
                CANCheckStatus(false);
                checkStatusInterval = 100; // every second
            }

            SendNextInQueue();
        }

        #endregion Events
    }
}
