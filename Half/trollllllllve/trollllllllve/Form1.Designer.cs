namespace trollllllllve
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
            this.state = new System.Windows.Forms.Label();
            this.btn_act = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // state
            // 
            this.state.AutoSize = true;
            this.state.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.state.Location = new System.Drawing.Point(13, 13);
            this.state.Name = "state";
            this.state.Size = new System.Drawing.Size(73, 27);
            this.state.TabIndex = 0;
            this.state.Text = "Ready";
            // 
            // btn_act
            // 
            this.btn_act.Location = new System.Drawing.Point(197, 17);
            this.btn_act.Name = "btn_act";
            this.btn_act.Size = new System.Drawing.Size(75, 23);
            this.btn_act.TabIndex = 1;
            this.btn_act.Text = "Active";
            this.btn_act.UseVisualStyleBackColor = true;
            this.btn_act.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 56);
            this.Controls.Add(this.btn_act);
            this.Controls.Add(this.state);
            this.Name = "Form1";
            this.Text = "Trollllllllve";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label state;
        private System.Windows.Forms.Button btn_act;
    }
}

