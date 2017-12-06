using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conduit;
using Conduit.Devices;
using Conduit.Enums;

namespace LightingSystemUI
{
    public partial class PropertiesForm : Form
    {
        private DimmerOut light;
        public PropertiesForm(DimmerOut light)
        {
            InitializeComponent();
            this.light = light;
        }

        private void PropertiesForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = "Name: " + light.Name;
            nodelbl.Text = "Node: " + light.NodeId;
            devicelbl.Text = "Device: " + light.DeviceId;
            DimValTxt.Text = "";
            statusTextBox.Text = "Done";
            DimValTxt.Text = light.Brightness + "%";
            trackSoft.Value = light.SoftOnOff;
            trackMin.Value = light.MinimumBrightness;
            trackMax.Value = light.MaximumBrightness;
            trackPresetOn.Value = light.PresetOn;
            trackDimStep.Value = light.DimStep;
            trackDimVal.Value = light.Brightness;
            int i = 0;
            switch (light.Mode)
            {
                case 0x00:
                    radDisabled.Checked = true;
                    break;
                case 1:
                    radDimming.Checked = true;
                    break;
                case 2:
                    radDimmingInverted.Checked = true;
                    break;
                case 3:
                    radNonDimming.Checked = true;
                    break;
                case 4:
                    radNonDimmingInverted.Checked = true;
                    break;
            }
            statuslblsoftonoff.Text = "";
            statuslblminimum.Text = "";
            statuslblmaximum.Text = "";
            statuslblpresetOn.Text = "";
            statuslblDimStep.Text = "";


        }
        #region EventHandlers
        private void CancelAndClosee_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveChangesToDeviceAndClsoe_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveToDevice_Click(object sender, EventArgs e)
        {

        }

        private void trackSoft_Scroll(object sender, EventArgs e)
        {

        }

        private void trackMin_Scroll(object sender, EventArgs e)
        {

        }

        private void trackMax_Scroll(object sender, EventArgs e)
        {

        }

        private void trackPresetOn_Scroll(object sender, EventArgs e)
        {

        }

        private void trackDimStep_Scroll(object sender, EventArgs e)
        {

        }

        private void OnOff_Click(object sender, EventArgs e)
        {

        }

        private void btnFullOn_Click(object sender, EventArgs e)
        {

        }

        private void Off_Click(object sender, EventArgs e)
        {

        }
        private void radDisabled_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radDimming_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radDimmingInverted_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radNonDimming_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radNonDimmingInverted_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
