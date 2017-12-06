namespace LightingSystemUI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.IconToolbox = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BTNLoadBitmap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnOpenLayoutEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadLayoutFromFile = new System.Windows.Forms.ToolStripMenuItem();
            this.bitmappanel = new System.Windows.Forms.Panel();
            this.statusLbl = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // IconToolbox
            // 
            this.IconToolbox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.IconToolbox.BackColor = System.Drawing.Color.Transparent;
            this.IconToolbox.Location = new System.Drawing.Point(12, 383);
            this.IconToolbox.Name = "IconToolbox";
            this.IconToolbox.Size = new System.Drawing.Size(797, 56);
            this.IconToolbox.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton2,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(821, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.BTNLoadBitmap});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(38, 22);
            this.toolStripDropDownButton2.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // BTNLoadBitmap
            // 
            this.BTNLoadBitmap.Name = "BTNLoadBitmap";
            this.BTNLoadBitmap.Size = new System.Drawing.Size(175, 22);
            this.BTNLoadBitmap.Text = "Load Layout Image";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenLayoutEditor,
            this.btnLoadLayoutFromFile});
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(135, 22);
            this.toolStripDropDownButton1.Text = "Layout Editor Options";
            // 
            // btnOpenLayoutEditor
            // 
            this.btnOpenLayoutEditor.Name = "btnOpenLayoutEditor";
            this.btnOpenLayoutEditor.Size = new System.Drawing.Size(183, 22);
            this.btnOpenLayoutEditor.Text = "Create new layout";
            this.btnOpenLayoutEditor.Click += new System.EventHandler(this.btnOpenLayoutEditor_Click);
            // 
            // btnLoadLayoutFromFile
            // 
            this.btnLoadLayoutFromFile.Name = "btnLoadLayoutFromFile";
            this.btnLoadLayoutFromFile.Size = new System.Drawing.Size(183, 22);
            this.btnLoadLayoutFromFile.Text = "Load layout in editor";
            // 
            // bitmappanel
            // 
            this.bitmappanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bitmappanel.BackColor = System.Drawing.Color.Transparent;
            this.bitmappanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bitmappanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.bitmappanel.Location = new System.Drawing.Point(12, 28);
            this.bitmappanel.Name = "bitmappanel";
            this.bitmappanel.Size = new System.Drawing.Size(797, 349);
            this.bitmappanel.TabIndex = 3;
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(534, 9);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(35, 13);
            this.statusLbl.TabIndex = 4;
            this.statusLbl.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(821, 451);
            this.Controls.Add(this.statusLbl);
            this.Controls.Add(this.bitmappanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.IconToolbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel IconToolbox;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnOpenLayoutEditor;
        private System.Windows.Forms.ToolStripMenuItem btnLoadLayoutFromFile;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BTNLoadBitmap;
        public System.Windows.Forms.Panel bitmappanel;
        private System.Windows.Forms.Label statusLbl;
    }
}

