using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CyUSB;     // first, add reference manually in solution explorer

namespace LightTest
{
    static public class C4UFX
    {
        #region PublicVariables
        public class CANMessage
        {
            public long ID;
            public bool RTR = false;
            public bool EID = true;
            public byte[] Data = new byte[8];
            public byte DLC;
            public byte MO=0;                     // Message object, 0,1 receiving, 0,1,2 sending
            public byte SendOption=7;             // sending options
            // The following are only used for incoming messages
            public double TimeStamp;
            public bool BOF;                    // Buffer Over Flow
        }
        public enum CANBaud : int
        {
            Kbps10 = 0, Kbps20, Kbps50, Kbps100, Kbps125, Kbps250, Kbps500, Kbps800, Kbps1000
        }

        public const int Resp_NAck = 0;
        public const int Resp_Ack = 1;
        public const int Resp_ErrNoInterfacePresent = -1;
        public const int Resp_ErrImproperCallingParameter = -3;
        public const int Resp_ErrImproperResponse = -4;

        //public enum Response : int
        //{
        //    NAck = 0, Ack = 1, ErrNoInterfacePresent = -1, ErrImproperCallingParameter = -3, ErrImproperResponse = -4
        //}
        public enum LEDMode : byte
        {
            Default = 0, User_temp, User_perm
        }
        public enum LEDColor : byte
        {
            Off = 0, Red, Green
        }

        #endregion

        #region PrivateVariables
        static CyUSBDevice[] MyDevice = new CyUSBDevice[10];
        static USBDeviceList usbDevices = null;
        static CyBulkEndPoint[] inEndpoint = new CyBulkEndPoint[10];
        static CyBulkEndPoint[] outEndpoint = new CyBulkEndPoint[10];
        static bool[] ClassInit = new bool[10] { false, false, false, false, false, false, false, false, false, false };        // first call to any method will start background setup 

        private enum LLCMD : byte
        {
            NACK = 0, ACK, GETSTATSREQ, GETSTATSRESP, INITREQ, INITRESP, SETBAUDREQ, SETBAUDRESP, SETFILTERREQ, SETFILTERRESP,
            SENDCANREQ = 0x10, SENDCANRESP, RECCANREQ, RECCANRESP, GETCANMESREQ, GETCANMESRESP, READREGREQ, READREGRESP,
            WRITEREGREQ, WRITEREGRESP,
            GETNUMMESREQ = 0x1C, GETNUMMESRESP, CLEARMESREQ, CLEARMESRESP, ENABLETSREQ, ENABLETSRESP, DISABLETSREQ,
            DISABLETSRESP, SETLEDPATREQ, SETLEDPATRESP
        };
        #endregion

        #region PublicMethods
        // ##############################################################################
        static public int SetCANBaud(byte InterfaceNum, byte DeviceNum, CANBaud Baud)
        {
            byte[] USBOutBuf = new byte[10];
            byte[] USBInBuf = new byte[100];
            int Result;

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.SETBAUDREQ;
            USBOutBuf[2] = (byte)Baud;
            Result = USBRawCommand(InterfaceNum, USBOutBuf, 3, ref USBInBuf);

            if (Result < 0) return (Result);				// return error
            if (USBInBuf[0] != (byte)LLCMD.SETBAUDRESP)
                return (Resp_ErrImproperResponse);				//improper response from node
            else
                return (Resp_Ack);
        }

        // ##############################################################################
        // VerH(igh) and L(ow) will get filled with major and minor version
        // Manufact will be a string up to 20 characters of the board manufacturer name
        // There is additional information being past from the board based on the number
        // of CAN controllers present and their type but this information is not used and
        // no past back
        static public int GetInfo(byte InterfaceNum, byte DeviceNum, ref byte VerH, ref byte VerL, ref string Manufact)
        {
            byte[] USBOutBuf = new byte[10];
            byte[] USBInBuf = new byte[100];
            int Result;

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.GETSTATSREQ;

            Result = USBRawCommand(InterfaceNum, USBOutBuf, 2, ref USBInBuf);

            if (Result < 0) return (Result);				// return error
            if (USBInBuf[0] == (byte)LLCMD.GETSTATSRESP)
            {
                VerH = USBInBuf[1];
                VerL = USBInBuf[2];
                // Feature=USBInBuf[3];  no longer bothering with this value
                Manufact = System.Text.ASCIIEncoding.ASCII.GetString(USBInBuf, 4, IndexOfByte(USBInBuf, 0, 4) - 4);
                return (Resp_Ack);
            }
            else
                return (Resp_ErrImproperResponse);				//improper response from node
        }


