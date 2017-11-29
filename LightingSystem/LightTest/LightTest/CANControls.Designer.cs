namespace LightTest
{
    partial class CANControls
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CANDataGrid = new System.Windows.Forms.DataGridView();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DLC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CANData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.InterfaceErrlabel0 = new System.Windows.Forms.Label();
            this.MIBText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ErrLabel8 = new System.Windows.Forms.Label();
            this.ErrLabel7 = new System.Windows.Forms.Label();
            this.ErrLabel6 = new System.Windows.Forms.Label();
            this.ErrLabel5 = new System.Windows.Forms.Label();
            this.ErrLabel4 = new System.Windows.Forms.Label();
            this.ErrLabel3 = new System.Windows.Forms.Label();
            this.ErrLabel2 = new System.Windows.Forms.Label();
            this.ErrLabel1 = new System.Windows.Forms.Label();
            this.ErrLabel0 = new System.Windows.Forms.Label();
            this.InterfaceErrlabel3 = new System.Windows.Forms.Label();
            this.InterfaceErrlabel2 = new System.Windows.Forms.Label();
            this.InterfaceErrlabel1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CANErrorTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CANDataGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.CANDataGrid);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 286);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // CANDataGrid
            // 
            this.CANDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CANDataGrid.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CANDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.CANDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CANDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeStamp,
            this.CANID,
            this.DLC,
            this.CANData});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.CANDataGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.CANDataGrid.EnableHeadersVisualStyles = false;
            this.CANDataGrid.GridColor = System.Drawing.Color.White;
            this.CANDataGrid.Location = new System.Drawing.Point(21, 133);
            this.CANDataGrid.Name = "CANDataGrid";
            this.CANDataGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CANDataGrid.Size = new System.Drawing.Size(673, 147);
            this.CANDataGrid.TabIndex = 23;
            // 
            // TimeStamp
            // 
            this.TimeStamp.HeaderText = "Time Stamp";
            this.TimeStamp.Name = "TimeStamp";
            this.TimeStamp.Width = 120;
            // 
            // CANID
            // 
            this.CANID.HeaderText = "CAN ID";
            this.CANID.Name = "CANID";
            this.CANID.Width = 150;
            // 
            // DLC
            // 
            this.DLC.HeaderText = "DLC";
            this.DLC.Name = "DLC";
            this.DLC.Width = 45;
            // 
            // CANData
            // 
            this.CANData.HeaderText = "Data";
            this.CANData.Name = "CANData";
            this.CANData.Width = 360;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Black;
            this.groupBox2.Controls.Add(this.InterfaceErrlabel0);
            this.groupBox2.Controls.Add(this.MIBText);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ErrLabel8);
            this.groupBox2.Controls.Add(this.ErrLabel7);
            this.groupBox2.Controls.Add(this.ErrLabel6);
            this.groupBox2.Controls.Add(this.ErrLabel5);
            this.groupBox2.Controls.Add(this.ErrLabel4);
            this.groupBox2.Controls.Add(this.ErrLabel3);
            this.groupBox2.Controls.Add(this.ErrLabel2);
            this.groupBox2.Controls.Add(this.ErrLabel1);
            this.groupBox2.Controls.Add(this.ErrLabel0);
            this.groupBox2.Controls.Add(this.InterfaceErrlabel3);
            this.groupBox2.Controls.Add(this.InterfaceErrlabel2);
            this.groupBox2.Controls.Add(this.InterfaceErrlabel1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(21, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(673, 108);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CAN Interface";
            // 
            // InterfaceErrlabel0
            // 
            this.InterfaceErrlabel0.BackColor = System.Drawing.Color.Black;
            this.InterfaceErrlabel0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterfaceErrlabel0.ForeColor = System.Drawing.Color.DimGray;
            this.InterfaceErrlabel0.Location = new System.Drawing.Point(185, 25);
            this.InterfaceErrlabel0.Name = "InterfaceErrlabel0";
            this.InterfaceErrlabel0.Size = new System.Drawing.Size(35, 16);
            this.InterfaceErrlabel0.TabIndex = 20;
            this.InterfaceErrlabel0.Text = "OK";
            this.InterfaceErrlabel0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MIBText
            // 
            this.MIBText.BackColor = System.Drawing.Color.Black;
            this.MIBText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MIBText.ForeColor = System.Drawing.Color.DimGray;
            this.MIBText.Location = new System.Drawing.Point(185, 72);
            this.MIBText.Name = "MIBText";
            this.MIBText.Size = new System.Drawing.Size(35, 26);
            this.MIBText.TabIndex = 33;
            this.MIBText.Text = "0";
            this.MIBText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "Interface Connection:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ErrLabel8
            // 
            this.ErrLabel8.BackColor = System.Drawing.Color.Black;
            this.ErrLabel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrLabel8.ForeColor = System.Drawing.Color.DimGray;
            this.ErrLabel8.Location = new System.Drawing.Point(538, 76);
            this.ErrLabel8.Name = "ErrLabel8";
            this.ErrLabel8.Size = new System.Drawing.Size(121, 16);
            this.ErrLabel8.TabIndex = 32;
            this.ErrLabel8.Text = "Buffer = 1500";
            this.ErrLabel8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrLabel7
            // 
            this.ErrLabel7.BackColor = System.Drawing.Color.Black;
            this.ErrLabel7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrLabel7.ForeColor = System.Drawing.Color.DimGray;
            this.ErrLabel7.Location = new System.Drawing.Point(411, 76);
            this.ErrLabel7.Name = "ErrLabel7";
            this.ErrLabel7.Size = new System.Drawing.Size(121, 16);
            this.ErrLabel7.TabIndex = 31;
            this.ErrLabel7.Text = "Bus Off";
            this.ErrLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ErrLabel6
            // 
            this.ErrLabel6.AutoSize = true;
            this.ErrLabel6.BackColor = System.Drawing.Color.Black;
            this.ErrLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrLabel6.ForeColor = System.Drawing.Color.DimGray;
            this.ErrLabel6.Location = new System.Drawing.Point(320, 76);
            this.ErrLabel6.Name = "ErrLabel6";
            this.ErrLabel6.Size = new System.Drawing.Size(83, 20);
            this.ErrLabel6.TabIndex = 30;
            this.ErrLabel6.Text = "Tx Passive";
            // 
            // ErrLabel5
            // 
            this.ErrLabel5.AutoSize = true;
            this.ErrLabel5.BackColor = System.Drawing.Color.Black;
            this.ErrLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrLabel5.ForeColor = System.Drawing.Color.DimGray;
            this.ErrLabel5.Location = new System.Drawing.Point(226, 76);
            this.ErrLabel5.Name = "ErrLabel5";
            this.ErrLabel5.Size = new System.Drawing.Size(86, 20);
            this.ErrLabel5.TabIndex = 29;
            this.ErrLabel5.Text = "Rx Passive";
            // 
            // ErrLabel4
            // 
            this.ErrLabel4.AutoSize = true;
            this.ErrLabel4.BackColor = System.Drawing.Color.Black;
            this.ErrLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrLabel4.ForeColor = System.Drawing.Color.DimGray;
            this.ErrLabel4.Location = new System.Drawing.Point(538, 50);
            this.ErrLabel4.Name = "ErrLabel4";
            this.ErrLabel4.Size = new System.Drawing.Size(129, 20);
            this.ErrLabel4.TabIndex = 28;
            this.ErrLabel4.Text = "Buffer 1 Warning";
            // 
            // ErrLabel3
            // 
            this.ErrLabel3.AutoSize = true;
            this.ErrLabel3.BackColor = System.Drawing.Color.Black;
            this.ErrLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrLabel3.ForeColor = System.Drawing.Color.DimGray;
            this.ErrLabel3.Location = new System.Drawing.Point(411, 50);
            this.ErrLabel3.Name = "ErrLabel3";
            this.ErrLabel3.Size = new System.Drawing.Size(129, 20);
            this.ErrLabel3.TabIndex = 27;
            this.ErrLabel3.Text = "Buffer 0 Warning";
            // 
            // ErrLabel2
            // 
            this.ErrLabel2.AutoSize = true;
            this.ErrLabel2.BackColor = System.Drawing.Color.Black;
            this.ErrLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrLabel2.ForeColor = System.Drawing.Color.DimGray;
            this.ErrLabel2.Location = new System.Drawing.Point(319, 50);
            this.ErrLabel2.Name = "ErrLabel2";
            this.ErrLabel2.Size = new System.Drawing.Size(88, 20);
            this.ErrLabel2.TabIndex = 26;
            this.ErrLabel2.Text = "Tx Warning";
            // 
            // ErrLabel1
            // 
            this.ErrLabel1.AutoSize = true;
            this.ErrLabel1.BackColor = System.Drawing.Color.Black;
            this.ErrLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrLabel1.ForeColor = System.Drawing.Color.DimGray;
            this.ErrLabel1.Location = new System.Drawing.Point(226, 50);
            this.ErrLabel1.Name = "ErrLabel1";
            this.ErrLabel1.Size = new System.Drawing.Size(91, 20);
            this.ErrLabel1.TabIndex = 25;
            this.ErrLabel1.Text = "Rx Warning";
            // 
            // ErrLabel0
            // 
            this.ErrLabel0.BackColor = System.Drawing.Color.Black;
            this.ErrLabel0.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrLabel0.ForeColor = System.Drawing.Color.DimGray;
            this.ErrLabel0.Location = new System.Drawing.Point(185, 50);
            this.ErrLabel0.Name = "ErrLabel0";
            this.ErrLabel0.Size = new System.Drawing.Size(35, 16);
            this.ErrLabel0.TabIndex = 24;
            this.ErrLabel0.Text = "OK";
            this.ErrLabel0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InterfaceErrlabel3
            // 
            this.InterfaceErrlabel3.AutoSize = true;
            this.InterfaceErrlabel3.BackColor = System.Drawing.Color.Black;
            this.InterfaceErrlabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterfaceErrlabel3.ForeColor = System.Drawing.Color.DimGray;
            this.InterfaceErrlabel3.Location = new System.Drawing.Point(519, 25);
            this.InterfaceErrlabel3.Name = "InterfaceErrlabel3";
            this.InterfaceErrlabel3.Size = new System.Drawing.Size(146, 20);
            this.InterfaceErrlabel3.TabIndex = 23;
            this.InterfaceErrlabel3.Text = "Error Sending Data";
            // 
            // InterfaceErrlabel2
            // 
            this.InterfaceErrlabel2.AutoSize = true;
            this.InterfaceErrlabel2.BackColor = System.Drawing.Color.Black;
            this.InterfaceErrlabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterfaceErrlabel2.ForeColor = System.Drawing.Color.DimGray;
            this.InterfaceErrlabel2.Location = new System.Drawing.Point(369, 25);
            this.InterfaceErrlabel2.Name = "InterfaceErrlabel2";
            this.InterfaceErrlabel2.Size = new System.Drawing.Size(151, 20);
            this.InterfaceErrlabel2.TabIndex = 22;
            this.InterfaceErrlabel2.Text = "No CAN Connection";
            // 
            // InterfaceErrlabel1
            // 
            this.InterfaceErrlabel1.BackColor = System.Drawing.Color.Black;
            this.InterfaceErrlabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InterfaceErrlabel1.ForeColor = System.Drawing.Color.DimGray;
            this.InterfaceErrlabel1.Location = new System.Drawing.Point(226, 25);
            this.InterfaceErrlabel1.Name = "InterfaceErrlabel1";
            this.InterfaceErrlabel1.Size = new System.Drawing.Size(137, 16);
            this.InterfaceErrlabel1.TabIndex = 21;
            this.InterfaceErrlabel1.Text = "Interface Missing";
            this.InterfaceErrlabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(13, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Messages in Buffer:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "Interface Status:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CANErrorTimer
            // 
            this.CANErrorTimer.Interval = 500;
            this.CANErrorTimer.Tick += new System.EventHandler(this.CANErrorTimer_Tick);
            // 
            // CANControls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(736, 316);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "CANControls";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CANControls";
            this.Load += new System.EventHandler(this.CANControls_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CANDataGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox MIBText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ErrLabel8;
        private System.Windows.Forms.Label ErrLabel7;
        private System.Windows.Forms.Label ErrLabel6;
        private System.Windows.Forms.Label ErrLabel5;
        private System.Windows.Forms.Label ErrLabel4;
        private System.Windows.Forms.Label ErrLabel3;
        private System.Windows.Forms.Label ErrLabel2;
        private System.Windows.Forms.Label ErrLabel1;
        private System.Windows.Forms.Label ErrLabel0;
        private System.Windows.Forms.Label InterfaceErrlabel3;
        private System.Windows.Forms.Label InterfaceErrlabel2;
        private System.Windows.Forms.Label InterfaceErrlabel1;
        public System.Windows.Forms.Label InterfaceErrlabel0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView CANDataGrid;
        private System.Windows.Forms.Timer CANErrorTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DLC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANData;
    }
}