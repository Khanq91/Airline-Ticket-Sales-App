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
            this.pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.White;
            this.pnl.Controls.Add(this.flowLayoutPanelTT);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(1092, 775);
            this.pnl.TabIndex = 0;
            // 
            // flowLayoutPanelTT
            // 
            this.flowLayoutPanelTT.AutoScroll = true;
            this.flowLayoutPanelTT.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelTT.Location = new System.Drawing.Point(37, 37);
            this.flowLayoutPanelTT.Name = "flowLayoutPanelTT";
            this.flowLayoutPanelTT.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanelTT.Size = new System.Drawing.Size(1000, 701);
            this.flowLayoutPanelTT.TabIndex = 0;
            // 
            // frmNhapTT_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1092, 775);
            this.Controls.Add(this.pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNhapTT_Main";
            this.Text = "frmNhapTT_Main";
            this.Load += new System.EventHandler(this.frmNhapTT_Main_Load);
            this.pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTT;
    }
}