        // ##############################################################################
        // Error Int is returned with the two byte values from the MCP2515, the highest byte
        // is from the TXBnCRTL register and the lower byte is the TEC
        // Option variable, lower 4 bits, defines message priority (lowest 2 bits) and Txwait bit (0x04 bit)
        static public int SendCANMess(byte InterfaceNum, byte DeviceNum, CANMessage Msg, out int ErrorInt)
        {
            byte[] USBOutBuf = new byte[30];
            byte[] USBInBuf = new byte[100];
            int Result;
            ErrorInt = 0;

            
            if (Msg.DLC > 8) return (Resp_ErrImproperCallingParameter);
            if (Msg.MO > 2) return (Resp_ErrImproperCallingParameter);

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.SENDCANREQ;
            USBOutBuf[2] = (byte)(Msg.ID >> 24);
            USBOutBuf[3] = (byte)(Msg.ID >> 16);
            USBOutBuf[4] = (byte)(Msg.ID >> 8);
            USBOutBuf[5] = (byte)Msg.ID;
            if (Msg.EID) USBOutBuf[2] |= 0x80;     // set highest bit high for extended ID messages
            if (Msg.RTR) USBOutBuf[2] |= 0x40;     // set next highest bit high for RTR messages

            USBOutBuf[6] = (byte)(Msg.SendOption & 0x07);               // transmit wait and priority bits
            USBOutBuf[7] = (byte)((byte)(Msg.MO << 4) | Msg.DLC);         // Tx buffer to send and DLC

            for (int c = 0; c < Msg.DLC; c++)
                USBOutBuf[c + 8] = Msg.Data[c];

            Result = USBRawCommand(InterfaceNum, USBOutBuf, Msg.DLC + 8, ref USBInBuf);

            if (Result < 0) return (Result);                // return error

            if ((int)USBInBuf[0] != (int)LLCMD.SENDCANRESP) return (Resp_ErrImproperResponse); //improper response from node
            if (((int)USBInBuf[0] == (int)LLCMD.SENDCANRESP) && ((int)USBInBuf[1] == Resp_Ack))
                return (Resp_Ack); // success
            else
            {
                ErrorInt = (USBInBuf[2] << 8); // first error code
                ErrorInt |= USBInBuf[3];     // second error code
            }
            return (Resp_NAck);


        }

        // ##############################################################################
        // Set up the Receive message object
        // Interface Number 0-9 for for than one interface connected (CAN-4-USB only)
        // DeviceNum is which CAN controller within an interface if more than one but normally 0
        // ID is the CAN ID, right justified
        // CB1=Command Byte 1. 
        //     Upper 4 bits = Message object to use, 0 or 1 in this case
        //     bit 0x08 = 1 - Extended ID
        //     bit 0x06 = 11 - turn mask/filter off, receive all messages
        //              = 10 - Receive only 29 bit IDs that meet filter req.
        //              = 01 - Receive only 11 bit IDs that meet filter req.
        //              = 00 - Receive either 11 or 29 bit ID’s that meet filt.
        //     bit 0x01 = BUKT: rollover bit.  if this is message object 0 and this bit is 1, then incoming messages may 'rollover'
        //                                      to message object 2 if message object 1 is busy
        static public int RecCANMess(byte InterfaceNum, byte DeviceNum, long ID, byte CB1)
        {
            byte[] USBOutBuf = new byte[30];
            byte[] USBInBuf = new byte[100];
            int Result;

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.RECCANREQ;
            USBOutBuf[2] = (byte)(ID >> 24);
            USBOutBuf[3] = (byte)(ID >> 16);
            USBOutBuf[4] = (byte)(ID >> 8);
            USBOutBuf[5] = (byte)ID;
            USBOutBuf[6] = CB1;

            Result = USBRawCommand(InterfaceNum, USBOutBuf, 7, ref USBInBuf);

            if (Result < 0) return (Result); // return error
            if ((int)USBInBuf[0] != (int)LLCMD.RECCANRESP) return (Resp_ErrImproperResponse); //improper response from node

            return (Resp_Ack);
        }



