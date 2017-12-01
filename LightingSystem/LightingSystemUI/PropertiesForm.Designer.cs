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
            this.label1 = new System.Windows.Forms.Label();
            this.testGroup = new System.Windows.Forms.GroupBox();
            this.fullonbtn = new System.Windows.Forms.Button();
            this.onoffbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.testGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(142, 19);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 283);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // testGroup
            // 
            this.testGroup.Controls.Add(this.onoffbtn);
            this.testGroup.Controls.Add(this.fullonbtn);
            this.testGroup.Controls.Add(this.trackBar1);
            this.testGroup.Location = new System.Drawing.Point(698, 276);
            this.testGroup.Name = "testGroup";
            this.testGroup.Size = new System.Drawing.Size(193, 302);
            this.testGroup.TabIndex = 2;
            this.testGroup.TabStop = false;
            this.testGroup.Text = "Testing";
            // 
            // fullonbtn
            // 
            this.fullonbtn.Location = new System.Drawing.Point(6, 19);
            this.fullonbtn.Name = "fullonbtn";
            this.fullonbtn.Size = new System.Drawing.Size(75, 39);
            this.fullonbtn.TabIndex = 1;
            this.fullonbtn.Text = "Full On";
            this.fullonbtn.UseVisualStyleBackColor = true;
            // 
            // onoffbtn
            // 
            this.onoffbtn.Location = new System.Drawing.Point(6, 64);
            this.onoffbtn.Name = "onoffbtn";
            this.onoffbtn.Size = new System.Drawing.Size(75, 39);
            this.onoffbtn.TabIndex = 2;
            this.onoffbtn.Text = "Full On";
            this.onoffbtn.UseVisualStyleBackColor = true;
            // 
            // PropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 590);
            this.Controls.Add(this.testGroup);
            this.Controls.Add(this.label1);
            this.Name = "PropertiesForm";
            this.Text = "PropertiesForm";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.testGroup.ResumeLayout(false);
            this.testGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox testGroup;
        private System.Windows.Forms.Button onoffbtn;
        private System.Windows.Forms.Button fullonbtn;
    }
}