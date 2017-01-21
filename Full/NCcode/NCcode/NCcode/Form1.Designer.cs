namespace NCcode
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
            this.MainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.OpListBox = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_down = new System.Windows.Forms.Button();
            this.btn_del = new System.Windows.Forms.Button();
            this.btn_up = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.detailZone = new System.Windows.Forms.Panel();
            this.panel_addOp = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_pocket = new System.Windows.Forms.Button();
            this.btn_hole = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.btn_out = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.detailZone.SuspendLayout();
            this.panel_addOp.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.ColumnCount = 2;
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.MainPanel.Controls.Add(this.OpListBox, 0, 0);
            this.MainPanel.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.MainPanel.Controls.Add(this.detailZone, 1, 0);
            this.MainPanel.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.RowCount = 2;
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.MainPanel.Size = new System.Drawing.Size(884, 561);
            this.MainPanel.TabIndex = 0;
            // 
            // OpListBox
            // 
            this.OpListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpListBox.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.OpListBox.FormattingEnabled = true;
            this.OpListBox.ItemHeight = 20;
            this.OpListBox.Location = new System.Drawing.Point(3, 3);
            this.OpListBox.Name = "OpListBox";
            this.OpListBox.Size = new System.Drawing.Size(259, 470);
            this.OpListBox.TabIndex = 0;
            this.OpListBox.SelectedIndexChanged += new System.EventHandler(this.OpListBox_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btn_down, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_del, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_up, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_add, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 479);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(259, 79);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_down
            // 
            this.btn_down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_down.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_down.Location = new System.Drawing.Point(132, 42);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(124, 34);
            this.btn_down.TabIndex = 3;
            this.btn_down.Text = "Move down";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // btn_del
            // 
            this.btn_del.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_del.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_del.Location = new System.Drawing.Point(3, 42);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(123, 34);
            this.btn_del.TabIndex = 2;
            this.btn_del.Text = "Delete OP";
            this.btn_del.UseVisualStyleBackColor = true;
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_up
            // 
            this.btn_up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_up.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_up.Location = new System.Drawing.Point(132, 3);
            this.btn_up.Name = "btn_up";
            this.btn_up.Size = new System.Drawing.Size(124, 33);
            this.btn_up.TabIndex = 1;
            this.btn_up.Text = "Move up";
            this.btn_up.UseVisualStyleBackColor = true;
            this.btn_up.Click += new System.EventHandler(this.btn_up_Click);
            // 
            // btn_add
            // 
            this.btn_add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_add.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_add.Location = new System.Drawing.Point(3, 3);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(123, 33);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "Add new OP";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // detailZone
            // 
            this.detailZone.Controls.Add(this.panel_addOp);
            this.detailZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailZone.Location = new System.Drawing.Point(268, 3);
            this.detailZone.Name = "detailZone";
            this.detailZone.Size = new System.Drawing.Size(613, 470);
            this.detailZone.TabIndex = 2;
            // 
            // panel_addOp
            // 
            this.panel_addOp.Controls.Add(this.tableLayoutPanel1);
            this.panel_addOp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_addOp.Location = new System.Drawing.Point(0, 0);
            this.panel_addOp.Name = "panel_addOp";
            this.panel_addOp.Size = new System.Drawing.Size(613, 470);
            this.panel_addOp.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btn_pocket, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btn_hole, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(613, 470);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btn_pocket
            // 
            this.btn_pocket.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_pocket.Location = new System.Drawing.Point(268, 66);
            this.btn_pocket.Name = "btn_pocket";
            this.btn_pocket.Size = new System.Drawing.Size(75, 23);
            this.btn_pocket.TabIndex = 1;
            this.btn_pocket.Text = "Pocket";
            this.btn_pocket.UseVisualStyleBackColor = true;
            this.btn_pocket.Click += new System.EventHandler(this.btn_pocket_Click);
            // 
            // btn_hole
            // 
            this.btn_hole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_hole.Location = new System.Drawing.Point(64, 66);
            this.btn_hole.Name = "btn_hole";
            this.btn_hole.Size = new System.Drawing.Size(75, 23);
            this.btn_hole.TabIndex = 0;
            this.btn_hole.Text = "Hole";
            this.btn_hole.UseVisualStyleBackColor = true;
            this.btn_hole.Click += new System.EventHandler(this.btn_hole_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3.Controls.Add(this.btn_save, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_load, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btn_out, 3, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(268, 479);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(613, 79);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // btn_save
            // 
            this.btn_save.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_save.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_save.Location = new System.Drawing.Point(156, 42);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(147, 34);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Save project";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_load
            // 
            this.btn_load.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_load.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_load.Location = new System.Drawing.Point(3, 42);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(147, 34);
            this.btn_load.TabIndex = 3;
            this.btn_load.Text = "Load project";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // btn_out
            // 
            this.btn_out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_out.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_out.Location = new System.Drawing.Point(462, 42);
            this.btn_out.Name = "btn_out";
            this.btn_out.Size = new System.Drawing.Size(148, 34);
            this.btn_out.TabIndex = 2;
            this.btn_out.Text = "Output NC code";
            this.btn_out.UseVisualStyleBackColor = true;
            this.btn_out.Click += new System.EventHandler(this.btn_out_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NCcode";
            this.MainPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.detailZone.ResumeLayout(false);
            this.panel_addOp.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainPanel;
        private System.Windows.Forms.ListBox OpListBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.Button btn_del;
        private System.Windows.Forms.Button btn_up;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Panel detailZone;
        private System.Windows.Forms.Panel panel_addOp;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_pocket;
        private System.Windows.Forms.Button btn_hole;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_out;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_load;
    }
}