        // ##############################################################################
        static public int GetCANMess(byte InterfaceNum, byte DeviceNum, ref CANMessage Msg)
        {
            byte[] USBOutBuf = new byte[30];
            byte[] USBInBuf = new byte[100];
            int Result;

          
                if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
                if (!ClassInit[InterfaceNum])
                {
                    Result = Init(InterfaceNum);
                    if (Result == Resp_ErrNoInterfacePresent) return (Result);
                }

                USBOutBuf[0] = DeviceNum;
                USBOutBuf[1] = (byte)LLCMD.GETCANMESREQ;

                Result = USBRawCommand(InterfaceNum, USBOutBuf, 2, ref USBInBuf);

                if (Result < 0) return (Result); // return error
                if ((int)USBInBuf[0] != (int)LLCMD.GETCANMESRESP) return (Resp_ErrImproperResponse); //improper response from node
                if ((int)USBInBuf[1] == 0) return (Resp_NAck);

                Msg.DLC = (byte)(USBInBuf[4] & 0x0F);
                Msg.MO = ((USBInBuf[1] & 0x10) > 0) ? (byte)1 : (byte)0;  // two message objects defined by 0x10 bit
                Msg.ID = ((long)(USBInBuf[6] & 0x3F)) << 24;        // lose the top two bits
                Msg.ID |= ((long)USBInBuf[7] << 16);
                Msg.ID |= ((long)USBInBuf[8] << 8);
                Msg.ID |= (long)USBInBuf[9];
                Msg.EID = ((USBInBuf[5] & 0x80) > 0) ? true : false;    // extended ID
                Msg.RTR = ((USBInBuf[5] & 0x40) > 0) ? true : false;    // RTR true
                Msg.BOF = ((USBInBuf[5] & 0x20) > 0) ? true : false;    // Buffer Overflow
                Msg.SendOption = 0;

                for (int c = 0; c < Msg.DLC; c++)
                    Msg.Data[c] = USBInBuf[c + 10];

                if (USBInBuf[3] == (Msg.DLC + 10))                      // timestamp
                {
                    Msg.TimeStamp = (long)USBInBuf[Msg.DLC + 10] * .524288;
                    Msg.TimeStamp += ((long)USBInBuf[Msg.DLC + 11] * .002048);
                    Msg.TimeStamp += ((long)USBInBuf[Msg.DLC + 12] * .000008);
                }
                else
                {
                    Msg.TimeStamp = 0;
                }
           
            return (Resp_Ack);
        }

        // ##############################################################################
        // Address will be 0-0xFF for the MCP2515 internal register numbers
        // NumBytes can be 1-62
        // Data is a byte array by reference that will be filled.  Must be at least NumBytes long
        static public int ReadReg(byte InterfaceNum, byte DeviceNum, byte Address, byte NumBytes, ref byte[] Data)
        {
            byte[] USBOutBuf = new byte[30];
            byte[] USBInBuf = new byte[100];
            int Result;

            if (Data.Length < NumBytes) return (Resp_ErrImproperCallingParameter);
            if (NumBytes > 62) return (Resp_ErrImproperCallingParameter);

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.READREGREQ;
            USBOutBuf[2] = Address;
            USBOutBuf[3] = NumBytes;

            Result = USBRawCommand(InterfaceNum, USBOutBuf, 4, ref USBInBuf);

            if (Result < 0) return (Result); // return error
            if ((int)USBInBuf[0] == (int)LLCMD.READREGRESP)
            {
                if ((int)USBInBuf[1] == Resp_Ack)
                {
                    for (int c = 0; c < NumBytes; c++)
                        Data[c] = USBInBuf[c + 2];
                    return ((int)NumBytes);
                }
                else
                    return (Resp_NAck);
            }
            else
                return (Resp_ErrImproperResponse); //improper response from node
        }

