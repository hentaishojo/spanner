namespace SpeechTest
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
            this.TextBox = new System.Windows.Forms.RichTextBox();
            this.Btn_En = new System.Windows.Forms.Button();
            this.Btn_Dis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(12, 12);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(541, 433);
            this.TextBox.TabIndex = 0;
            this.TextBox.Text = "-Log-";
            // 
            // Btn_En
            // 
            this.Btn_En.Location = new System.Drawing.Point(12, 451);
            this.Btn_En.Name = "Btn_En";
            this.Btn_En.Size = new System.Drawing.Size(75, 23);
            this.Btn_En.TabIndex = 1;
            this.Btn_En.Text = "Enable";
            this.Btn_En.UseVisualStyleBackColor = true;
            this.Btn_En.Click += new System.EventHandler(this.Btn_En_Click);
            // 
            // Btn_Dis
            // 
            this.Btn_Dis.Location = new System.Drawing.Point(478, 451);
            this.Btn_Dis.Name = "Btn_Dis";
            this.Btn_Dis.Size = new System.Drawing.Size(75, 23);
            this.Btn_Dis.TabIndex = 2;
            this.Btn_Dis.Text = "Disable";
            this.Btn_Dis.UseVisualStyleBackColor = true;
            this.Btn_Dis.Click += new System.EventHandler(this.Btn_Dis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 486);
            this.Controls.Add(this.Btn_Dis);
            this.Controls.Add(this.Btn_En);
            this.Controls.Add(this.TextBox);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TextBox;
        private System.Windows.Forms.Button Btn_En;
        private System.Windows.Forms.Button Btn_Dis;
    }
}

