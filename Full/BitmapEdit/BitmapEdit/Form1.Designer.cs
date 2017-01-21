namespace BitmapEdit
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
            this.PbxMain = new System.Windows.Forms.PictureBox();
            this.BtnOutput = new System.Windows.Forms.Button();
            this.Xaxis = new System.Windows.Forms.Label();
            this.Yaxis = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PbxMain)).BeginInit();
            this.SuspendLayout();
            // 
            // PbxMain
            // 
            this.PbxMain.InitialImage = null;
            this.PbxMain.Location = new System.Drawing.Point(13, 13);
            this.PbxMain.Name = "PbxMain";
            this.PbxMain.Size = new System.Drawing.Size(800, 600);
            this.PbxMain.TabIndex = 0;
            this.PbxMain.TabStop = false;
            this.PbxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.PbxMain_Paint);
            this.PbxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_Click);
            this.PbxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            // 
            // BtnOutput
            // 
            this.BtnOutput.Location = new System.Drawing.Point(13, 626);
            this.BtnOutput.Name = "BtnOutput";
            this.BtnOutput.Size = new System.Drawing.Size(75, 23);
            this.BtnOutput.TabIndex = 1;
            this.BtnOutput.Text = "Output";
            this.BtnOutput.UseVisualStyleBackColor = true;
            this.BtnOutput.Click += new System.EventHandler(this.BtnOutput_Click);
            // 
            // Xaxis
            // 
            this.Xaxis.Location = new System.Drawing.Point(0, 0);
            this.Xaxis.Name = "Xaxis";
            this.Xaxis.Size = new System.Drawing.Size(100, 23);
            this.Xaxis.TabIndex = 0;
            // 
            // Yaxis
            // 
            this.Yaxis.Location = new System.Drawing.Point(0, 0);
            this.Yaxis.Name = "Yaxis";
            this.Yaxis.Size = new System.Drawing.Size(100, 23);
            this.Yaxis.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.BtnOutput);
            this.Controls.Add(this.PbxMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PbxMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PbxMain;
        private System.Windows.Forms.Button BtnOutput;
        private System.Windows.Forms.Label Xaxis;
        private System.Windows.Forms.Label Yaxis;
    }
}