        // ##############################################################################
        // Address will be 0-0xFF for the MCP2515 internal register numbers
        // NumBytes can be 1-60
        // Data is a byte array containing the data to write
        static public int WriteReg(byte InterfaceNum, byte DeviceNum, byte Address, byte NumBytes, byte[] Data)
        {
            byte[] USBOutBuf = new byte[70];
            byte[] USBInBuf = new byte[100];
            int Result;

            if (Data.Length < NumBytes) return (Resp_ErrImproperCallingParameter);
            if (NumBytes > 60) return (Resp_ErrImproperCallingParameter);

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.WRITEREGREQ;
            USBOutBuf[2] = Address;
            USBOutBuf[3] = NumBytes;
            for (int c = 0; c < NumBytes; c++)
                USBOutBuf[c + 4] = Data[c];

            Result = USBRawCommand(InterfaceNum, USBOutBuf, NumBytes + 4, ref USBInBuf);

            if (Result < 0) return (Result); // return error
            if ((int)USBInBuf[0] == (int)LLCMD.WRITEREGRESP)
            {
                if ((int)USBInBuf[1] == Resp_Ack)
                    return (Resp_Ack);
                else
                    return (Resp_NAck);
            }
            else
                return (Resp_ErrImproperResponse); //improper response from node
        }

        // ##############################################################################
        // reset the MCP2515
        static public int ResetInterface(byte InterfaceNum, byte DeviceNum)
        {
            byte[] USBOutBuf = new byte[10];
            byte[] USBInBuf = new byte[10];
            int Result;

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.INITREQ;

            Result = USBRawCommand(InterfaceNum, USBOutBuf, 2, ref USBInBuf);

            if (Result < 0) return (Result); // return error
            if ((int)USBInBuf[0] == (int)LLCMD.INITRESP)
            {
                if ((int)USBInBuf[1] == Resp_Ack)
                    return (Resp_Ack);
                else
                    return (Resp_NAck);
            }
            else
                return (Resp_ErrImproperResponse);
        }

        // ##############################################################################
        // Enable the TimeStamp Feature
        static public int EnableTS(byte InterfaceNum, byte DeviceNum)
        {
            byte[] USBOutBuf = new byte[10];
            byte[] USBInBuf = new byte[10];
            int Result;

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.ENABLETSREQ;

            Result = USBRawCommand(InterfaceNum, USBOutBuf, 2, ref USBInBuf);

            if (Result < 0) return (Result); // return error
            if ((int)USBInBuf[0] == (int)LLCMD.ENABLETSRESP)
                return (Resp_Ack);
            else
                return (Resp_ErrImproperResponse);
        }

        // ##############################################################################
        // Disable the TimeStamp Feature
        static public int DisableTS(byte InterfaceNum, byte DeviceNum)
        {
            byte[] USBOutBuf = new byte[10];
            byte[] USBInBuf = new byte[10];
            int Result;

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.DISABLETSREQ;

            Result = USBRawCommand(InterfaceNum, USBOutBuf, 2, ref USBInBuf);

            if (Result < 0) return (Result); // return error
            if ((int)USBInBuf[0] == (int)LLCMD.DISABLETSRESP)
            {
                if ((int)USBInBuf[1] == Resp_Ack)
                    return (Resp_Ack);
                else
                    return (Resp_NAck);
            }
            else
                return (Resp_ErrImproperResponse);
        }

        // ##############################################################################
        // Set LED Pattern
        // you can override the LED pattern to display your own custom status or error messages
        // Mode
        static public int SetLEDPattern(byte InterfaceNum, byte DeviceNum, byte Mode, byte[] Pattern)
        {
            byte[] USBOutBuf = new byte[30];
            byte[] USBInBuf = new byte[10];
            int Result;

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (Pattern.Length < 20) return (Resp_ErrImproperCallingParameter);

            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.SETLEDPATREQ;
            USBOutBuf[2] = Mode;
            for (int i = 0; i < 20; i++)
                USBOutBuf[i + 3] = Pattern[i];

            Result = USBRawCommand(InterfaceNum, USBOutBuf, 23, ref USBInBuf);

            if (Result < 0) return (Result); // return error
            if ((int)USBInBuf[0] == (int)LLCMD.SETLEDPATRESP)
            {
                if ((int)USBInBuf[1] == Resp_Ack)
                    return (Resp_Ack);
                else
                    return (Resp_NAck);
            }
            else
                return (Resp_ErrImproperResponse);
        }

