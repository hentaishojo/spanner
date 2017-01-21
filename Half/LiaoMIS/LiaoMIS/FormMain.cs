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

namespace LiaoMIS
{
    public partial class FormMain : Form
    {
        SqlConnection connection;
        string connectionString;

        public FormMain()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["LiaoMIS.Properties.Settings.Database1ConnectionString"].ConnectionString;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            PopulateAccount();
        }

        

        private void PopulateAccount()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Account", connection))
            {
                DataTable accountTable = new DataTable();
                adapter.Fill(accountTable);

                ListAccount.DisplayMember = "Account";
                ListAccount.ValueMember = "Account";
                ListAccount.DataSource = accountTable;
            }

        }

        private void PopulateDescription()
        {
            string query = "select a.Description from Board a " +
                            "inner join Account c on a.Name = c.Account " +
                            "where c.Account = @account";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@account", ListAccount.SelectedValue);

                DataTable DescriptionTable = new DataTable();
                adapter.Fill(DescriptionTable);

                ListDescription.DisplayMember = "Description";
                ListDescription.ValueMember = "Name";
                ListDescription.DataSource = DescriptionTable;
            }

        }

        private void ListAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDescription();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string query = "insert into Board values (@Account, @Description)";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@Account", ListAccount.SelectedValue);
                command.Parameters.AddWithValue("@Description", TbxAdd.Text);

                command.ExecuteNonQuery();
            }

            PopulateDescription();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

    }
}
