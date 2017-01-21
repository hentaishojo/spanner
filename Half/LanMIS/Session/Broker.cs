using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Domain;

namespace Session
{
    public class Broker
    {
        SqlConnection conn;
        SqlConnectionStringBuilder connStringBuilder;

        void ConnectTo()
        {
            //Data Source=DESKTOP-6SAR9JF;Initial Catalog=MIS;Persist Security Info=True;User ID=sa;Password=s9951111
            connStringBuilder = new SqlConnectionStringBuilder();
            connStringBuilder.DataSource = "DESKTOP-6SAR9JF";
            connStringBuilder.InitialCatalog = "MIS";
            connStringBuilder.IntegratedSecurity = true;

            conn = new SqlConnection(connStringBuilder.ToString());
        }

        public Broker()
        {
            ConnectTo();
        }

        public void Insert(Person P)
        {
            try
            {
                string cmdText = "INSERT INTO dbo.Person(FirstName, LastName) VALUES(@FirstName, @LastName) ";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@FirstName", P.FirstName);
                cmd.Parameters.AddWithValue("@LastName", P.LastName);

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
            }
        }
    }
}