        // ##############################################################################
        // Get the number of CAN messages stored in the receive buffer without retrieving any actual message
        static public int GetNumCANMess(byte InterfaceNum, byte DeviceNum)
        {
            byte[] USBOutBuf = new byte[10];
            byte[] USBInBuf = new byte[10];
            int Result;

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.GETNUMMESREQ;

            Result = USBRawCommand(InterfaceNum, USBOutBuf, 2, ref USBInBuf);

            if (Result < 0) return (Result); // return error
            if ((int)USBInBuf[0] == (int)LLCMD.GETNUMMESRESP)
            {
                return (((int)USBInBuf[1] << 8) + (int)USBInBuf[2]);
            }
            else
                return (Resp_ErrImproperResponse);
        }

        // ##############################################################################
        // Clear any received messages currently in buffer without reading them
        static public int ClearCANMess(byte InterfaceNum, byte DeviceNum)
        {
            byte[] USBOutBuf = new byte[10];
            byte[] USBInBuf = new byte[10];
            int Result;

            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.CLEARMESREQ;

            Result = USBRawCommand(InterfaceNum, USBOutBuf, 2, ref USBInBuf);

            if (Result < 0) return (Result); // return error
            if ((int)USBInBuf[0] == (int)LLCMD.CLEARMESRESP)
                return (Resp_Ack);
            else
                return (Resp_ErrImproperResponse);
        }

        // ##############################################################################
        // FilterNum = 0-5
        // EID set for extended ID
        static public int SetFilters(byte InterfaceNum, byte DeviceNum, byte FilterNum, long FilterVal, bool EID)
        {
            byte[] USBOutBuf = new byte[30];
            byte[] USBInBuf = new byte[100];
            int Result;

            if (FilterNum > 5) return (Resp_ErrImproperCallingParameter);
            if (InterfaceNum > 9) return (Resp_ErrImproperCallingParameter);
            if (EID)
            {
                if (FilterVal > 0x1FFFFFFF) return (Resp_ErrImproperCallingParameter);
            }
            else
            {
                if (FilterVal > 0x7FF) return (Resp_ErrImproperCallingParameter);
            }

            if (!ClassInit[InterfaceNum])
            {
                Result = Init(InterfaceNum);
                if (Result == Resp_ErrNoInterfacePresent) return (Result);
            }

            USBOutBuf[0] = DeviceNum;
            USBOutBuf[1] = (byte)LLCMD.SETFILTERREQ;
            USBOutBuf[2] = (byte)(1 << FilterNum);            // 1,2,4,8,16
            USBOutBuf[3] = (byte)(FilterVal >> 24);
            USBOutBuf[4] = (byte)(FilterVal >> 16);
            USBOutBuf[5] = (byte)(FilterVal >> 8);
            USBOutBuf[6] = (byte)FilterVal;
            if (EID) USBOutBuf[3] |= 0x80;                  // use low level protocol of setting EID bit

            Result = USBRawCommand(InterfaceNum, USBOutBuf, 7, ref USBInBuf);

            if (Result < 0) return (Result); // return error
            if ((int)USBInBuf[0] == (int)LLCMD.SETFILTERRESP)
                return (Resp_Ack);
            else
                return (Resp_ErrImproperResponse);
        }

        // ##############################################################################
        static public string ReturnErrorMessage(int ErrorNum)
        {
            string RetString;

            switch (ErrorNum)
            {
                case Resp_ErrNoInterfacePresent:
                    RetString = "No Interface was found at that interface number";
                    break;

                case Resp_ErrImproperCallingParameter:
                    RetString = "An improper or out of range value was sent to this function";
                    break;

                case Resp_ErrImproperResponse:
                    RetString = "The Interface responded with an improper response to this command (should never happen!)";
                    break;

                default:
                    RetString = "Unknown error (" + ErrorNum.ToString() + ") was returned";
                    break;
            }

            return (RetString);
        }
        #endregion

