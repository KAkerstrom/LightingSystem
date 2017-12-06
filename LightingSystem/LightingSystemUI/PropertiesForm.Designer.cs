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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.TestingGB = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFullOn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.GB = new System.Windows.Forms.GroupBox();
            this.customizationGB = new System.Windows.Forms.GroupBox();
            this.statuslblDimStep = new System.Windows.Forms.Label();
            this.statuslblpresetOn = new System.Windows.Forms.Label();
            this.statuslblmaximum = new System.Windows.Forms.Label();
            this.statuslblminimum = new System.Windows.Forms.Label();
            this.statuslblsoftonoff = new System.Windows.Forms.Label();
            this.trackBar6 = new System.Windows.Forms.TrackBar();
            this.trackBar5 = new System.Windows.Forms.TrackBar();
            this.trackBar4 = new System.Windows.Forms.TrackBar();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.lbldimstep = new System.Windows.Forms.Label();
            this.lblpreseton = new System.Windows.Forms.Label();
            this.lblmaximum = new System.Windows.Forms.Label();
            this.lblminimum = new System.Windows.Forms.Label();
            this.lblsoftonoff = new System.Windows.Forms.Label();
            this.currentVal = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.TestingGB.SuspendLayout();
            this.GB.SuspendLayout();
            this.customizationGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.currentVal.SuspendLayout();
            this.ModeGB.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(162, 29);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 303);
            this.trackBar1.TabIndex = 0;
            // 
            // TestingGB
            // 
            this.TestingGB.Controls.Add(this.button2);
            this.TestingGB.Controls.Add(this.button1);
            this.TestingGB.Controls.Add(this.btnFullOn);
            this.TestingGB.Controls.Add(this.label1);
            this.TestingGB.Controls.Add(this.trackBar1);
            this.TestingGB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestingGB.Location = new System.Drawing.Point(1045, 221);
            this.TestingGB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TestingGB.Name = "TestingGB";
            this.TestingGB.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TestingGB.Size = new System.Drawing.Size(238, 345);
            this.TestingGB.TabIndex = 1;
            this.TestingGB.TabStop = false;
            this.TestingGB.Text = "Testing";
            this.TestingGB.Enter += new System.EventHandler(this.TestingGB_Enter);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(12, 136);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 41);
            this.button2.TabIndex = 4;
            this.button2.Tag = "";
            this.button2.Text = "Full On";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 84);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 42);
            this.button1.TabIndex = 3;
            this.button1.Tag = "";
            this.button1.Text = "Full On";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.customizationGB.Controls.Add(this.trackBar6);
            this.customizationGB.Controls.Add(this.trackBar5);
            this.customizationGB.Controls.Add(this.trackBar4);
            this.customizationGB.Controls.Add(this.trackBar3);
            this.customizationGB.Controls.Add(this.trackBar2);
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
            // trackBar6
            // 
            this.trackBar6.Location = new System.Drawing.Point(102, 250);
            this.trackBar6.Name = "trackBar6";
            this.trackBar6.Size = new System.Drawing.Size(243, 45);
            this.trackBar6.TabIndex = 17;
            // 
            // trackBar5
            // 
            this.trackBar5.Location = new System.Drawing.Point(102, 199);
            this.trackBar5.Maximum = 100;
            this.trackBar5.Name = "trackBar5";
            this.trackBar5.Size = new System.Drawing.Size(243, 45);
            this.trackBar5.TabIndex = 16;
            // 
            // trackBar4
            // 
            this.trackBar4.Location = new System.Drawing.Point(102, 148);
            this.trackBar4.Maximum = 100;
            this.trackBar4.Name = "trackBar4";
            this.trackBar4.Size = new System.Drawing.Size(243, 45);
            this.trackBar4.TabIndex = 15;
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(102, 97);
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(243, 45);
            this.trackBar3.TabIndex = 14;
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(102, 46);
            this.trackBar2.Maximum = 2;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(243, 45);
            this.trackBar2.TabIndex = 13;
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
            this.currentVal.Controls.Add(this.richTextBox1);
            this.currentVal.Location = new System.Drawing.Point(263, 25);
            this.currentVal.Name = "currentVal";
            this.currentVal.Size = new System.Drawing.Size(200, 110);
            this.currentVal.TabIndex = 7;
            this.currentVal.TabStop = false;
            this.currentVal.Text = "Current Value";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(0, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(200, 86);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "100%";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
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
            // 
            // btnSaveToDevice
            // 
            this.btnSaveToDevice.Location = new System.Drawing.Point(788, 12);
            this.btnSaveToDevice.Name = "btnSaveToDevice";
            this.btnSaveToDevice.Size = new System.Drawing.Size(495, 42);
            this.btnSaveToDevice.TabIndex = 3;
            this.btnSaveToDevice.Text = "Save Changes To Device";
            this.btnSaveToDevice.UseVisualStyleBackColor = true;
            // 
            // btnSaveChangesToDeviceAndClsoe
            // 
            this.btnSaveChangesToDeviceAndClsoe.Location = new System.Drawing.Point(788, 93);
            this.btnSaveChangesToDeviceAndClsoe.Name = "btnSaveChangesToDeviceAndClsoe";
            this.btnSaveChangesToDeviceAndClsoe.Size = new System.Drawing.Size(495, 42);
            this.btnSaveChangesToDeviceAndClsoe.TabIndex = 4;
            this.btnSaveChangesToDeviceAndClsoe.Text = "Save Changes To Device And Close";
            this.btnSaveChangesToDeviceAndClsoe.UseVisualStyleBackColor = true;
            // 
            // CancelAndClosee
            // 
            this.CancelAndClosee.Location = new System.Drawing.Point(789, 171);
            this.CancelAndClosee.Name = "CancelAndClosee";
            this.CancelAndClosee.Size = new System.Drawing.Size(495, 42);
            this.CancelAndClosee.TabIndex = 5;
            this.CancelAndClosee.Text = "Cancel And Close";
            this.CancelAndClosee.UseVisualStyleBackColor = true;
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
            this.statusTextBox.ReadOnly = true;
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PropertiesForm";
            this.Text = "PropertiesForm";
            this.Load += new System.EventHandler(this.PropertiesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.TestingGB.ResumeLayout(false);
            this.TestingGB.PerformLayout();
            this.GB.ResumeLayout(false);
            this.customizationGB.ResumeLayout(false);
            this.customizationGB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.currentVal.ResumeLayout(false);
            this.ModeGB.ResumeLayout(false);
            this.ModeGB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.GroupBox TestingGB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnFullOn;
        private System.Windows.Forms.GroupBox GB;
        private System.Windows.Forms.GroupBox currentVal;
        private System.Windows.Forms.RichTextBox richTextBox1;
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
        private System.Windows.Forms.TrackBar trackBar6;
        private System.Windows.Forms.TrackBar trackBar5;
        private System.Windows.Forms.TrackBar trackBar4;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.TrackBar trackBar2;
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