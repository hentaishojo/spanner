namespace LiaoMIS
{
    partial class FormMain
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
            this.database1DataSet = new LiaoMIS.Database1DataSet();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblDescription = new System.Windows.Forms.Label();
            this.ListDescription = new System.Windows.Forms.ListBox();
            this.ListAccount = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TbxAdd = new System.Windows.Forms.TextBox();
            this.TbxUpdate = new System.Windows.Forms.TextBox();
            this.BtnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // database1DataSet
            // 
            this.database1DataSet.DataSetName = "Database1DataSet";
            this.database1DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Description";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.Location = new System.Drawing.Point(170, 96);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(58, 12);
            this.LblDescription.TabIndex = 0;
            this.LblDescription.Text = "Description";
            // 
            // ListDescription
            // 
            this.ListDescription.FormattingEnabled = true;
            this.ListDescription.ItemHeight = 12;
            this.ListDescription.Location = new System.Drawing.Point(171, 112);
            this.ListDescription.Name = "ListDescription";
            this.ListDescription.Size = new System.Drawing.Size(128, 244);
            this.ListDescription.TabIndex = 1;
            // 
            // ListAccount
            // 
            this.ListAccount.FormattingEnabled = true;
            this.ListAccount.ItemHeight = 12;
            this.ListAccount.Location = new System.Drawing.Point(21, 112);
            this.ListAccount.Name = "ListAccount";
            this.ListAccount.Size = new System.Drawing.Size(128, 244);
            this.ListAccount.TabIndex = 3;
            this.ListAccount.SelectedIndexChanged += new System.EventHandler(this.ListAccount_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Account";
            // 
            // BtnAdd
            // 
            this.BtnAdd.Location = new System.Drawing.Point(153, 13);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(100, 22);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "Add Description";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TbxAdd
            // 
            this.TbxAdd.Location = new System.Drawing.Point(22, 13);
            this.TbxAdd.Name = "TbxAdd";
            this.TbxAdd.Size = new System.Drawing.Size(100, 22);
            this.TbxAdd.TabIndex = 5;
            // 
            // TbxUpdate
            // 
            this.TbxUpdate.Location = new System.Drawing.Point(22, 54);
            this.TbxUpdate.Name = "TbxUpdate";
            this.TbxUpdate.Size = new System.Drawing.Size(100, 22);
            this.TbxUpdate.TabIndex = 7;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.Location = new System.Drawing.Point(153, 54);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(100, 22);
            this.BtnUpdate.TabIndex = 6;
            this.BtnUpdate.Text = "Update";
            this.BtnUpdate.UseVisualStyleBackColor = true;
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 434);
            this.Controls.Add(this.TbxUpdate);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.TbxAdd);
            this.Controls.Add(this.BtnAdd);
            this.Controls.Add(this.ListAccount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListDescription);
            this.Controls.Add(this.LblDescription);
            this.Name = "FormMain";
            this.Text = "LiaoMIS-v0.0.0";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.database1DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Database1DataSet database1DataSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.ListBox ListDescription;
        private System.Windows.Forms.ListBox ListAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox TbxAdd;
        private System.Windows.Forms.TextBox TbxUpdate;
        private System.Windows.Forms.Button BtnUpdate;

    }
}

