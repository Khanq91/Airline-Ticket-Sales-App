namespace BanVeMayBay
{
    partial class frmNhapTT_Main
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
            this.pnl = new System.Windows.Forms.Panel();
            this.flowLayoutPanelTT = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.pnl.SuspendLayout();
            this.flowLayoutPanelTT.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.White;
            this.pnl.Controls.Add(this.flowLayoutPanelTT);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Margin = new System.Windows.Forms.Padding(2);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(1102, 502);
            this.pnl.TabIndex = 0;
            // 
            // flowLayoutPanelTT
            // 
            this.flowLayoutPanelTT.AutoScroll = true;
            this.flowLayoutPanelTT.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelTT.Controls.Add(this.button1);
            this.flowLayoutPanelTT.Controls.Add(this.button2);
            this.flowLayoutPanelTT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTT.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelTT.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanelTT.Name = "flowLayoutPanelTT";
            this.flowLayoutPanelTT.Padding = new System.Windows.Forms.Padding(8);
            this.flowLayoutPanelTT.Size = new System.Drawing.Size(1102, 502);
            this.flowLayoutPanelTT.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(92, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmNhapTT_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1102, 502);
            this.Controls.Add(this.pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmNhapTT_Main";
            this.Text = "frmNhapTT_Main";
            this.Load += new System.EventHandler(this.frmNhapTT_Main_Load);
            this.pnl.ResumeLayout(false);
            this.flowLayoutPanelTT.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}