using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Session;

namespace LanMIS
{
    public partial class MIS : Form
    {
        Broker b;
        Person p;

        public MIS()
        {
            InitializeComponent();
        }

        private void MIS_Load(object sender, EventArgs e)
        {

        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            p = new Person();
            p.FirstName = TxtFirstname.Text;
            p.LastName = TxtLastname.Text;
            b = new Broker();
            b.Insert(p);
        }

        private void MIS_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


    }
}
