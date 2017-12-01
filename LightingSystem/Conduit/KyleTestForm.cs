using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace LightTest.Kyle
{
    public partial class KyleTestForm : Form
    {
        List<Node> allNodes;

        public KyleTestForm()
        {
            InitializeComponent();
            Poll.StatusUpdate += Poll_StatusUpdate;
            CANInterface.MessageReceived += CANInterface_MessageReceived;
        }

        private void CANInterface_MessageReceived(C4UFX.CANMessage message)
        {

        }

        private void newPollBtn_Click(object sender, EventArgs e)
        {
            newPollBtn.Visible = false;
            Poll.PollNetwork();
            Poll.PongsReceived += Poll_PollReceived;
        }

        private void Poll_StatusUpdate(string status)
        {
            testLbl.Text = status;
        }

        private void Poll_PollReceived(List<Node> responses)
        {
            allNodes = responses;

            foreach (Node node in responses)
            {
                textBox1.Text += $"{node.NodeId.ToString().PadRight(3)} {node.DeviceId.ToString().PadRight(3)} {node.Name} ({node.GetType().ToString()}) \r\n";
                foreach (Device device in node.Devices)
                {
                    if (device is Light)
                        AddButton(device.Name, (Light)device);
                    textBox1.Text += $"   {device.NodeId.ToString().PadRight(3)} {device.DeviceId.ToString().PadRight(3)} {device.Name} ({device.GetType().ToString()}) \r\n";
                }
            }
        }

        private void AddButton(string Name, Light device)
        {
            Button newBtn = new Button();
            newBtn.Width = lightButtonsFlp.Width - 5;
            newBtn.Text = Name;
            newBtn.Tag = device;
            newBtn.Click += NewBtn_Click;
            lightButtonsFlp.Controls.Add(newBtn);
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            Light light = (Light)(((Button)sender).Tag);
            if (light.Brightness < 50)
                light.Brightness = 100;
            else
                light.Brightness = 0;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (allNodes == null)
                return;

            using (Stream stream = File.Open("testSave.bin", FileMode.Create))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, allNodes);
            }
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            using (Stream stream = File.Open("testSave.bin", FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                allNodes = (List<Node>)bin.Deserialize(stream);
            }

            foreach (Node node in allNodes)
            {
                textBox1.Text += $"{node.NodeId.ToString().PadRight(3)} {node.DeviceId.ToString().PadRight(3)} {node.Name} ({node.GetType().ToString()}) \r\n";
                foreach (Device device in node.Devices)
                {
                    if (device is Light)
                    {
                        AddButton(device.Name, (Light)device);
                        ((Light)device).OnDeserializingMethod();
                    }

                    textBox1.Text += $"   {device.NodeId.ToString().PadRight(3)} {device.DeviceId.ToString().PadRight(3)} {device.Name} ({device.GetType().ToString()}) \r\n";
                }
            }
        }
    }
}
