using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Conduit;

namespace LightingSystemUI
{
    public partial class PropertiesForm : Form
    {
        public PropertiesForm()
        {
            InitializeComponent();
        }

        private void PropertiesForm_Load(object sender, EventArgs e)
        {
            namelbl.Text = "Name: ";
            nodelbl.Text = "Node: ";
            devicelbl.Text = "Device: ";
            DimValTxt.Text = "";
            statusTextBox.Text = "";
            DimValTxt.Text = "" + "%";
            trackSoft.Value = 0;
            trackMin.Value = 0;
            trackMax.Value = 0;
            trackPresetOn.Value = 0;
            trackDimStep.Value = 0;
            int i = 0;
            switch (i)
            {
                case 0:
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
            statuslbl.Text = "";
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
