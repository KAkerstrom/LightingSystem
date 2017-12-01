namespace LightTest.Kyle
{
    partial class KyleTestForm
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
            this.testLbl = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.newPollBtn = new System.Windows.Forms.Button();
            this.lightButtonsFlp = new System.Windows.Forms.FlowLayoutPanel();
            this.saveBtn = new System.Windows.Forms.Button();
            this.loadBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testLbl
            // 
            this.testLbl.AutoSize = true;
            this.testLbl.Location = new System.Drawing.Point(229, 61);
            this.testLbl.Name = "testLbl";
            this.testLbl.Size = new System.Drawing.Size(22, 13);
            this.testLbl.TabIndex = 2;
            this.testLbl.Text = "     ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(232, 80);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(371, 540);
            this.textBox1.TabIndex = 3;
            // 
            // newPollBtn
            // 
            this.newPollBtn.Location = new System.Drawing.Point(12, 12);
            this.newPollBtn.Name = "newPollBtn";
            this.newPollBtn.Size = new System.Drawing.Size(122, 62);
            this.newPollBtn.TabIndex = 6;
            this.newPollBtn.Text = "new polling btn";
            this.newPollBtn.UseVisualStyleBackColor = true;
            this.newPollBtn.Click += new System.EventHandler(this.newPollBtn_Click);
            // 
            // lightButtonsFlp
            // 
            this.lightButtonsFlp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lightButtonsFlp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.lightButtonsFlp.Location = new System.Drawing.Point(12, 80);
            this.lightButtonsFlp.Name = "lightButtonsFlp";
            this.lightButtonsFlp.Size = new System.Drawing.Size(200, 540);
            this.lightButtonsFlp.TabIndex = 7;
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(481, 12);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(122, 26);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(481, 44);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(122, 26);
            this.loadBtn.TabIndex = 9;
            this.loadBtn.Text = "load";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // KyleTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 632);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.lightButtonsFlp);
            this.Controls.Add(this.newPollBtn);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.testLbl);
            this.Name = "KyleTestForm";
            this.Text = "KyleTestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label testLbl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button newPollBtn;
        private System.Windows.Forms.FlowLayoutPanel lightButtonsFlp;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button loadBtn;
    }
}