using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LightTest
{
    public partial class CANControls : Form
    {
        #region definitions
        
        public static int CANStatus = 10;                // set so that it will fire the first time fairly soon (1000)
        public static CANSTAT CANInterfaceStatus = 0;

        public enum CANSTAT : int { UNKNOWN = 0, OK, NOINT, ERROR, SENDERR };
        //  status not yet known so check,connected and no errors,no interface present,
        // connected but unknown connection error,connected but sending error

        const C4UFX.CANBaud CANBAUD = C4UFX.CANBaud.Kbps500;
        const long CANRECMESS0 = 0x00000000; // '&H9FFFFF00 ' ID for receive message 1  ' at this point, accept from any node SS
        const long CANRECMESS1 = 0x00000000; // ' ID for receive message 2  ' same for this one
        const long CANRECFILTER0 = 0x00000000; // ' &H98EFFE00 ' filter 0  ' Mess 0 accept FE messages from anyone (for now)
        const long CANRECFILTER1 = 0x00000000; // ' filter 1  ' same
        const long CANRECFILTER2 = 0x00000000; // ' filter 2  ' Mess 1 accept FF messages (name announce) always
        const long CANRECFILTER3 = 0x00000000; // ' filter 3
        const long CANRECFILTER4 = 0x00000000; // ' filter 4
        const long CANRECFILTER5 = 0x00000000; // ' filter 5
  
        const byte NB = 1;                     // Incoming data NumBytes are in buffer location 1
        const byte CB2 = 2;                    // control byte 2
        const byte IDB0 = 3;                   // incoming data packets have the ID starting at location 3
        const byte IDB1 = 4;
        const byte IDB2 = 5;
        const byte IDB3 = 6;
        const byte DB0 = 7;                    // incoming data packets have the data byte start at location 7 in buffer
        const byte DB1 = 8;
        const byte DB2 = 9;
        const byte DB3 = 10;
        const byte DB4 = 11;
        const byte DB5 = 12;
        const byte DB6 = 13;
        const byte DB7 = 14;

        public delegate void IncomingMessageHandler(C4UFX.CANMessage message);
        public event IncomingMessageHandler inCANMessage;

        #endregion

        private static Queue<C4UFX.CANMessage> CANSendQueue = new Queue<C4UFX.CANMessage>();

        // The CAN ID is broken down into 4 - 7 bit groups
        // with From Node being the most significant and working down from there
        // This uses up 28 bits of the 29 bit ID.  MSb is always zero
        public struct FndTnd        // From Node/Device To Node/Device
        {
            public byte Fn;     // From Node
            public byte Fd;     // From Device
            public byte Tn;     // To Node
            public byte Td;     // To Device
        };

        public static FndTnd ConvIDND(long ID)
        {
            FndTnd nd = new FndTnd();
            // 01111111000000000000000000000    7 bits for From Node
            nd.Fn = (byte)((ID >> 21) & 0x7F);
            // 00000000111111100000000000000    7 bits for From Device
            nd.Fd = (byte)((ID >> 14) & 0x7F);
            // 00000000000000011111110000000    7 bits for To Node
            nd.Tn = (byte)((ID >> 7) & 0x7F);
            // 00000000000000000000001111111    7 bits for To Device
            nd.Td = (byte)(ID & 0x7F);
            return nd;
        }

        // convert from From Node/From Device/To Node/To Device to CAN ID
        public static long ConvNDID(FndTnd nd)
        {
            long id;
            id =  (long)nd.Fn << 21;
            id += (long)nd.Fd << 14;
            id += (long)nd.Tn << 7;
            id += (long)nd.Td;
          
            return id;
        }
        // ####################################################################
        public static void SendCANMessage(C4UFX.CANMessage mess)
        {
            CANSendQueue.Enqueue(mess);
        }

        // ########################################################################################
        public CANControls()
        {
            InitializeComponent();
        }

        // ########################################################################################
        private void timer1_Tick(object sender, EventArgs e)
        {
            CANService();
        }
        // ################################################################################################
        private void SetCANErrorTimerState(bool State)
        {
            CANErrorTimer.Enabled = State;
        }

        // ########################################################################################
        private void CANControls_Load(object sender, EventArgs e)
        {
            bool Result;

            Result = CANInit();
            //if (Result == false) MessageBox.Show("CAN Init Error");

            timer1.Enabled = true;

            CANDataGrid.RowHeadersVisible = false;
        }

        // ########################################################################################
        private void CANCheckStatus(bool ForceErr)
        {
            int Result;

            if ((CANInterfaceStatus != CANSTAT.OK) | (ForceErr == true))
            {
                C4UFX.CANMessage CANMess = new C4UFX.CANMessage();
                int Error;

                CANMess.ID = 0;
                CANMess.DLC = 0;
                for (int c = 0; c < 8; c++) CANMess.Data[c] = 0;
                CANMess.EID = true;
                CANMess.RTR = false;
                CANMess.MO = 0;
                CANMess.SendOption = 7;

                Result = C4UFX.SendCANMess(0, 0, CANMess, out Error);

                if (Result != C4UFX.Resp_Ack)
                {
                    switch (Result)
                    {
                        case C4UFX.Resp_NAck:                   // message was transmitted but there was an error, so reset
                            CANInit();
                            SetCANInterfaceError(CANSTAT.SENDERR);
                            break;
                        case C4UFX.Resp_ErrImproperResponse:
                            SetCANInterfaceError(CANSTAT.NOINT);
                            break;
                        default:
                            SetCANInterfaceError(CANSTAT.ERROR);
                            break;
                    }
                }
                else
                {
                    SetCANInterfaceError(CANSTAT.OK);
                }
            }
            else                           // we're connected and working so display status register
            {
                byte[] DataBuf = new byte[10];

                Result = C4UFX.ReadReg(0, 0, 0x2D, 1, ref DataBuf);       // EFLG
                if (Result == C4UFX.Resp_Ack)
                {
                    if (DataBuf[0] == 0)
                        SetInterfaceStatusLabelVisible(0, true);
                    else
                        SetInterfaceStatusLabelVisible(0, false);

                    if ((DataBuf[0] & 0x80) > 0)
                    {
                        SetInterfaceStatusLabelVisible(7, true);
                        SetCANErrorTimerState(true);
                    }
                    else
                        SetInterfaceStatusLabelVisible(7, false);

                    if ((DataBuf[0] & 0x40) > 0)
                    {
                        SetInterfaceStatusLabelVisible(6, true);
                        SetCANErrorTimerState(true);
                    }
                    else
                        SetInterfaceStatusLabelVisible(6, false);

                    if ((DataBuf[0] & 0x20) > 0)
                         SetInterfaceStatusLabelVisible(5, true);
                    else
                         SetInterfaceStatusLabelVisible(5, false);

                    if ((DataBuf[0] & 0x10) > 0)
                         SetInterfaceStatusLabelVisible(4, true);
                    else
                         SetInterfaceStatusLabelVisible(4, false);

                    if ((DataBuf[0] & 0x08) > 0)
                         SetInterfaceStatusLabelVisible(3, true);
                    else
                         SetInterfaceStatusLabelVisible(3, false);

                    if ((DataBuf[0] & 0x04) > 0)
                         SetInterfaceStatusLabelVisible(2, true);
                    else
                         SetInterfaceStatusLabelVisible(2, false);

                    if ((DataBuf[0] & 0x02) > 0)
                         SetInterfaceStatusLabelVisible(1, true);
                    else
                         SetInterfaceStatusLabelVisible(1, false);

                }
                else
                {
                }

            }
        }



        // ########################################################################################
        // There are interface errors like interface not present and then there
        // are status errors within the interface.  This handles the first
        private void SetCANInterfaceError(CANSTAT State)
        {
            CANInterfaceStatus = State;

            switch (State)
            {
                case CANSTAT.OK:
                     SetInterfaceConnectionLabelVisible(0, true);
                     SetInterfaceConnectionLabelVisible(1, false);
                     SetInterfaceConnectionLabelVisible(2, false);
                     SetInterfaceConnectionLabelVisible(3, false);
                    break;
                case CANSTAT.NOINT:
                     SetInterfaceConnectionLabelVisible(0, false);
                     SetInterfaceConnectionLabelVisible(1, true);
                     SetInterfaceConnectionLabelVisible(2, false);
                     SetInterfaceConnectionLabelVisible(3, false);
                    break;
                case CANSTAT.ERROR:
                     SetInterfaceConnectionLabelVisible(0, false);
                     SetInterfaceConnectionLabelVisible(1, false);
                     SetInterfaceConnectionLabelVisible(2, true);
                     SetInterfaceConnectionLabelVisible(3, false);
                    break;
                case CANSTAT.SENDERR:
                     SetInterfaceConnectionLabelVisible(0, false);
                     SetInterfaceConnectionLabelVisible(1, false);
                     SetInterfaceConnectionLabelVisible(2, false);
                     SetInterfaceConnectionLabelVisible(3, true);
                    break;
            }
        }

        // ########################################################################################
        // called from CANForm CANErrorTimer to reset error register
        private void ResetErrorReg()
        {
            int Result;
            byte[] Buf = new Byte[4];
            Buf[0] = 0;
            Result = C4UFX.WriteReg(0, 0, 0x2D, 1, Buf);
        }

        // ########################################################################################
        private bool CANInit()
        {
            int Result;
            Result = C4UFX.EnableTS(0, 0);
            Result = C4UFX.ResetInterface(0, 0);          // clear out any misc messages
            if (Result != C4UFX.Resp_Ack) { CANCheckStatus(true); return (false); }

            Result = C4UFX.ClearCANMess(0, 0);            // clear out any misc messages
            if (Result != 1) { CANCheckStatus(true); return (false); }

            Result = C4UFX.SetCANBaud(0, 0, CANBAUD);
            if (Result != 1) { CANCheckStatus(true); return (false); }
            Result = C4UFX.ClearCANMess(0, 0);
            if (Result != 1) {  CANCheckStatus(true); return (false); }
            Result = C4UFX.RecCANMess(0, 0, CANRECMESS0, 0x0C + 1); //'//MO0 + enable rollover bit
            if (Result != 1) {  CANCheckStatus(true); return (false); }
            Result = C4UFX.RecCANMess(0, 0, CANRECMESS1, 0x1C);
            if (Result != 1) {  CANCheckStatus(true); return (false); }
            Result = C4UFX.SetFilters(0, 0, 0, CANRECFILTER0, true);
            if (Result != 1) {  CANCheckStatus(true); return (false); }
            Result = C4UFX.SetFilters(0, 0, 1, CANRECFILTER1, true);
            if (Result != 1) {  CANCheckStatus(true); return (false); }
            Result = C4UFX.SetFilters(0, 0, 2, CANRECFILTER2, true);
            if (Result != 1) {  CANCheckStatus(true); return (false); }
            Result = C4UFX.SetFilters(0, 0, 3, CANRECFILTER3, true);
            if (Result != 1) {  CANCheckStatus(true); return (false); }
            Result = C4UFX.SetFilters(0, 0, 4, CANRECFILTER4, true);
            if (Result != 1) {  CANCheckStatus(true); return (false); }
            Result = C4UFX.SetFilters(0, 0, 5, CANRECFILTER5, true);
            if (Result != 1) {  CANCheckStatus(true); return (false); }

            return (true);
        }
        // ####################################################################
        // called from the timer service on the CANForm every 10ms
        private void CANService()
        {
            CheckForIncomingCANMessages();

            if (--CANStatus <= 0)
            {
                CANCheckStatus(false);
                CANStatus = 100;        // every second
            }
            if (CANSendQueue.Count>0)   // send any messages in the queue
            {
                int error=0;
                C4UFX.CANMessage mess = CANSendQueue.Dequeue();
                C4UFX.SendCANMess(0, 0, mess, out error);
                DisplayCANData(mess);
            }
        }

 
        // ####################################################################
        private void CheckForIncomingCANMessages()
        {
            int Result = C4UFX.Resp_Ack;
            C4UFX.CANMessage CANMess = new C4UFX.CANMessage();

            while (Result == C4UFX.Resp_Ack)
            {
                Result = C4UFX.GetCANMess(0, 0, ref CANMess);

                if (Result == C4UFX.Resp_Ack)
                {
                        DisplayCANData(CANMess);
                    if (inCANMessage != null)
                        inCANMessage(CANMess);   // call our delegate
                }
                MIBText.Text = C4UFX.GetNumCANMess(0, 0).ToString();
            }
        }

        
        public void SendPCodeRequest(byte Addr)
        {
            //int Result;
            //C4UFX.CANMessage CANMess = new C4UFX.CANMessage();
            //int Error = 0;

            //CANMess.MO = 0;
            //CANMess.SendOption = 7;
            //CANMess.ID = (long)Addr;
            //CANMess.ID *= 0x100;
            //CANMess.ID |= 0x18EF0000;
            //CANMess.ID |= MySrcAddr;

            //CANMess.Data[0] = PCodeResp;
            //CANMess.DLC = 1;
            //CANMess.EID = true;
            //CANMess.RTR = false;

            //Result = C4UFX.SendCANMess(0, 0, CANMess, out Error);
            // DisplayCANData(CANMess);
        }

        private void CANErrorTimer_Tick(object sender, EventArgs e)
        {
           ResetErrorReg();
           CANErrorTimer.Enabled = false;
        }
        // ####################################################################
        private void SetInterfaceConnectionLabelVisible(int whichone, bool Visible)
        {
            Color tmpC;
            if (Visible) tmpC = Color.Lime; else tmpC = Color.DimGray;
            switch (whichone)
            {
                case 0:
                    InterfaceErrlabel0.ForeColor = tmpC;
                    break;
                case 1:
                    InterfaceErrlabel1.ForeColor = tmpC;
                    break;
                case 2:
                    InterfaceErrlabel2.ForeColor = tmpC;
                    break;
                case 3:
                    InterfaceErrlabel3.ForeColor = tmpC;
                    break;
            }
        }
        // ####################################################################
        private void SetInterfaceStatusLabelVisible(int whichone, bool Visible)
        {
            Color tmpC;
            if (Visible) tmpC = Color.Lime; else tmpC = Color.DimGray;
            switch (whichone)
            {
                case 0:
                    ErrLabel0.ForeColor = tmpC;
                    break;
                case 1:
                    ErrLabel1.ForeColor = tmpC;
                    break;
                case 2:
                    ErrLabel2.ForeColor = tmpC;
                    break;
                case 3:
                    ErrLabel3.ForeColor = tmpC;
                    break;
                case 4:
                    ErrLabel4.ForeColor = tmpC;
                    break;
                case 5:
                    ErrLabel5.ForeColor = tmpC;
                    break;
                case 6:
                    ErrLabel6.ForeColor = tmpC;
                    break;
                case 7:
                    ErrLabel7.ForeColor = tmpC;
                    break;
                case 8:
                    ErrLabel8.ForeColor = tmpC;
                    break;
            }
        }

        // ####################################################################
        private void DisplayCANData(C4UFX.CANMessage Msg)
        {
            int R;
            string Tmp = null;
           // string ASC = null;

            for (int i = 0; i < Msg.DLC; i++)
            {
                Tmp += Msg.Data[i].ToString("X2") + " ";
            //    if ((Msg.Data[i] > 31) && (Msg.Data[i] < 127))
            //        ASC += (char)Msg.Data[i];
            //    else
            //        ASC += " ";
            }

                if (CANDataGrid.RowCount > 25)
                    CANDataGrid.Rows.RemoveAt(0);

                R = CANDataGrid.Rows.Add();
                CANDataGrid.Rows[R].Cells[0].Value = Msg.TimeStamp;
                CANDataGrid.Rows[R].Cells[1].Value = Msg.ID.ToString("X8");
                CANDataGrid.Rows[R].Cells[2].Value = Msg.DLC;
                CANDataGrid.Rows[R].Cells[3].Value = Tmp;
                //CANDataGrid.Rows[R].Cells[4].Value = ASC;

                CANDataGrid.FirstDisplayedScrollingRowIndex = R;

        }

      

    }
}
