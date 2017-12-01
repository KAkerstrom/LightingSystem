using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CANControls CANForm = new CANControls();
            CANForm.Show();
            CANForm.inCANMessage += new CANControls.IncomingMessageHandler(IncomingCANMessages);
        }

        public void IncomingCANMessages(C4UFX.CANMessage mess)
        {
            CANControls.FndTnd nd;
            string data="";

            nd = CANControls.ConvIDND(mess.ID);  // convert 29 bit ID to seperates


            for (int i = 0; i < mess.DLC; i++)
                data += mess.Data[i].ToString("x")+" ";

            listBox1.Items.Add(nd.Fn.ToString() + "," +
                nd.Fd.ToString() + "," +
                nd.Tn.ToString() + "," +
                nd.Td.ToString()+":"+data);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // this test assumes the light switch is node 1 and will program switch 3
            // (middle left button)
            C4UFX.CANMessage mess= new C4UFX.CANMessage();
            CANControls.FndTnd nd = new CANControls.FndTnd();

            nd.Fn = 0x7F;   // highest possible 7 bit value as this node. Doesn't really matter from who
            nd.Fd = 0;      // device
            nd.Tn = 1;      // To Node 1
            nd.Td = 0;      // To Device 0 (node itself)

            mess.ID = CANControls.ConvNDID(nd);
            mess.Data[0] = 0x1A;   // unlock code from protocol overview doc
            mess.Data[1] = 0x01;   // unlock code from protocol overview doc
            mess.Data[2] = 0xFE;   // unlock code from protocol overview doc
            mess.Data[3] = 0x00;   // unlock code from protocol overview doc

            mess.DLC = 4;           // send 4 bytes
            CANControls.SendCANMessage(mess);  // unlocks node for programming
            
            

            // ######## set new address for switch itself
            nd.Fn = 0x7F;   // highest possible 7 bit value as this node. Doesn't really matter from who
            nd.Fd = 0;      // device
            nd.Tn = 1;      // To Node 1
            nd.Td = 3;      // To Device 3 (switch 3)

            mess.ID = CANControls.ConvNDID(nd);
            mess.Data[0] = 0x21;   // CmdSysPPar command - see "Smart switch protocol details.doc"
            mess.Data[1] = 0x01;   // mode = enabled
            mess.Data[2] = 0x05;   // double click time = 5*50ms
            mess.Data[3] = 0x06;   // hold time = 6*50ms

            mess.DLC = 4;           // send 4 bytes
            //CANControls.SendCANMessage(mess);  // unlocks node for programming

            //// ######## we can reuse the same address for next commands
            //mess.Data[0] = 0x22;   // CmdSysPPar2 command - see "Smart switch protocol details.doc"
            //mess.Data[1] = 0x01;   // sub command 1
            //mess.Data[2] = 0x01;   // first click event goes to node 1
            //mess.Data[3] = 0x01;   // first click event goes to device 1
            //mess.Data[4] = 0x01;   // send one additional command byte
            //mess.Data[5] = 0x30;   // command 30 is on/off toggle (from "device description for dimming output")
            //mess.DLC = 6;           // send 6 bytes
            //CANControls.SendCANMessage(mess);  // unlocks node for programming

            //// ######## now repeat for sub commands 2-7
            //mess.Data[0] = 0x22;   // CmdSysPPar2 command - see "Smart switch protocol details.doc"
            //mess.Data[1] = 0x02;   // sub command 2
            //mess.Data[2] = 0x01;   // second click event goes to node 1
            //mess.Data[3] = 0x01;   // second click event goes to device 1
            //mess.Data[4] = 0x01;   // send one additional command byte
            //mess.Data[5] = 0x30;   // command 30 is on/off toggle (from "device description for dimming output")
            //mess.DLC = 6;           // send 6 bytes
            //CANControls.SendCANMessage(mess);  // unlocks node for programming

            //// ######## sub 3
            //mess.Data[0] = 0x22;   // CmdSysPPar2 command - see "Smart switch protocol details.doc"
            //mess.Data[1] = 0x03;   // sub command 3
            //mess.Data[2] = 0x01;   // double click event goes to node 1
            //mess.Data[3] = 0x01;   // double click event goes to device 1
            //mess.Data[4] = 0x01;   // send one additional command byte
            //mess.Data[5] = 0x31;   // command 31 is full on (from "device description for dimming output")
            //mess.DLC = 6;           // send 6 bytes
            //CANControls.SendCANMessage(mess);  // unlocks node for programming

            //// ######## sub 4
            //mess.Data[0] = 0x22;   // CmdSysPPar2 command - see "Smart switch protocol details.doc"
            //mess.Data[1] = 0x04;   // sub command 4
            //mess.Data[2] = 0x01;   // 1st hold event goes to node 1
            //mess.Data[3] = 0x01;   // 1st hold click event goes to device 1
            //mess.Data[4] = 0x01;   // send one additional command byte
            //mess.Data[5] = 0x32;   // command 32 is fade continous (from "device description for dimming output")
            //mess.DLC = 6;           // send 6 bytes
            //CANControls.SendCANMessage(mess);  // unlocks node for programming

            //// ######## sub 5
            //mess.Data[0] = 0x22;   // CmdSysPPar2 command - see "Smart switch protocol details.doc"
            //mess.Data[1] = 0x05;   // sub command 5
            //mess.Data[2] = 0x01;   // 2nd hold event goes to node 1
            //mess.Data[3] = 0x01;   // 2nd hold click event goes to device 1
            //mess.Data[4] = 0x01;   // send one additional command byte
            //mess.Data[5] = 0x32;   // command 32 is fade continous (from "device description for dimming output")
            //mess.DLC = 6;           // send 6 bytes
            //CANControls.SendCANMessage(mess);  // unlocks node for programming

            //// ######## sub 6
            //mess.Data[0] = 0x22;   // CmdSysPPar2 command - see "Smart switch protocol details.doc"
            //mess.Data[1] = 0x06;   // sub command 6 - 
            //mess.Data[2] = 0x01;   // release event goes to node 1
            //mess.Data[3] = 0x01;   // release click event goes to device 1
            //mess.Data[4] = 0x01;   // send one additional command byte
            //mess.Data[5] = 0x33;   // command 33 is release (from "device description for dimming output")
            //mess.DLC = 6;           // send 6 bytes
            //CANControls.SendCANMessage(mess);  // unlocks node for programming

            //// ######## sub 7
            //mess.Data[0] = 0x22;   // CmdSysPPar2 command - see "Smart switch protocol details.doc"
            //mess.Data[1] = 0x07;   // sub command 7 - 
            //mess.Data[2] = 0xFF;   // 1st press event is not used and set to 255
            //mess.Data[3] = 0xFF;   // 1st press event is not used and set to 255
            //mess.Data[4] = 0x01;   // send one additional command byte
            //mess.Data[5] = 0x00;   // no command (from "device description for dimming output")
            //mess.DLC = 6;           // send 6 bytes
            //CANControls.SendCANMessage(mess);  // unlocks node for programming

        }

        private void button3_Click(object sender, EventArgs e)
        {
            C4UFX.CANMessage mess = new C4UFX.CANMessage();
            CANControls.FndTnd nd = new CANControls.FndTnd();

            nd.Fn = 0x7F;   // highest possible 7 bit value as this node. Doesn't really matter from who
            nd.Fd = 1;      // also doesn't really matter from which device
            nd.Tn = 2;      // To Node 2
            nd.Td = 1;      // To Device 1 (1st output)

            mess.ID = CANControls.ConvNDID(nd);
            mess.Data[0] = 0x30;   // toggle on/off
            mess.DLC = 1;           // send one byte
            CANControls.SendCANMessage(mess);
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
