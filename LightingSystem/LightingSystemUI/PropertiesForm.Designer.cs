namespace LightingSystemUI
{
    partial class PropertiesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackDimVal = new System.Windows.Forms.TrackBar();
            this.TestingGB = new System.Windows.Forms.GroupBox();
            this.Off = new System.Windows.Forms.Button();
            this.OnOff = new System.Windows.Forms.Button();
            this.btnFullOn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GB = new System.Windows.Forms.GroupBox();
            this.customizationGB = new System.Windows.Forms.GroupBox();
            this.statuslblDimStep = new System.Windows.Forms.Label();
            this.statuslblpresetOn = new System.Windows.Forms.Label();
            this.statuslblmaximum = new System.Windows.Forms.Label();
            this.statuslblminimum = new System.Windows.Forms.Label();
            this.statuslblsoftonoff = new System.Windows.Forms.Label();
            this.trackDimStep = new System.Windows.Forms.TrackBar();
            this.trackPresetOn = new System.Windows.Forms.TrackBar();
            this.trackMax = new System.Windows.Forms.TrackBar();
            this.trackMin = new System.Windows.Forms.TrackBar();
            this.trackSoft = new System.Windows.Forms.TrackBar();
            this.lbldimstep = new System.Windows.Forms.Label();
            this.lblpreseton = new System.Windows.Forms.Label();
            this.lblmaximum = new System.Windows.Forms.Label();
            this.lblminimum = new System.Windows.Forms.Label();
            this.lblsoftonoff = new System.Windows.Forms.Label();
            this.currentVal = new System.Windows.Forms.GroupBox();
            this.DimValTxt = new System.Windows.Forms.RichTextBox();
            this.ModeGB = new System.Windows.Forms.GroupBox();
            this.radDimming = new System.Windows.Forms.RadioButton();
            this.radNonDimmingInverted = new System.Windows.Forms.RadioButton();
            this.radDisabled = new System.Windows.Forms.RadioButton();
            this.radNonDimming = new System.Windows.Forms.RadioButton();
            this.radDimmingInverted = new System.Windows.Forms.RadioButton();
            this.btnSaveToDevice = new System.Windows.Forms.Button();
            this.btnSaveChangesToDeviceAndClsoe = new System.Windows.Forms.Button();
            this.CancelAndClosee = new System.Windows.Forms.Button();
            this.namelbl = new System.Windows.Forms.Label();
            this.nodelbl = new System.Windows.Forms.Label();
            this.devicelbl = new System.Windows.Forms.Label();
            this.statusTextBox = new System.Windows.Forms.RichTextBox();
            this.statuslbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackDimVal)).BeginInit();
            this.TestingGB.SuspendLayout();
            this.GB.SuspendLayout();
            this.customizationGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDimStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPresetOn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSoft)).BeginInit();
            this.currentVal.SuspendLayout();
            this.ModeGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackDimVal
            // 
            this.trackDimVal.Location = new System.Drawing.Point(162, 29);
            this.trackDimVal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackDimVal.Maximum = 100;
            this.trackDimVal.Name = "trackDimVal";
            this.trackDimVal.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackDimVal.Size = new System.Drawing.Size(45, 303);
            this.trackDimVal.TabIndex = 0;
            // 
            // TestingGB
            // 
            this.TestingGB.Controls.Add(this.Off);
            this.TestingGB.Controls.Add(this.OnOff);
            this.TestingGB.Controls.Add(this.btnFullOn);
            this.TestingGB.Controls.Add(this.label1);
            this.TestingGB.Controls.Add(this.trackDimVal);
            this.TestingGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestingGB.Location = new System.Drawing.Point(1045, 221);
            this.TestingGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TestingGB.Name = "TestingGB";
            this.TestingGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TestingGB.Size = new System.Drawing.Size(238, 345);
            this.TestingGB.TabIndex = 1;
            this.TestingGB.TabStop = false;
            this.TestingGB.Text = "Testing";
            // 
            // Off
            // 
            this.Off.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Off.Location = new System.Drawing.Point(12, 136);
            this.Off.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Off.Name = "Off";
            this.Off.Size = new System.Drawing.Size(142, 41);
            this.Off.TabIndex = 4;
            this.Off.Tag = "";
            this.Off.Text = "Off";
            this.Off.UseVisualStyleBackColor = true;
            this.Off.Click += new System.EventHandler(this.Off_Click);
            // 
            // OnOff
            // 
            this.OnOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OnOff.Location = new System.Drawing.Point(12, 84);
            this.OnOff.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OnOff.Name = "OnOff";
            this.OnOff.Size = new System.Drawing.Size(142, 42);
            this.OnOff.TabIndex = 3;
            this.OnOff.Tag = "";
            this.OnOff.Text = "On/Off";
            this.OnOff.UseVisualStyleBackColor = true;
            this.OnOff.Click += new System.EventHandler(this.OnOff_Click);
            // 
            // btnFullOn
            // 
            this.btnFullOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFullOn.Location = new System.Drawing.Point(12, 29);
            this.btnFullOn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFullOn.Name = "btnFullOn";
            this.btnFullOn.Size = new System.Drawing.Size(142, 46);
            this.btnFullOn.TabIndex = 2;
            this.btnFullOn.Tag = "";
            this.btnFullOn.Text = "Full On";
            this.btnFullOn.UseVisualStyleBackColor = true;
            this.btnFullOn.Click += new System.EventHandler(this.btnFullOn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 194);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 111);
            this.label1.TabIndex = 1;
            this.label1.Text = "You can use the buttons or move the slider to change the value";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GB
            // 
            this.GB.Controls.Add(this.customizationGB);
            this.GB.Controls.Add(this.currentVal);
            this.GB.Controls.Add(this.ModeGB);
            this.GB.Location = new System.Drawing.Point(12, 221);
            this.GB.Name = "GB";
            this.GB.Size = new System.Drawing.Size(1026, 345);
            this.GB.TabIndex = 2;
            this.GB.TabStop = false;
            // 
            // customizationGB
            // 
            this.customizationGB.Controls.Add(this.statuslblDimStep);
            this.customizationGB.Controls.Add(this.statuslblpresetOn);
            this.customizationGB.Controls.Add(this.statuslblmaximum);
            this.customizationGB.Controls.Add(this.statuslblminimum);
            this.customizationGB.Controls.Add(this.statuslblsoftonoff);
            this.customizationGB.Controls.Add(this.trackDimStep);
            this.customizationGB.Controls.Add(this.trackPresetOn);
            this.customizationGB.Controls.Add(this.trackMax);
            this.customizationGB.Controls.Add(this.trackMin);
            this.customizationGB.Controls.Add(this.trackSoft);
            this.customizationGB.Controls.Add(this.lbldimstep);
            this.customizationGB.Controls.Add(this.lblpreseton);
            this.customizationGB.Controls.Add(this.lblmaximum);
            this.customizationGB.Controls.Add(this.lblminimum);
            this.customizationGB.Controls.Add(this.lblsoftonoff);
            this.customizationGB.Location = new System.Drawing.Point(493, 25);
            this.customizationGB.Name = "customizationGB";
            this.customizationGB.Size = new System.Drawing.Size(527, 307);
            this.customizationGB.TabIndex = 8;
            this.customizationGB.TabStop = false;
            this.customizationGB.Text = "Customization";
            // 
            // statuslblDimStep
            // 
            this.statuslblDimStep.AutoSize = true;
            this.statuslblDimStep.Location = new System.Drawing.Point(372, 250);
            this.statuslblDimStep.Name = "statuslblDimStep";
            this.statuslblDimStep.Size = new System.Drawing.Size(51, 20);
            this.statuslblDimStep.TabIndex = 22;
            this.statuslblDimStep.Text = "label6";
            // 
            // statuslblpresetOn
            // 
            this.statuslblpresetOn.AutoSize = true;
            this.statuslblpresetOn.Location = new System.Drawing.Point(372, 200);
            this.statuslblpresetOn.Name = "statuslblpresetOn";
            this.statuslblpresetOn.Size = new System.Drawing.Size(51, 20);
            this.statuslblpresetOn.TabIndex = 21;
            this.statuslblpresetOn.Text = "label5";
            // 
            // statuslblmaximum
            // 
            this.statuslblmaximum.AutoSize = true;
            this.statuslblmaximum.Location = new System.Drawing.Point(372, 150);
            this.statuslblmaximum.Name = "statuslblmaximum";
            this.statuslblmaximum.Size = new System.Drawing.Size(51, 20);
            this.statuslblmaximum.TabIndex = 20;
            this.statuslblmaximum.Text = "label4";
            // 
            // statuslblminimum
            // 
            this.statuslblminimum.AutoSize = true;
            this.statuslblminimum.Location = new System.Drawing.Point(372, 100);
            this.statuslblminimum.Name = "statuslblminimum";
            this.statuslblminimum.Size = new System.Drawing.Size(51, 20);
            this.statuslblminimum.TabIndex = 19;
            this.statuslblminimum.Text = "label3";
            // 
            // statuslblsoftonoff
            // 
            this.statuslblsoftonoff.AutoSize = true;
            this.statuslblsoftonoff.Location = new System.Drawing.Point(372, 50);
            this.statuslblsoftonoff.Name = "statuslblsoftonoff";
            this.statuslblsoftonoff.Size = new System.Drawing.Size(51, 20);
            this.statuslblsoftonoff.TabIndex = 18;
            this.statuslblsoftonoff.Text = "label2";
            // 
            // trackDimStep
            // 
            this.trackDimStep.Location = new System.Drawing.Point(102, 250);
            this.trackDimStep.Name = "trackDimStep";
            this.trackDimStep.Size = new System.Drawing.Size(243, 45);
            this.trackDimStep.TabIndex = 17;
            this.trackDimStep.Scroll += new System.EventHandler(this.trackDimStep_Scroll);
            // 
            // trackPresetOn
            // 
            this.trackPresetOn.Location = new System.Drawing.Point(102, 199);
            this.trackPresetOn.Maximum = 100;
            this.trackPresetOn.Name = "trackPresetOn";
            this.trackPresetOn.Size = new System.Drawing.Size(243, 45);
            this.trackPresetOn.TabIndex = 16;
            this.trackPresetOn.Scroll += new System.EventHandler(this.trackPresetOn_Scroll);
            // 
            // trackMax
            // 
            this.trackMax.Location = new System.Drawing.Point(102, 148);
            this.trackMax.Maximum = 100;
            this.trackMax.Name = "trackMax";
            this.trackMax.Size = new System.Drawing.Size(243, 45);
            this.trackMax.TabIndex = 15;
            this.trackMax.Scroll += new System.EventHandler(this.trackMax_Scroll);
            // 
            // trackMin
            // 
            this.trackMin.Location = new System.Drawing.Point(102, 97);
            this.trackMin.Maximum = 100;
            this.trackMin.Name = "trackMin";
            this.trackMin.Size = new System.Drawing.Size(243, 45);
            this.trackMin.TabIndex = 14;
            this.trackMin.Scroll += new System.EventHandler(this.trackMin_Scroll);
            // 
            // trackSoft
            // 
            this.trackSoft.Location = new System.Drawing.Point(102, 46);
            this.trackSoft.Maximum = 250;
            this.trackSoft.Name = "trackSoft";
            this.trackSoft.Size = new System.Drawing.Size(243, 45);
            this.trackSoft.TabIndex = 13;
            this.trackSoft.Scroll += new System.EventHandler(this.trackSoft_Scroll);
            // 
            // lbldimstep
            // 
            this.lbldimstep.AutoSize = true;
            this.lbldimstep.Location = new System.Drawing.Point(6, 250);
            this.lbldimstep.Name = "lbldimstep";
            this.lbldimstep.Size = new System.Drawing.Size(75, 20);
            this.lbldimstep.TabIndex = 12;
            this.lbldimstep.Text = "Dim Step";
            // 
            // lblpreseton
            // 
            this.lblpreseton.AutoSize = true;
            this.lblpreseton.Location = new System.Drawing.Point(6, 200);
            this.lblpreseton.Name = "lblpreseton";
            this.lblpreseton.Size = new System.Drawing.Size(80, 20);
            this.lblpreseton.TabIndex = 11;
            this.lblpreseton.Text = "Preset On";
            // 
            // lblmaximum
            // 
            this.lblmaximum.AutoSize = true;
            this.lblmaximum.Location = new System.Drawing.Point(6, 150);
            this.lblmaximum.Name = "lblmaximum";
            this.lblmaximum.Size = new System.Drawing.Size(76, 20);
            this.lblmaximum.TabIndex = 10;
            this.lblmaximum.Text = "Maximum";
            // 
            // lblminimum
            // 
            this.lblminimum.AutoSize = true;
            this.lblminimum.Location = new System.Drawing.Point(6, 100);
            this.lblminimum.Name = "lblminimum";
            this.lblminimum.Size = new System.Drawing.Size(72, 20);
            this.lblminimum.TabIndex = 9;
            this.lblminimum.Text = "Minimum";
            // 
            // lblsoftonoff
            // 
            this.lblsoftonoff.AutoSize = true;
            this.lblsoftonoff.Location = new System.Drawing.Point(6, 50);
            this.lblsoftonoff.Name = "lblsoftonoff";
            this.lblsoftonoff.Size = new System.Drawing.Size(90, 20);
            this.lblsoftonoff.TabIndex = 0;
            this.lblsoftonoff.Text = "Soft On/Off";
            // 
            // currentVal
            // 
            this.currentVal.Controls.Add(this.DimValTxt);
            this.currentVal.Location = new System.Drawing.Point(263, 25);
            this.currentVal.Name = "currentVal";
            this.currentVal.Size = new System.Drawing.Size(200, 110);
            this.currentVal.TabIndex = 7;
            this.currentVal.TabStop = false;
            this.currentVal.Text = "Current Value";
            // 
            // DimValTxt
            // 
            this.DimValTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DimValTxt.Location = new System.Drawing.Point(0, 24);
            this.DimValTxt.Name = "DimValTxt";
            this.DimValTxt.Size = new System.Drawing.Size(200, 86);
            this.DimValTxt.TabIndex = 0;
            this.DimValTxt.Text = "100%";
            // 
            // ModeGB
            // 
            this.ModeGB.Controls.Add(this.radDimming);
            this.ModeGB.Controls.Add(this.radNonDimmingInverted);
            this.ModeGB.Controls.Add(this.radDisabled);
            this.ModeGB.Controls.Add(this.radNonDimming);
            this.ModeGB.Controls.Add(this.radDimmingInverted);
            this.ModeGB.Location = new System.Drawing.Point(15, 25);
            this.ModeGB.Name = "ModeGB";
            this.ModeGB.Size = new System.Drawing.Size(208, 183);
            this.ModeGB.TabIndex = 6;
            this.ModeGB.TabStop = false;
            this.ModeGB.Text = "Mode";
            // 
            // radDimming
            // 
            this.radDimming.AutoSize = true;
            this.radDimming.Location = new System.Drawing.Point(6, 56);
            this.radDimming.Name = "radDimming";
            this.radDimming.Size = new System.Drawing.Size(89, 24);
            this.radDimming.TabIndex = 2;
            this.radDimming.TabStop = true;
            this.radDimming.Text = "Dimming";
            this.radDimming.UseVisualStyleBackColor = true;
            this.radDimming.CheckedChanged += new System.EventHandler(this.radDimming_CheckedChanged);
            // 
            // radNonDimmingInverted
            // 
            this.radNonDimmingInverted.AutoSize = true;
            this.radNonDimmingInverted.Location = new System.Drawing.Point(6, 148);
            this.radNonDimmingInverted.Name = "radNonDimmingInverted";
            this.radNonDimmingInverted.Size = new System.Drawing.Size(194, 24);
            this.radNonDimmingInverted.TabIndex = 5;
            this.radNonDimmingInverted.TabStop = true;
            this.radNonDimmingInverted.Text = "Non Dimming (Inverted)";
            this.radNonDimmingInverted.UseVisualStyleBackColor = true;
            this.radNonDimmingInverted.CheckedChanged += new System.EventHandler(this.radNonDimmingInverted_CheckedChanged);
            // 
            // radDisabled
            // 
            this.radDisabled.AutoSize = true;
            this.radDisabled.Location = new System.Drawing.Point(6, 26);
            this.radDisabled.Name = "radDisabled";
            this.radDisabled.Size = new System.Drawing.Size(89, 24);
            this.radDisabled.TabIndex = 1;
            this.radDisabled.TabStop = true;
            this.radDisabled.Text = "Disabled";
            this.radDisabled.UseVisualStyleBackColor = true;
            this.radDisabled.CheckedChanged += new System.EventHandler(this.radDisabled_CheckedChanged);
            // 
            // radNonDimming
            // 
            this.radNonDimming.AutoSize = true;
            this.radNonDimming.Location = new System.Drawing.Point(6, 116);
            this.radNonDimming.Name = "radNonDimming";
            this.radNonDimming.Size = new System.Drawing.Size(122, 24);
            this.radNonDimming.TabIndex = 4;
            this.radNonDimming.TabStop = true;
            this.radNonDimming.Text = "Non Dimming";
            this.radNonDimming.UseVisualStyleBackColor = true;
            this.radNonDimming.CheckedChanged += new System.EventHandler(this.radNonDimming_CheckedChanged);
            // 
            // radDimmingInverted
            // 
            this.radDimmingInverted.AutoSize = true;
            this.radDimmingInverted.Location = new System.Drawing.Point(6, 86);
            this.radDimmingInverted.Name = "radDimmingInverted";
            this.radDimmingInverted.Size = new System.Drawing.Size(161, 24);
            this.radDimmingInverted.TabIndex = 3;
            this.radDimmingInverted.TabStop = true;
            this.radDimmingInverted.Text = "Dimming (Inverted)";
            this.radDimmingInverted.UseVisualStyleBackColor = true;
            this.radDimmingInverted.CheckedChanged += new System.EventHandler(this.radDimmingInverted_CheckedChanged);
            // 
            // btnSaveToDevice
            // 
            this.btnSaveToDevice.Location = new System.Drawing.Point(788, 12);
            this.btnSaveToDevice.Name = "btnSaveToDevice";
            this.btnSaveToDevice.Size = new System.Drawing.Size(495, 42);
            this.btnSaveToDevice.TabIndex = 3;
            this.btnSaveToDevice.Text = "Save Changes To Device";
            this.btnSaveToDevice.UseVisualStyleBackColor = true;
            this.btnSaveToDevice.Click += new System.EventHandler(this.btnSaveToDevice_Click);
            // 
            // btnSaveChangesToDeviceAndClsoe
            // 
            this.btnSaveChangesToDeviceAndClsoe.Location = new System.Drawing.Point(788, 93);
            this.btnSaveChangesToDeviceAndClsoe.Name = "btnSaveChangesToDeviceAndClsoe";
            this.btnSaveChangesToDeviceAndClsoe.Size = new System.Drawing.Size(495, 42);
            this.btnSaveChangesToDeviceAndClsoe.TabIndex = 4;
            this.btnSaveChangesToDeviceAndClsoe.Text = "Save Changes To Device And Close";
            this.btnSaveChangesToDeviceAndClsoe.UseVisualStyleBackColor = true;
            this.btnSaveChangesToDeviceAndClsoe.Click += new System.EventHandler(this.btnSaveChangesToDeviceAndClsoe_Click);
            // 
            // CancelAndClosee
            // 
            this.CancelAndClosee.Location = new System.Drawing.Point(789, 171);
            this.CancelAndClosee.Name = "CancelAndClosee";
            this.CancelAndClosee.Size = new System.Drawing.Size(495, 42);
            this.CancelAndClosee.TabIndex = 5;
            this.CancelAndClosee.Text = "Cancel And Close";
            this.CancelAndClosee.UseVisualStyleBackColor = true;
            this.CancelAndClosee.Click += new System.EventHandler(this.CancelAndClosee_Click);
            // 
            // namelbl
            // 
            this.namelbl.AutoSize = true;
            this.namelbl.Location = new System.Drawing.Point(23, 23);
            this.namelbl.Name = "namelbl";
            this.namelbl.Size = new System.Drawing.Size(163, 20);
            this.namelbl.TabIndex = 6;
            this.namelbl.Text = "Name: ..........................";
            // 
            // nodelbl
            // 
            this.nodelbl.AutoSize = true;
            this.nodelbl.Location = new System.Drawing.Point(23, 77);
            this.nodelbl.Name = "nodelbl";
            this.nodelbl.Size = new System.Drawing.Size(67, 20);
            this.nodelbl.TabIndex = 7;
            this.nodelbl.Text = "Node: ...";
            // 
            // devicelbl
            // 
            this.devicelbl.AutoSize = true;
            this.devicelbl.Location = new System.Drawing.Point(23, 129);
            this.devicelbl.Name = "devicelbl";
            this.devicelbl.Size = new System.Drawing.Size(77, 20);
            this.devicelbl.TabIndex = 8;
            this.devicelbl.Text = "Device: ...";
            // 
            // statusTextBox
            // 
            this.statusTextBox.Location = new System.Drawing.Point(250, 171);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(482, 42);
            this.statusTextBox.TabIndex = 9;
            this.statusTextBox.Text = "";
            // 
            // statuslbl
            // 
            this.statuslbl.AutoSize = true;
            this.statuslbl.Location = new System.Drawing.Point(23, 182);
            this.statuslbl.Name = "statuslbl";
            this.statuslbl.Size = new System.Drawing.Size(64, 20);
            this.statuslbl.TabIndex = 10;
            this.statuslbl.Text = "Status: ";
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 580);
            this.Controls.Add(this.statuslbl);
            this.Controls.Add(this.statusTextBox);
            this.Controls.Add(this.devicelbl);
            this.Controls.Add(this.nodelbl);
            this.Controls.Add(this.namelbl);
            this.Controls.Add(this.CancelAndClosee);
            this.Controls.Add(this.btnSaveChangesToDeviceAndClsoe);
            this.Controls.Add(this.btnSaveToDevice);
            this.Controls.Add(this.GB);
            this.Controls.Add(this.TestingGB);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PropertiesForm";
            this.Text = "PropertiesForm";
            this.Load += new System.EventHandler(this.PropertiesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackDimVal)).EndInit();
            this.TestingGB.ResumeLayout(false);
            this.TestingGB.PerformLayout();
            this.GB.ResumeLayout(false);
            this.customizationGB.ResumeLayout(false);
            this.customizationGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackDimStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackPresetOn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackSoft)).EndInit();
            this.currentVal.ResumeLayout(false);
            this.ModeGB.ResumeLayout(false);
            this.ModeGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackDimVal;
        private System.Windows.Forms.GroupBox TestingGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Off;
        private System.Windows.Forms.Button OnOff;
        private System.Windows.Forms.Button btnFullOn;
        private System.Windows.Forms.GroupBox GB;
        private System.Windows.Forms.GroupBox currentVal;
        private System.Windows.Forms.RichTextBox DimValTxt;
        private System.Windows.Forms.GroupBox ModeGB;
        private System.Windows.Forms.RadioButton radDimming;
        private System.Windows.Forms.RadioButton radNonDimmingInverted;
        private System.Windows.Forms.RadioButton radDisabled;
        private System.Windows.Forms.RadioButton radNonDimming;
        private System.Windows.Forms.RadioButton radDimmingInverted;
        private System.Windows.Forms.GroupBox customizationGB;
        private System.Windows.Forms.Label lbldimstep;
        private System.Windows.Forms.Label lblpreseton;
        private System.Windows.Forms.Label lblmaximum;
        private System.Windows.Forms.Label lblminimum;
        private System.Windows.Forms.Label lblsoftonoff;
        private System.Windows.Forms.Label statuslblDimStep;
        private System.Windows.Forms.Label statuslblpresetOn;
        private System.Windows.Forms.Label statuslblmaximum;
        private System.Windows.Forms.Label statuslblminimum;
        private System.Windows.Forms.Label statuslblsoftonoff;
        private System.Windows.Forms.TrackBar trackDimStep;
        private System.Windows.Forms.TrackBar trackPresetOn;
        private System.Windows.Forms.TrackBar trackMax;
        private System.Windows.Forms.TrackBar trackMin;
        private System.Windows.Forms.TrackBar trackSoft;
        private System.Windows.Forms.Button btnSaveToDevice;
        private System.Windows.Forms.Button btnSaveChangesToDeviceAndClsoe;
        private System.Windows.Forms.Button CancelAndClosee;
        private System.Windows.Forms.Label namelbl;
        private System.Windows.Forms.Label nodelbl;
        private System.Windows.Forms.Label devicelbl;
        private System.Windows.Forms.RichTextBox statusTextBox;
        private System.Windows.Forms.Label statuslbl;
    }
}