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
        #region Event Hadlers
        private void PropertiesForm_Load(object sender, EventArgs e)
        {
            light.BrightnessChanged += Light_BrightnessChanged; ;
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
                case DimmerMode.Disabled:
                    radDisabled.Checked = true;
                    break;
                case DimmerMode.Dimming:
                    radDimming.Checked = true;
                    break;
                case DimmerMode.DimmingInverted:
                    radDimmingInverted.Checked = true;
                    break;
                case DimmerMode.NonDimming:
                    radNonDimming.Checked = true;
                    break;
                case DimmerMode.NonDimmingInverted:
                    radNonDimmingInverted.Checked = true;
                    break;
            }
            statuslblsoftonoff.Text = light.SoftOnOff.ToString();
            statuslblminimum.Text = light.MinimumBrightness.ToString();
            statuslblmaximum.Text = light.MaximumBrightness.ToString();
            statuslblpresetOn.Text = light.PresetOn.ToString();
            statuslblDimStep.Text = light.DimStep.ToString();


        }

        private void Light_BrightnessChanged(byte brightness)
        {
            DimValTxt.Text = light.Brightness + "%";
        }

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
            light.SoftOnOff = (byte)trackSoft.Value;
            statuslblsoftonoff.Text = light.SoftOnOff.ToString();
        }

        private void trackMin_Scroll(object sender, EventArgs e)
        {
            light.MinimumBrightness = (byte)trackMin.Value;
            statuslblminimum.Text = light.MinimumBrightness.ToString();
        }

        private void trackMax_Scroll(object sender, EventArgs e)
        {
            light.MaximumBrightness = (byte)trackMax.Value;
            statuslblmaximum.Text = light.MaximumBrightness.ToString();
        }

        private void trackPresetOn_Scroll(object sender, EventArgs e)
        {
            light.PresetOn = (byte)trackPresetOn.Value;
            statuslblpresetOn.Text = light.PresetOn.ToString();
        }

        private void trackDimStep_Scroll(object sender, EventArgs e)
        {
            light.DimStep = (byte)trackDimStep.Value;
            statuslblDimStep.Text = light.DimStep.ToString();
        }

        private void OnOff_Click(object sender, EventArgs e)
        {
            light.ToggleOnOff();
        }

        private void btnFullOn_Click(object sender, EventArgs e)
        {
            light.FullOn();
        }

        private void Off_Click(object sender, EventArgs e)
        {
            light.SetOnOff(false);
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

        private void trackDimVal_Scroll(object sender, EventArgs e)
        {
            light.Brightness = (byte)trackDimVal.Value;
        }
        #endregion

    }
}
