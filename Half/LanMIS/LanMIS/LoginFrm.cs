using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace LanMIS
{
    public partial class LoginFrm : Form
    {
        SqlConnection conn;
        SqlConnectionStringBuilder connStringBuilder;
        //string connString = "Data Source=DESKTOP-6SAR9JF;Initial Catalog=MIS;Persist Security Info=True;";
        //User ID=sa;Password=s9951111

        public LoginFrm()
        {
            InitializeComponent();

            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "DESKTOP-6SAR9JF";
            connStringBuilder.InitialCatalog = "MIS";
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (TxtAccount.Text != "" && TxtPassword.Text != "")
            {

                try
                {
                    string cmdText = "insert into dbo.LogLogin(DateTime, Account, Info) VALUES(@DateTime, @Account, @Info)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    cmd.Parameters.AddWithValue("@Account", TxtAccount.Text);
                    cmd.Parameters.AddWithValue("@Info", "Login success from 192.168.1.1");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    
                    throw;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    this.Hide();
                    Form misFrm = new MIS();
                    misFrm.Show();
                }
                
                
            }
        }
    }
}
