using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace LanMIS
{
    public partial class MainFrm : Form
    {
        string account;
        string password;

        public static string connectionString;
        List<Page> pages = new List<Page>();

        public MainFrm(string account, string password)
        {
            InitializeComponent();
            this.account = account;
            this.password = password;

        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder connStringBuilder;
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "DESKTOP-6SAR9JF";
            connStringBuilder.InitialCatalog = "MIS";
            connStringBuilder.IntegratedSecurity = true;
            connectionString = connStringBuilder.ToString();
        }

        private void ListFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isExist = false;

            pages.ForEach(delegate(Page p)
            {
                if (p.name == ListFunction.SelectedItem.ToString())
                {
                    isExist = true;
                    p.Show();
                }
            });

            if (isExist == false)
            {
                Page page = new PageMain(ListFunction.SelectedItem.ToString(), PanelMain);
                page.Show();
                pages.Add(page);
            }
        }

        
    }
}
