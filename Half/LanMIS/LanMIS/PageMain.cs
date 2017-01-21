using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace LanMIS
{
    class PageMain : Page
    {
        public PageMain(string name, Panel panelParent)
            : base(name, panelParent) { }

        public override void initialize()
        {
            if (name == "General")
            {
                TextBox txtGeneral = new TextBox();
                txtGeneral.Multiline = true;
                txtGeneral.Name = "txtGeneral";
                txtGeneral.Dock = DockStyle.Fill;
                txtGeneral.Enabled = false;
                txtGeneral.Text = "20161228 Liao";
                txtGeneral.TabIndex = 0;
                panelThis.Controls.Add(txtGeneral);
            }
            if (name == "Board")
            {
                //
                //Gui
                //
                ListBox listBoard = new ListBox();
                listBoard.Name = "ListBoard";
                listBoard.Dock = DockStyle.Left;
                listBoard.Size = new System.Drawing.Size(200, 600);
                //listBoard.SelectedIndexChanged += new System.EventHandler(this.ListFunction_SelectedIndexChanged());
                panelThis.Controls.Add(listBoard);

                TextBox txtBoard = new TextBox();
                txtBoard.Multiline = true;
                txtBoard.Name = "txtBoard";
                txtBoard.Dock = DockStyle.Right;
                txtBoard.Size = new System.Drawing.Size(770, 600);
                txtBoard.Enabled = false;
                txtBoard.TabIndex = 0;
                panelThis.Controls.Add(txtBoard);

                //
                //Sql
                //
                query = "SELECT * FROM dbo.MessageBoard";
                using (SqlConnection connection = new SqlConnection(MainFrm.connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable accountTable = new DataTable();
                    adapter.Fill(accountTable);

                    listBoard.DisplayMember = "Account";
                    listBoard.ValueMember = "Description";
                    listBoard.DataSource = accountTable;
                }

                //
                //Events
                //
                listBoard.SelectedIndexChanged += new System.EventHandler((sender, e) => ListFunction_SelectedIndexChanged(sender, e, listBoard, txtBoard));
                listBoard.Select();
            }
            //Button b = new Button();
            //panelThis.Controls.Add(b);
            //controlList.Add(b);
        }


        private void ListFunction_SelectedIndexChanged(object sender, EventArgs e, ListBox listBoard, TextBox txtBoard)
        {
            txtBoard.Text = listBoard.SelectedValue.ToString();
        }

        private void SqlQuery(string query)
        {
            
        }
    }
}
