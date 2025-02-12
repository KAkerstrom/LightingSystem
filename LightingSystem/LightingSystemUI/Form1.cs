﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Conduit;

namespace LightingSystemUI
{
    public partial class Form1 : Form
    {
        #region init

        string[] bitmaps, layouts;
        int filecharcount;
        List<Node> allNodes = new List<Node>();
        List<LightIcon> icons = new List<LightIcon>();

        #endregion  

        #region Constructor
        public Form1()
        {

            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            InitializeComponent();
            LightIcon Licon = new LightIcon(IconToolbox, this);
            try
            {
                bitmaps = Directory.GetFiles(@"./Layouts/bitmaps/");
                layouts = Directory.GetFiles(@"./Layouts/serialized/");
            }
            catch
            {
                Directory.CreateDirectory(@"./Layouts/bitmaps");
                Directory.CreateDirectory(@"./Layouts/serialized");
                bitmaps = Directory.GetFiles(@"./Layouts/bitmaps/");
                layouts = Directory.GetFiles(@"./Layouts/serialized/");
            }

            for (int i = 0; i < bitmaps.Length; i++)
            {
                ToolStripItem tsbitmaps = (BTNLoadBitmap.DropDownItems.Add(bitmaps[i].Substring(18)));
                tsbitmaps.Click += Ts_Click;
                filecharcount = 0;
            }
            for (int i = 0; i < layouts.Length; i++)
            {
                foreach (char tmp in layouts[i])
                    filecharcount++;
                try
                {
                    ToolStripItem tslayouts = (btnLoadLayoutFromFile.DropDownItems.Add(layouts[i].Substring(21, filecharcount - 25)));
                    tslayouts.Click += Tslayouts_Click;
                    filecharcount = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (File.Exists("NodeDevices.bin"))
            {
                using (Stream stream = File.Open("NodeDevices.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    allNodes = (List<Node>)bin.Deserialize(stream);

                    foreach (Node node in allNodes)
                        foreach (Device device in node.Devices)
                        {
                            if (device is Light)
                            {
                                LightIcon icon = new LightIcon(IconToolbox, this);
                                icon.thisLight = (Light)device;
                                ((Light)device).OnDeserializingMethod();
                            }
                        }
                }
            }
            else
            {
                Poll.PongsReceived += Poll_PongsReceived;
                Poll.StatusUpdate += Poll_StatusUpdate;
                Poll.PollNetwork();
            }
        }
        #endregion

        #region PollEvents
        private void Poll_StatusUpdate(string status)
        {
            statusLbl.Text = status;
        }

        private void Poll_PongsReceived(List<Node> pongs, bool complete)
        {
            foreach (Node node in pongs)
            {
                Node foundNode = allNodes.FirstOrDefault(x => x.NodeId == node.NodeId && x.DeviceId == node.DeviceId);
                if (foundNode != null)
                    foundNode = node;
                else
                    allNodes.Add(node);
            }

            foreach (Node node in allNodes)
                foreach (Device device in node.Devices)
                    if (device is Light)
                    {
                        LightIcon icon = icons.FirstOrDefault(x => x.thisLight.NodeId == device.NodeId && x.thisLight.DeviceId == device.DeviceId);
                        if (icon != null)
                            icon.thisLight = (Light)device;
                        else
                        {
                            LightIcon newIcon = new LightIcon(IconToolbox, this);
                            newIcon.thisLight = (Light)device;
                            icons.Add(newIcon);
                        }
                    }

            if (complete)
            {
                try
                {
                    using (Stream stream = File.Open("NodeDevices.bin", FileMode.Create))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(stream, allNodes);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region Buttons\form events
        private void Tslayouts_Click(object sender, EventArgs e)
        {
            ToolStripItem ts = (ToolStripItem)sender;
            using (layoutEditorForm editorForm = new layoutEditorForm("./Layouts/serialized/" + ts.Text + ".bin"))
            {
                editorForm.ShowDialog();
            }
        }
        private void Ts_Click(object sender, EventArgs e)
        {
            ToolStripItem ts = (ToolStripItem)sender;
            Bitmap loaded = new Bitmap("./Layouts/bitmaps/" + ts.Text);
            bitmappanel.BackgroundImage = loaded;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Brush toolboxBrush = new SolidBrush(Color.FromArgb(220, 220, 220));
            e.Graphics.FillRectangle(toolboxBrush, IconToolbox.Location.X, IconToolbox.Location.Y, IconToolbox.Width, IconToolbox.Height);
        }

        private void btnOpenLayoutEditor_Click(object sender, EventArgs e)
        {
            layoutEditorForm editorForm = new layoutEditorForm();
            editorForm.Show();
        }
        #endregion  
    }
}
