namespace LanMIS
{
    partial class MainFrm
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
            this.ListFunction = new System.Windows.Forms.ListBox();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // ListFunction
            // 
            this.ListFunction.FormattingEnabled = true;
            this.ListFunction.ItemHeight = 12;
            this.ListFunction.Items.AddRange(new object[] {
            "General",
            "Board",
            "Money"});
            this.ListFunction.Location = new System.Drawing.Point(12, 12);
            this.ListFunction.Name = "ListFunction";
            this.ListFunction.Size = new System.Drawing.Size(179, 604);
            this.ListFunction.TabIndex = 0;
            this.ListFunction.SelectedIndexChanged += new System.EventHandler(this.ListFunction_SelectedIndexChanged);
            // 
            // PanelMain
            // 
            this.PanelMain.Location = new System.Drawing.Point(197, 12);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(1000, 600);
            this.PanelMain.TabIndex = 1;
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 622);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.ListFunction);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFrm";
            this.Text = "MainFrm";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ListFunction;
        private System.Windows.Forms.Panel PanelMain;
    }
}