        #region PrivateMethods
        // ##############################################################################
        static private int USBRawCommand(byte InterfaceNum, byte[] Out, int NumBytes, ref byte[] In)
        {
            bool bResult;
            int NumBytesIn = 100;

            if (outEndpoint[InterfaceNum] != null)
            {
                try
                {
                    bResult = outEndpoint[InterfaceNum].XferData(ref Out, ref NumBytes);
                    if (bResult)
                    {
                        //calls the XferData function for bulk transfer(OUT/IN) in the cyusb.dll
                        bResult = inEndpoint[InterfaceNum].XferData(ref In, ref NumBytesIn);
                    }
                }
                catch
                {
                    ClassInit[InterfaceNum] = false;
                    return (Resp_ErrNoInterfacePresent);
                }

            }
            else
                return (Resp_ErrNoInterfacePresent);

            return (NumBytesIn);
        }


        // ##############################################################################
        static private int Init(byte InterfaceNum)
        {
            int Result;
            // string s;
            // CyUSBDevice myDevice;

            try
            {
                usbDevices = new USBDeviceList(CyConst.DEVICES_CYUSB);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //myDevice = usbDevices[0x0BE7, 0x0006] as CyUSBDevice;
            //if (myDevice != null)
            //    s = myDevice.FriendlyName + " connected.";

            //Adding event handlers for device attachment and device removal
            //usbDevices.DeviceAttached += new EventHandler(usbDevices_DeviceAttached);  left here for reference
            //usbDevices.DeviceRemoved += new EventHandler(usbDevices_DeviceRemoved);

            //The below function sets the device with particular VID and PId and searches for the device with the same VID and PID.
            Result = setDevice(InterfaceNum);

            return (Result);
        }
        
        /// <summary>
        /// Event Handler for the USB Removed event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static private void usbDevices_DeviceRemoved(object sender, EventArgs e)
        {
            //  don't do anything when the interface is removed otherwise it re-arranges the
            // numbering of the interfaces still connected
            // left here for reference only
        }

        // ##############################################################################
        // This is the event handler for Device Attachment event.
        static private void usbDevices_DeviceAttached(object sender, EventArgs e)
        {
            //  don't do anything when the interface is added otherwise it re-arranges the
            // numbering of the interfaces still connected
            // left here for reference only
        }

        // ##############################################################################
        //    This will detect only the devices with the CAN-4-USB/FX VID,PID combinations
        static private int setDevice(byte InterfaceNum)
        {
            int ReturnVal;
            // MyDevice = usbDevices[0x0BE7, 0x0006] as CyUSBDevice;  // CAN-4-USB-FX

            if (InterfaceNum >= usbDevices.Count)
                ReturnVal = Resp_ErrNoInterfacePresent;
            else
            {
                MyDevice[InterfaceNum] = usbDevices[InterfaceNum] as CyUSBDevice;  // CAN-4-USB-FX

                if (MyDevice[InterfaceNum] != null)
                {
                    ClassInit[InterfaceNum] = true;
                    ReturnVal = Resp_Ack;
                    outEndpoint[InterfaceNum] = MyDevice[InterfaceNum].EndPointOf(0x01) as CyBulkEndPoint;
                    inEndpoint[InterfaceNum] = MyDevice[InterfaceNum].EndPointOf(0x81) as CyBulkEndPoint;
                    outEndpoint[InterfaceNum].TimeOut = 200;
                    inEndpoint[InterfaceNum].TimeOut = 200;
                }
                else
                {
                    ClassInit[InterfaceNum] = false;
                    ReturnVal = Resp_ErrNoInterfacePresent;
                }
            }

            return (ReturnVal);
        }
        // ##############################################################################
        static private int IndexOfByte(byte[] array, byte val, int offset)
        {
            int Location = -1;
            int i = offset;
            while ((i < array.Length) && (Location == -1))
                if (array[i++] == val) Location = i - 1;
            return (Location);
        }

    }
    #endregion

}