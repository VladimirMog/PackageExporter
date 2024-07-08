using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ReportExporter
{
    public partial class FormConnect : Form
    {
        string _connstr;
        public FormConnect()
        {
            InitializeComponent();
        }

        public string ConnectionString 
        { 
            get 
            { 
                 return _connstr;  
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            txbUser.Enabled = txbPass.Enabled = (cbxAuth.SelectedIndex == 0);
            if (txbUser.Enabled)
            {
                txbUser.Text = "";
            }
            else 
            {
                txbUser.Text = WindowsIdentity.GetCurrent().Name;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            StringBuilder sbConnStr = new StringBuilder("Data Source=");
            sbConnStr.Append(txbServer.Text);
            sbConnStr.Append(";Initial Catalog=ReportServer;");
            if (txbUser.Enabled)
            {
                sbConnStr.Append("User Id=");
                sbConnStr.Append(txbUser.Text);
                sbConnStr.Append(";Password=");
                sbConnStr.Append(txbPass.Text);
                sbConnStr.Append(";");
            }
            else
            {
                sbConnStr.Append("Integrated Security=True;");
            }
            //sbConnStr.Append(" providerName=\"System.Data.SqlClient\"");

            _connstr = sbConnStr.ToString();

            //string sqlQuery = "SELECT [ItemID],[Name],[ParentID] FROM [dbo].[Catalog] WHERE [Type] = 1 AND [PolicyRoot] = 1 ORDER BY [Path]";
            //try
            //{
            //   using (SqlConnection cnn = new SqlConnection())
            //    {
            //        cnn.ConnectionString = sbConnStr.ToString();
            //        cnn.Open();
            //        SqlCommand cmd = new SqlCommand(sqlQuery, cnn);
            //        SqlDataReader rdr = cmd.ExecuteReader();
            //        while (rdr.Read())
            //        {


            //        }
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Error connection!");
            //}


        }

        private void FormConnect_Load(object sender, EventArgs e)
        {
            cbxAuth.SelectedIndex = 1;
        }
    }
}
